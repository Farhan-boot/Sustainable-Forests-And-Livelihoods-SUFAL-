using EntityFrameworkCore.Triggers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using PTSL.GENERIC.Common.ModelBuilderExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Common.Entity
{
    public class GENERICWriteOnlyCtx : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public GENERICWriteOnlyCtx(DbContextOptions<GENERICWriteOnlyCtx> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public GENERICWriteOnlyCtx()
            : base()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
#endif
        }

        public override EntityEntry Attach(object entity)
        {
            return base.Entry(entity).State == EntityState.Detached
                ? base.Attach(entity)
                : base.Entry(entity);
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            return base.Entry(entity).State == EntityState.Detached
                ? base.Attach(entity)
                : base.Entry(entity);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesWithTriggersAsync(
                    base.SaveChangesAsync,
                    acceptAllChangesOnSuccess: true,
                    cancellationToken: cancellationToken);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            EntityModelBuilderExtensions.ConfigureUser(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRefreshToken(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUserGroup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCategory(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDivision(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDistrict(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUpazilla(modelBuilder);
            EntityModelBuilderExtensions.ConfigureColor(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUserRole(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUserRolePermissionMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccesslist(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccessMapper(modelBuilder);
            EntityModelBuilderExtensions.ConfigureModule(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePmsGroup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureUnion(modelBuilder);
            EntityModelBuilderExtensions.ConfigureFinancialYear(modelBuilder);

            EntityModelBuilderExtensions.ConfigureCip(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCipFile(modelBuilder);

            // Beneficiary
            EntityModelBuilderExtensions.ConfigureForestCircle(modelBuilder);
            EntityModelBuilderExtensions.ConfigureForestDivision(modelBuilder);
            EntityModelBuilderExtensions.ConfigureForestRange(modelBuilder);
            EntityModelBuilderExtensions.ConfigureForestBeat(modelBuilder);
            EntityModelBuilderExtensions.ConfigureFcvVcf(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNgo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNaturalIncomeSourceType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEthnicity(modelBuilder);
            EntityModelBuilderExtensions.ConfigureFoodItem(modelBuilder);
            EntityModelBuilderExtensions.ConfigureFoodSecurityItem(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAssetType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAsset(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEnergyType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEnergyUse(modelBuilder);
            EntityModelBuilderExtensions.ConfigureImmovableAssetType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureImmovableAsset(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLandOccupancy(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLiveStockType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLiveStock(modelBuilder);
            EntityModelBuilderExtensions.ConfigureExistingSkill(modelBuilder);
            EntityModelBuilderExtensions.ConfigureBFDAssociation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOccupation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSafetyNet(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRelationWithHeadHouseHoldType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureBFDAssociationHouseholdMembersMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDisabilityType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDisabilityTypeHouseholdMembersMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureHouseholdMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureExpenditureType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAnnualHouseholdExpenditure(modelBuilder);
            EntityModelBuilderExtensions.ConfigureBusinessIncomeSourceType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureBusiness(modelBuilder);
            EntityModelBuilderExtensions.ConfigureGrossMarginIncomeAndCostStatus(modelBuilder);
            EntityModelBuilderExtensions.ConfigureManualIncomeSourceType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureManualPhysicalWork(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNaturalIncomeSourceType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNaturalResourcesIncomeAndCostStatus(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOtherIncomeSourceType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOtherIncomeSource(modelBuilder);
            EntityModelBuilderExtensions.ConfigureVulnerabilitySituationType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureVulnerabilitySituation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSurvey(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSurveyDocument(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSurveyIncident(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMarketing(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTypeOfHouse(modelBuilder);

            // Capacity
            EntityModelBuilderExtensions.ConfigureTrainingOrganizer(modelBuilder);
            EntityModelBuilderExtensions.ConfigureEventType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommunityTrainingType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommunityTrainingParticipentsMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommunityTrainingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommunityTrainingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommunityTraining(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDepartmentalTrainingType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDepartmentalTrainingParticipentsMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDepartmentalTrainingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDepartmentalTrainingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDepartmentalTraining(modelBuilder);
            //Forest Management
            EntityModelBuilderExtensions.ConfigureOtherCommitteeMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureStudent(modelBuilder);

            // Labour
            EntityModelBuilderExtensions.ConfigureOtherLabourMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLabourDatabase(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLabourWork(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLabourDatabaseFile(modelBuilder);

            // Trade
            EntityModelBuilderExtensions.ConfigureTrade(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommitteeDesignation(modelBuilder);

            // Meeting
            EntityModelBuilderExtensions.ConfigureMeetingType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMeetingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMeetingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMeeting(modelBuilder);
            EntityModelBuilderExtensions.ConfigureMeetingParticipantsMap(modelBuilder);

            // Transaction
            EntityModelBuilderExtensions.ConfigureFundType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTransaction(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTransactionFiles(modelBuilder);
            EntityModelBuilderExtensions.ConfigureExpenseDetailsForCDF(modelBuilder);

            // BeneficiarySavingsAccount
            EntityModelBuilderExtensions.ConfigureSavingsAccount(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSavingsAmountInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureWithdrawAmountInformation(modelBuilder);

            // New AIG
            EntityModelBuilderExtensions.ConfigureFirstSixtyPercentageLDF(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSecondFourtyPercentageLDF(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAIGBasicInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRepaymentLDF(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRepaymentLDFFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLDFProgress(modelBuilder);
            EntityModelBuilderExtensions.ConfigureIndividualLDFInfoForm(modelBuilder);
            EntityModelBuilderExtensions.ConfigureGroupLDFInfoForm(modelBuilder);
            EntityModelBuilderExtensions.ConfigureGroupLDFInfoFormMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureIndividualGroupFormSetup(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRepaymentLDFHistory(modelBuilder);

            // Patrolling
            EntityModelBuilderExtensions.ConfigurePatrollingScheduleInformetion(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePatrollingPaymentInformetion(modelBuilder);
            EntityModelBuilderExtensions.ConfigureOtherPatrollingMember(modelBuilder);

            //InternalLoan
            EntityModelBuilderExtensions.ConfigureInternalLoanInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRepaymentInternalLoan(modelBuilder);

            // PatrollingScheduling
            EntityModelBuilderExtensions.ConfigurePatrollingSchedulingParticipentsMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePatrollingSchedulingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePatrollingSchedulingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePatrollingScheduling(modelBuilder);
            EntityModelBuilderExtensions.ConfigureInternalLoanInformationFile(modelBuilder);

            // Committee Management
            EntityModelBuilderExtensions.ConfigureCommitteeManagement(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommitteeManagementMember(modelBuilder);

            // Archive
            EntityModelBuilderExtensions.ConfigureRegistrationArchive(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRegistrationArchiveFile(modelBuilder);

            // NecessaryLinkManagement
            EntityModelBuilderExtensions.ConfigureNecessaryLink(modelBuilder);

            // Committee Configuration
            EntityModelBuilderExtensions.ConfigureCommitteeTypeConfiguration(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommitteesConfiguration(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCommitteeDesignationsConfiguration(modelBuilder);

            // PermissionSettings
            EntityModelBuilderExtensions.ConfigurePermissionHeaderSettings(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePermissionRowSettings(modelBuilder);

            // Account Management
            EntityModelBuilderExtensions.ConfigureAccount(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccountDeposit(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccountTransfer(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccountTransferApproval(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccountTransferDetails(modelBuilder);
            EntityModelBuilderExtensions.ConfigureAccountTransferLog(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSourceOfFund(modelBuilder);

            // Configure Approval Log For CFM
            EntityModelBuilderExtensions.ConfigureApprovalLogForCfm(modelBuilder);

            // Map To Account into User Log
            EntityModelBuilderExtensions.ConfigureAccountsUserTagLog(modelBuilder);

            // BeneficiarySubmissionHistory
            EntityModelBuilderExtensions.ConfigureBeneficiarySubmissionHistory(modelBuilder);

            //Bank Accounts Information
            EntityModelBuilderExtensions.ConfigureBankAccountsInformation(modelBuilder);

            //Social Forestry Training
            EntityModelBuilderExtensions.ConfigureEventTypeForTraining(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainerDesignationForTraining(modelBuilder);
            EntityModelBuilderExtensions.ConfigureTrainingOrganizerForTraining(modelBuilder);
            EntityModelBuilderExtensions.ConfigureFinancialYearForTraining(modelBuilder);
            //Social Forestry Training(Training Main)
            EntityModelBuilderExtensions.ConfigureSocialForestryTraining(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryTrainingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryTrainingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryTrainingParticipentsMap(modelBuilder);

            //Social Forestry Meeting
            EntityModelBuilderExtensions.ConfigureMeetingTypeForSocialForestryMeeting(modelBuilder);
            //Social Forestry Meeting(Meeting Main)
            EntityModelBuilderExtensions.ConfigureSocialForestryMeeting(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryMeetingFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryMeetingMember(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryMeetingParticipentsMap(modelBuilder);

            #region Social Forestry

            EntityModelBuilderExtensions.ConfigureConcernedOfficial(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCostInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCostInformationFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureCostType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureInspectionDetails(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLaborCostType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLaborInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLaborInformationFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLandOwningAgency(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNewRaisedPlantation(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationCauseOfDamage(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationDamageInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationFile(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationPlant(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationSocialForestryBeneficiaryMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationTopography(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationType(modelBuilder);
            EntityModelBuilderExtensions.ConfigurePlantationUnit(modelBuilder);
            EntityModelBuilderExtensions.ConfigureProjectType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryBeneficiary(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryDesignation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureSocialForestryNgo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureZoneOrArea(modelBuilder);

            EntityModelBuilderExtensions.ConfigureNurseryType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNurseryRaisingSector(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNurseryRaisedSeedlingInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNurseryInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNurseryCostInformation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureNurseryCostInformationFile(modelBuilder);

            EntityModelBuilderExtensions.ConfigureNurseryDistribution(modelBuilder);
            EntityModelBuilderExtensions.ConfigureConcernedOfficialMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureInspectionDetailsMap(modelBuilder);


            EntityModelBuilderExtensions.ConfigureCuttingPlantation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureLotWiseSellingInformation(modelBuilder);

            EntityModelBuilderExtensions.ConfigureReplantation(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationCostInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationInspectionMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationLaborInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationNurseryInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationSocialForestryBeneficiaryMap(modelBuilder);
            EntityModelBuilderExtensions.ConfigureReplantationDamageInfo(modelBuilder);
            EntityModelBuilderExtensions.ConfigureRealization(modelBuilder);

            EntityModelBuilderExtensions.ConfigureDistributedToBeneficiary(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDistributionFundType(modelBuilder);
            EntityModelBuilderExtensions.ConfigureDistributionPercentage(modelBuilder);
            EntityModelBuilderExtensions.ConfigureShareDistribution(modelBuilder);

            #endregion
        }
    }
}
