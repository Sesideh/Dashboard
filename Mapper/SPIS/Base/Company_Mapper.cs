using System;
using System.Data.SqlClient;
using Business.Mapper.Common;
using Business.Mapper.ICommon;
using Common;
using SPIS;

namespace Business.Mapper.Base
{
    public class Company_Mapper : Comman_Mapper<SPIS_Company_obj> , ICompany_Mapper
    {
        public override void SetDataToObject(SPIS_Company_obj inObject, SqlDataReader inSDR)
        {
            base.SetDataToObject(inObject, inSDR);
            inObject.Id = new Guid(inSDR["Id"].ToString().Trim());
            inObject.Name = inSDR["Name"] != DBNull.Value ? inSDR["Name"].ToString().Trim() : null;
            inObject.Type = inSDR["Type"] != DBNull.Value ? (CompanyType)Enum.Parse(typeof(CompanyType), inSDR["Type"].ToString().Trim()) : CompanyType.Company;
        }
    }
}
