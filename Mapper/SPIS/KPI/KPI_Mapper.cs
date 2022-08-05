using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.KPI;
using Common;
using SPIS;

namespace Business.Mapper.SPIS.KPI
{
    public class KPI_Mapper : Comman_Mapper<SPIS_KPI_obj>, IKPI_Mapper
    {
        public override void SetDataToObject(SPIS_KPI_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.OwnerId = inSDR["OwnerId"] != DBNull.Value ? new Guid(inSDR["OwnerId"].ToString().Trim()) : (Guid?)null;
            inObject.History_Id = inSDR["History_Id"] != DBNull.Value ? new Guid(inSDR["History_Id"].ToString().Trim()) : (Guid?)null;
            inObject.Name = inSDR["Name"] != DBNull.Value ? inSDR["Name"].ToString().Trim() : null;
            inObject.DataTypeId = inSDR["DataTypeId"] != DBNull.Value ? new Guid(inSDR["DataTypeId"].ToString().Trim()) : (Guid?)null;
            inObject.Trending = inSDR["Trending"] != DBNull.Value ? (Trending)Enum.Parse(typeof(Trending), inSDR["Trending"].ToString().Trim()) : Trending.None;
            inObject.KPIType = inSDR["KPIType"] != DBNull.Value ? (KPIType)Enum.Parse(typeof(KPIType), inSDR["KPIType"].ToString().Trim()) : KPIType.Upward;
        }
    }
}
