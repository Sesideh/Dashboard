using Business;
using Business.Mapper.Common;
using Business.Mapper.ICommon;
using Common;
using DAl.Common;
using DAl.ICommon;
using Helper.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for Common_DAL
/// </summary>
namespace DAL.Common
{
    public class Common_DAL<T> : DataAccessRow, ICommon_DAL<T>
        where T : Common_obj
    {
        #region Private Properties

        private SqlConnection _SC;
        public virtual SqlConnection SC { get { return _SC ?? (_SC = new SqlConnection(connString)); } }
        private string connString { get; set; }
        public IFactory factory;
        public ICommon_Mapper<T> _Mapper { get; }

        #endregion

        #region Constructor

        public Common_DAL(ICommon_Mapper<T> mapper)
        {
            connString = WebConfigurationManager.ConnectionStrings["SPIS"].ConnectionString;
            factory = new Factory();
            _Mapper = mapper;
        }

        #endregion

        #region Virtual Methods

        public virtual IList<T> GetObjectList(string inProject, string inTop)
        {
            var cmd = new SqlCommand();
            var objectList = new List<T>();
            cmd.CommandText = GetObjectListCommand(inProject, inTop);
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();
                while (SDR.Read())
                {
                    var item = CreatNewObject();
                    _Mapper.SetDataToObject(item, SDR);
                    objectList.Add(item);
                }
                return objectList;
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Link Error: " + err.Message);
            }
            finally
            {
                SC.Close();
            }
        }

        public virtual T GetObject(Guid Id)
        {
            var cmd = new SqlCommand();
            var item = CreatNewObject();
            cmd.CommandText = GetObjectCommand(Id);
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                var SDR = cmd.ExecuteReader();

                if (SDR.Read())
                {
                    _Mapper.SetDataToObject(item, SDR);
                }
                else
                {
                }
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Data Error: " + err.Message);
            }
            finally
            {
                SC.Close();
            }

            return item;
        }

        public virtual int InsertNewObject(T inNewObject)
        {
            var cmd = new SqlCommand();

            cmd.CommandText = InsertCommand(inNewObject);
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException err)
            {
                if (err.Message.Contains("PRIMARY KEY") || err.Message.Contains("duplicate"))
                {
                    return 3;
                }
                else
                    return 4;
            }
            finally
            {
                SC.Close();
            }
        }

        public virtual bool DeleteObject(Guid inId)
        {
            var cmd = new SqlCommand();

            cmd.CommandText = DeleteCommand(inId);
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Data Error: " + err.Message);
            }
            finally
            {
                SC.Close();
            }
        }

        public virtual bool UpdateObject(T inEditedObject, Guid inId)
        {
            var cmd = new SqlCommand();

            cmd.CommandText = UpdateCommand(inEditedObject, inId);
            cmd.Connection = SC;
            cmd.CommandType = CommandType.Text;
            try
            {
                SC.Open();
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException err)
            {
                throw new ApplicationException("Data Error In Updating 'Object' : " + err.Message);
            }
            finally
            {
                SC.Close();
            }
        }

        public virtual void Dispose()
        {

        }

        #endregion

        #region Abstract Methods

        public virtual T CreatNewObject()
        {
            throw new NotImplementedException();
        }

        public virtual string InsertCommand(T inNewObject)
        {
            throw new NotImplementedException();
        }

        public virtual string UpdateCommand(T inEditedObject, Guid inId)
        {
            throw new NotImplementedException();
        }

        public virtual string DeleteCommand(Guid inId)
        {
            throw new NotImplementedException();
        }

        public virtual string GetObjectCommand(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual string GetObjectListCommand(string inProject, string inTop)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
