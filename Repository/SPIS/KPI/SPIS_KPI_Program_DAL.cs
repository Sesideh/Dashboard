using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Business.Mapper.ISPIS.KPI;
using Business.Repository.ISPIS;
using DAL.Common;
using SPIS;

public class SPIS_KPI_Program_DAL : Common_DAL<SPIS_KPI_Program_obj> , ISPIS_KPI_Program_DAL
{
    #region Constructor

    public SPIS_KPI_Program_DAL(IKPI_Program_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Override Members

    public override SPIS_KPI_Program_obj CreatNewObject()
    {
        return new SPIS_KPI_Program_obj();
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT " + inTop + " * FROM [dbo].[KPI_Program] " + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL"); ;
    }

    public override string InsertCommand(SPIS_KPI_Program_obj inNewObject)
    {
        return "INSERT INTO [dbo].[KPI_Program] ([KPI_Id] ," +
                                                "[Program_Id] ," +
                                                "[Description] ," +
                                                "[CreateId] ," +
                                                "[CreateDate] ," +
                                                "[UpdateId] ," +
                                                "[UpdateDate] ) " +
                                  "VALUES ('" + inNewObject.KPI_Id + "', '" +
                                                inNewObject.Program_Id + "' , '" +
                                                inNewObject.Description + "' , '" +
                                                inNewObject.CreateId + "' , " +
                                                "GETDATE() ,'" +
                                                inNewObject.UpdateId + "'," +
                                                "GETDATE() ) ";
    }

    #endregion

    #region Public Methods

    public IList<SPIS_KPI_Program_obj> GetObjectList(string inProject, Guid inKPI_Id)
    {
        var cmd = new SqlCommand();
        var objectList = new List<SPIS_KPI_Program_obj>();
        if (inKPI_Id != null && inKPI_Id != Guid.Empty)
        {
            cmd.CommandText = "SELECT * FROM [dbo].[KPI_Program] where " +
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
                    var item = new SPIS_KPI_Program_obj();
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

    public SPIS_KPI_Program_obj GetObject(Guid? Program_Id, Guid? KPI_Id)
    {
        var cmd = new SqlCommand();
        var item = new SPIS_KPI_Program_obj();
        cmd.CommandText = " SELECT * FROM [dbo].[KPI_Program] where " +
                                " " + (Program_Id != null ? "Program_Id ='" + Program_Id + "'" : "Program_Id IS NULL") +
                                " and  " + (KPI_Id != null ? "KPI_Id ='" + KPI_Id + "'" : "KPI_Id IS NULL") +
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
                item.Program_Id = Guid.NewGuid();
                item.KPI_Id = Guid.NewGuid();
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

    public bool UpdateObject(SPIS_KPI_Program_obj inEditedItem, string Program_Id, string KPI_Id)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = "UPDATE [dbo].[KPI_Program] SET [Program_Id] = '" + inEditedItem.Program_Id + "' " +
                                                        ",[KPI_Id] = '" + inEditedItem.KPI_Id + "' " +
                                                        ",[Description] = '" + inEditedItem.Description + "' " +
                                                        ",[UpdateId] = '" + inEditedItem.CreateId + "' " +
                                                        ",[UpdateDate] = GETDATE()" +
                                                    " where [Program_Id] = '" + Program_Id + "'" +
                                                    " and [KPI_Id] = '" + KPI_Id + "'";
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
            throw new ApplicationException("Data Error In Updating 'KPI_Program' : " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    public bool DeleteObject(string Program_Id, string KPI_Id)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = "DELETE  FROM  [dbo].[KPI_Program]  where [Program_Id] = '" + Program_Id + "'" +
                                                   (KPI_Id != null ? "and [KPI_Id] ='" + KPI_Id + "'" : "");
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

    public override string UpdateCommand(SPIS_KPI_Program_obj inEditedObject, Guid inId)
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

    #endregion
}

