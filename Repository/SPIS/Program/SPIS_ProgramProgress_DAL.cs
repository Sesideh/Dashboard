using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Business.Mapper.ISPIS.Program;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;

/// <summary>
/// Summary description for SPIS_ProgramProgress_DAL
/// </summary>
public class SPIS_ProgramProgress_DAL : Common_DAL<SPIS_ProgramProgress_obj> , ISPIS_ProgramProgress_DAL
{
    #region Constructor

    public SPIS_ProgramProgress_DAL(IProgramProgress_Mapper mapper) :base(mapper)
    {
    }

    #endregion

    #region Public Methods

    public IList<SPIS_ProgramProgress_obj> GetObjectLists(string inProject, Guid inProgramId)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_ProgramProgress_obj>();
        if (inProgramId != null && inProgramId != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[ProgramProgress] where " +
                       (inProgramId != Guid.Empty && inProgramId != null ? " (Plan_Id = '" + inProgramId + "') " : string.Empty) +
                        " order by UpdateDate ASC";
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    var item = new SPIS_ProgramProgress_obj();
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

    #region Override Members

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[ProgramProgress] ";
    }

    public override SPIS_ProgramProgress_obj CreatNewObject()
    {
        return new SPIS_ProgramProgress_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[ProgramProgress] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[ProgramProgress] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_ProgramProgress_obj inNewObject)
    {
        return "INSERT INTO [dbo].[ProgramProgress] ([Id] ," +
                                                    "[Plan_Id] ," +
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
                                                    inNewObject.Plan_Id + "', " +
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

    public override string UpdateCommand(SPIS_ProgramProgress_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[ProgramProgress] SET  [Plan_Id] = '" + inEditedObject.Plan_Id + "'" +
                                                    ",[TargetValue] =  " + inEditedObject.TargetValue + " " +
                                                    ",[ActualValue] =  " + inEditedObject.ActualValue + " " +
                                                    ",[TargetDate] = '" + inEditedObject.TargetDate + "' " +
                                                    ",[ActualDate] = '" + inEditedObject.ActualDate + "' " +
                                                    ",[Description] = '" + inEditedObject.Description + "' " +
                                                    ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                                    ",[UpdateDate] = GETDATE()" +
                                              " where [Id] = '" + inId + "'";
    }

    #endregion
}