using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ISPIS.Base;
using SPIS;

namespace Business.Mapper.SPIS.Base
{
    public class Owner_Mapper : Comman_Mapper<SPIS_Owner_obj>, IOwner_Mapper
    {
        public override void SetDataToObject(SPIS_Owner_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.History_Id = new Guid(inSDR["History_Id"].ToString().Trim());
            inObject.Owner = inSDR["Owner"] != DBNull.Value ? inSDR["Owner"].ToString().Trim() : null;
        }
    }
}
