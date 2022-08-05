using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.StrategicTree;
using SPIS;

namespace Business.Mapper.SPIS.StrategicTree
{
    public class StrategicTreeHistory_Mapper : Comman_Mapper<SPIS_StrategicTreeHistory_obj>, IStrategicTreeHistory_Mapper
    {
        public override void SetDataToObject(SPIS_StrategicTreeHistory_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.Company_Id = new Guid(inSDR["Company_Id"].ToString().Trim());
            inObject.TreeName = inSDR["TreeName"] != DBNull.Value ? inSDR["TreeName"].ToString().Trim() : null;
            inObject.DataTypeId = inSDR["DataTypeId"] != DBNull.Value ? new Guid(inSDR["DataTypeId"].ToString().Trim()) : (Guid?)null;
            inObject.StartDate = inSDR["StartDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["StartDate"].ToString().Trim()) : (DateTime?)null;
            inObject.EndDate = inSDR["EndDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["EndDate"].ToString().Trim()) : (DateTime?)null;
            inObject.Achieved = inSDR["Achieved"] != DBNull.Value ? Convert.ToDecimal(inSDR["Achieved"].ToString().Trim()) : (decimal?)null;
            inObject.Target = inSDR["Target"] != DBNull.Value ? Convert.ToDecimal(inSDR["Target"].ToString().Trim()) : (decimal?)null;
        }
    }
}
