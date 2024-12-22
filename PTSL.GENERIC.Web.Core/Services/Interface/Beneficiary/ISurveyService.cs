using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.DashBoard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface ISurveyService
    {
        (ExecutionState executionState, List<SurveyVM> entity, string message) List();
        (ExecutionState executionState, SurveyVM entity, string message) Create(SurveyVM model);
        (ExecutionState executionState, SurveyVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SurveyVM entity, string message) Update(SurveyVM model);
        (ExecutionState executionState, SurveyVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, PaginationResutlVM<SurveyEssentialVM> entity, string message) GetBeneficiaryByFilter(BeneficiaryFilterVM filter);
        (ExecutionState executionState, List<SurveyVM> entity, string message) GetBeneficiaryByFcvVcfId(long id);
        (ExecutionState executionState, List<HouseholdMemberVM> entity, string message) LoadMembers(long id);
        (ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message) LoadVulnerabilitySituation(long id);
        (ExecutionState executionState, List<FoodSecurityItemVM> entity, string message) LoadFoodSecurityItem(long id);
        (ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message) LoadAnnualHouseholdExpenditure(long id);
        (ExecutionState executionState, List<ExistingSkillVM> entity, string message) LoadExistingSkill(long id);
        (ExecutionState executionState, List<LandOccupancyVM> entity, string message) LoadLandOccupancy(long id);
        (ExecutionState executionState, List<LiveStockVM> entity, string message) LoadLiveStock(long id);
        (ExecutionState executionState, List<AssetVM> entity, string message) LoadAsset(long id);
        (ExecutionState executionState, List<ImmovableAssetVM> entity, string message) LoadImmovableAsset(long id);
        (ExecutionState executionState, List<EnergyUseVM> entity, string message) LoadEnergyUse(long id);
        (ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message) LoadGrossMarginIncomeAndCostStatus(long id);
        (ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message) LoadManualPhysicalWork(long id);
        (ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message) LoadNaturalResourcesIncomeAndCostStatus(long id);
        (ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message) LoadOtherIncomeSource(long id);
        (ExecutionState executionState, List<BusinessVM> entity, string message) LoadBusiness(long id);
        (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) ListLatest(int take = 50);
        (ExecutionState executionState, SurveyVM entity, string message) GetDetailsById(long id);
        (ExecutionState executionState, SurveyChildsVM? entity, string message) LoadAllChilds(long id);
        (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) ListNotHasAccountIncluding(ForestCivilLocationFilter filter, long? surveyId = null);
        (ExecutionState executionState, bool entity, string message) PendingStatus(long surveyId);
        (ExecutionState executionState, bool entity, string message) ApproveStatus(long surveyId);
        (ExecutionState executionState, bool entity, string message) RejectStatus(long surveyId);
        (ExecutionState executionState, bool entity, string message) Deactivate(long surveyId);
        (ExecutionState executionState, bool entity, string message) Activate(long surveyId);
    }
}
