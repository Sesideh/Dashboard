using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_KPI_DAL : ICommon_DAL<SPIS_KPI_obj>
    {
        SPIS_KPI_obj GetObject(string KPIName, Guid historyId);
        Color GetRowColor(decimal Prcentage);
        IList<SPIS_KPI_obj> GetKPIList_ByOwnerId(Guid inOwnerId, Guid inHistoryId);
        IList<SPIS_KPI_obj> GetKPIList_ByOwnerOrder(int inOwner, Guid inHistoryId);
        IList<SPIS_KPI_obj> GetKPIList();
    }
}
