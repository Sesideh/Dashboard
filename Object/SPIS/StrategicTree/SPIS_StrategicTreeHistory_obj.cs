using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StrategicTreeHistory
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTreeHistory_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTreeHistory_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid Company_Id { get; set; }
        public string TreeName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Achieved { get; set; }
        public decimal? Target { get; set; }
        public Guid? DataTypeId { get; set; }

        #endregion

        #region None Persistance Properties

        public Guid? ImportFrom { get; set; }

        public string CompanyName { get; set; }

        #endregion
    }
}
