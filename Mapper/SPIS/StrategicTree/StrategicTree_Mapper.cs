using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.StrategicTree;
using SPIS;

namespace Business.Mapper.SPIS.StrategicTree
{
    public class StrategicTree_Mapper : Comman_Mapper<SPIS_StrategicTree_obj>, IStrategicTree_Mapper
    {
        public override void SetDataToObject(SPIS_StrategicTree_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.ParentId = inSDR["ParentId"] != DBNull.Value ? new Guid(inSDR["ParentId"].ToString().Trim()) : (Guid?)null;
            inObject.History_Id = inSDR["History_Id"] != DBNull.Value ? new Guid(inSDR["History_Id"].ToString().Trim()) : (Guid?)null;
            inObject.PrespectiveId = new Guid(inSDR["PrespectiveId"].ToString().Trim());
            inObject.Title = inSDR["Title"] != DBNull.Value ? inSDR["Title"].ToString().Trim() : null;
            inObject.WeightFactor = inSDR["WeightFactor"] != DBNull.Value ? Convert.ToDecimal(inSDR["WeightFactor"].ToString().Trim()) : (decimal?)null;
            inObject.Target = inSDR["Target"] != DBNull.Value ? Convert.ToDecimal(inSDR["Target"].ToString().Trim()) : (decimal?)null;
            inObject.Actual = inSDR["Actual"] != DBNull.Value ? Convert.ToDecimal(inSDR["Actual"].ToString().Trim()) : (decimal?)null;
            inObject.ChildrenWeightFactorEffect = inSDR["ChildrenWeightFactorEffect"] != DBNull.Value ? Convert.ToDecimal(inSDR["ChildrenWeightFactorEffect"].ToString().Trim()) : (decimal?)null;
            inObject.KPIWeightFactorEffect = inSDR["KPIWeightFactorEffect"] != DBNull.Value ? Convert.ToDecimal(inSDR["KPIWeightFactorEffect"].ToString().Trim()) : (decimal?)null;
            inObject.ObjectViewCalculation = inSDR["ObjectViewCalculation"] != DBNull.Value ? Convert.ToDecimal(inSDR["ObjectViewCalculation"].ToString().Trim()) : (decimal?)null;
            inObject.TreeViewCalculation = inSDR["TreeViewCalculation"] != DBNull.Value ? Convert.ToDecimal(inSDR["TreeViewCalculation"].ToString().Trim()) : (decimal?)null;
        }
    }
}
