using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StrategicTree_KPI
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTree_KPI_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTree_KPI_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Propeties

        public Guid? History_Id { get; set; }
        public Guid StrategicTree_Id { get; set; }
        public Guid KPI_Id { get; set; }
        public decimal WeightFactor { get; set; }
        public decimal DepartmentWeightFactor { get; set; }

        #endregion

        #region None Persistance Properties

        public string KPI_Name { get; set; }
        public KPIType KPI_Type { get; set; }
        public decimal KPI_Actual { get; set; }
        public decimal KPI_Target { get; set; }
        public decimal KPI_Precentage { get; set; }
        public decimal Pre_KPI_Precentage { get; set; }

        #endregion
    }
}
