using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Business.Mapper.ISPIS.StrategicTree;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;

/// <summary>
/// Summary description for SPIS_StrategicTree_Status_DAL
/// </summary>
public class SPIS_StrategicTree_Status_DAL : Common_DAL<SPIS_StrategicTree_Status_obj> , ISPIS_StrategicTree_Status_DAL
{
    #region Constructor

    public SPIS_StrategicTree_Status_DAL(IStrategicTree_Status_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override SPIS_StrategicTree_Status_obj CreatNewObject()
    {
        return new SPIS_StrategicTree_Status_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[StrategicTree_Status] ";
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[StrategicTree_Status] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[StrategicTree_Status] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_StrategicTree_Status_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTree_Status] ( [Id] ," +
                                                        "[StrategicTree_Id] ," +
                                                        "[StartRange] ," +
                                                        "[EndRange] ," +
                                                        "[DataTypeId] ," +
                                                        "[Color]  ," +
                                                        "[Description] ," +
                                                        "[CreateId] ," +
                                                        "[CreateDate] ," +
                                                        "[UpdateId] ," +
                                                        "[UpdateDate] ) " +
                                            "VALUES ('" + Guid.NewGuid() + "' , '" +
                                                        inNewObject.StrategicTree_Id + "', " +
                                                        inNewObject.StartRange + " , " +
                                                        inNewObject.EndRange + " , '" +
                                                       (inNewObject.DataTypeId != null ? "'" + inNewObject.DataTypeId.ToString() + "','" : "NULL" + ", '") +
                                                        inNewObject.Color + "' , '" +
                                                        inNewObject.Description + "' , '" +
                                                        inNewObject.CreateId + "' , " +
                                                        "GETDATE() ,'" +
                                                        inNewObject.UpdateId + "'," +
                                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTree_Status_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[StrategicTree_Status] SET [StrategicTree_Id] = '" + inEditedObject.StrategicTree_Id + "'" +
                                                        ",[StartRange] = " + inEditedObject.StartRange + " " +
                                                        ",[EndRange] = " + inEditedObject.EndRange + " " +
                                                        ",[DataTypeId] = " + (inEditedObject.DataTypeId != null ? "'" + inEditedObject.DataTypeId.ToString() + "'" : " NULL" + "") +
                                                        ",[Color] = " + inEditedObject.Color + " " +
                                                        ",[Description] = '" + inEditedObject.Description + "' " +
                                                        ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                        ",[UpdateDate] = GETDATE()" +
                                                  " where [Id] = '" + inId + "'";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_StrategicTree_Status_obj> GetObjectList(string inProject, Guid inStrategicId)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_StrategicTree_Status_obj>();
        if (inStrategicId != null && inStrategicId != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[StrategicTree_Status] where " +
                       (inStrategicId != Guid.Empty && inStrategicId != null ? " (StrategicTree_Id = '" + inStrategicId + "') " : string.Empty) +
                        " order by UpdateDate ASC";
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    var item = new SPIS_StrategicTree_Status_obj();
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