using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.Base;
using SPIS;

namespace Business.Mapper.SPIS.Base
{
    public class Prespective_Mapper : Comman_Mapper<SPIS_Prespective_obj>, IPrespective_Mapper
    {
        public override void SetDataToObject(SPIS_Prespective_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.Title = inSDR["Title"] != DBNull.Value ? inSDR["Title"].ToString().Trim() : null;
            inObject.Weight = inSDR["Weight"] != DBNull.Value ? Convert.ToDecimal(inSDR["Weight"].ToString().Trim()) : 0;
        }

    }
}
