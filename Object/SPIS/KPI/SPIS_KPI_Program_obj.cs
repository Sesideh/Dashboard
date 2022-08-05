using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
   public class SPIS_KPI_Program_obj : Common_obj
    {
        #region Construction

        public SPIS_KPI_Program_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region public Properties
        public Guid? History_Id { get; set; }
        public Guid Program_Id { get; set; }
        public Guid KPI_Id { get; set; }
        public string Program_Name { get; set; }

        #endregion
    }
}
