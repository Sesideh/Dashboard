using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_Program_DAL : ICommon_DAL<SPIS_Program_obj>
    {
        IList<SPIS_Program_obj> GetChildList(string inProject, Guid inParentId);
    }
}
