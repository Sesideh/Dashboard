using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_Owner_DAL : ICommon_DAL<SPIS_Owner_obj>
    {
        IList<SPIS_Owner_obj> GetOwnerList(string inProject, string inTop, Guid PreHistoryId);
        IList<SPIS_Owner_obj> GetOwnerList(string inProject, string inTop);
        IList<SPIS_Owner_obj> GetOwnerList(string inProject);
    }
}
