using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
    public class SPIS_KPI_Progress_obj : Common_obj
    {
        #region Construction

        public SPIS_KPI_Progress_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid? History_Id { get; set; }
        public Guid Id { get; set; }
        public Guid KPI_Id { get; set; }
        public decimal? TargetValue { get; set; }
        public decimal? ActualValue { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? ActualDate { get; set; }

        #endregion
    }
}
