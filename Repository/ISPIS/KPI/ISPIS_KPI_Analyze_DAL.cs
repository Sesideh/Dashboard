using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_KPI_Analyze_DAL : ICommon_DAL<SPIS_KPI_Analyze_obj>
    {
        IList<SPIS_KPI_Analyze_obj> GetObjectList(string inProject, Guid inKPI_Id);
    }
}
