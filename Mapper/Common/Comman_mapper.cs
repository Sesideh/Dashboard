using System;
using System.Data.SqlClient;
using Business.Mapper.ICommon;
using Common;

namespace Business.Mapper.Common
{
    public class Comman_Mapper<T> : ICommon_Mapper<T>
        where T : Common_obj
    {

        public Comman_Mapper()
        {
            
        }
        
        public virtual void SetDataToObject(T inObject, SqlDataReader inSDR)
        {
            inObject.CreateId = inSDR["CreateId"] != null ? inSDR["CreateId"].ToString().Trim() : null;
            inObject.ProjectId = inSDR["ProjectId"] != DBNull.Value ? inSDR["ProjectId"].ToString().Trim() : string.Empty;
            inObject.CreateDate = inSDR["CreateDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["CreateDate"].ToString().Trim()) : DateTime.Now;
            inObject.UpdateId = inSDR["UpdateId"] != null ? inSDR["UpdateId"].ToString().Trim() : null;
            inObject.UpdateDate = inSDR["UpdateDate"] != DBNull.Value ? Convert.ToDateTime(inSDR["UpdateDate"].ToString().Trim()) : DateTime.Now;
            inObject.Description = inSDR["Description"] != null ? inSDR["Description"].ToString().Trim() : null;
        }
    }
}
