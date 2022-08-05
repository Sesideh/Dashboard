using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StrategicTree
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTree_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTree_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? History_Id { get; set; }
        public Guid PrespectiveId { get; set; }
        public string Title { get; set; }
        public decimal? WeightFactor { get; set; }
        public decimal? Actual { get; set; }
        public decimal? Target { get; set; }
        public decimal? ChildrenWeightFactorEffect { get; set; }
        public decimal? KPIWeightFactorEffect { get; set; }
        public decimal? ObjectViewCalculation { get; set; }
        public decimal? TreeViewCalculation { get; set; }

        #endregion

        #region None Persistance Properties

        public bool IsParent { get; set; }
        public decimal Pre_Actual { get; set; }
        
        #endregion
    }
}

