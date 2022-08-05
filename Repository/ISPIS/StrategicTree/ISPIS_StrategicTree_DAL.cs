using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_StrategicTree_DAL : ICommon_DAL<SPIS_StrategicTree_obj>
    {
        IList<SPIS_StrategicTree_obj> GetObjectList(string inProject, string inTop, Guid PreHistoryId);
        IList<SPIS_StrategicTree_obj> GetObjectList(Guid inPrespectiveId, Guid inHitoryId);
        Color GetRowColor(decimal Actual);
        SPIS_StrategicTree_obj GetObject(string inTitle, string inHitoryId);
    }
}
