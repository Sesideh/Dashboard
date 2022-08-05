using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Business;
using Business.Mapper.ISPIS.StrategicTree;
using Business.Repository.ISPIS;
using DAL.Common;
using Helper.Factory;
using SPIS;

/// <summary>
/// Summary description for SPIS_StrategicTree_KPI_DAL
/// </summary>
public class SPIS_StrategicTree_KPI_DAL : Common_DAL<SPIS_StrategicTree_KPI_obj> , ISPIS_StrategicTree_KPI_DAL
{
    #region Private Properties

    private IFactory factory = new Factory();

    #endregion

    #region Constructor

    public SPIS_StrategicTree_KPI_DAL(IStrategicTree_KPI_Mapper mapper) : base(mapper)
    {
    }

    #endregion

    #region Public Methods

    public IList<SPIS_StrategicTree_KPI_obj> GetObjectList(Guid? StrategicTree_Id, Guid? KPI_Id, decimal? WeightFactor, string Top, Guid PreHistoryId)
    {
        var result = GetObjectList(StrategicTree_Id, KPI_Id, WeightFactor, Top);

        if (PreHistoryId != Guid.Empty)
            foreach (var item in result)
            {
                var preKPI = factory.KPI_DAL.GetObject(item.KPI_Name, PreHistoryId);
                item.Pre_KPI_Precentage = factory.KPI_Service.KpiCalculation(preKPI.Id, preKPI.KPIType);
            }

        return result;
    }

    public IList<SPIS_StrategicTree_KPI_obj> GetObjectList(Guid? StrategicTree_Id, Guid? KPI_Id, decimal? WeightFactor, string Top)
    {
        if (StrategicTree_Id != null)
        {
            var cmd = new SqlCommand();
            Top = (Top != "All" ? " TOP " + Top + " " : "All");
            cmd.CommandText = "SELECT * FROM [dbo].[StrategicTree_KPI] where " +
                                         (StrategicTree_Id != Guid.Empty && StrategicTree_Id != null ? " (StrategicTree_Id = '" + StrategicTree_Id + "') " : string.Empty) +
                                         (KPI_Id != Guid.Empty && KPI_Id != null ? " and (KPI_Id = '" + KPI_Id + "') " : string.Empty) +
                                         (WeightFactor != null ? " and (WeightFactor = " + WeightFactor + ") " : string.Empty) +
                                         " order by UpdateDate ASC";
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                var list = new List<SPIS_StrategicTree_KPI_obj>();
                while (SDR.Read())
                {
                    var item = new SPIS_StrategicTree_KPI_obj();
                    _Mapper.SetDataToObject(item, SDR);

                    var kpi = factory.KPI_DAL.GetObject(item.KPI_Id);
                    item.KPI_Name = kpi.Name;
                    item.KPI_Type = kpi.KPIType;
                    item.KPI_Precentage = factory.KPI_Service.KpiCalculation(kpi.Id, kpi.KPIType);

                    var progressList = factory.KPI_Progress_DAL.GetObjectList(null, kpi.Id);
                    if (progressList.Count > 0)
                    {
                        var last = progressList.OrderByDescending(x => x.CreateDate).FirstOrDefault();

                        item.KPI_Target = last.TargetValue.HasValue ? last.TargetValue.Value : 0;
                        item.KPI_Actual = last.ActualValue.HasValue ? last.ActualValue.Value : 0;
                    }

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
        else
            return new List<SPIS_StrategicTree_KPI_obj>();
    }

    public SPIS_StrategicTree_KPI_obj GetObject(Guid? StrategicTree_Id, Guid? KPI_Id)
    {
        var cmd = new SqlCommand();
        var item = new SPIS_StrategicTree_KPI_obj();
        cmd.CommandText = " SELECT * FROM [dbo].[StrategicTree_KPI] where " +
                                                     " " + (StrategicTree_Id != null ? "StrategicTree_Id ='" + StrategicTree_Id + "'" : "StrategicTree_Id IS NULL") +
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
                item.StrategicTree_Id = Guid.NewGuid();
                item.KPI_Id = Guid.NewGuid();
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

    public SPIS_StrategicTree_KPI_obj GetObject(Guid? KPI_Id)
    {
        var cmd = new SqlCommand();
        var item = new SPIS_StrategicTree_KPI_obj();
        cmd.CommandText = " SELECT * FROM [dbo].[StrategicTree_KPI] where " +
                                                     " " + (KPI_Id != null ? "KPI_Id ='" + KPI_Id + "'" : "KPI_Id IS NULL") +
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
                item.KPI_Id = Guid.NewGuid();
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

    public bool UpdateObject(SPIS_StrategicTree_KPI_obj inEditedItem, string StrategicTree_Id, string KPI_Id)
    {
        var cmd = new SqlCommand
        {
            CommandText = " UPDATE [dbo].[StrategicTree_KPI] SET  [StrategicTree_Id] = '" + inEditedItem.StrategicTree_Id + "' " +
                                                                ",[KPI_Id] = '" + inEditedItem.KPI_Id + "' " +
                                                                ",[WeightFactor] =  " + inEditedItem.WeightFactor + "  " +
                                                                ",[DepartmentWeightFactor] =  " + inEditedItem.DepartmentWeightFactor + "  " +
                                                                ",[UpdateId] = '" + inEditedItem.CreateId + "' " +
                                                                ",[UpdateDate] = GETDATE()" +
                                                          " where [StrategicTree_Id] = '" + StrategicTree_Id + "'" +
                                                            " and [KPI_Id] = '" + KPI_Id + "'",
            Connection = SC,
            CommandType = CommandType.Text
        };
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
            throw new ApplicationException("Data Error In Updating 'StrategicTree_KPI' : " + err.Message);
        }
        finally
        {
            SC.Close();
        }
    }

    public bool DeleteObject(string StrategicTree_KPI, string KPI_Id)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = "DELETE  FROM  [dbo].[StrategicTree_KPI]  where [StrategicTree_Id] = '" + StrategicTree_KPI + "'" +
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

    #endregion

    #region Override Members

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT All * FROM [dbo].[StrategicTree_KPI]"
            + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL");
    }

    public override SPIS_StrategicTree_KPI_obj CreatNewObject()
    {
        return new SPIS_StrategicTree_KPI_obj();
    }

    public override string InsertCommand(SPIS_StrategicTree_KPI_obj inNewObject)
    {
        return "INSERT INTO [dbo].[StrategicTree_KPI] ([StrategicTree_Id] ," +
                                                      "[History_Id] ," +
                                                      "[KPI_Id] ," +
                                                      "[WeightFactor] ," +
                                                      "[DepartmentWeightFactor] ," +
                                                      "[CreateId] ," +
                                                      "[CreateDate] ," +
                                                      "[UpdateId] ," +
                                                      "[UpdateDate] ) " +
                                          "VALUES ('" + inNewObject.StrategicTree_Id + "' , '" +
                                                        inNewObject.History_Id + "' , '" +
                                                        inNewObject.KPI_Id + "' , " +
                                                        inNewObject.WeightFactor + "  , " +
                                                        inNewObject.DepartmentWeightFactor + "  , '" +
                                                        inNewObject.CreateId + "' ,  " +
                                                        "GETDATE() ,'" +
                                                        inNewObject.UpdateId + "'," +
                                                        "GETDATE() ) ";
    }

    public override string UpdateCommand(SPIS_StrategicTree_KPI_obj inEditedObject, Guid inId)
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