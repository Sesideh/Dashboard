using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Business.Permission
{
    public class GetPermission
    {
        //private string _Create;
        //private string _Read;
        //private string _Update;
        //private string _Delete;

        public Permission FetchPermission()
        {
            return null;
        }

        public Permission FetchingPermission(AMS_USER_Security securable)
        {

            var amsService = ConfigurationManager.AppSettings["AMSService"];

            string url = string.Format("http://{0}/Services/WEBAPI/api/Account/getPermission", amsService);

            //string url = string.Format("http://localhost:51599/Services/WEBAPI/api/Account/getPermission");


            string param = securable.User_Id + "," + securable.project_id + "," + securable.sys_id + "," + securable.mdl_id;

            var javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            // added by sadeghi
            // Unathorized access for web service problem
            request.UseDefaultCredentials = true;

            request.PreAuthenticate = true;

            request.Credentials = CredentialCache.DefaultCredentials;
            //Serialize request object as JSON and write to request body

            var stringBuilder = new StringBuilder();
            javaScriptSerializer.Serialize(param, stringBuilder);
            var requestBody = stringBuilder.ToString();
            request.ContentLength = requestBody.Length;
            var streamWriter = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            streamWriter.Write(requestBody);
            streamWriter.Close();

            var response = request.GetResponse();

            //Read JSON response stream and deserialize
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseContent = streamReader.ReadToEnd().Trim();
            //var jsonObject = javaScriptSerializer.Deserialize<string>(responseContent);

            string[] perm = responseContent.Replace("[", "").Replace("]", "").Split(',');
            Permission pr = new Permission();

            int count = perm.Count();


            pr.Prm_Read = "No Access!";
            pr.Prm_Create = "No Access!";
            pr.Prm_Update = "No Access!";
            pr.Prm_Delete = "No Access!";
            pr.Prm_Import = "No Access!";
            pr.Prm_Export = "No Access!";
            pr.Prm_Approve = "No Access!";
            pr.Prm_Complete = "No Access!";
            pr.Prm_Confirm = "No Access!";
            pr.Prm_Operation = "No Access!";
            pr.Prm_AttachmentAdd = "No Access!";
            pr.Prm_AttachmentRemove = "No Access!";
            pr.Prm_AttachmentView = "No Access!";
            pr.Prm_FullAccess = "No Access!";

            if (count > 0)
                if (perm[0] != null && perm[0] != "[]" && perm[0] != "")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if ((perm[i]).Contains("Read"))
                            pr.Prm_Read = perm[i];
                        if ((perm[i]).Contains("Create"))
                            pr.Prm_Create = perm[i];
                        if ((perm[i]).Contains("Update"))
                            pr.Prm_Update = perm[i];
                        if ((perm[i]).Contains("Delete"))
                            pr.Prm_Delete = perm[i];
                        if ((perm[i]).Contains("Import"))
                            pr.Prm_Import = perm[i];
                        if ((perm[i]).Contains("Export"))
                            pr.Prm_Export = perm[i];
                        if ((perm[i]).Contains("Approve"))
                            pr.Prm_Approve = perm[i];
                        if ((perm[i]).Contains("Complete"))
                            pr.Prm_Complete = perm[i];
                        if ((perm[i]).Contains("Confirm"))
                            pr.Prm_Confirm = perm[i];
                        if ((perm[i]).Contains("Operation"))
                            pr.Prm_Operation = perm[i];
                        if ((perm[i]).Contains("AttachmentAdd"))
                            pr.Prm_AttachmentAdd = perm[i];
                        if ((perm[i]).Contains("AttachmentRemove"))
                            pr.Prm_AttachmentRemove = perm[i];
                        if ((perm[i]).Contains("AttachmentView"))
                            pr.Prm_AttachmentView = perm[i];
                        if ((perm[i]).Contains("FullAccess"))
                            pr.Prm_FullAccess = perm[i];
                    }
                }
            return pr;
        }

        //public List<ProjectsDDL> FetchingProjectList(string User_Id)
        //{
        //    var amsService = ConfigurationManager.AppSettings["AMSService"];

        //    string url = string.Format("http://{0}/Services/WEBAPI/api/Account/getProject", amsService);

        //    string param = User_Id;

        //    var javaScriptSerializer = new JavaScriptSerializer();
        //    javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "Post";
        //    request.Accept = "application/json";
        //    request.ContentType = "application/json; charset=utf-8";
        //    // added by sadeghi
        //    // Unathorized access for web service problem
        //    request.UseDefaultCredentials = true;

        //    request.PreAuthenticate = true;

        //    request.Credentials = CredentialCache.DefaultCredentials;
        //    //Serialize request object as JSON and write to request body

        //    var stringBuilder = new StringBuilder();
        //    javaScriptSerializer.Serialize(param, stringBuilder);
        //    var requestBody = stringBuilder.ToString();
        //    request.ContentLength = requestBody.Length;
        //    var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //    streamWriter.Write(requestBody);
        //    streamWriter.Close();
        //    var response = request.GetResponse();

        //    //Read JSON response stream and deserialize
        //    var streamReader = new System.IO.StreamReader(response.GetResponseStream());
        //    var responseContent = streamReader.ReadToEnd().Trim();
        //    //var jsonObject = javaScriptSerializer.Deserialize<string>(responseContent);

        //    //string[] Scopes = responseContent.Replace("\"", "").Replace("[", "").Replace("]", "").Split(',');
        //    //return Scopes;
        //    string ProjList = responseContent.Replace("ProjectId", "Project_Id").Replace("ProjectTitle", "Project_Title");
        //    List<ProjectsDDL> prList = javaScriptSerializer.Deserialize<List<ProjectsDDL>>(@ProjList);
        //    return prList;
        //}

        //public UsersProfile FetchingUserProfile(string User_Id)
        //{
        //    var amsService = ConfigurationManager.AppSettings["AMSService"];

        //    string url = string.Format("http://{0}/Services/WEBAPI/api/Account/GetUserProfile", amsService);

        //    string param = User_Id;



        //    var javaScriptSerializer = new JavaScriptSerializer();
        //    javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "Post";
        //    request.Accept = "application/json";
        //    request.ContentType = "application/json; charset=utf-8";
        //    // added by sadeghi
        //    // Unathorized access for web service problem
        //    request.UseDefaultCredentials = true;

        //    request.PreAuthenticate = true;

        //    request.Credentials = CredentialCache.DefaultCredentials;
        //    //Serialize request object as JSON and write to request body

        //    var stringBuilder = new StringBuilder();
        //    javaScriptSerializer.Serialize(param, stringBuilder);
        //    var requestBody = stringBuilder.ToString();
        //    request.ContentLength = requestBody.Length;
        //    var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //    streamWriter.Write(requestBody);
        //    streamWriter.Close();
        //    var response = request.GetResponse();
        //    UsersProfile Prof = new UsersProfile();
        //    //Read JSON response stream and deserialize
        //    var streamReader = new System.IO.StreamReader(response.GetResponseStream());
        //    var responseContent = streamReader.ReadToEnd().Trim();
        //    string result = responseContent.ToString().Replace("[", "").Replace("]", "");
        //    Prof = javaScriptSerializer.Deserialize<UsersProfile>(@result);
        //    return Prof;
        //}

        public IList<String> FetchingSystemList(string User_Id, string Scope)
        {
            var amsService = ConfigurationManager.AppSettings["AMSService"];

            string url = string.Format("http://{0}/Services/WEBAPI/api/Account/getSystem", amsService);

            string param = User_Id + "," + Scope;

            var javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            // added by sadeghi
            // Unathorized access for web service problem
            request.UseDefaultCredentials = true;

            request.PreAuthenticate = true;

            request.Credentials = CredentialCache.DefaultCredentials;
            //Serialize request object as JSON and write to request body

            var stringBuilder = new StringBuilder();
            javaScriptSerializer.Serialize(param, stringBuilder);
            var requestBody = stringBuilder.ToString();
            request.ContentLength = requestBody.Length;
            var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            streamWriter.Write(requestBody);
            streamWriter.Close();

            var response = request.GetResponse();

            //Read JSON response stream and deserialize
            var streamReader = new System.IO.StreamReader(response.GetResponseStream());
            var responseContent = streamReader.ReadToEnd().Trim();
            //var jsonObject = javaScriptSerializer.Deserialize<apiSystem>(responseContent);

            string[] Systems = responseContent.Replace("\"", "").Replace("[", "").Replace("]", "").Split(',');

            return Systems;
        }
        //public List<MCS_Discpline_obj> FetchingDiscipline(AMS_USER_Security securable)
        //{
        //    var amsService = ConfigurationManager.AppSettings["AMSService"];

        //    string url = string.Format("http://{0}/Services/WEBAPI/api/Account/GetDiscipline", amsService);


        //    string param = securable.User_Id + "," + securable.project_id + "," + securable.sys_id + "," + securable.mdl_id;

        //    var javaScriptSerializer = new JavaScriptSerializer();
        //    javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    request.Method = "Post";
        //    request.Accept = "application/json";
        //    request.ContentType = "application/json; charset=utf-8";
        //    // added by sadeghi
        //    // Unathorized access for web service problem
        //    request.UseDefaultCredentials = true;

        //    request.PreAuthenticate = true;

        //    request.Credentials = CredentialCache.DefaultCredentials;
        //    //Serialize request object as JSON and write to request body

        //    var stringBuilder = new StringBuilder();
        //    javaScriptSerializer.Serialize(param, stringBuilder);
        //    var requestBody = stringBuilder.ToString();
        //    request.ContentLength = requestBody.Length;
        //    var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        //    streamWriter.Write(requestBody);
        //    streamWriter.Close();

        //    var response = request.GetResponse();

        //    //Read JSON response stream and deserialize
        //    var streamReader = new System.IO.StreamReader(response.GetResponseStream());
        //    var responseContent = streamReader.ReadToEnd().Trim();
        //    //var jsonObject = javaScriptSerializer.Deserialize<string>(responseContent);
        //    string discString = responseContent.Replace("DiscCode", "C90_DEPT").Replace("DiscName", "C90_NAME");
        //    List<MCS_Discpline_obj> discList = javaScriptSerializer.Deserialize<List<MCS_Discpline_obj>>(@discString);

        //    return discList;
        //}
    }

    public class GetModule
    {
        public string AmsService = ConfigurationManager.AppSettings["AMSService"];

        public string GetModuleTitle(string systemId, string moduleId)
        {
            var url = string.Format("http://{0}/Services/WEBAPI/api/Account/GetModuleTitle", AmsService);

            var param = systemId + "," + moduleId;

            var javaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = 104857600 }; //200 MB unicode
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Post";
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";

            request.UseDefaultCredentials = true;

            request.PreAuthenticate = true;

            request.Credentials = CredentialCache.DefaultCredentials;

            var stringBuilder = new StringBuilder();
            javaScriptSerializer.Serialize(param, stringBuilder);
            var requestBody = stringBuilder.ToString();
            request.ContentLength = requestBody.Length;
            var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            streamWriter.Write(requestBody);
            streamWriter.Close();
            var response = request.GetResponse();


            var streamReader = new System.IO.StreamReader(response.GetResponseStream());
            var responseContent = streamReader.ReadToEnd().Trim();

            var result = responseContent.Replace("\"", "").Replace("[", "").Replace("]", "");

            return result;
        }
    }
}
