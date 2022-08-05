using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProgramProgress
/// </summary>
namespace SPIS
{
    public class SPIS_ProgramProgress_obj : Common_obj
    {
        #region Constructor

        public SPIS_ProgramProgress_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Plan_Id { get; set; }
        public Guid Id { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? ActualValue { get; set; }

        #endregion
    }
}

