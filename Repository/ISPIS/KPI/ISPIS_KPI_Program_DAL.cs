using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_KPI_Program_DAL : ICommon_DAL<SPIS_KPI_Program_obj>
    {
        IList<SPIS_KPI_Program_obj> GetObjectList(string inProject, Guid inKPI_Id);
        SPIS_KPI_Program_obj GetObject(Guid? Program_Id, Guid? KPI_Id);
        bool UpdateObject(SPIS_KPI_Program_obj inEditedItem, string Program_Id, string KPI_Id);
        bool DeleteObject(string Program_Id, string KPI_Id);
    }
}
