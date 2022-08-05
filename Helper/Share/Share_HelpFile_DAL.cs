using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class Share_HelpFile_DAL
{
    #region Constructor
    public Share_HelpFile_DAL()
    {
        connString = WebConfigurationManager.ConnectionStrings["AMS_ITTFS"].ConnectionString;
    }
    #endregion

    #region Private Fields
    public Share_HelpFile_obj objHelpFile = new Share_HelpFile_obj();
    private string connString;

    private SqlConnection _SC;

    private SqlConnection SC
    {
        get { return _SC ?? (_SC = new SqlConnection(connString)); }
    }

    #endregion

    #region Public Method

    public Share_HelpFile_obj Get_HelpFile(string mdl)
    {
        var cmd = new SqlCommand();

        cmd.CommandText = "SELECT   * FROM [AMS].[dbo].[wf_Modules] where Mdl_Id ='" + mdl + "'";
        cmd.Connection = SC;
        cmd.CommandType = CommandType.Text;
        try
        {
            SC.Open();
            var SDR = cmd.ExecuteReader();
            
            while (SDR.Read())
            {
                SetDataToObject( SDR);
            }
            return objHelpFile;
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

    private void SetDataToObject( SqlDataReader inSDR)
    {
        objHelpFile.ModuleTitle = inSDR["Mdl_Title"] != null ? inSDR["Mdl_Title"].ToString().Trim() : null;
        objHelpFile.HelpFile = inSDR["HelpFile"] != DBNull.Value ? inSDR["HelpFile"].ToString().Trim() : null;
    }

    #endregion
}