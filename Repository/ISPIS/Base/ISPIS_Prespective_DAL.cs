using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_Prespective_DAL : ICommon_DAL<SPIS_Prespective_obj>
    {
        IList<SPIS_Prespective_obj> GetObjectList(string inProject, string inTop, Guid PreHistoryId);
    }
}
