using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.StrategicTree;
using SPIS;

namespace Business.Mapper.SPIS.StrategicTree
{
    public class StrategicTree_Prospective_Mapper : Comman_Mapper<SPIS_StrategicTree_Prospective_obj>, IStrategicTree_Prospective_Mapper
    {
        public override void SetDataToObject(SPIS_StrategicTree_Prospective_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.StrategicTree_Id = new Guid(inSDR["StrategicTree_Id"].ToString().Trim());
            inObject.Prospective_Id = new Guid(inSDR["Prospective_Id"].ToString().Trim());
            inObject.WeightFactor = inSDR["WeightFactor"] != DBNull.Value ? Convert.ToDecimal(inSDR["WeightFactor"].ToString().Trim()) : 0;
        }
    }
}
