using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Prespective
/// </summary>
namespace SPIS
{
    public class SPIS_Prespective_obj : Common_obj
    {
        #region Constructor

        public SPIS_Prespective_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Weight { get; set; }

        #endregion

        #region None Persistance Properties

        public decimal Prespective_Calculation { get; set; }
        public decimal Prespective_Total { get; set; }

        public decimal Pre_Prespective_Calculation { get; set; }
        public decimal Pre_Prespective_Total { get; set; }

        #endregion
    }
}
