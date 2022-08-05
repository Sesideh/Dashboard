using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.KPI;
using SPIS;

namespace Business.Mapper.SPIS.KPI
{
    public class KPI_Analyze_Mapper : Comman_Mapper<SPIS_KPI_Analyze_obj>, IKPI_Analyze_Mapper
    {
        public override void SetDataToObject(SPIS_KPI_Analyze_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.KPI_Id = new Guid(inSDR["KPI_Id"].ToString().Trim());
            inObject.History_Id = new Guid(inSDR["History_Id"].ToString().Trim());
            inObject.Analyze = inSDR["Analyze"] != DBNull.Value ? Convert.ToString(inSDR["Analyze"].ToString().Trim()) : null;
        }
    }
}
