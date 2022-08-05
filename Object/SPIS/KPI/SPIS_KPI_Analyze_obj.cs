using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
    public class SPIS_KPI_Analyze_obj : Common_obj
    {
        #region Construction

        public SPIS_KPI_Analyze_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid KPI_Id { get; set; }
        public Guid History_Id { get; set; }
        public string Analyze { get; set; }

        #endregion
    }
}
