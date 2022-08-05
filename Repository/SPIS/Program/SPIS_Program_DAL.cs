using Business.Mapper.ISPIS.Program;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for SPIS_Program_DAL
/// </summary>
public class SPIS_Program_DAL : Common_DAL<SPIS_Program_obj>, ISPIS_Program_DAL
{
    #region Constructor

    public SPIS_Program_DAL(IProgram_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override IList<SPIS_Program_obj> GetObjectList(string inProject, string inTop)
    {
        var programList = base.GetObjectList(inProject, inTop);

        foreach (var item in programList)
        {
            if (item.ParentId == null)
                item.IsParent = true;
            else
                item.IsParent = false;
        }

        return programList;
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[Program] ";
    }

    public override SPIS_Program_obj CreatNewObject()
    {
        return new SPIS_Program_obj();
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[Program] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[Program] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_Program_obj inNewObject)
    {
        return "INSERT INTO [dbo].[Program] ([Id] ," +
                                            "[ParentId] ," +
                                            "[OwnerId] ," +
                                            "[Title] ," +
                                            "[Description] ," +
                                            "[CreateId] ," +
                                            "[CreateDate] ," +
                                            "[UpdateId] ," +
                                            "[UpdateDate] ) " +
                                "VALUES ('" + Guid.NewGuid() + "' , " +
                                           (inNewObject.ParentId != null ? "'" + inNewObject.ParentId.ToString() + "','" : "NULL" + ", '") +
                                           (inNewObject.OwnerId != null ? "'" + inNewObject.OwnerId.ToString() + "','" : "NULL" + ", '") +
                                            inNewObject.Title + "' , '" +
                                            inNewObject.Description + "' , '" +
                                            inNewObject.CreateId + "' , " +
                                            "GETDATE() ,'" +
                                            inNewObject.UpdateId + "'," +
                                            "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_Program_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[Program] SET [ParentId] = " + (inEditedObject.ParentId != null ? "'" + inEditedObject.ParentId.ToString() + "'" : " NULL" + "") +
                                            ",[OwnerId] = " + (inEditedObject.OwnerId != null ? "'" + inEditedObject.OwnerId.ToString() + "'" : " NULL" + "") +
                                            ",[Title] = '" + inEditedObject.Title + "' " +
                                            ",[Description] = '" + inEditedObject.Description + "' " +
                                            ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                            ",[UpdateDate] = GETDATE()" +
                                      " where [Id] = '" + inId + "'";
    }

    #endregion

    #region Public Methods

    public virtual IList<SPIS_Program_obj> GetChildList(string inProject, Guid inParentId)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_Program_obj>();
        cmd.CommandText = "SELECT * FROM [dbo].[Program] where " +
                          (inParentId != Guid.Empty && inParentId != null ? " (ParentId = '" + inParentId + "') " : string.Empty) +
                          " order by UpdateDate ASC";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            while (SDR.Read())
            {
                var item = CreatNewObject();
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

    #endregion
}