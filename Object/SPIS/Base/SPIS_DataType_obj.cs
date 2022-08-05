using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPIS
{
    public class SPIS_DataType_obj : Common_obj
    {
        #region Constructor

        public SPIS_DataType_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Properties

        public Guid Id { get; set; }
        public string Title { get; set; }

        #endregion
    }
}
