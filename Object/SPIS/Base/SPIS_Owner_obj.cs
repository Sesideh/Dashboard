using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
    public class SPIS_Owner_obj : Common_obj
    {
        #region Constructor

        public SPIS_Owner_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public Guid? History_Id { get; set; }
        public string Owner { get; set; }

        #endregion

        #region None Persistance Properties

        public decimal Progress { get; set; }

        public decimal Pre_Progress { get; set; }

        #endregion
    }
}
