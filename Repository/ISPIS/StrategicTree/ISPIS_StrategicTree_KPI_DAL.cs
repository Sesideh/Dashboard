using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_StrategicTree_KPI_DAL : ICommon_DAL<SPIS_StrategicTree_KPI_obj>
    {
        IList<SPIS_StrategicTree_KPI_obj> GetObjectList(Guid? StrategicTree_Id, Guid? KPI_Id, decimal? WeightFactor, string Top, Guid PreHistoryId);
        IList<SPIS_StrategicTree_KPI_obj> GetObjectList(Guid? StrategicTree_Id, Guid? KPI_Id, decimal? WeightFactor, string Top);
        SPIS_StrategicTree_KPI_obj GetObject(Guid? StrategicTree_Id, Guid? KPI_Id);
        SPIS_StrategicTree_KPI_obj GetObject(Guid? KPI_Id);
        bool UpdateObject(SPIS_StrategicTree_KPI_obj inEditedItem, string StrategicTree_Id, string KPI_Id);
        bool DeleteObject(string StrategicTree_KPI, string KPI_Id);
    }
}
