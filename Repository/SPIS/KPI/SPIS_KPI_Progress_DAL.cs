using Business.Mapper.ISPIS.KPI;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class SPIS_KPI_Progress_DAL : Common_DAL<SPIS_KPI_Progress_obj> , ISPIS_KPI_Progress_DAL
{
    #region Constructor

    public SPIS_KPI_Progress_DAL(IKPI_Progress_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override SPIS_KPI_Progress_obj CreatNewObject()
    {
        return new SPIS_KPI_Progress_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[KPI_Progress] where Id ='" + Id + "'";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[KPI_Progress] where ProjectId ='" + inProject + "'";
    }

    public override string InsertCommand(SPIS_KPI_Progress_obj inNewObject)
    {
        return "INSERT INTO [dbo].[KPI_Progress] ([Id] ," +
                                                "[KPI_Id] ," +
                                                "[TargetValue] ," +
                                                "[ActualValue] ," +
                                                "[TargetDate] ," +
                                                "[ActualDate] ," +
                                                "[Description] ," +
                                                "[CreateId] ," +
                                                "[CreateDate] ," +
                                                "[UpdateId] ," +
                                                "[UpdateDate] ) " +
                                    "VALUES ('" + Guid.NewGuid() + "' , '" +
                                                inNewObject.KPI_Id + "', " +
                                                inNewObject.TargetValue + " , " +
                                                inNewObject.ActualValue + " , " +
                                                (inNewObject.TargetDate != null ? " '" + inNewObject.TargetDate + "' " : "null") + " , " +
                                                (inNewObject.ActualDate != null ? " '" + inNewObject.ActualDate + "' " : "null") + " , '" +
                                                inNewObject.Description + "' , '" +
                                                inNewObject.CreateId + "' , " +
                                                "GETDATE() ,'" +
                                                inNewObject.UpdateId + "'," +
                                                "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_KPI_Progress_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[KPI_Progress] SET  [KPI_Id] = '" + inEditedObject.KPI_Id + "'" +
                                                    ",[TargetValue] =  " + inEditedObject.TargetValue + " " +
                                                    ",[ActualValue] =  " + inEditedObject.ActualValue + " " +
                                                    ",[TargetDate] = '" + inEditedObject.TargetDate + "' " +
                                                    ",[ActualDate] = '" + inEditedObject.ActualDate + "' " +
                                                    ",[Description] = '" + inEditedObject.Description + "' " +
                                                    ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                    ",[UpdateDate] = GETDATE()" +
                                              " where [Id] = '" + inId + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[KPI_Progress] where Id ='" + inId + "'";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_KPI_Progress_obj> GetObjectList(string inProject, Guid inKPI_Id)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_KPI_Progress_obj>();
        if (inKPI_Id != null && inKPI_Id != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[KPI_Progress] where " +
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
                    var item = new SPIS_KPI_Progress_obj();
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
