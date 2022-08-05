using Common;
using System;


/// <summary>
/// Summary description for KPI_Status
/// </summary>
namespace SPIS
{
    public class SPIS_KPI_Status_obj : Common_obj
    {
        #region Construction

        public SPIS_KPI_Status_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid KPI_Id { get; set; }
        public string Color { get; set; }
        public Guid? DataTypeId { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }

        #endregion
    }
}
