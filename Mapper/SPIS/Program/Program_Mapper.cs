using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.Program;
using SPIS;

namespace Business.Mapper.SPIS.Program
{
    public class Program_Mapper : Comman_Mapper<SPIS_Program_obj>, IProgram_Mapper
    {
        public override void SetDataToObject(SPIS_Program_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.ParentId = inSDR["ParentId"] != DBNull.Value ? new Guid(inSDR["ParentId"].ToString().Trim()) : (Guid?)null;
            inObject.OwnerId = inSDR["OwnerId"] != DBNull.Value ? new Guid(inSDR["OwnerId"].ToString().Trim()) : (Guid?)null;
            inObject.Title = inSDR["Title"] != DBNull.Value ? inSDR["Title"].ToString().Trim() : null;
        }
    }
}
