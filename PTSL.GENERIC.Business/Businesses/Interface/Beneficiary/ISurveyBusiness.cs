using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Dashboard;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface ISurveyBusiness : IBaseBusiness<Survey>
    {
        Task<(ExecutionState executionState, bool entity, string message)> ApproveStatus(long surveyId, long approvedByUserId);
        Task<(ExecutionState executionState, bool entity, string message)> RejectStatus(long surveyId, long rejectedByUserId);
        Task<(ExecutionState executionState, SurveyDashboard entity, string message)> BeneficiaryDashboardData(long? surveyId);
        Task<(ExecutionState executionState, SurveyDropdownLocation entity, string message)> DropdownLocation();
        Task<(ExecutionState executionState, SurveyDropdownOthers entity, string message)> DropdownOthers();
        Task<(ExecutionState executionState, IQueryable<Survey> entity, string message)> GetBeneficiaryByFcvVcf(long fcvVcfId);
        Task<(ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message)> GetBeneficiaryByFilter(BeneficiaryFilterVM filterData);
        Task<(ExecutionState executionState, Survey? entity, string message)> GetByIdWithChilds(long surveyId);
        Task<(ExecutionState executionState, Survey entity, string message)> GetDetailsAsync(long key);
        Task<(ExecutionState executionState, BeneficiaryVM entity, string message)> GetTotalBeneficiary(ForestCivilLocationFilter filter);
        Task<(ExecutionState executionState, IList<SurveyEssentialVM> entity, string message)> ListLatest(int take = 50);
        Task<(ExecutionState executionState, IList<SurveyEssentialVM> entity, string message)> ListNotHasAccountIncluding(ForestCivilLocationFilter filter, long? surveyId);
        Task<(ExecutionState executionState, SurveyChilds entity, string message)> LoadAllChilds(long surveyId);
        Task<(ExecutionState executionState, IQueryable<AnnualHouseholdExpenditure> entity, string message)> LoadAnnualHouseholdExpenditure(long surveyId);
        Task<(ExecutionState executionState, IQueryable<Asset> entity, string message)> LoadAsset(long surveyId);
        Task<(ExecutionState executionState, IQueryable<Common.Entity.Beneficiary.Business> entity, string message)> LoadBusiness(long surveyId);
        Task<(ExecutionState executionState, EconomicStatusModel entity, string message)> LoadEconomicStatus(long surveyId);
        Task<(ExecutionState executionState, IQueryable<EnergyUse> entity, string message)> LoadEnergyUse(long surveyId);
        Task<(ExecutionState executionState, IQueryable<ExistingSkill> entity, string message)> LoadExistingSkill(long surveyId);
        Task<(ExecutionState executionState, IQueryable<FoodSecurityItem> entity, string message)> LoadFoodSecurityItem(long surveyId);
        Task<(ExecutionState executionState, IQueryable<GrossMarginIncomeAndCostStatus> entity, string message)> LoadGrossMarginIncomeAndCostStatus(long surveyId);
        Task<(ExecutionState executionState, IQueryable<ImmovableAsset> entity, string message)> LoadImmovableAsset(long surveyId);
        Task<(ExecutionState executionState, IQueryable<LandOccupancy> entity, string message)> LoadLandOccupancy(long surveyId);
        Task<(ExecutionState executionState, IQueryable<LiveStock> entity, string message)> LoadLiveStock(long surveyId);
        Task<(ExecutionState executionState, IQueryable<ManualPhysicalWork> entity, string message)> LoadManualPhysicalWork(long surveyId);
        Task<(ExecutionState executionState, IQueryable<HouseholdMember> entity, string message)> LoadMembers(long surveyId);
        Task<(ExecutionState executionState, IQueryable<NaturalResourcesIncomeAndCostStatus> entity, string message)> LoadNaturalResourcesIncomeAndCostStatus(long surveyId);
        Task<(ExecutionState executionState, IQueryable<OtherIncomeSource> entity, string message)> LoadOtherIncomeSource(long surveyId);
        Task<(ExecutionState executionState, SocioEconomicStatusModel entity, string message)> LoadSocioEconomicStatus(long surveyId);
        Task<(ExecutionState executionState, IQueryable<VulnerabilitySituation> entity, string message)> LoadVulnerabilitySituation(long surveyId);
        Task<(ExecutionState executionState, bool entity, string message)> PendingStatus(long surveyId, long pendingByUserId);
        Task<(ExecutionState executionState, bool entity, string message)> UploadFiles(
            long surveyId,
            string profileUrl,
            List<SurveyDocument> documents,
            string beneficiaryHouseFrontImageUrl,
            string beneficiaryNidFrontImageUrl,
            string beneficiaryNidBackImageUrl,
            string notesImageUrl);
        Task<(ExecutionState executionState, bool entity, string message)> Activate(long surveyId, long activatedBy);
        Task<(ExecutionState executionState, bool entity, string message)> Deactivate(long surveyId, long deactivatedBy);
    }
}
