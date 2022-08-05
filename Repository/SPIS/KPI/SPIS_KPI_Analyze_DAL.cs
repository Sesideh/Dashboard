using Business.Mapper.ISPIS.KPI;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class SPIS_KPI_Analyze_DAL : Common_DAL<SPIS_KPI_Analyze_obj> , ISPIS_KPI_Analyze_DAL
{
    #region Constructor

    public SPIS_KPI_Analyze_DAL(IKPI_Analyze_Mapper mapper) : base(mapper)
    {

    }

    #endregion

    #region Override Members

    public override SPIS_KPI_Analyze_obj CreatNewObject()
    {
        return new SPIS_KPI_Analyze_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[KPI_Analyze] where Id ='" + Id + "'";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[KPI_Analyze] where ProjectId ='" + inProject + "'";
    }

    public override string InsertCommand(SPIS_KPI_Analyze_obj inNewObject)
    {
        return "INSERT INTO [dbo].[KPI_Analyze] ([Id] ," +
                                                "[KPI_Id] ," +
                                                "[History_Id] ," +
                                                "[Analyze] ," +
                                                "[Description] ," +
                                                "[CreateId] ," +
                                                "[CreateDate] ," +
                                                "[UpdateId] ," +
                                                "[UpdateDate] ) " +
                                    "VALUES ('" + Guid.NewGuid() + "' , '" +
                                                inNewObject.KPI_Id + "','" +
                                                inNewObject.History_Id + "','" +
                                                inNewObject.Analyze + "' , '" +
                                                inNewObject.Description + "' , '" +
                                                inNewObject.CreateId + "' , " +
                                                "GETDATE() ,'" +
                                                inNewObject.UpdateId + "'," +
                                                "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_KPI_Analyze_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[KPI_Analyze] SET  [KPI_Id] = '" + inEditedObject.KPI_Id + "'" +
                                                ",[Analyze] =  '" + inEditedObject.Analyze + "' " +
                                                ",[Description] = '" + inEditedObject.Description + "' " +
                                                ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                ",[UpdateDate] = GETDATE()" +
                                          " where [Id] = '" + inId + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[KPI_Analyze] where Id ='" + inId + "'";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_KPI_Analyze_obj> GetObjectList(string inProject, Guid inKPI_Id)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_KPI_Analyze_obj>();
        if (inKPI_Id != null && inKPI_Id != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[KPI_Analyze] where " +
                       (inKPI_Id != Guid.Empty && inKPI_Id != null ? " (KPI_Id = '" + inKPI_Id + "') " : string.Empty) +
                        " order by UpdateDate ASC";
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    var item = new SPIS_KPI_Analyze_obj();
                    _Mapper.SetDataToObject(item, SDR);
                    objectList.Add(item);
                }
                return objectList;
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Link Error: " + err.Message);
            }
            finally
            {
                SC.Close();
            }
        }
        else
            return objectList;
    }

    #endregion
}

