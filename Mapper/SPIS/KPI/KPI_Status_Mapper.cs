using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.KPI;
using SPIS;

namespace Business.Mapper.SPIS.KPI
{
    public class KPI_Status_Mapper : Comman_Mapper<SPIS_KPI_Status_obj>, IKPI_Status_Mapper
    {
        public override void SetDataToObject(SPIS_KPI_Status_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.KPI_Id = new Guid(inSDR["KPI_Id"].ToString().Trim());
            inObject.StartRange = inSDR["StartRange"] != DBNull.Value ? Convert.ToDecimal(inSDR["StartRange"].ToString().Trim()) : 0;
            inObject.EndRange = inSDR["EndRange"] != DBNull.Value ? Convert.ToDecimal(inSDR["EndRange"].ToString().Trim()) : 0;
            inObject.DataTypeId = inSDR["DataTypeId"] != DBNull.Value ? new Guid(inSDR["DataTypeId"].ToString().Trim()) : (Guid?)null;
            inObject.Color = inSDR["Color"] != DBNull.Value ? inSDR["Color"].ToString().Trim() : null;
        }
    }
}
