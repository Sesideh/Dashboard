using Business;
using Business.Mapper.ISPIS.KPI;
using Business.Repository.ISPIS;
using Common;
using DAL.Common;
using Helper.Factory;
using SPIS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.Configuration;

/// <summary>
/// Summary description for SPIS_KPI_DAL
/// </summary>
public class SPIS_KPI_DAL : Common_DAL<SPIS_KPI_obj>, ISPIS_KPI_DAL
{
    #region Constructor

    public SPIS_KPI_DAL(IKPI_Mapper mapper) : base(mapper)
    {

    }

    #endregion

    #region Override Members

    public override SPIS_KPI_obj CreatNewObject()
    {
        return new SPIS_KPI_obj();
    }

    public override string InsertCommand(SPIS_KPI_obj inNewObject)
    {
        string result;

        result = "INSERT INTO [dbo].[KPI] ([Id] ," +
                                        "[Name] ," +
                                        "[OwnerId] ," +
                                        "[DataTypeId] ," +
                                        "[History_Id] ," +
                                        "[Trending] ," +
                                        "[KPIType] ," +
                                        "[Description] ," +
                                        "[CreateId] ," +
                                        "[CreateDate] ," +
                                        "[UpdateId] ," +
                                        "[UpdateDate] ) " +
                            "VALUES ('" + inNewObject.Id + "' , '" +
                                        inNewObject.Name + "' , " +
                                       (inNewObject.OwnerId != null ? "'" + inNewObject.OwnerId.ToString() + "'," : "NULL" + ", ") +
                                       (inNewObject.DataTypeId != null ? "'" + inNewObject.DataTypeId.ToString() + "'," : "NULL" + ",  ") +
                                       (inNewObject.History_Id != null ? "'" + inNewObject.History_Id.ToString() + "','" : "NULL" + ", '") +
                                        inNewObject.Trending + "' , '" +
                                        inNewObject.KPIType + "' , '" +
                                        inNewObject.Description + "' , '" +
                                        inNewObject.CreateId + "' , " +
                                        "GETDATE() ,'" +
                                        inNewObject.UpdateId + "'," +
                                        "GETDATE() ) ";

        return result;
    }

    public override string UpdateCommand(SPIS_KPI_obj inEditedObject, Guid inId)
    {
        return "  UPDATE [dbo].[KPI] SET [Name] = '" + inEditedObject.Name + "' " +
                                        ",[OwnerId] = " + (inEditedObject.OwnerId != null ? "'" + inEditedObject.OwnerId.ToString() + "'" : " NULL" + "") +
                                        ",[DataTypeId] = " + (inEditedObject.DataTypeId != null ? "'" + inEditedObject.DataTypeId.ToString() + "'" : " NULL" + "") +
                                        ",[Trending] = '" + inEditedObject.Trending + "' " +
                                        ",[KPIType] = '" + inEditedObject.KPIType + "' " +
                                        ",[Description] = '" + inEditedObject.Description + "' " +
                                        ",[UpdateId] = '" + inEditedObject.CreateId + "' " +
                                        ",[UpdateDate] = GETDATE()" +
                                  " where [Id] = '" + inId + "'";
    }

    public override string GetObjectListCommand(string inProject, string inTop)
    {
        return "SELECT All * FROM [dbo].[KPI]"
            + (inProject != null ? "Where History_Id = '" + inProject + "'" : " Where History_Id is NULL");
    }

    public override string GetObjectCommand(Guid Id)
    {
        return " SELECT * FROM [dbo].[KPI] where Id ='" + Id + "'";
    }

    public override string DeleteCommand(Guid inId)
    {
        return "DELETE FROM  [dbo].[KPI] where Id ='" + inId + "'";
    }

    #endregion

    #region Public Methods

    public SPIS_KPI_obj GetObject(string KPIName, Guid historyId)
    {
        var cmd = new SqlCommand();
        var item = CreatNewObject();
        cmd.CommandText = " SELECT * FROM [dbo].[KPI] where Name ='" + KPIName + "' and History_Id = '" + historyId + "'";
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

    public Color GetRowColor(decimal Prcentage)
    {
        Color result = Color.White;

        if (Prcentage < 65)
            result = Color.LightSalmon;
        else if (Prcentage >= 65 && Prcentage < 80)
            result = Color.Yellow;
        else if (Prcentage >= 80)
            result = Color.LightGreen;

        return result;
    }

    public decimal KpiCalculation(Guid inKPIId, KPIType inKPIType)
    {
        decimal? result = 0;
        var progressList = factory.KPI_Progress_DAL.GetObjectList(null, inKPIId);

        if (progressList.Count() > 0)
        {
            var last = progressList.OrderByDescending(x => x.CreateDate).FirstOrDefault();

            if (inKPIType == KPIType.Upward && last.TargetValue != 0)
            {
                result = (last.ActualValue / last.TargetValue) * 100;

                if (result > 100)
                    result = 100;
                else if (result < 0)
                    result = 0;
            }
            else if (inKPIType == KPIType.DownWard && last.TargetValue != 0)
            {
                result = (((last.TargetValue * 2) - last.ActualValue) / last.TargetValue) * 100;

                if (result > 100)
                    result = 100;
                else if (result < 0)
                    result = 0;
            }
        }

        return result.Value;
    }

    public IList<SPIS_KPI_obj> GetKPIList_ByOwnerOrder(int inOwner, Guid inHistoryId)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT  All * FROM [dbo].[KPI] inner join Owner on KPI.OwnerId = Owner.Id where Ordering ='" + inOwner + "'" + (inHistoryId != Guid.Empty ? " and KPI.History_Id = '" + inHistoryId + "'" : string.Empty);
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var kpiList = new List<SPIS_KPI_obj>();
            while (SDR.Read())
            {
                var kpi = new SPIS_KPI_obj();
                _Mapper.SetDataToObject(kpi, SDR);
                kpiList.Add(kpi);
            }
            foreach (var item in kpiList)
            {
                var items = factory.StrategicTree_KPI_DAL.GetObject(item.Id);

                if (item.DataTypeId != null)
                {
                    var dataType = factory.DataType_DAL.GetObject(item.DataTypeId.Value);
                    item.DataTypeName = dataType.Title;
                }

                item.DepartmentWeightFactor = items.DepartmentWeightFactor;

                var progressList = factory.KPI_Progress_DAL.GetObjectList(null, item.Id);
                if (progressList.Count > 0)
                {
                    var last = progressList.OrderByDescending(x => x.CreateDate).FirstOrDefault();

                    item.Target = last.TargetValue.HasValue ? last.TargetValue.Value : 0;
                    item.Actual = last.ActualValue.HasValue ? last.ActualValue.Value : 0;
                }
            }
            return kpiList;
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

    public IList<SPIS_KPI_obj> GetKPIList_ByOwnerId(Guid inOwnerId, Guid inHistoryId)
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT  All * FROM [dbo].[KPI] where OwnerId ='" + inOwnerId + "'" + (inHistoryId != Guid.Empty ? " and History_Id = '" + inHistoryId + "'" : string.Empty);
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var kpiList = new List<SPIS_KPI_obj>();
            while (SDR.Read())
            {
                var kpi = new SPIS_KPI_obj();
                _Mapper.SetDataToObject(kpi, SDR);
                kpiList.Add(kpi);
            }
            foreach (var item in kpiList)
            {
                var items = factory.StrategicTree_KPI_DAL.GetObject(item.Id);

                if (item.DataTypeId != null)
                {
                    var dataType = factory.DataType_DAL.GetObject(item.DataTypeId.Value);
                    item.DataTypeName = dataType.Title;
                }

                item.DepartmentWeightFactor = items.DepartmentWeightFactor;

                var progressList = factory.KPI_Progress_DAL.GetObjectList(null, item.Id);
                if (progressList.Count > 0)
                {
                    var last = progressList.OrderByDescending(x => x.CreateDate).FirstOrDefault();

                    item.Target = last.TargetValue.HasValue ? last.TargetValue.Value : 0;
                    item.Actual = last.ActualValue.HasValue ? last.ActualValue.Value : 0;
                }
            }
            return kpiList;
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

    public IList<SPIS_KPI_obj> GetKPIList()
    {
        var cmd = new SqlCommand();
        cmd.CommandText = "SELECT  All * FROM [dbo].[KPI] ";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            var KPIList = new List<SPIS_KPI_obj>();
            while (SDR.Read())
            {
                var KPIObject = new SPIS_KPI_obj();
                _Mapper.SetDataToObject(KPIObject, SDR);
                KPIList.Add(KPIObject);
            }
            foreach (var item in KPIList)
            {
                var items = factory.StrategicTree_KPI_DAL.GetObject(item.Id);
                item.DepartmentWeightFactor = items.WeightFactor;

                var progressList = factory.KPI_Progress_DAL.GetObjectList(null, item.Id);
                if (progressList.Count > 0)
                {
                    var last = progressList.OrderByDescending(x => x.CreateDate).FirstOrDefault();

                    item.Target = last.TargetValue.HasValue ? last.TargetValue.Value : 0;
                    item.Actual = last.ActualValue.HasValue ? last.ActualValue.Value : 0;
                }
            }
            return KPIList;
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
