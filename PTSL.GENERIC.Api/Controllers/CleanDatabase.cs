using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.TransactionMangement;

namespace PTSL.GENERIC.Api.Controllers
{
    public class CleanDatabase : ControllerBase
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public CleanDatabase(GENERICWriteOnlyCtx writeOnlyCtx)
        {
            _writeOnlyCtx = writeOnlyCtx;
        }

        [HttpGet("/clean-beneficiary")]
        public async Task<IActionResult> CleanBeneficiaries()
        {
            #region Beneficiary
            await _writeOnlyCtx.Set<AnnualHouseholdExpenditure>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Asset>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<BFDAssociationHouseholdMembersMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Common.Entity.Beneficiary.Business>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<DisabilityTypeHouseholdMembersMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<EnergyUse>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<ExistingSkill>().IgnoreQueryFilters().ExecuteDeleteAsync();

            await _writeOnlyCtx.Set<FoodSecurityItem>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<GrossMarginIncomeAndCostStatus>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<HouseholdMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LandOccupancy>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LiveStock>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<ManualPhysicalWork>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<NaturalResourcesIncomeAndCostStatus>().IgnoreQueryFilters().ExecuteDeleteAsync();

            await _writeOnlyCtx.Set<OtherIncomeSource>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SurveyDocument>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SurveyIncident>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<VulnerabilitySituation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Survey>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            return Ok();
        }

        [HttpGet("/clean-without-general-setup")]
        public async Task<IActionResult> CleanWithoutGeneralSetup()
        {
            #region Clean AIG
            await _writeOnlyCtx.Set<LDFProgress>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<RepaymentLDFFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<RepaymentLDFHistory>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<RepaymentLDF>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<FirstSixtyPercentageLDF>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SecondFourtyPercentageLDF>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<AIGBasicInformation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<IndividualLDFInfoForm>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<GroupLDFInfoFormMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<GroupLDFInfoForm>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Internal Loan
            await _writeOnlyCtx.Set<InternalLoanInformationFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<RepaymentInternalLoan>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<InternalLoanInformation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Meeting
            await _writeOnlyCtx.Set<MeetingParticipantsMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<MeetingFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<MeetingMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Meeting>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Community Training
            await _writeOnlyCtx.Set<CommunityTrainingParticipentsMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CommunityTrainingFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CommunityTrainingMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CommunityTraining>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Patrolling Schedule
            await _writeOnlyCtx.Set<PatrollingSchedulingParticipentsMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<PatrollingSchedulingMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<PatrollingSchedulingFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<PatrollingPaymentInformetion>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<PatrollingScheduleInformetion>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<PatrollingScheduling>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Labour
            await _writeOnlyCtx.Set<LabourDatabaseFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LabourWork>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LabourDatabase>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<OtherLabourMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Transaction
            await _writeOnlyCtx.Set<TransactionFiles>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<ExpenseDetailsForCDF>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Transaction>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Savings
            await _writeOnlyCtx.Set<WithdrawAmountInformation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SavingsAmountInformation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SavingsAccount>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Cip
            await _writeOnlyCtx.Set<CipTeamMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CipTeam>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CipFile>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Cip>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Committee
            await _writeOnlyCtx.Set<CommitteeManagementMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<OtherCommitteeMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<CommitteeManagement>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            #region Beneficiary
            await _writeOnlyCtx.Set<AnnualHouseholdExpenditure>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Asset>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<BFDAssociationHouseholdMembersMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Common.Entity.Beneficiary.Business>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<DisabilityTypeHouseholdMembersMap>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<EnergyUse>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<ExistingSkill>().IgnoreQueryFilters().ExecuteDeleteAsync();

            await _writeOnlyCtx.Set<FoodSecurityItem>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<GrossMarginIncomeAndCostStatus>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<HouseholdMember>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LandOccupancy>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<LiveStock>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<ManualPhysicalWork>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<NaturalResourcesIncomeAndCostStatus>().IgnoreQueryFilters().ExecuteDeleteAsync();

            await _writeOnlyCtx.Set<OtherIncomeSource>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SurveyDocument>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<SurveyIncident>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<VulnerabilitySituation>().IgnoreQueryFilters().ExecuteDeleteAsync();
            await _writeOnlyCtx.Set<Survey>().IgnoreQueryFilters().ExecuteDeleteAsync();
            #endregion

            return Ok();
        }
    }
}
