using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.StrategicTree;
using SPIS;

namespace Business.Mapper.SPIS.StrategicTree
{
    public class StrategicTreeProgress_Mapper : Comman_Mapper<SPIS_StrategicTreeProgress_obj> , IStrategicTreeProgress_Mapper
    {
        public override void SetDataToObject(SPIS_StrategicTreeProgress_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.StrategicTree_Id = new Guid(inSDR["StrategicTree_Id"].ToString().Trim());
            inObject.TargectValue = inSDR["TargectValue"] != DBNull.Value ? Convert.ToDecimal(inSDR["TargectValue"].ToString().Trim()) : (decimal?)null;
            inObject.ActualValue = inSDR["ActualValue"] != DBNull.Value ? Convert.ToDecimal(inSDR["ActualValue"].ToString().Trim()) : (decimal?)null;
        }
    }
}
