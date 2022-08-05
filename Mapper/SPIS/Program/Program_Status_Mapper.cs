using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.Program;
using SPIS;

namespace Business.Mapper.SPIS.Program
{
    public class Program_Status_Mapper : Comman_Mapper<SPIS_Program_Status_obj>, IProgram_Status_Mapper
    {
        public override void SetDataToObject(SPIS_Program_Status_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.Program_Id = new Guid(inSDR["Program_Id"].ToString().Trim());
            inObject.StartRange = inSDR["StartRange"] != DBNull.Value ? Convert.ToDecimal(inSDR["StartRange"].ToString().Trim()) : 0;
            inObject.EndRange = inSDR["EndRange"] != DBNull.Value ? Convert.ToDecimal(inSDR["EndRange"].ToString().Trim()) : 0;
            inObject.DataTypeId = inSDR["DataTypeId"] != DBNull.Value ? new Guid(inSDR["DataTypeId"].ToString().Trim()) : (Guid?)null;
            inObject.Color = inSDR["Color"] != DBNull.Value ? inSDR["Color"].ToString().Trim() : null;
        }
    }
}
