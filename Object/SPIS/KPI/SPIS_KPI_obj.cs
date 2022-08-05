using Common;
using System;

/// <summary>
/// Summary description for KPI
/// </summary>
namespace SPIS
{
    public class SPIS_KPI_obj : Common_obj
    {
        #region Constructor

        public SPIS_KPI_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? History_Id { get; set; }
        public string Name { get; set; }
        public Guid? DataTypeId { get; set; }
        public Trending Trending { get; set; }
        public KPIType KPIType { get; set; }

        #endregion

        #region None Persistance Properties

        public decimal DepartmentWeightFactor { get; set; }
        public decimal Target { get; set; }
        public decimal Actual { get; set; }
        public string DataTypeName { get; set; }

        #endregion
    }
}
