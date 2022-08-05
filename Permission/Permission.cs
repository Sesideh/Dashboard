using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Permission
{
    public class Permission
    {
        public Permission()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Prm_Create { set; get; }
        public string Prm_Read { set; get; }
        public string Prm_Update { set; get; }
        public string Prm_Delete { set; get; }
        public string Prm_Import { set; get; }
        public string Prm_Export { set; get; }
        public string Prm_Approve { set; get; }

        public string Prm_Confirm { set; get; }
        public string Prm_Operation { set; get; }
        public string Prm_Complete { set; get; }

        public string Prm_AttachmentView { get; set; }
        public string Prm_AttachmentAdd { get; set; }
        public string Prm_AttachmentRemove { get; set; }

        public string Prm_FullAccess { get; set; }


        public Permission(string _Create, string _Read, string _Update, string _Delete, string _Import, string _Export, string _Approve, string _Operation, string _AttachmentAdd, string _AttachmentView, string _AttachmentRemove, string _FullAccess)
        {
            Prm_Read = _Read;
            Prm_Create = _Create;
            Prm_Update = _Update;
            Prm_Delete = _Delete;
            Prm_Import = _Import;
            Prm_Export = _Export;
            Prm_Approve = _Approve;
            Prm_Confirm = _Approve;
            Prm_Complete = _Approve;
            Prm_Operation = _Operation;
            Prm_AttachmentAdd = _AttachmentAdd;
            Prm_AttachmentView = _AttachmentView;
            Prm_AttachmentRemove = _AttachmentRemove;
            Prm_FullAccess = _FullAccess;
        }
    }
}
