using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
    public class SPIS_Program_Status_obj : Common_obj
    {
        #region Construction

        public SPIS_Program_Status_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid Program_Id { get; set; }
        public string Color { get; set; }
        public Guid? DataTypeId { get; set; }
        public decimal StartRange { get; set; }
        public decimal EndRange { get; set; }

        #endregion
    }
}
