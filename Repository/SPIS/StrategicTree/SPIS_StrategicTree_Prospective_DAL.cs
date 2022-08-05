using Business.Mapper.ISPIS.StrategicTree;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for SPIS_StrategicTree_Prospective_DAL
/// </summary>
public class SPIS_StrategicTree_Prospective_DAL : Common_DAL<SPIS_StrategicTree_Prospective_obj> , ISPIS_StrategicTree_Prospective_DAL
{
    #region Constructor

    public SPIS_StrategicTree_Prospective_DAL(IStrategicTree_Prospective_Mapper mapper):base(mapper)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion

    #region Public Methods

    public IList<SPIS_StrategicTree_Prospective_obj> Get_ItemList(Guid? StrategicTree_Id, Guid? Prospective_Id, decimal? WeightFactor, string Top)
    {
        var cmd = new SqlCommand();

        Top = (Top != "All" ? " TOP " + Top + " " : "All");
        cmd.CommandText = "SELECT  " + Top + " * FROM [dbo].[StrategicTree_Prospective] where " +
                                     (StrategicTree_Id != Guid.Empty && StrategicTree_Id != null ? " and (StrategicTree_Id = '" + StrategicTree_Id + "') " : string.Empty) +
                                     (Prospective_Id != Guid.Empty && Prospective_Id != null ? " and (Prospective_Id = '" + Prospective_Id + "') " : string.Empty) +
                                     (WeightFactor != null ? " and (WeightFactor = " + WeightFactor + ") " : string.Empty) +
                                     " order by UpdateDate ASC";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var list = new List<SPIS_StrategicTree_Prospective_obj>();
            while (SDR.Read())
            {
                var item = new SPIS_StrategicTree_Prospective_obj();
                _Mapper.SetDataToObject(item, SDR);
                list.Add(item);
            }
            return list;
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

    public SPIS_StrategicTree_Prospective_obj Get_Item(Guid? StrategicTree_Id, Guid? Prospective_Id)
    {
        var cmd = new SqlCommand();
        var item = new SPIS_StrategicTree_Prospective_obj();
        cmd.CommandText = " SELECT * FROM [dbo].[StrategicTree_Prospective] where " +
                                                     " and  " + (StrategicTree_Id != null ? "StrategicTree_Id ='" + StrategicTree_Id + "'" : "StrategicTree_Id IS NULL") +
                                                     " and  " + (Prospective_Id != null ? "Prospective_Id ='" + Prospective_Id + "'" : "Prospective_Id IS NULL") +
                                                     " order by UpdateDate ASC";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();

            if (SDR.Read())
            {
                _Mapper.SetDataToObject(item, SDR);
            }
            else
            {
                //fill for empty dropdown list
                item.StrategicTree_Id = Guid.NewGuid();
                item.Prospective_Id = Guid.NewGuid();
                item.WeightFactor = 0;
            }
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data Error: " + err.Message);
        }
        finally
        {
            SC.Close();
        }
        return item;
    }

    public bool UpdateItem(SPIS_StrategicTree_Prospective_obj inEditedItem, string StrategicTree_Id, string Prospective_Id)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = " UPDATE [dbo].[StrategicTree_Prospective] SET  [StrategicTree_Id] = '" + inEditedItem.StrategicTree_Id + "' " +
                                                                ",[Prospective_Id] = '" + inEditedItem.Prospective_Id + "' " +
                                                                ",[WeightFactor] =  " + inEditedItem.WeightFactor + "  " +
                                                                ",[UpdateId] = '" + inEditedItem.CreateId + "' " +
                                                                ",[UpdateDate] = GETDATE()" +
                                                          " where [StrategicTree_Id] = '" + StrategicTree_Id + "'" +
                                                            " and [Prospective_Id] = '" + Prospective_Id + "'";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                return true;
            else
                return false;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data Error In Updating 'StrategicTree_Prospective' : " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    public bool DeleteItem(string StrategicTree_Prospective, string Prospective_Id)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = "DELETE  FROM  [dbo].[StrategicTree_Prospective]  where [StrategicTree_Prospective] = '" + StrategicTree_Prospective + "'" +
                                             " " + (Prospective_Id != null ? "and [Prospective_Id] ='" + Prospective_Id + "'" : "");
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                return true;
            else
                return false;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data Error: " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    #endregion

    #region Override Members

    public override SPIS_StrategicTree_Prospective_obj CreatNewObject()
    {
        return new SPIS_StrategicTree_Prospective_obj();
    }

    public override string InsertCommand(SPIS_StrategicTree_Prospective_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTree_Prospective] ([StrategicTree_Id] ," +
                                                      "[Prospective_Id] ," +
                                                      "[WeightFactor] ," +
                                                      "[CreateId] ," +
                                                      "[CreateDate] ," +
                                                      "[UpdateId] ," +
                                                      "[UpdateDate] ) " +
                                          "VALUES ('" + inNewObject.StrategicTree_Id + "' , " +
                                                        inNewObject.Prospective_Id + "' , " +
                                                        inNewObject.WeightFactor + "  , '" +
                                                        inNewObject.CreateId + "' ,  " +
                                                        "GETDATE() ,'" +
                                                        inNewObject.UpdateId + "'," +
                                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTree_Prospective_obj inEditedObject, Guid inId)
    {
        throw new NotImplementedException();
    }

    public override string DeleteCommand(Guid inId)
    {
        throw new NotImplementedException();
    }

    public override string GetObjectCommand(Guid Id)
    {
        throw new NotImplementedException();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        throw new NotImplementedException();
    }

    #endregion
}