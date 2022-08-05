using Business;
using Business.Mapper.ISPIS.Base;
using Business.Repository.ISPIS;
using DAL.Common;
using Helper.Factory;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class SPIS_Owner_DAL : Common_DAL<SPIS_Owner_obj> , ISPIS_Owner_DAL
{
    #region Constructor

    public SPIS_Owner_DAL(IOwner_Mapper mapper): base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Override Members

    public override SPIS_Owner_obj CreatNewObject()
    {
        return new SPIS_Owner_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[Owner] "
            + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL"); ;
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[Owner] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[Owner] where Id ='" + inId + "'";
    }

    public override string InsertCommand(SPIS_Owner_obj inNewObject)
    {
        return "INSERT INTO [dbo].[Owner] ([Id] ," +
                                        "[History_Id] ," +
                                        "[Owner] ," +
                                        "[Description] ," +
                                        "[CreateId] ," +
                                        "[CreateDate] ," +
                                        "[UpdateId] ," +
                                        "[UpdateDate] ) " +
                            "VALUES ('" + Guid.NewGuid() + "' , '" +
                                        inNewObject.History_Id + "' , '" +
                                        inNewObject.Owner + "' , '" +
                                        inNewObject.Description + "' , '" +
                                        inNewObject.CreateId + "' , " +
                                        "GETDATE() ,'" +
                                        inNewObject.UpdateId + "'," +
                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_Owner_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[Owner] SET [Owner] = '" + inEditedObject.Owner + "' " +
                                        ",[Description] = '" + inEditedObject.Description + "' " +
                                        ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                        ",[UpdateDate] = GETDATE()" +
                                    " where [Id] = '" + inId + "'";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_Owner_obj> GetOwnerList(string inProject, string inTop, Guid PreHistoryId)
    {
        var ownerList = GetOwnerList(inProject, inTop);
        if (PreHistoryId != Guid.Empty)
            foreach (var item in ownerList)
            {
                item.Pre_Progress = factory.KPI_Service.RollUpByDepartmentId(item.Id, PreHistoryId);
            }

        return ownerList;
    }

    public IList<SPIS_Owner_obj> GetOwnerList(string inProject, string inTop)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT All * FROM [dbo].[Owner] " + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL"); ;
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var ownerList = new List<SPIS_Owner_obj>();
            while (SDR.Read())
            {
                var owner = new SPIS_Owner_obj();
                _Mapper.SetDataToObject(owner, SDR);
                ownerList.Add(owner);
            }

            foreach (var item in ownerList)
            {
                item.Progress = factory.KPI_Service.RollUpByDepartmentId(item.Id, (inProject != null ? new Guid(inProject) : Guid.Empty));
            }

            return ownerList;
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

    public IList<SPIS_Owner_obj> GetOwnerList(string inProject)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT All * FROM [dbo].[Owner] " + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL"); ;
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var ownerList = new List<SPIS_Owner_obj>();
            while (SDR.Read())
            {
                var owner = new SPIS_Owner_obj();
                _Mapper.SetDataToObject(owner, SDR);
                ownerList.Add(owner);
            }

            return ownerList;
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

