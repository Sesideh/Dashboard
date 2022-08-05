using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StrategicTreeProgress
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTreeProgress_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTreeProgress_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region public Properties

        public Guid Id { get; set; }
        public Guid StrategicTree_Id { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public decimal? TargectValue { get; set; }
        public decimal? ActualValue { get; set; } 

        #endregion
    }
}
