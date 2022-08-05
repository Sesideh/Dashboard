using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StrategicTree_Status
/// </summary>
namespace SPIS
{
    public class SPIS_StrategicTree_Status_obj : Common_obj
    {
        #region Constructor

        public SPIS_StrategicTree_Status_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region public Properties

        public Guid Id { get; set; }
        public Guid StrategicTree_Id { get; set; }
        public String Color { get; set; }
        public Guid? DataTypeId { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }

        #endregion
    }
}