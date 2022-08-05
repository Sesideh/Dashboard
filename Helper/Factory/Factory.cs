using Business.ISPIS.IServices;
using Business.Mapper.Base;
using Business.Mapper.SPIS.Base;
using Business.Mapper.SPIS.KPI;
using Business.Mapper.SPIS.Program;
using Business.Mapper.SPIS.StrategicTree;
using Business.Repository.ISPIS;
using Business.SPIS.Services;
using Helper.Factory;
using System;

namespace Business
{
    public class Factory : IFactory ,IDisposable
    {
        #region Private Properties

        private bool disposed = false;
        private ISPIS_Company_DAL _Company_DAL;
        private ISPIS_DataType_DAL _DataType_DAL;
        private ISPIS_KPI_Analyze_DAL _KPI_Analyze_DAL;
        private ISPIS_KPI_DAL _KPI_DAL;
        private ISPIS_KPI_Program_DAL _KPI_Program_DAL;
        private ISPIS_KPI_Progress_DAL _KPI_Progress_DAL;
        private ISPIS_KPI_Status_DAL _KPI_Status_DAL;
        private ISPIS_Owner_DAL _Owner_DAL;
        private ISPIS_Prespective_DAL _Prespective_DAL;
        private ISPIS_Program_DAL _Program_DAL;
        private ISPIS_Program_Status_DAL _Program_Status_DAL;
        private ISPIS_ProgramProgress_DAL _ProgramProgress_DAL;
        private ISPIS_StrategicTree_Status_DAL _StrategicTree_Status_DAL;
        private ISPIS_StrategicTree_KPI_DAL _StrategicTree_KPI_DAL;
        private ISPIS_StrategicTree_Prospective_DAL _StrategicTree_Prospective_DAL;
        private ISPIS_StrategicTreeHistory_DAL _StrategicTreeHistory_DAL;
        private ISPIS_StrategicTreeProgress_DAL _StrategicTreeProgress_DAL;
        private ISPIS_StrategicTree_DAL _StrategicTree_DAL;

        private ISPIS_KPI_Service _KPI_Service;
        private ISPIS_StrategicTree_Service _StrategicTree_Service;

        #endregion

        #region Public Methods

        public ISPIS_Company_DAL Company_DAL => _Company_DAL ?? (_Company_DAL = new SPIS_Company_DAL(new Company_Mapper()));

        public ISPIS_DataType_DAL DataType_DAL => _DataType_DAL ?? (_DataType_DAL = new SPIS_DataType_DAL(new DataType_Mapper()));

        public ISPIS_KPI_Analyze_DAL KPI_Analyze_DAL => _KPI_Analyze_DAL ?? (_KPI_Analyze_DAL = new SPIS_KPI_Analyze_DAL(new KPI_Analyze_Mapper()));

        public ISPIS_KPI_DAL KPI_DAL => _KPI_DAL ?? (_KPI_DAL = new SPIS_KPI_DAL(new KPI_Mapper()));

        public ISPIS_KPI_Program_DAL KPI_Program_DAL => _KPI_Program_DAL ?? (_KPI_Program_DAL = new SPIS_KPI_Program_DAL(new KPI_Program_Mappper()));

        public ISPIS_KPI_Progress_DAL KPI_Progress_DAL => _KPI_Progress_DAL ?? (_KPI_Progress_DAL = new SPIS_KPI_Progress_DAL(new KPI_Progress_Mapper()));

        public ISPIS_KPI_Status_DAL KPI_Status_DAL => _KPI_Status_DAL ?? (_KPI_Status_DAL = new SPIS_KPI_Status_DAL(new KPI_Status_Mapper()));

        public ISPIS_Owner_DAL Owner_DAL => _Owner_DAL ?? (_Owner_DAL = new SPIS_Owner_DAL(new Owner_Mapper()));

        public ISPIS_Prespective_DAL Prespective_DAL => _Prespective_DAL ?? (_Prespective_DAL = new SPIS_Prespective_DAL(new Prespective_Mapper()));

        public ISPIS_Program_DAL Program_DAL => _Program_DAL ?? (_Program_DAL = new SPIS_Program_DAL(new Program_Mapper()));

        public ISPIS_Program_Status_DAL Program_Status_DAL => _Program_Status_DAL ?? (_Program_Status_DAL = new SPIS_Program_Status_DAL(new Program_Status_Mapper()));

        public ISPIS_ProgramProgress_DAL ProgramProgress_DAL => _ProgramProgress_DAL ?? (_ProgramProgress_DAL = new SPIS_ProgramProgress_DAL(new ProgramProgress_Mapper()));

        public ISPIS_StrategicTree_Status_DAL StrategicTree_Status_DAL => _StrategicTree_Status_DAL ?? (_StrategicTree_Status_DAL = new SPIS_StrategicTree_Status_DAL(new StrategicTree_Status_Mapper()));

        public ISPIS_StrategicTree_KPI_DAL StrategicTree_KPI_DAL => _StrategicTree_KPI_DAL ?? (_StrategicTree_KPI_DAL = new SPIS_StrategicTree_KPI_DAL(new StrategicTree_KPI_Mapper()));

        public ISPIS_StrategicTree_Prospective_DAL StrategicTree_Prospective_DAL => _StrategicTree_Prospective_DAL ?? (_StrategicTree_Prospective_DAL = new SPIS_StrategicTree_Prospective_DAL(new StrategicTree_Prospective_Mapper()));

        public ISPIS_StrategicTreeHistory_DAL StrategicTreeHistory_DAL => _StrategicTreeHistory_DAL ?? (_StrategicTreeHistory_DAL = new SPIS_StrategicTreeHistory_DAL(new StrategicTreeHistory_Mapper()));

        public ISPIS_StrategicTreeProgress_DAL StrategicTreeProgress_DAL => _StrategicTreeProgress_DAL ?? (_StrategicTreeProgress_DAL = new SPIS_StrategicTreeProgress_DAL(new StrategicTreeProgress_Mapper()));

        public ISPIS_StrategicTree_DAL StrategicTree_DAL => _StrategicTree_DAL ?? (_StrategicTree_DAL = new SPIS_StrategicTree_DAL(new StrategicTree_Mapper()));


        public ISPIS_KPI_Service KPI_Service => _KPI_Service ?? (_KPI_Service = new SPIS_KPI_Service(new KPI_Mapper()));
        public ISPIS_StrategicTree_Service StrategicTree_Service => _StrategicTree_Service ?? (_StrategicTree_Service = new SPIS_StrategicTree_Service(new StrategicTree_Mapper()));

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
