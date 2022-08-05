using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ICommon_DAL
/// </summary>
namespace DAl.ICommon
{
    public interface ICommon_DAL<T> : IDisposable
        where T : ICommon_obj 
    {
        IList<T> GetObjectList(string inProject, string inTop);
        T GetObject(Guid Id);
        bool DeleteObject(Guid inId);
        T CreatNewObject();
        int InsertNewObject(T inNewObject);
        bool UpdateObject(T inEditedObject, Guid inId);
    }
}
