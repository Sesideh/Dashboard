using Common;
using System;

/// <summary>
/// Summary description for StrategicTree_Prospective
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTree_Prospective_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTree_Prospective_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid StrategicTree_Id { get; set; }
        public Guid Prospective_Id { get; set; }
        public Guid? History_Id { get; set; }
        public decimal WeightFactor { get; set; }

        #endregion
    }
}
