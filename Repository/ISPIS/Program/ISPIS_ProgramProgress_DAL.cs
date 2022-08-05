using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_ProgramProgress_DAL : ICommon_DAL<SPIS_ProgramProgress_obj>
    {
        IList<SPIS_ProgramProgress_obj> GetObjectLists(string inProject, Guid inProgramId);
    }
}
