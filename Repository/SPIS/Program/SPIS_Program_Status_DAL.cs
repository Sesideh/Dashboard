using Business.Mapper.ISPIS.Program;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class SPIS_Program_Status_DAL : Common_DAL<SPIS_Program_Status_obj>, ISPIS_Program_Status_DAL
{
    #region Constructor

    public SPIS_Program_Status_DAL(IProgram_Status_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override SPIS_Program_Status_obj CreatNewObject()
    {
        return new SPIS_Program_Status_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[Program_Status] where ProjectId ='" + inProject + "'";
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[Program_Status] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[Program_Status] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_Program_Status_obj inNewObject)
    {
        return "INSERT INTO [dbo].[Program_Status] ( [Id] ," +
                                                "[Program_Id] ," +
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
                                                inNewObject.Program_Id + "', " +
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

    public override string UpdateCommand(SPIS_Program_Status_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[Program_Status] SET [Program_Id] = '" + inEditedObject.Program_Id + "'" +
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

    public IList<SPIS_Program_Status_obj> GetObjectList(string inProject, Guid inProgram_Id)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_Program_Status_obj>();
        if (inProgram_Id != null && inProgram_Id != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[Program_Status] where " +
                       (inProgram_Id != Guid.Empty && inProgram_Id != null ? " (Program_Id = '" + inProgram_Id + "') " : string.Empty) +
                        " order by UpdateDate ASC";
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    var item = new SPIS_Program_Status_obj();
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
