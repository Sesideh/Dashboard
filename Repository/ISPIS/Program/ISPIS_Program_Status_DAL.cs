using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_Program_Status_DAL : ICommon_DAL<SPIS_Program_Status_obj>
    {
        IList<SPIS_Program_Status_obj> GetObjectList(string inProject, Guid inProgram_Id);
    }
}
