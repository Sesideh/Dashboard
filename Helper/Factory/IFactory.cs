using Business.ISPIS.IServices;
using Business.Repository.ISPIS;

namespace Helper.Factory
{
    public interface IFactory
    {
        ISPIS_Company_DAL Company_DAL { get; }
        ISPIS_DataType_DAL DataType_DAL { get; }
        ISPIS_KPI_Analyze_DAL KPI_Analyze_DAL { get; }
        ISPIS_KPI_DAL KPI_DAL { get; }
        ISPIS_StrategicTree_DAL StrategicTree_DAL { get; }
        ISPIS_KPI_Program_DAL KPI_Program_DAL { get; }
        ISPIS_KPI_Progress_DAL KPI_Progress_DAL { get; }
        ISPIS_KPI_Status_DAL KPI_Status_DAL { get; }
        ISPIS_Owner_DAL Owner_DAL { get; }
        ISPIS_Prespective_DAL Prespective_DAL { get; }
        ISPIS_Program_DAL Program_DAL { get; }
        ISPIS_Program_Status_DAL Program_Status_DAL { get; }
        ISPIS_ProgramProgress_DAL ProgramProgress_DAL { get; }
        ISPIS_StrategicTree_Status_DAL StrategicTree_Status_DAL { get; }
        ISPIS_StrategicTree_KPI_DAL StrategicTree_KPI_DAL { get; }
        ISPIS_StrategicTree_Prospective_DAL StrategicTree_Prospective_DAL { get; }
        ISPIS_StrategicTreeHistory_DAL StrategicTreeHistory_DAL { get; }
        ISPIS_StrategicTreeProgress_DAL StrategicTreeProgress_DAL { get; }

        ISPIS_KPI_Service KPI_Service { get; }
        ISPIS_StrategicTree_Service StrategicTree_Service { get; }
    }
}
