using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper.ICommon
{
    public interface ICommon_Mapper<T> 
        where T : ICommon_obj
    {
        void SetDataToObject(T inObject, SqlDataReader inSDR);
    }
}
