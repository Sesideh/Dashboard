using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Program
/// </summary>
namespace SPIS
{
    public class SPIS_Program_obj : Common_obj
    {
        #region Construtor

        public SPIS_Program_obj()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion

        #region Public Methods

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? OwnerId { get; set; }
        public string Title { get; set; }

        #region None Persistance Properties

        public bool IsParent { get; set; }

        #endregion
        #endregion
    }
}
