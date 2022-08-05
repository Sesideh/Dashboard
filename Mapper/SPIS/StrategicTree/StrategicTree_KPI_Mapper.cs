using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.StrategicTree;
using SPIS;

namespace Business.Mapper.SPIS.StrategicTree
{
    public class StrategicTree_KPI_Mapper : Comman_Mapper<SPIS_StrategicTree_KPI_obj>, IStrategicTree_KPI_Mapper
    {
        public override void SetDataToObject(SPIS_StrategicTree_KPI_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.StrategicTree_Id = new Guid(inSDR["StrategicTree_Id"].ToString().Trim());
            inObject.History_Id = inSDR["History_Id"] != DBNull.Value ? new Guid(inSDR["History_Id"].ToString().Trim()) : (Guid?)null;
            inObject.KPI_Id = new Guid(inSDR["KPI_Id"].ToString().Trim());
            inObject.WeightFactor = inSDR["WeightFactor"] != DBNull.Value ? Convert.ToDecimal(inSDR["WeightFactor"].ToString().Trim()) : 0;
            inObject.DepartmentWeightFactor = inSDR["DepartmentWeightFactor"] != DBNull.Value ? Convert.ToDecimal(inSDR["DepartmentWeightFactor"].ToString().Trim()) : 0;
        }

    }
}
