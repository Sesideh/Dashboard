using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.KPI;
using SPIS;

namespace Business.Mapper.SPIS.KPI
{
    public class KPI_Program_Mappper : Comman_Mapper<SPIS_KPI_Program_obj>, IKPI_Program_Mapper
    {
        public override void SetDataToObject(SPIS_KPI_Program_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Program_Id = new Guid(inSDR["Program_Id"].ToString().Trim());
            inObject.History_Id = new Guid(inSDR["History_Id"].ToString().Trim());
            inObject.KPI_Id = new Guid(inSDR["KPI_Id"].ToString().Trim());
        }
    }
}
