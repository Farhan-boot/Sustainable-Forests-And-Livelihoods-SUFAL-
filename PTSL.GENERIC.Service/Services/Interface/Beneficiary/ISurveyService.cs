using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public interface ISurveyService : IBaseService<SurveyVM, Survey>
    {
        Task<(ExecutionState executionState, IList<SurveyVM> entity, string message)> GetBeneficiaryByFcvVcf(long fcvVcfId);
        Task<(ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message)> GetBeneficiaryByFilter(BeneficiaryFilterVM filterData);
        Task<(ExecutionState executionState, SurveyVM entity, string message)> GetDetailsAsync(long key);
        Task<(ExecutionState executionState, SurveyChildsVM entity, string message)> LoadAllChilds(long surveyId);
        Task<(ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message)> LoadAnnualHouseholdExpenditure(long surveyId);
        Task<(ExecutionState executionState, List<AssetVM> entity, string message)> LoadAsset(long surveyId);
        Task<(ExecutionState executionState, List<BusinessVM> entity, string message)> LoadBusiness(long surveyId);
        Task<(ExecutionState executionState, EconomicStatusModelVM entity, string message)> LoadEconomicStatus(long surveyId);
        Task<(ExecutionState executionState, List<EnergyUseVM> entity, string message)> LoadEnergyUse(long surveyId);
        Task<(ExecutionState executionState, List<ExistingSkillVM> entity, string message)> LoadExistingSkill(long surveyId);
        Task<(ExecutionState executionState, List<FoodSecurityItemVM> entity, string message)> LoadFoodSecurityItem(long surveyId);
        Task<(ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message)> LoadGrossMarginIncomeAndCostStatus(long surveyId);
        Task<(ExecutionState executionState, List<ImmovableAssetVM> entity, string message)> LoadImmovableAsset(long surveyId);
        Task<(ExecutionState executionState, List<LandOccupancyVM> entity, string message)> LoadLandOccupancy(long surveyId);
        Task<(ExecutionState executionState, List<LiveStockVM> entity, string message)> LoadLiveStock(long surveyId);
        Task<(ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message)> LoadManualPhysicalWork(long surveyId);
        Task<(ExecutionState executionState, List<HouseholdMemberVM> entity, string message)> LoadMembers(long surveyId);
        Task<(ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message)> LoadNaturalResourcesIncomeAndCostStatus(long surveyId);
        Task<(ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message)> LoadOtherIncomeSource(long surveyId);
        Task<(ExecutionState executionState, SocioEconomicStatusModelVM entity, string message)> LoadSocioEconomicStatus(long surveyId);
        Task<(ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message)> LoadVulnerabilitySituation(long surveyId);
        Task<(ExecutionState executionState, SurveyDashboardVM entity, string message)> BeneficiaryDashboardData(long? surveyId);
        Task<(ExecutionState executionState, SurveyVM entity, string message)> GetByIdWithChilds(long surveyId);
        Task<(ExecutionState executionState, bool entity, string message)> Deactivate(long surveyId, long deactivatedBy);
        Task<(ExecutionState executionState, bool entity, string message)> Activate(long surveyId, long activatedBy);
    }
}
