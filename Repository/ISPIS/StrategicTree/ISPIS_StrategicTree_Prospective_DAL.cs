using DAl.ICommon;
using SPIS;
using System;
using System.Collections.Generic;

namespace Business.Repository.ISPIS
{
    public interface ISPIS_StrategicTree_Prospective_DAL : ICommon_DAL<SPIS_StrategicTree_Prospective_obj>
    {
        IList<SPIS_StrategicTree_Prospective_obj> Get_ItemList(Guid? StrategicTree_Id, Guid? Prospective_Id, decimal? WeightFactor, string Top);
        SPIS_StrategicTree_Prospective_obj Get_Item(Guid? StrategicTree_Id, Guid? Prospective_Id);
        bool UpdateItem(SPIS_StrategicTree_Prospective_obj inEditedItem, string StrategicTree_Id, string Prospective_Id);
        bool DeleteItem(string StrategicTree_Prospective, string Prospective_Id);
    }
}
