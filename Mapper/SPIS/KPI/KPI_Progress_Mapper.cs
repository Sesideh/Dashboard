using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.KPI;
using SPIS;

namespace Business.Mapper.SPIS.KPI
{
    public class KPI_Progress_Mapper : Comman_Mapper<SPIS_KPI_Progress_obj>, IKPI_Progress_Mapper
    {
        public override void SetDataToObject(SPIS_KPI_Progress_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.KPI_Id = new Guid(inSDR["KPI_Id"].ToString().Trim());
            inObject.TargetValue = inSDR["TargetValue"] != DBNull.Value ? Convert.ToDecimal(inSDR["TargetValue"].ToString().Trim()) : (decimal?)null;
            inObject.ActualValue = inSDR["ActualValue"] != DBNull.Value ? Convert.ToDecimal(inSDR["ActualValue"].ToString().Trim()) : (decimal?)null;
            inObject.ActualDate = inSDR["ActualDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["ActualDate"].ToString().Trim()) : (DateTime?)null;
            inObject.TargetDate = inSDR["TargetDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["TargetDate"].ToString().Trim()) : (DateTime?)null;
        }
    }
}
