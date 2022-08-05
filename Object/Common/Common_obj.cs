using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonDTO
/// </summary>
namespace Common
{
    public class Common_obj : ICommon_obj
    {
        #region Constructor

        public Common_obj()
        {
        }

        public Common_obj
            (string inDescription,
            DateTime inCreateDate,
            string inCreateId,
            DateTime inUpdateDate,
            string inUpdateId,
            string inProjectId)
        {
            Description = inDescription;
            CreateDate = inCreateDate;
            CreateId = inCreateId;
            UpdateId = inUpdateId;
            UpdateDate = inUpdateDate;
            ProjectId = inProjectId;
        }

        #endregion

        #region Public Properties

        public string Description { get; set; }
        public string ProjectId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateId { get; set; }

        #endregion
    }
}
