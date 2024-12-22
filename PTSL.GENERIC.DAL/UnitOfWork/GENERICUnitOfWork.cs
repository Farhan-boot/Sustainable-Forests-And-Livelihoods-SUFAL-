using Microsoft.EntityFrameworkCore.Storage;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.Students;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.Repositories.Implementation.AccountManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.ForestManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.Labour;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface;
using PTSL.GENERIC.DAL.Repositories.Interface.AccountManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.ApprovalLog;
using PTSL.GENERIC.DAL.Repositories.Interface.Archive;
using PTSL.GENERIC.DAL.Repositories.Interface.Beneficiary;
using PTSL.GENERIC.DAL.Repositories.Interface.Capacity;
using PTSL.GENERIC.DAL.Repositories.Interface.CipManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.ForestManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.GeneralSetup;
using PTSL.GENERIC.DAL.Repositories.Interface.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Interface.Labour;
using PTSL.GENERIC.DAL.Repositories.Interface.NecessaryLinkManagement;
using PTSL.GENERIC.DAL.Repositories.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.Repositories.Interface.PermissionSettings;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.DAL.Repositories.Interface.TransactionMangement;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.DAL.UnitOfWork
{
    public class GENERICUnitOfWork : IGENERICUnitOfWork
    {
        private GENERICWriteOnlyCtx WriteOnlyCtx { get; }
        private GENERICReadOnlyCtx ReadOnlyCtx { get; }

        public IUserRepository users { get; set; }
        public IUserGroupRepository usergroups { get; set; }
        public ICategoryRepository Categoriess { get; set; }
        public IDistrictRepository Districts { get; set; }
        public IDivisionRepository Divisions { get; set; }
        public IUpazillaRepository UpazillaRepo { get; set; }
        public IColorRepository Color { get; set; }
        public IUserRoleRepository UserRoles { get; set; }
        public IAccesslistRepository Accesslist { get; set; }
        public IAccessMapperRepository AccessMapper { get; set; }
        public IModuleRepository Module { get; set; }
        public IPmsGroupRepository PmsGroup { get; set; }
        public IUnionRepository UnionRepo { get; set; }
        public IFinancialYearRepository FinancialYearRepo { get; set; }


        public ICipRepository CipRepository { get; set; }
        public ICipFileRepository CipFileRepository { get; set; }

        // Beneficiary
        public IForestCircleRepository ForestCircleRepo { get; set; }
        public IForestBeatRepository ForestBeatRepo { get; set; }
        public IForestDivisionRepository ForestDivisionRepo { get; set; }
        public IForestFcvVcfRepository ForestFcvVcfRepo { get; set; }
        public IForestRangeRepository ForestRangeRepo { get; set; }
        public IExistingSkillRepository ExistingSkillRepo { get; set; }
        public IAssetRepository AssetRepo { get; set; }
        public IAssetTypeRepository AssetTypeRepo { get; set; }
        public IEnergyTypeRepository EnergyTypeRepo { get; set; }
        public IEnergyUseRepository EnergyUseRepo { get; set; }
        public IImmovableAssetRepository ImmovableAssetRepo { get; set; }
        public IImmovableAssetTypeRepository ImmovableAssetTypeRepo { get; set; }
        public ILandOccupancyRepository LandOccupancyRepo { get; set; }
        public ILiveStockRepository LiveStockRepo { get; set; }
        public ILiveStockTypeRepository LiveStockTypeRepo { get; set; }
        public IFoodItemRepository FoodItemRepo { get; set; }
        public IFoodSecurityItemRepository FoodSecurityItemRepo { get; set; }
        public IBFDAssociationRepository BFDAssociationRepo { get; set; }
        public IDisabilityTypeRepository DisabilityTypeRepo { get; set; }
        public IHouseholdMemberRepository HouseholdMemberRepo { get; set; }
        public IOccupationRepository OccupationRepo { get; set; }
        public IRelationWithHeadHouseHoldTypeRepository RelationWithHeadHouseHoldTypeRepo { get; set; }
        public ISafetyNetRepository SafetyNetRepo { get; set; }
        public IBFDAssociationHouseholdMembersMapRepository BFDAssociationHouseholdMembersMapRepo { get; set; }
        public IDisabilityTypeHouseholdMembersMapRepository DisabilityTypeHouseholdMembersMapRepo { get; set; }
        public IAnnualHouseholdExpenditureRepository AnnualHouseholdExpenditureRepo { get; set; }
        public IExpenditureTypeRepository ExpenditureTypeRepo { get; set; }
        public IBusinessRepository BusinessRepo { get; set; }
        public IBusinessIncomeSourceTypeRepository BusinessIncomeSourceTypeRepo { get; set; }
        public IGrossMarginIncomeAndCostStatusRepository GrossMarginIncomeAndCostStatusRepo { get; set; }
        public IManualIncomeSourceTypeRepository ManualIncomeSourceTypeRepo { get; set; }
        public IManualPhysicalWorkRepository ManualPhysicalWorkRepo { get; set; }
        public INaturalIncomeSourceTypeRepository NaturalIncomeSourceTypeRepo { get; set; }
        public INaturalResourcesIncomeAndCostStatusRepository NaturalResourcesIncomeAndCostStatusRepo { get; set; }
        public IOtherIncomeSourceRepository OtherIncomeSourceRepo { get; set; }
        public IOtherIncomeSourceTypeRepository OtherIncomeSourceTypeRepo { get; set; }
        public IVulnerabilitySituationRepository VulnerabilitySituationRepo { get; set; }
        public IVulnerabilitySituationTypeRepository VulnerabilitySituationTypeRepo { get; set; }
        public IEthnicityRepository EthnicityRepo { get; set; }
        public INgoRepository NgoRepo { get; set; }
        public ISurveyRepository SurveyRepo { get; set; }
        public ISurveyIncidentRepository SurveyIncidentRepo { get; set; }
        public ITypeOfHouseRepository TypeOfHouseRepository { get; set; }

        public IMarketingRepository MarketingRepo { get; set; }

        // Capacity
        public ICommunityTrainingMemberRepository CommunityTrainingMemberRepo { get; set; }
        public ICommunityTrainingParticipentsMapRepository CommunityTrainingParticipentsMapRepo { get; set; }
        public ICommunityTrainingRepository CommunityTrainingRepo { get; set; }
        public ICommunityTrainingTypeRepository CommunityTrainingTypeRepo { get; set; }
        public ICommunityTrainingFileRepository CommunityTrainingFileRepo { get; set; }

        public IDepartmentalTrainingMemberRepository DepartmentalTrainingMemberRepo { get; set; }
        public IDepartmentalTrainingParticipentsMapRepository DepartmentalTrainingParticipentsMapRepo { get; set; }
        public IDepartmentalTrainingRepository DepartmentalTrainingRepo { get; set; }
        public IDepartmentalTrainingTypeRepository DepartmentalTrainingTypeRepo { get; set; }
        public IDepartmentalTrainingFileRepository DepartmentalTrainingFileRepo { get; set; }

        public IEventTypeRepository EventTypeRepo { get; set; }
        public ITrainingOrganizerRepository TrainingOrganizerRepo { get; set; }

        //ForestManagement
        public IOtherCommitteeMemberRepository OtherCommitteeMemberRepo { get; set; }
        public ISubCommitteeDesignationRepository SubCommitteeDesignationRepositoryRepo { get; set; }

        //Student
        public IStudentRepository StudentRepo { get; set; }

        // Labour
        public IOtherLabourMemberRepository OtherLabourMemberRepo { get; set; }
        public ILabourDatabaseRepository LabourDatabaseRepo { get; set; }
        public ILabourWorkRepository LabourWorkRepo { get; set; }
        public ILabourDatabaseFileRepository LabourDatabaseFileRepo { get; set; }

        //Trade
        public ITradeRepository TradeRepo { get; set; }

        // Meeting
        public IMeetingRepository MeetingRepo { get; set; }
        public IMeetingFileRepository MeetingFileRepo { get; set; }
        public IMeetingMemberRepository MeetingMemberRepo { get; set; }
        public IMeetingParticipantsMapRepository MeetingParticipantsMapRepo { get; set; }
        public IMeetingTypeRepository MeetingTypeRepo { get; set; }

        // Transaction
        public ITransactionRepository TransactionRepo { get; set; }
        public ITransactionFilesRepository TransactionFilesRepository { get; set; }
        public IFundTypeRepository FundTypeRepo { get; set; }

        // Beneficiary Savings Account
        public ISavingsAccountRepository SavingsAccountRepo { get; set; }
        public ISavingsAmountInformationRepository SavingsAmountInformationRepo { get; set; }
        public IWithdrawAmountInformationRepository WithdrawAmountInformationRepo { get; set; }

        // New AIG
        public IAIGBasicInformationRepository AIGBasicInformationRepo { get; set; }
        public IRepaymentLDFRepository RepaymentLDFRepo { get; set; }
        public IFirstSixtyPercentageLDFRepository FirstSixtyPercentageLDFRepo { get; set; }
        public ISecondFourtyPercentageLDFRepository SecondFourtyPercentageLDFRepo { get; set; }
        public ILDFProgressRepository LDFProgressRepo { get; set; }
        public IIndividualLDFInfoFormRepository IndividualLDFInfoFormRepository { get; set; }
        public IGroupLDFInfoFormRepository GroupLDFInfoFormRepository { get; set; }
        public IGroupLDFInfoFormMemberRepository GroupLDFInfoFormMemberRepository { get; set; }
        public IIndividualGroupFormSetupRepository IndividualGroupFormSetupRepository { get; set; }
        public IRepaymentLDFHistoryRepository RepaymentLDFHistoryRepository { get; set; }

        public IRepaymentLDFFileRepository RepaymentLDFFileRepository { get; set; }


        // Patrolling
        public IPatrollingScheduleInformetionRepository PatrollingScheduleInformetionRepo { get; set; }
        public IOtherPatrollingMemberRepository OtherPatrollingMemberRepo { get; set; }

        // InternalLoan
        public IInternalLoanInformationRepository InternalLoanInformationRepo { get; set; }
        public IRepaymentInternalLoanRepository RepaymentInternalLoanRepo { get; set; }
        public IInternalLoanInformationFileRepository InternalLoanInformationFileRepo { get; set; }
        public IAccountTransferApprovalRepository AccountTransferApprovalRepository { get; set; }


        // PatrollingSchedulingInformetion
        public IPatrollingSchedulingMemberRepository PatrollingSchedulingMemberRepo { get; set; }
        public IPatrollingSchedulingParticipentsMapRepository PatrollingSchedulingParticipentsMapRepo { get; set; }
        public IPatrollingSchedulingRepository PatrollingSchedulingRepo { get; set; }
        public IPatrollingSchedulingFileRepository PatrollingSchedulingFileRepo { get; set; }

        public ICommitteeManagementRepository CommitteeManagementRepository { get; set; }
        public ICommitteeManagementMemberRepository CommitteeManagementMemberRepository { get; set; }

        public IRegistrationArchiveRepository RegistrationArchiveRepository { get; set; }
        public IRegistrationArchiveFileRepository RegistrationArchiveFileRepository { get; set; }

        // CipManagement
        public ICipTeamRepository CipTeamRepository { get; set; }
        public ICipTeamMemberRepository CipTeamMemberRepository { get; set; }
        public ISurveyDocumentRepository SurveyDocumentRepository { get; set; }


        // NecessaryLinkManagement
        public INecessaryLinkRepository NecessaryLinkRepository { get; set; }

        // CommitteeTypeConfiguration
        public ICommitteeTypeConfigurationRepository CommitteeTypeConfigurationRepository { get; set; }
        public ICommitteesConfigurationRepository CommitteesConfigurationRepository { get; set; }
        public ICommitteeDesignationsConfigurationRepository CommitteeDesignationsConfigurationRepository { get; set; }

        //PermissionSettings
        public IPermissionHeaderSettingsRepository PermissionHeaderSettingsRepository { get; set; }
        public IPermissionRowSettingsRepository PermissionRowSettingsRepository { get; set; }

        //ApprovalLogForCfm
        public IApprovalLogForCfmRepository ApprovalLogForCfmRepository { get; set; }

        //Accounts
        public IAccountsUserTagLogRepository AccountsUserTagLogRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public ISourceOfFundRepository SourceOfFundRepository { get; set; }
        public IAccountTransferRepository AccountTransferRepository { get; set; }
        public IAccountTransferLogRepository AccountTransferLogRepository { get; set; }
        public IAccountDepositRepository AccountDepositRepository { get; set; }


        //Submission History For Mobile
        public IBeneficiarySubmissionHistoryRepository BeneficiarySubmissionHistoryRepository { get; set; }

        //Bank Accounts Information
        public IBankAccountsInformationRepository BankAccountsInformationRepository { get; set; }


        //Social Forestry Training
        public IEventTypeForTrainingRepository EventTypeForTrainingRepository { get; set; }
        public ITrainerDesignationForTrainingRepository TrainerDesignationForTrainingRepository { get; set; }
        public ITrainingOrganizerForTrainingRepository TrainingOrganizerForTrainingRepository { get; set; }
        public IFinancialYearForTrainingRepository FinancialYearForTrainingRepository { get; set; }

        //Social Forestry Training(Main)
        public ISocialForestryTrainingRepository SocialForestryTrainingRepository { get; set; }
        public ISocialForestryTrainingParticipentsMapRepository SocialForestryTrainingParticipentsMapRepository { get; set; }
        public ISocialForestryTrainingFileRepository SocialForestryTrainingFileRepository { get; set; }
        public ISocialForestryTrainingMemberRepository SocialForestryTrainingMemberRepository { get; set; }

        //Social Forestry Meeting
        public IMeetingTypeForSocialForestryMeetingRepository MeetingTypeForSocialForestryMeetingRepository { get; set; }
        //Social Forestry Meeting(Main)

        public ISocialForestryMeetingRepository SocialForestryMeetingRepository { get; set; }
        public ISocialForestryMeetingParticipentsMapRepository SocialForestryMeetingParticipentsMapRepository { get; set; }
        public ISocialForestryMeetingFileRepository SocialForestryMeetingFileRepository { get; set; }
        public ISocialForestryMeetingMemberRepository SocialForestryMeetingMemberRepository { get; set; }

        #region Social Forestry
        public IConcernedOfficialRepository ConcernedOfficialRepository { get; set; }
        public ICostInformationRepository CostInformationRepository { get; set; }
        public ICostInformationFileRepository CostInformationFileRepository { get; set; }
        public ICostTypeRepository CostTypeRepository { get; set; }
        public IInspectionDetailsRepository InspectionDetailsRepository { get; set; }
        public ILaborCostTypeRepository LaborCostTypeRepository { get; set; }
        public ILaborInformationRepository LaborInformationRepository { get; set; }
        public ILaborInformationFileRepository LaborInformationFileRepository { get; set; }
        public ILandOwningAgencyRepository LandOwningAgencyRepository { get; set; }
        public INewRaisedPlantationRepository NewRaisedPlantationRepository { get; set; }
        public IPlantationCauseOfDamageRepository PlantationCauseOfDamageRepository { get; set; }
        public IPlantationDamageInformationRepository PlantationDamageInformationRepository { get; set; }
        public IPlantationFileRepository PlantationFileRepository { get; set; }
        public IPlantationPlantRepository PlantationPlantRepository { get; set; }
        public IPlantationSocialForestryBeneficiaryMapRepository PlantationSocialForestryBeneficiaryMapRepository { get; set; }
        public IPlantationTopographyRepository PlantationTopographyRepository { get; set; }
        public IPlantationTypeRepository PlantationTypeRepository { get; set; }
        public IPlantationUnitRepository PlantationUnitRepository { get; set; }
        public IProjectTypeRepository ProjectTypeRepository { get; set; }
        public ISocialForestryBeneficiaryRepository SocialForestryBeneficiaryRepository { get; set; }
        public ISocialForestryDesignationRepository SocialForestryDesignationRepository { get; set; }
        public ISocialForestryNgoRepository SocialForestryNgoRepository { get; set; }
        public IZoneOrAreaRepository ZoneOrAreaRepository { get; set; }
        public INurseryCostInformationRepository NurseryCostInformationRepository { get; set; }
        public INurseryCostInformationFileRepository NurseryCostInformationFileRepository { get; set; }
        public IDistributedToBeneficiaryRepository DistributedToBeneficiaryRepository { get; set; }
        public IDistributionFundTypeRepository DistributionFundTypeRepository { get; set; }
        public IDistributionPercentageRepository DistributionPercentageRepository { get; set; }
        public IShareDistributionRepository ShareDistributionRepository { get; set; }


        //Nursery

        public INurseryInformationRepository NurseryInformationRepository { get; set; }
        public INurseryRaisedSeedlingInformationRepository NurseryRaisedSeedlingInformationRepository { get; set; }
        public INurseryRaisingSectorRepository NurseryRaisingSectorRepository { get; set; }
        public INurseryTypeRepository NurseryTypeRepository { get; set; }
        public INurseryDistributionRepository NurseryDistributionRepository { get; set; }

        //
        public IReplantationRepository ReplantationRepository { get; set; }
        public IReplantationCostInfoRepository ReplantationCostInfoRepository { get; set; }
        public IReplantationInspectionMapRepository ReplantationInspectionMapRepository { get; set; }
        public IReplantationLaborInfoRepository ReplantationLaborInfoRepository { get; set; }
        public IReplantationNurseryInfoRepository ReplantationNurseryInfoRepository { get; set; }
        public IReplantationSocialForestryBeneficiaryMapRepository ReplantationSocialForestryBeneficiaryMapRepository { get; set; }
        public ICuttingPlantationRepository CuttingPlantationRepository { get; set; }
        public ILotWiseSellingInformationRepository LotWiseSellingInformationRepository { get; set; }
        public IReplantationDamageInfoRepository ReplantationDamageInfoRepository { get; set; }

        public IRealizationRepository RealizationRepository { get; set; }


        #endregion


        public GENERICUnitOfWork(
            GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
            GENERICReadOnlyCtx ecommarceReadOnlyCtx,
            IUserRepository userRepository,
            IUserGroupRepository userGroupRepository,
            ICategoryRepository categoryRepository,
            IDistrictRepository districtRepository,
            IDivisionRepository divisionRepository,
            IUpazillaRepository upazillaRepository,
            IColorRepository colorRepository,
            IUserRoleRepository userRolesRepository,
            IAccesslistRepository accesslistRepository,
            IAccessMapperRepository accessMapperRepository,
            IModuleRepository moduleRepository,
            IPmsGroupRepository pmsGroupRepository,
            IFinancialYearRepository financialYearRepository,

            ICipRepository cipRepository,
            ICipFileRepository cipFileRepository,
            IForestCircleRepository forestCirlceRepository,
            IForestBeatRepository forestBeatRepository,
            IForestDivisionRepository forestDivisionRepository,
            IForestFcvVcfRepository forestFcvVcfRepository,
            IForestRangeRepository forestRangeRepository,
            IExistingSkillRepository existingSkillRepository,
            IAssetRepository assetRepository,
            IAssetTypeRepository assetTypeRepository,
            IEnergyTypeRepository energyTypeRepository,
            IEnergyUseRepository energyUseRepository,
            IImmovableAssetRepository immovableAssetRepository,
            IImmovableAssetTypeRepository immovableAssetTypeRepository,
            ILandOccupancyRepository landOccupancyRepository,
            ILiveStockRepository liveStockRepository,
            ILiveStockTypeRepository liveStockTypeRepository,
            IFoodItemRepository foodItemRepository,
            IFoodSecurityItemRepository foodSecurityItemRepository,
            IBFDAssociationRepository bFDAssociationRepository,
            IDisabilityTypeRepository disabilityTypeRepository,
            IHouseholdMemberRepository householdMemberRepository,
            IOccupationRepository occupationRepository,
            IRelationWithHeadHouseHoldTypeRepository relationWithHeadHouseHoldTypeRepository,
            ISafetyNetRepository safetyNetRepository,
            IBFDAssociationHouseholdMembersMapRepository bFDAssociationHouseholdMembersMapRepository,
            IDisabilityTypeHouseholdMembersMapRepository disabilityTypeHouseholdMembersMapRepository,
            IAnnualHouseholdExpenditureRepository annualHouseholdExpenditureRepository,
            IExpenditureTypeRepository expenditureTypeRepository,
            IBusinessRepository businessRepository,
            IBusinessIncomeSourceTypeRepository businessIncomeSourceTypeRepository,
            IGrossMarginIncomeAndCostStatusRepository grossMarginIncomeAndCostStatusRepository,
            IManualIncomeSourceTypeRepository manualIncomeSourceTypeRepository,
            IManualPhysicalWorkRepository manualPhysicalWorkRepository,
            INaturalIncomeSourceTypeRepository naturalIncomeSourceTypeRepository,
            INaturalResourcesIncomeAndCostStatusRepository naturalResourcesIncomeAndCostStatusRepository,
            IOtherIncomeSourceRepository otherIncomeSourceRepository,
            IOtherIncomeSourceTypeRepository otherIncomeSourceTypeRepository,
            IVulnerabilitySituationRepository vulnerabilitySituationRepository,
            IVulnerabilitySituationTypeRepository vulnerabilitySituationTypeRepository,
            INgoRepository ngoRepository,
            IEthnicityRepository ethnicityRepository,
            ISurveyRepository surveyRepository,
            IMarketingRepository marketingRepository,
            IUnionRepository unionRepository,
            ISurveyIncidentRepository surveyIncidentRepository,
            ITypeOfHouseRepository typeOfHouseRepository,

            ICommunityTrainingMemberRepository communityTrainingMemberRepository,
            ICommunityTrainingParticipentsMapRepository communityTrainingParticipentsMapRepository,
            ICommunityTrainingRepository communityTrainingRepository,
            ICommunityTrainingFileRepository communityTrainingFileRepository,
            ICommunityTrainingTypeRepository communityTrainingTypeRepository,

            IDepartmentalTrainingMemberRepository departmentalTrainingMemberRepository,
            IDepartmentalTrainingParticipentsMapRepository departmentalTrainingParticipentsMapRepository,
            IDepartmentalTrainingRepository departmentalTrainingRepository,
            IDepartmentalTrainingFileRepository departmentalTrainingFileRepository,
            IDepartmentalTrainingTypeRepository departmentalTrainingTypeRepository,
            IEventTypeRepository eventTypeRepository,
            ITrainingOrganizerRepository trainingOrganizerRepository,
              //ForestManagement
              IOtherCommitteeMemberRepository otherCommitteeMemberRepository,
              ISubCommitteeDesignationRepository subCommitteeDesignationRepository,
               //Student
               IStudentRepository studentRepository,

               //Labour
               IOtherLabourMemberRepository otherLabourMemberRepository,
               ILabourDatabaseRepository labourDatabaseRepository,
               ILabourWorkRepository labourWorkRepository,
               ILabourDatabaseFileRepository labourDatabaseFileRepository,
               //Trade
               ITradeRepository tradeRepository,

        // Meeting
        IMeetingRepository meetingRepository,
        IMeetingFileRepository meetingFileRepository,
        IMeetingMemberRepository meetingMemberRepository,
        IMeetingParticipantsMapRepository meetingParticipantsMapRepository,
        IMeetingTypeRepository meetingTypeRepository,

        // Transaction
        ITransactionRepository transactionRepository,
        ITransactionFilesRepository transactionFilesRepository,
        IFundTypeRepository fundTypeRepository,

        //Beneficiary Savings Account
        ISavingsAccountRepository savingsAccountRepository,
        ISavingsAmountInformationRepository savingsAmountInformationRepository,
        IWithdrawAmountInformationRepository withdrawAmountInformationRepository,

        // AIG
        IAIGBasicInformationRepository aIGBasicInformationRepository,
        IRepaymentLDFRepository repaymentLDFRepository,
        IFirstSixtyPercentageLDFRepository firstSixtyPercentageLDFRepository,
        ISecondFourtyPercentageLDFRepository secondFourtyPercentageLDFRepository,
        ILDFProgressRepository lDFProgressRepository,
        IIndividualLDFInfoFormRepository individualLDFInfoFormRepository,
        IGroupLDFInfoFormRepository groupLDFInfoFormRepository,
        IGroupLDFInfoFormMemberRepository groupLDFInfoFormMemberRepository,
        IIndividualGroupFormSetupRepository individualGroupFormSetupRepository,
        IRepaymentLDFHistoryRepository repaymentLDFHistoryRepository,
        IRepaymentLDFFileRepository repaymentLDFFileRepository,

        // Patrolling
        IPatrollingScheduleInformetionRepository patrollingScheduleInformetionRepository,
        IOtherPatrollingMemberRepository otherPatrollingMemberRepository,

          // InternalLoan
          IInternalLoanInformationRepository internalLoanInformationRepository,
          IRepaymentInternalLoanRepository repaymentInternalLoanRepository,
          IInternalLoanInformationFileRepository internalLoanInformationFileRepository,

            // PatrollingSchedulingInformetion
            IPatrollingSchedulingMemberRepository patrollingSchedulingMemberRepository,
            IPatrollingSchedulingParticipentsMapRepository patrollingSchedulingParticipentsMapRepository,
            IPatrollingSchedulingRepository patrollingSchedulingRepository,
            IPatrollingSchedulingFileRepository patrollingSchedulingFileRepository,

        ICommitteeManagementRepository committeeManagementRepository,
        ICommitteeManagementMemberRepository committeeManagementMemberRepository,
        IRegistrationArchiveRepository registrationArchiveRepository,
        IRegistrationArchiveFileRepository registrationArchiveFileRepository,
        //CipManagement
        ICipTeamRepository cipTeamRepository,
        ICipTeamMemberRepository cipTeamMemberRepository,
        ISurveyDocumentRepository surveyDocumentRepository,

        //NecessaryLinkManagement
        INecessaryLinkRepository necessaryLinkRepository,

        //CommitteeTypeConfiguration
        ICommitteeTypeConfigurationRepository committeeTypeConfigurationRepository,
        ICommitteesConfigurationRepository committeesConfigurationRepository,
        ICommitteeDesignationsConfigurationRepository committeeDesignationsConfigurationRepository,

        //PermissionSettings
        IPermissionHeaderSettingsRepository permissionHeaderSettingsRepository,
        IPermissionRowSettingsRepository permissionRowSettingsRepository,

        IAccountRepository accountRepository,
        ISourceOfFundRepository sourceOfFundRepository,
        IAccountTransferRepository accountTransferRepository,
        IAccountTransferLogRepository accountTransferLogRepository,
        IAccountDepositRepository accountDepositRepository,
        IAccountTransferApprovalRepository accountTransferApprovalRepository,

        //ApprovalLogForCfm
        IApprovalLogForCfmRepository approvalLogForCfmRepository,

        //ApprovalLogForCfm
        IAccountsUserTagLogRepository accountsUserTagLogRepository,

        //Submission History For Mobile
        IBeneficiarySubmissionHistoryRepository beneficiarySubmissionHistoryRepository,

        //Bank Accounts Information
        IBankAccountsInformationRepository bankAccountsInformationRepository,

        //Social Forestry Training
        IEventTypeForTrainingRepository eventTypeForTrainingRepository,
        ITrainerDesignationForTrainingRepository trainerDesignationForTrainingRepository,
        ITrainingOrganizerForTrainingRepository trainingOrganizerForTrainingRepository,
        IFinancialYearForTrainingRepository financialYearForTrainingRepository,
        //Social Forestry Training(Main)
        ISocialForestryTrainingRepository socialForestryTrainingRepository,
        ISocialForestryTrainingParticipentsMapRepository socialForestryTrainingParticipentsMapRepository,
        ISocialForestryTrainingFileRepository socialForestryTrainingFileRepository,
        ISocialForestryTrainingMemberRepository socialForestryTrainingMemberRepository,

        //Social Forestry Meeting
        IMeetingTypeForSocialForestryMeetingRepository meetingTypeForSocialForestryMeetingRepository,
        //Social Forestry Meeting(Main)
        ISocialForestryMeetingRepository socialForestryMeetingRepository,
        ISocialForestryMeetingParticipentsMapRepository socialForestryMeetingParticipentsMapRepository,
        ISocialForestryMeetingFileRepository socialForestryMeetingFileRepository,
        ISocialForestryMeetingMemberRepository socialForestryMeetingMemberRepository,

        IReplantationRepository replantationRepository,
        IReplantationCostInfoRepository replantationCostInfoRepository,
        IReplantationInspectionMapRepository replantationInspectionMapRepository,
        IReplantationLaborInfoRepository replantationLaborInfoRepository,
        IReplantationNurseryInfoRepository replantationNurseryInfoRepository,
        IReplantationSocialForestryBeneficiaryMapRepository replantationSocialForestryBeneficiaryMapRepository,
        ICuttingPlantationRepository cuttingPlantationRepository,
        ILotWiseSellingInformationRepository lotWiseSellingInformationRepository,
        IReplantationDamageInfoRepository replantationDamageInfoRepository,

        #region Social Forestry

        IConcernedOfficialRepository concernedOfficialRepository,
        ICostInformationRepository costInformationRepository,
        ICostInformationFileRepository costInformationFileRepository,
        ICostTypeRepository costTypeRepository,
        IInspectionDetailsRepository inspectionDetailsRepository,
        ILaborCostTypeRepository laborCostTypeRepository,
        ILaborInformationRepository laborInformationRepository,
        ILaborInformationFileRepository laborInformationFileRepository,
        ILandOwningAgencyRepository landOwningAgencyRepository,
        INewRaisedPlantationRepository newRaisedPlantationRepository,
        IPlantationCauseOfDamageRepository plantationCauseOfDamageRepository,
        IPlantationDamageInformationRepository plantationDamageInformationRepository,
        IPlantationFileRepository plantationFileRepository,
        IPlantationPlantRepository plantationPlantRepository,
        IPlantationSocialForestryBeneficiaryMapRepository plantationSocialForestryBeneficiaryMapRepository,
        IPlantationTopographyRepository plantationTopographyRepository,
        IPlantationTypeRepository plantationTypeRepository,
        IPlantationUnitRepository plantationUnitRepository,
        IProjectTypeRepository projectTypeRepository,
        ISocialForestryBeneficiaryRepository socialForestryBeneficiaryRepository,
        ISocialForestryDesignationRepository socialForestryDesignationRepository,
        ISocialForestryNgoRepository socialForestryNgoRepository,
        IZoneOrAreaRepository zoneOrAreaRepository,
        INurseryCostInformationRepository nurseryCostInformationRepository,
        INurseryCostInformationFileRepository nurseryCostInformationFileRepository,


        IDistributedToBeneficiaryRepository distributedToBeneficiaryRepository,
        IDistributionFundTypeRepository distributionFundTypeRepository,
        IDistributionPercentageRepository distributionPercentageRepository,
        IShareDistributionRepository shareDistributionRepository,

        //Nursery

        INurseryInformationRepository nurseryInformationRepository,
        INurseryRaisedSeedlingInformationRepository nurseryRaisedSeedlingInformationRepository,
        INurseryRaisingSectorRepository nurseryRaisingSectorRepository,
        INurseryTypeRepository nurseryTypeRepository,
        INurseryDistributionRepository nurseryDistributionRepository,
        IRealizationRepository realizationRepository


        #endregion
            )
        {
            WriteOnlyCtx = ecommarceWriteOnlyCtx;
            ReadOnlyCtx = ecommarceReadOnlyCtx;
            users = userRepository;
            usergroups = userGroupRepository;
            Categoriess = categoryRepository;
            Districts = districtRepository;
            Divisions = divisionRepository;
            UpazillaRepo = upazillaRepository;
            Color = colorRepository;
            UserRoles = userRolesRepository;
            Accesslist = accesslistRepository;
            AccessMapper = accessMapperRepository;
            Module = moduleRepository;
            PmsGroup = pmsGroupRepository;
            UnionRepo = unionRepository;
            FinancialYearRepo = financialYearRepository;
            AccountTransferApprovalRepository = accountTransferApprovalRepository;

            ForestCircleRepo = forestCirlceRepository;
            ForestBeatRepo = forestBeatRepository;
            ForestRangeRepo = forestRangeRepository;
            ForestFcvVcfRepo = forestFcvVcfRepository;
            ForestDivisionRepo = forestDivisionRepository;
            ExistingSkillRepo = existingSkillRepository;
            AssetRepo = assetRepository;
            AssetTypeRepo = assetTypeRepository;
            EnergyUseRepo = energyUseRepository;
            EnergyTypeRepo = energyTypeRepository;
            ImmovableAssetRepo = immovableAssetRepository;
            ImmovableAssetTypeRepo = immovableAssetTypeRepository;
            LandOccupancyRepo = landOccupancyRepository;
            LiveStockRepo = liveStockRepository;
            LiveStockTypeRepo = liveStockTypeRepository;
            FoodItemRepo = foodItemRepository;
            FoodSecurityItemRepo = foodSecurityItemRepository;
            BFDAssociationRepo = bFDAssociationRepository;
            DisabilityTypeRepo = disabilityTypeRepository;
            HouseholdMemberRepo = householdMemberRepository;
            OccupationRepo = occupationRepository;
            RelationWithHeadHouseHoldTypeRepo = relationWithHeadHouseHoldTypeRepository;
            SafetyNetRepo = safetyNetRepository;
            BFDAssociationHouseholdMembersMapRepo = bFDAssociationHouseholdMembersMapRepository;
            DisabilityTypeHouseholdMembersMapRepo = disabilityTypeHouseholdMembersMapRepository;
            AnnualHouseholdExpenditureRepo = annualHouseholdExpenditureRepository;
            ExpenditureTypeRepo = expenditureTypeRepository;
            BusinessRepo = businessRepository;
            BusinessIncomeSourceTypeRepo = businessIncomeSourceTypeRepository;
            GrossMarginIncomeAndCostStatusRepo = grossMarginIncomeAndCostStatusRepository;
            ManualIncomeSourceTypeRepo = manualIncomeSourceTypeRepository;
            ManualPhysicalWorkRepo = manualPhysicalWorkRepository;
            NaturalIncomeSourceTypeRepo = naturalIncomeSourceTypeRepository;
            NaturalResourcesIncomeAndCostStatusRepo = naturalResourcesIncomeAndCostStatusRepository;
            OtherIncomeSourceRepo = otherIncomeSourceRepository;
            OtherIncomeSourceTypeRepo = otherIncomeSourceTypeRepository;
            VulnerabilitySituationRepo = vulnerabilitySituationRepository;
            VulnerabilitySituationTypeRepo = vulnerabilitySituationTypeRepository;
            NgoRepo = ngoRepository;
            EthnicityRepo = ethnicityRepository;
            SurveyRepo = surveyRepository;
            MarketingRepo = marketingRepository;
            SurveyIncidentRepo = surveyIncidentRepository;
            TypeOfHouseRepository = typeOfHouseRepository;

            CipRepository = cipRepository;
            CipFileRepository = cipFileRepository;

            CommunityTrainingMemberRepo = communityTrainingMemberRepository;
            CommunityTrainingParticipentsMapRepo = communityTrainingParticipentsMapRepository;
            CommunityTrainingRepo = communityTrainingRepository;
            CommunityTrainingFileRepo = communityTrainingFileRepository;
            CommunityTrainingTypeRepo = communityTrainingTypeRepository;

            DepartmentalTrainingMemberRepo = departmentalTrainingMemberRepository;
            DepartmentalTrainingParticipentsMapRepo = departmentalTrainingParticipentsMapRepository;
            DepartmentalTrainingRepo = departmentalTrainingRepository;
            DepartmentalTrainingFileRepo = departmentalTrainingFileRepository;
            DepartmentalTrainingTypeRepo = departmentalTrainingTypeRepository;
            EventTypeRepo = eventTypeRepository;
            TrainingOrganizerRepo = trainingOrganizerRepository;
            //ForestManagement
            OtherCommitteeMemberRepo = otherCommitteeMemberRepository;
            SubCommitteeDesignationRepositoryRepo = subCommitteeDesignationRepository;
            //Student
            StudentRepo = studentRepository;

            //Labour
            OtherLabourMemberRepo = otherLabourMemberRepository;
            LabourDatabaseRepo = labourDatabaseRepository;
            LabourWorkRepo = labourWorkRepository;
            LabourDatabaseFileRepo = labourDatabaseFileRepository;

            //Trade
            TradeRepo = tradeRepository;

            // Meeting
            MeetingRepo = meetingRepository;
            MeetingFileRepo = meetingFileRepository;
            MeetingMemberRepo = meetingMemberRepository;
            MeetingParticipantsMapRepo = meetingParticipantsMapRepository;
            MeetingTypeRepo = meetingTypeRepository;

            // Transaction
            TransactionRepo = transactionRepository;
            TransactionFilesRepository = transactionFilesRepository;
            FundTypeRepo = fundTypeRepository;

            //Beneficiary Savings Account
            SavingsAccountRepo = savingsAccountRepository;
            SavingsAmountInformationRepo = savingsAmountInformationRepository;
            WithdrawAmountInformationRepo = withdrawAmountInformationRepository;

            // AIG
            AIGBasicInformationRepo = aIGBasicInformationRepository;
            RepaymentLDFRepo = repaymentLDFRepository;
            FirstSixtyPercentageLDFRepo = firstSixtyPercentageLDFRepository;
            SecondFourtyPercentageLDFRepo = secondFourtyPercentageLDFRepository;
            LDFProgressRepo = lDFProgressRepository;
            IndividualLDFInfoFormRepository = individualLDFInfoFormRepository;
            IndividualGroupFormSetupRepository = individualGroupFormSetupRepository;
            GroupLDFInfoFormRepository = groupLDFInfoFormRepository;
            GroupLDFInfoFormMemberRepository = groupLDFInfoFormMemberRepository;
            RepaymentLDFHistoryRepository = repaymentLDFHistoryRepository;
            RepaymentLDFFileRepository = repaymentLDFFileRepository;

            // Patrolling
            PatrollingScheduleInformetionRepo = patrollingScheduleInformetionRepository;
            OtherPatrollingMemberRepo = otherPatrollingMemberRepository;

            // InternalLoan
            InternalLoanInformationRepo = internalLoanInformationRepository;
            RepaymentInternalLoanRepo = repaymentInternalLoanRepository;
            InternalLoanInformationFileRepo = internalLoanInformationFileRepository;

            //PatrollingSchedulingInformetion
            PatrollingSchedulingMemberRepo = patrollingSchedulingMemberRepository;
            PatrollingSchedulingParticipentsMapRepo = patrollingSchedulingParticipentsMapRepository;
            PatrollingSchedulingRepo = patrollingSchedulingRepository;
            PatrollingSchedulingFileRepo = patrollingSchedulingFileRepository;

            CommitteeManagementMemberRepository = committeeManagementMemberRepository;
            CommitteeManagementRepository = committeeManagementRepository;

            RegistrationArchiveRepository = registrationArchiveRepository;
            RegistrationArchiveFileRepository = registrationArchiveFileRepository;
            //CipManagement

            CipTeamRepository = cipTeamRepository;
            CipTeamMemberRepository = cipTeamMemberRepository;
            SurveyDocumentRepository = surveyDocumentRepository;

            //NecessaryLinkManagement
            NecessaryLinkRepository = necessaryLinkRepository;

            //CommitteeTypeConfiguration
            CommitteeTypeConfigurationRepository = committeeTypeConfigurationRepository;
            CommitteesConfigurationRepository = committeesConfigurationRepository;
            CommitteeDesignationsConfigurationRepository = committeeDesignationsConfigurationRepository;

            //PermissionSettings
            PermissionHeaderSettingsRepository = permissionHeaderSettingsRepository;
            PermissionRowSettingsRepository = permissionRowSettingsRepository;

            AccountRepository = accountRepository;

            //ApprovalLogForCfm
            ApprovalLogForCfmRepository = approvalLogForCfmRepository;

            SourceOfFundRepository = sourceOfFundRepository;
            AccountTransferRepository = accountTransferRepository;
            AccountTransferLogRepository = accountTransferLogRepository;
            AccountDepositRepository = accountDepositRepository;

            //AccountsUserTagLog
            AccountsUserTagLogRepository = accountsUserTagLogRepository;

            //Submission History For Mobile
            BeneficiarySubmissionHistoryRepository = beneficiarySubmissionHistoryRepository;

            //Bank Accounts Information
            BankAccountsInformationRepository = bankAccountsInformationRepository;

            //Social Forestry Training
            EventTypeForTrainingRepository = eventTypeForTrainingRepository;
            TrainerDesignationForTrainingRepository = trainerDesignationForTrainingRepository;
            TrainingOrganizerForTrainingRepository = trainingOrganizerForTrainingRepository;
            FinancialYearForTrainingRepository = financialYearForTrainingRepository;
            //Social Forestry Training(Main)
            SocialForestryTrainingRepository = socialForestryTrainingRepository;
            SocialForestryTrainingParticipentsMapRepository = socialForestryTrainingParticipentsMapRepository;
            SocialForestryTrainingFileRepository = socialForestryTrainingFileRepository;
            SocialForestryTrainingMemberRepository = socialForestryTrainingMemberRepository;

            //Social Forestry Meeting
            MeetingTypeForSocialForestryMeetingRepository = meetingTypeForSocialForestryMeetingRepository;
            //Social Forestry Meeting(Main)
            SocialForestryMeetingRepository = socialForestryMeetingRepository;
            SocialForestryMeetingParticipentsMapRepository = socialForestryMeetingParticipentsMapRepository;
            SocialForestryMeetingFileRepository = socialForestryMeetingFileRepository;
            SocialForestryMeetingMemberRepository = socialForestryMeetingMemberRepository;

            #region Social Forestry

            ConcernedOfficialRepository = concernedOfficialRepository;
            CostInformationRepository = costInformationRepository;
            CostInformationFileRepository = costInformationFileRepository;
            CostTypeRepository = costTypeRepository;
            InspectionDetailsRepository = inspectionDetailsRepository;
            LaborCostTypeRepository = laborCostTypeRepository;
            LaborInformationRepository = laborInformationRepository;
            LaborInformationFileRepository = laborInformationFileRepository;
            LandOwningAgencyRepository = landOwningAgencyRepository;
            NewRaisedPlantationRepository = newRaisedPlantationRepository;
            PlantationCauseOfDamageRepository = plantationCauseOfDamageRepository;
            PlantationDamageInformationRepository = plantationDamageInformationRepository;
            PlantationFileRepository = plantationFileRepository;
            PlantationPlantRepository = plantationPlantRepository;
            PlantationSocialForestryBeneficiaryMapRepository = plantationSocialForestryBeneficiaryMapRepository;
            PlantationTopographyRepository = plantationTopographyRepository;
            PlantationTypeRepository = plantationTypeRepository;
            PlantationUnitRepository = plantationUnitRepository;
            ProjectTypeRepository = projectTypeRepository;
            SocialForestryBeneficiaryRepository = socialForestryBeneficiaryRepository;
            SocialForestryDesignationRepository = socialForestryDesignationRepository;
            SocialForestryNgoRepository = socialForestryNgoRepository;
            ZoneOrAreaRepository = zoneOrAreaRepository;
            NurseryCostInformationRepository = nurseryCostInformationRepository;
            NurseryCostInformationFileRepository = nurseryCostInformationFileRepository;
            NurseryInformationRepository = nurseryInformationRepository;
            NurseryRaisedSeedlingInformationRepository = nurseryRaisedSeedlingInformationRepository;
            NurseryRaisingSectorRepository = nurseryRaisingSectorRepository;
            NurseryTypeRepository = nurseryTypeRepository;
            NurseryDistributionRepository = nurseryDistributionRepository;

            ReplantationRepository = replantationRepository;
            ReplantationCostInfoRepository = replantationCostInfoRepository;
            ReplantationInspectionMapRepository = replantationInspectionMapRepository;
            ReplantationLaborInfoRepository = replantationLaborInfoRepository;
            ReplantationNurseryInfoRepository = replantationNurseryInfoRepository;
            ReplantationSocialForestryBeneficiaryMapRepository = replantationSocialForestryBeneficiaryMapRepository;
            CuttingPlantationRepository = cuttingPlantationRepository;
            LotWiseSellingInformationRepository = lotWiseSellingInformationRepository;
            ReplantationDamageInfoRepository = replantationDamageInfoRepository;

            DistributedToBeneficiaryRepository = distributedToBeneficiaryRepository;
            DistributionFundTypeRepository = distributionFundTypeRepository;
            DistributionPercentageRepository = distributionPercentageRepository;
            ShareDistributionRepository = shareDistributionRepository;

            RealizationRepository = realizationRepository;
            #endregion

            //Social Forestry PatrollingSchedule
        }

        public IDbContextTransaction Begin()
        {
            try
            {
                IDbContextTransaction transaction = WriteOnlyCtx.Database.BeginTransaction();
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Complete(IDbContextTransaction transaction, CompletionState completionState)
        {
            try
            {
                if (transaction != null && transaction.TransactionId != null && transaction.GetDbTransaction() != null)
                {
                    if (completionState == CompletionState.Success)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                transaction.Rollback();
            }
        }

        #region Select a Repository based on given type

        //public string GetEnumDisplayName(this Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

        //    if (attributes != null && attributes.Length > 0)
        //        return attributes[0].Name;
        //    else
        //        return value.ToString();
        //}

        public IBaseRepository<T> Select<T>(T entity) where T : BaseEntity
        {
            IBaseRepository<T> repository = default(IBaseRepository<T>);
            switch (entity)
            {
                case User _:
                    repository = (IBaseRepository<T>)users;
                    break;
                case ReplantationDamageInfo _:
                    repository = (IBaseRepository<T>)ReplantationDamageInfoRepository;
                    break;
                case UserGroup _:
                    repository = (IBaseRepository<T>)usergroups;
                    break;
                case Category _:
                    repository = (IBaseRepository<T>)Categoriess;
                    break;
                case District _:
                    repository = (IBaseRepository<T>)Districts;
                    break;
                case Division _:
                    repository = (IBaseRepository<T>)Divisions;
                    break;
                case Upazilla _:
                    repository = (IBaseRepository<T>)UpazillaRepo;
                    break;
                case CommitteeDesignation _:
                    repository = (IBaseRepository<T>)SubCommitteeDesignationRepositoryRepo;
                    break;
                case Color _:
                    repository = (IBaseRepository<T>)Color;
                    break;
                case UserRole _:
                    repository = (IBaseRepository<T>)UserRoles;
                    break;
                case Accesslist _:
                    repository = (IBaseRepository<T>)Accesslist;
                    break;
                case CuttingPlantation _:
                    repository = (IBaseRepository<T>)CuttingPlantationRepository;
                    break;
                case DistributedToBeneficiary _:
                    repository = (IBaseRepository<T>)DistributedToBeneficiaryRepository;
                    break;
                case DistributionFundType _:
                    repository = (IBaseRepository<T>)DistributionFundTypeRepository;
                    break;
                case DistributionPercentage _:
                    repository = (IBaseRepository<T>)DistributionPercentageRepository;
                    break;
                case ShareDistribution _:
                    repository = (IBaseRepository<T>)ShareDistributionRepository;
                    break;
                case LotWiseSellingInformation _:
                    repository = (IBaseRepository<T>)LotWiseSellingInformationRepository;
                    break;
                case Realization _:
                    repository = (IBaseRepository<T>)RealizationRepository;
                    break;
                case Replantation _:
                    repository = (IBaseRepository<T>)ReplantationRepository;
                    break;
                case ReplantationCostInfo _:
                    repository = (IBaseRepository<T>)ReplantationCostInfoRepository;
                    break;
                case ReplantationInspectionMap _:
                    repository = (IBaseRepository<T>)ReplantationInspectionMapRepository;
                    break;
                case ReplantationLaborInfo _:
                    repository = (IBaseRepository<T>)ReplantationLaborInfoRepository;
                    break;
                case ReplantationNurseryInfo _:
                    repository = (IBaseRepository<T>)ReplantationNurseryInfoRepository;
                    break;
                case ReplantationSocialForestryBeneficiaryMap _:
                    repository = (IBaseRepository<T>)ReplantationSocialForestryBeneficiaryMapRepository;
                    break;
                case AccessMapper _:
                    repository = (IBaseRepository<T>)AccessMapper;
                    break;
                case Common.Entity.Module _:
                    repository = (IBaseRepository<T>)Module;
                    break;
                case PmsGroup _:
                    repository = (IBaseRepository<T>)PmsGroup;
                    break;
                case Union _:
                    repository = (IBaseRepository<T>)UnionRepo;
                    break;
                case FinancialYear _:
                    repository = (IBaseRepository<T>)FinancialYearRepo;
                    break;
                // Marketing
                case Marketing _:
                    repository = (IBaseRepository<T>)MarketingRepo;
                    break;

                // Beneficiary
                case ForestCircle _:
                    repository = (IBaseRepository<T>)ForestCircleRepo;
                    break;
                case ForestDivision _:
                    repository = (IBaseRepository<T>)ForestDivisionRepo;
                    break;
                case ForestBeat _:
                    repository = (IBaseRepository<T>)ForestBeatRepo;
                    break;
                case ForestFcvVcf _:
                    repository = (IBaseRepository<T>)ForestFcvVcfRepo;
                    break;
                case ForestRange _:
                    repository = (IBaseRepository<T>)ForestRangeRepo;
                    break;
                case ExistingSkill _:
                    repository = (IBaseRepository<T>)ExistingSkillRepo;
                    break;
                case Asset _:
                    repository = (IBaseRepository<T>)AssetRepo;
                    break;
                case AssetType _:
                    repository = (IBaseRepository<T>)AssetTypeRepo;
                    break;
                case EnergyType _:
                    repository = (IBaseRepository<T>)EnergyTypeRepo;
                    break;
                case EnergyUse _:
                    repository = (IBaseRepository<T>)EnergyUseRepo;
                    break;
                case ImmovableAsset _:
                    repository = (IBaseRepository<T>)ImmovableAssetRepo;
                    break;
                case ImmovableAssetType _:
                    repository = (IBaseRepository<T>)ImmovableAssetTypeRepo;
                    break;
                case LandOccupancy _:
                    repository = (IBaseRepository<T>)LandOccupancyRepo;
                    break;
                case LiveStock _:
                    repository = (IBaseRepository<T>)LiveStockRepo;
                    break;
                case LiveStockType _:
                    repository = (IBaseRepository<T>)LiveStockTypeRepo;
                    break;
                case FoodItem _:
                    repository = (IBaseRepository<T>)FoodItemRepo;
                    break;
                case FoodSecurityItem _:
                    repository = (IBaseRepository<T>)FoodSecurityItemRepo;
                    break;
                case BFDAssociation _:
                    repository = (IBaseRepository<T>)BFDAssociationRepo;
                    break;
                case DisabilityType _:
                    repository = (IBaseRepository<T>)DisabilityTypeRepo;
                    break;
                case HouseholdMember _:
                    repository = (IBaseRepository<T>)HouseholdMemberRepo;
                    break;
                case Occupation _:
                    repository = (IBaseRepository<T>)OccupationRepo;
                    break;
                case Cip _:
                    repository = (IBaseRepository<T>)CipRepository;
                    break;
                case CipFile _:
                    repository = (IBaseRepository<T>)CipFileRepository;
                    break;
                case RelationWithHeadHouseHoldType _:
                    repository = (IBaseRepository<T>)RelationWithHeadHouseHoldTypeRepo;
                    break;
                case SafetyNet _:
                    repository = (IBaseRepository<T>)SafetyNetRepo;
                    break;
                case BFDAssociationHouseholdMembersMap _:
                    repository = (IBaseRepository<T>)BFDAssociationHouseholdMembersMapRepo;
                    break;
                case DisabilityTypeHouseholdMembersMap _:
                    repository = (IBaseRepository<T>)DisabilityTypeHouseholdMembersMapRepo;
                    break;
                case AnnualHouseholdExpenditure _:
                    repository = (IBaseRepository<T>)AnnualHouseholdExpenditureRepo;
                    break;
                case ExpenditureType _:
                    repository = (IBaseRepository<T>)ExpenditureTypeRepo;
                    break;
                case Business _:
                    repository = (IBaseRepository<T>)BusinessRepo;
                    break;
                case BusinessIncomeSourceType _:
                    repository = (IBaseRepository<T>)BusinessIncomeSourceTypeRepo;
                    break;
                case GrossMarginIncomeAndCostStatus _:
                    repository = (IBaseRepository<T>)GrossMarginIncomeAndCostStatusRepo;
                    break;
                case ManualIncomeSourceType _:
                    repository = (IBaseRepository<T>)ManualIncomeSourceTypeRepo;
                    break;
                case ManualPhysicalWork _:
                    repository = (IBaseRepository<T>)ManualPhysicalWorkRepo;
                    break;
                case NaturalIncomeSourceType _:
                    repository = (IBaseRepository<T>)NaturalIncomeSourceTypeRepo;
                    break;
                case NaturalResourcesIncomeAndCostStatus _:
                    repository = (IBaseRepository<T>)NaturalResourcesIncomeAndCostStatusRepo;
                    break;
                case OtherIncomeSource _:
                    repository = (IBaseRepository<T>)OtherIncomeSourceRepo;
                    break;
                case OtherIncomeSourceType _:
                    repository = (IBaseRepository<T>)OtherIncomeSourceTypeRepo;
                    break;
                case VulnerabilitySituation _:
                    repository = (IBaseRepository<T>)VulnerabilitySituationRepo;
                    break;
                case VulnerabilitySituationType _:
                    repository = (IBaseRepository<T>)VulnerabilitySituationTypeRepo;
                    break;
                case Ngo _:
                    repository = (IBaseRepository<T>)NgoRepo;
                    break;
                case Ethnicity _:
                    repository = (IBaseRepository<T>)EthnicityRepo;
                    break;
                case Survey _:
                    repository = (IBaseRepository<T>)SurveyRepo;
                    break;
                case SurveyIncident _:
                    repository = (IBaseRepository<T>)SurveyIncidentRepo;
                    break;
                case TypeOfHouse _:
                    repository = (IBaseRepository<T>)TypeOfHouseRepository;
                    break;

                // Capacity
                case CommunityTrainingMember _:
                    repository = (IBaseRepository<T>)CommunityTrainingMemberRepo;
                    break;
                case CommunityTrainingParticipentsMap _:
                    repository = (IBaseRepository<T>)CommunityTrainingParticipentsMapRepo;
                    break;
                case CommunityTraining _:
                    repository = (IBaseRepository<T>)CommunityTrainingRepo;
                    break;
                case CommunityTrainingFile _:
                    repository = (IBaseRepository<T>)CommunityTrainingFileRepo;
                    break;
                case CommunityTrainingType _:
                    repository = (IBaseRepository<T>)CommunityTrainingTypeRepo;
                    break;

                case DepartmentalTrainingMember _:
                    repository = (IBaseRepository<T>)DepartmentalTrainingMemberRepo;
                    break;
                case DepartmentalTrainingParticipentsMap _:
                    repository = (IBaseRepository<T>)DepartmentalTrainingParticipentsMapRepo;
                    break;
                case DepartmentalTraining _:
                    repository = (IBaseRepository<T>)DepartmentalTrainingRepo;
                    break;
                case DepartmentalTrainingFile _:
                    repository = (IBaseRepository<T>)DepartmentalTrainingFileRepo;
                    break;
                case DepartmentalTrainingType _:
                    repository = (IBaseRepository<T>)DepartmentalTrainingTypeRepo;
                    break;
                case EventType _:
                    repository = (IBaseRepository<T>)EventTypeRepo;
                    break;
                case TrainingOrganizer _:
                    repository = (IBaseRepository<T>)TrainingOrganizerRepo;
                    break;
                case OtherCommitteeMember _:
                    repository = (IBaseRepository<T>)OtherCommitteeMemberRepo;
                    break;

                // Meeting
                case Meeting _:
                    repository = (IBaseRepository<T>)MeetingRepo;
                    break;
                case MeetingFile _:
                    repository = (IBaseRepository<T>)MeetingFileRepo;
                    break;
                case MeetingMember _:
                    repository = (IBaseRepository<T>)MeetingMemberRepo;
                    break;
                case MeetingParticipantsMap _:
                    repository = (IBaseRepository<T>)MeetingParticipantsMapRepo;
                    break;
                case MeetingType _:
                    repository = (IBaseRepository<T>)MeetingTypeRepo;
                    break;

                //Student
                case Student _:
                    repository = (IBaseRepository<T>)StudentRepo;
                    break;

                //Labour
                case OtherLabourMember _:
                    repository = (IBaseRepository<T>)OtherLabourMemberRepo;
                    break;
                case LabourDatabaseFile _:
                    repository = (IBaseRepository<T>)LabourDatabaseFileRepo;
                    break;
                case LabourDatabase _:
                    repository = (IBaseRepository<T>)LabourDatabaseRepo;
                    break;
                case LabourWork _:
                    repository = (IBaseRepository<T>)LabourWorkRepo;
                    break;


                //Trade
                case Trade _:
                    repository = (IBaseRepository<T>)TradeRepo;
                    break;

                // Transaction
                case Transaction _:
                    repository = (IBaseRepository<T>)TransactionRepo;
                    break;
                case TransactionFiles _:
                    repository = (IBaseRepository<T>)TransactionFilesRepository;
                    break;
                case FundType _:
                    repository = (IBaseRepository<T>)FundTypeRepo;
                    break;

                //Beneficiary Savings Account
                case SavingsAccount _:
                    repository = (IBaseRepository<T>)SavingsAccountRepo;
                    break;
                case SavingsAmountInformation _:
                    repository = (IBaseRepository<T>)SavingsAmountInformationRepo;
                    break;
                case WithdrawAmountInformation _:
                    repository = (IBaseRepository<T>)WithdrawAmountInformationRepo;
                    break;

                // AIG
                case AIGBasicInformation _:
                    repository = (IBaseRepository<T>)AIGBasicInformationRepo;
                    break;
                case RepaymentLDF _:
                    repository = (IBaseRepository<T>)RepaymentLDFRepo;
                    break;
                case FirstSixtyPercentageLDF _:
                    repository = (IBaseRepository<T>)FirstSixtyPercentageLDFRepo;
                    break;
                case SecondFourtyPercentageLDF _:
                    repository = (IBaseRepository<T>)SecondFourtyPercentageLDFRepo;
                    break;
                case LDFProgress _:
                    repository = (IBaseRepository<T>)LDFProgressRepo;
                    break;
                case IndividualLDFInfoForm _:
                    repository = (IBaseRepository<T>)IndividualLDFInfoFormRepository;
                    break;
                case IndividualGroupFormSetup _:
                    repository = (IBaseRepository<T>)IndividualGroupFormSetupRepository;
                    break;
                case GroupLDFInfoForm _:
                    repository = (IBaseRepository<T>)GroupLDFInfoFormRepository;
                    break;
                case GroupLDFInfoFormMember _:
                    repository = (IBaseRepository<T>)GroupLDFInfoFormMemberRepository;
                    break;
                case RepaymentLDFHistory _:
                    repository = (IBaseRepository<T>)RepaymentLDFHistoryRepository;
                    break;
                case RepaymentLDFFile _:
                    repository = (IBaseRepository<T>)RepaymentLDFFileRepository;
                    break;


                // Patrolling
                case PatrollingScheduleInformetion _:
                    repository = (IBaseRepository<T>)PatrollingScheduleInformetionRepo;
                    break;
                case OtherPatrollingMember _:
                    repository = (IBaseRepository<T>)OtherPatrollingMemberRepo;
                    break;

                // InternalLoan
                case InternalLoanInformation _:
                    repository = (IBaseRepository<T>)InternalLoanInformationRepo;
                    break;
                case RepaymentInternalLoan _:
                    repository = (IBaseRepository<T>)RepaymentInternalLoanRepo;
                    break;
                case InternalLoanInformationFile _:
                    repository = (IBaseRepository<T>)InternalLoanInformationFileRepo;
                    break;

                //PatrollingSchedulingInformetion
                case PatrollingSchedulingMember _:
                    repository = (IBaseRepository<T>)PatrollingSchedulingMemberRepo;
                    break;
                case PatrollingSchedulingParticipentsMap _:
                    repository = (IBaseRepository<T>)PatrollingSchedulingParticipentsMapRepo;
                    break;
                case PatrollingScheduling _:
                    repository = (IBaseRepository<T>)PatrollingSchedulingRepo;
                    break;
                case PatrollingSchedulingFile _:
                    repository = (IBaseRepository<T>)PatrollingSchedulingFileRepo;
                    break;

                case CommitteeManagement _:
                    repository = (IBaseRepository<T>)CommitteeManagementRepository;
                    break;
                case CommitteeManagementMember _:
                    repository = (IBaseRepository<T>)CommitteeManagementMemberRepository;
                    break;

                // Archive
                case RegistrationArchive _:
                    repository = (IBaseRepository<T>)RegistrationArchiveRepository;
                    break;
                case RegistrationArchiveFile _:
                    repository = (IBaseRepository<T>)RegistrationArchiveFileRepository;
                    break;
                // CipManagement
                case CipTeam _:
                    repository = (IBaseRepository<T>)CipTeamRepository;
                    break;
                case CipTeamMember _:
                    repository = (IBaseRepository<T>)CipTeamMemberRepository;
                    break;
                case SurveyDocument _:
                    repository = (IBaseRepository<T>)SurveyDocumentRepository;
                    break;

                //NecessaryLinkManagement
                case NecessaryLink _:
                    repository = (IBaseRepository<T>)NecessaryLinkRepository;
                    break;

                //CommitteeTypeConfiguration
                case CommitteeTypeConfiguration _:
                    repository = (IBaseRepository<T>)CommitteeTypeConfigurationRepository;
                    break;

                case CommitteesConfiguration _:
                    repository = (IBaseRepository<T>)CommitteesConfigurationRepository;
                    break;

                case CommitteeDesignationsConfiguration _:
                    repository = (IBaseRepository<T>)CommitteeDesignationsConfigurationRepository;
                    break;

                //PermissionSettings
                case PermissionHeaderSettings _:
                    repository = (IBaseRepository<T>)PermissionHeaderSettingsRepository;
                    break;
                case PermissionRowSettings _:
                    repository = (IBaseRepository<T>)PermissionRowSettingsRepository;
                    break;
                case Account _:
                    repository = (IBaseRepository<T>)AccountRepository;
                    break;

                //ApprovalLogForCfm
                case ApprovalLogForCfm _:
                    repository = (IBaseRepository<T>)ApprovalLogForCfmRepository;
                    break;

                //Accounts User Tag Log
                case AccountsUserTagLog _:
                    repository = (IBaseRepository<T>)AccountsUserTagLogRepository;
                    break;
                case SourceOfFund _:
                    repository = (IBaseRepository<T>)SourceOfFundRepository;
                    break;
                case AccountTransfer _:
                    repository = (IBaseRepository<T>)AccountTransferRepository;
                    break;
                case AccountTransferLog _:
                    repository = (IBaseRepository<T>)AccountTransferLogRepository;
                    break;
                case AccountDeposit _:
                    repository = (IBaseRepository<T>)AccountDepositRepository;
                    break;

                //Submission History For Mobile
                case BeneficiarySubmissionHistory _:
                    repository = (IBaseRepository<T>)BeneficiarySubmissionHistoryRepository;
                    break;

                //Bank Accounts Information
                case BankAccountsInformation _:
                    repository = (IBaseRepository<T>)BankAccountsInformationRepository;
                    break;

                //Social Forestry Training
                case EventTypeForTraining _:
                    repository = (IBaseRepository<T>)EventTypeForTrainingRepository;
                    break;
                case TrainerDesignationForTraining _:
                    repository = (IBaseRepository<T>)TrainerDesignationForTrainingRepository;
                    break;
                case TrainingOrganizerForTraining _:
                    repository = (IBaseRepository<T>)TrainingOrganizerForTrainingRepository;
                    break;
                case FinancialYearForTraining _:
                    repository = (IBaseRepository<T>)FinancialYearForTrainingRepository;
                    break;
                //Social Forestry Training(Main)
                case SocialForestryTraining _:
                    repository = (IBaseRepository<T>)SocialForestryTrainingRepository;
                    break;
                case SocialForestryTrainingParticipentsMap _:
                    repository = (IBaseRepository<T>)SocialForestryTrainingParticipentsMapRepository;
                    break;
                case SocialForestryTrainingFile _:
                    repository = (IBaseRepository<T>)SocialForestryTrainingFileRepository;
                    break;
                case SocialForestryTrainingMember _:
                    repository = (IBaseRepository<T>)SocialForestryTrainingMemberRepository;
                    break;

                //Social Forestry Meeting
                case MeetingTypeForSocialForestryMeeting _:
                    repository = (IBaseRepository<T>)MeetingTypeForSocialForestryMeetingRepository;
                    break;
                //Social Forestry Meeting(Main)
                case SocialForestryMeetingMember _:
                    repository = (IBaseRepository<T>)SocialForestryMeetingMemberRepository;
                    break;
                case SocialForestryMeetingParticipentsMap _:
                    repository = (IBaseRepository<T>)SocialForestryMeetingParticipentsMapRepository;
                    break;
                case SocialForestryMeetingFile _:
                    repository = (IBaseRepository<T>)SocialForestryMeetingFileRepository;
                    break;
                case SocialForestryMeeting _:
                    repository = (IBaseRepository<T>)SocialForestryMeetingRepository;
                    break;
                case AccountTransferApproval _:
                    repository = (IBaseRepository<T>)AccountTransferApprovalRepository;
                    break;


                #region Social Forestry
                case ConcernedOfficial _:
                    repository = (IBaseRepository<T>)ConcernedOfficialRepository;
                    break;
                case CostInformation _:
                    repository = (IBaseRepository<T>)CostInformationRepository;
                    break;
                case CostInformationFile _:
                    repository = (IBaseRepository<T>)CostInformationFileRepository;
                    break;
                case CostType _:
                    repository = (IBaseRepository<T>)CostTypeRepository;
                    break;
                case InspectionDetails _:
                    repository = (IBaseRepository<T>)InspectionDetailsRepository;
                    break;
                case LaborCostType _:
                    repository = (IBaseRepository<T>)LaborCostTypeRepository;
                    break;
                case LaborInformation _:
                    repository = (IBaseRepository<T>)LaborInformationRepository;
                    break;
                case LaborInformationFile _:
                    repository = (IBaseRepository<T>)LaborInformationFileRepository;
                    break;
                case LandOwningAgency _:
                    repository = (IBaseRepository<T>)LandOwningAgencyRepository;
                    break;
                case NewRaisedPlantation _:
                    repository = (IBaseRepository<T>)NewRaisedPlantationRepository;
                    break;
                case PlantationCauseOfDamage _:
                    repository = (IBaseRepository<T>)PlantationCauseOfDamageRepository;
                    break;
                case PlantationDamageInformation _:
                    repository = (IBaseRepository<T>)PlantationDamageInformationRepository;
                    break;
                case PlantationFile _:
                    repository = (IBaseRepository<T>)PlantationFileRepository;
                    break;
                case PlantationPlant _:
                    repository = (IBaseRepository<T>)PlantationPlantRepository;
                    break;
                case PlantationSocialForestryBeneficiaryMap _:
                    repository = (IBaseRepository<T>)PlantationSocialForestryBeneficiaryMapRepository;
                    break;
                case PlantationTopography _:
                    repository = (IBaseRepository<T>)PlantationTopographyRepository;
                    break;
                case PlantationType _:
                    repository = (IBaseRepository<T>)PlantationTypeRepository;
                    break;
                case PlantationUnit _:
                    repository = (IBaseRepository<T>)PlantationUnitRepository;
                    break;
                case ProjectType _:
                    repository = (IBaseRepository<T>)ProjectTypeRepository;
                    break;
                case SocialForestryBeneficiary _:
                    repository = (IBaseRepository<T>)SocialForestryBeneficiaryRepository;
                    break;
                case SocialForestryDesignation _:
                    repository = (IBaseRepository<T>)SocialForestryDesignationRepository;
                    break;
                case SocialForestryNgo _:
                    repository = (IBaseRepository<T>)SocialForestryNgoRepository;
                    break;
                case ZoneOrArea _:
                    repository = (IBaseRepository<T>)ZoneOrAreaRepository;
                    break;

                case NurseryType _:
                    repository = (IBaseRepository<T>)NurseryTypeRepository;
                    break;
                case NurseryRaisingSector _:
                    repository = (IBaseRepository<T>)NurseryRaisingSectorRepository;
                    break;
                case NurseryRaisedSeedlingInformation _:
                    repository = (IBaseRepository<T>)NurseryRaisedSeedlingInformationRepository;
                    break;
                case NurseryInformation _:
                    repository = (IBaseRepository<T>)NurseryInformationRepository;
                    break;

                case NurseryCostInformation _:
                    repository = (IBaseRepository<T>)NurseryCostInformationRepository;
                    break;

                case NurseryCostInformationFile _:
                    repository = (IBaseRepository<T>)NurseryCostInformationFileRepository;
                    break;
                case NurseryDistribution _:
                    repository = (IBaseRepository<T>)NurseryDistributionRepository;
                    break;

                    #endregion
            }
            return repository;
        }

        public IBaseRepository<T> Select<T>() where T : BaseEntity
        {
            IBaseRepository<T> repository = default(IBaseRepository<T>);

            Type type = typeof(T);

            if (type == typeof(User))
            {
                repository = (IBaseRepository<T>)users;
            }
            else if (type == typeof(ReplantationDamageInfo))
            {
                repository = (IBaseRepository<T>)ReplantationDamageInfoRepository;
            }
            else if (type == typeof(UserGroup))
            {
                repository = (IBaseRepository<T>)usergroups;
            }
            else if (type == typeof(Category))
            {
                repository = (IBaseRepository<T>)Categoriess;
            }
            else if (type == typeof(District))
            {
                repository = (IBaseRepository<T>)Districts;
            }
            else if (type == typeof(AccountTransferApproval))
            {
                repository = (IBaseRepository<T>)AccountTransferApprovalRepository;
            }
            else if (type == typeof(Division))
            {
                repository = (IBaseRepository<T>)Divisions;
            }
            else if (type == typeof(Upazilla))
            {
                repository = (IBaseRepository<T>)UpazillaRepo;
            }
            else if (type == typeof(CommitteeDesignation))
            {
                repository = (IBaseRepository<T>)SubCommitteeDesignationRepositoryRepo;
            }
            else if (type == typeof(Color))
            {
                repository = (IBaseRepository<T>)Color;
            }
            else if (type == typeof(UserRole))
            {
                repository = (IBaseRepository<T>)UserRoles;
            }
            else if (type == typeof(Accesslist))
            {
                repository = (IBaseRepository<T>)Accesslist;
            }
            else if (type == typeof(AccessMapper))
            {
                repository = (IBaseRepository<T>)AccessMapper;
            }
            else if (type == typeof(Common.Entity.Module))
            {
                repository = (IBaseRepository<T>)Module;
            }
            else if (type == typeof(Realization))
            {
                repository = (IBaseRepository<T>)RealizationRepository;
            }
            else if (type == typeof(PmsGroup))
            {
                repository = (IBaseRepository<T>)PmsGroup;
            }
            else if (type == typeof(Union))
            {
                repository = (IBaseRepository<T>)UnionRepo;
            }
            else if (type == typeof(FinancialYear))
            {
                repository = (IBaseRepository<T>)FinancialYearRepo;
            }
            // Beneficiary
            else if (type == typeof(Marketing))
            {
                repository = (IBaseRepository<T>)MarketingRepo;
            }

            // Beneficiary
            else if (type == typeof(ForestCircle))
            {
                repository = (IBaseRepository<T>)ForestCircleRepo;
            }
            else if (type == typeof(ForestDivision))
            {
                repository = (IBaseRepository<T>)ForestDivisionRepo;
            }
            else if (type == typeof(ForestBeat))
            {
                repository = (IBaseRepository<T>)ForestBeatRepo;
            }
            else if (type == typeof(ForestFcvVcf))
            {
                repository = (IBaseRepository<T>)ForestFcvVcfRepo;
            }
            else if (type == typeof(ForestRange))
            {
                repository = (IBaseRepository<T>)ForestRangeRepo;
            }
            else if (type == typeof(ExistingSkill))
            {
                repository = (IBaseRepository<T>)ExistingSkillRepo;
            }
            else if (type == typeof(Asset))
            {
                repository = (IBaseRepository<T>)AssetRepo;
            }
            else if (type == typeof(AssetType))
            {
                repository = (IBaseRepository<T>)AssetTypeRepo;
            }
            else if (type == typeof(EnergyType))
            {
                repository = (IBaseRepository<T>)EnergyTypeRepo;
            }
            else if (type == typeof(EnergyUse))
            {
                repository = (IBaseRepository<T>)EnergyUseRepo;
            }
            else if (type == typeof(ImmovableAsset))
            {
                repository = (IBaseRepository<T>)ImmovableAssetRepo;
            }
            else if (type == typeof(ImmovableAssetType))
            {
                repository = (IBaseRepository<T>)ImmovableAssetTypeRepo;
            }
            else if (type == typeof(LandOccupancy))
            {
                repository = (IBaseRepository<T>)LandOccupancyRepo;
            }
            else if (type == typeof(LiveStock))
            {
                repository = (IBaseRepository<T>)LiveStockRepo;
            }
            else if (type == typeof(LiveStockType))
            {
                repository = (IBaseRepository<T>)LiveStockTypeRepo;
            }
            else if (type == typeof(FoodItem))
            {
                repository = (IBaseRepository<T>)FoodItemRepo;
            }
            else if (type == typeof(FoodSecurityItem))
            {
                repository = (IBaseRepository<T>)FoodSecurityItemRepo;
            }
            else if (type == typeof(BFDAssociation))
            {
                repository = (IBaseRepository<T>)BFDAssociationRepo;
            }
            else if (type == typeof(DisabilityType))
            {
                repository = (IBaseRepository<T>)DisabilityTypeRepo;
            }
            else if (type == typeof(HouseholdMember))
            {
                repository = (IBaseRepository<T>)HouseholdMemberRepo;
            }
            else if (type == typeof(Occupation))
            {
                repository = (IBaseRepository<T>)OccupationRepo;
            }
            else if (type == typeof(RelationWithHeadHouseHoldType))
            {
                repository = (IBaseRepository<T>)RelationWithHeadHouseHoldTypeRepo;
            }
            else if (type == typeof(SafetyNet))
            {
                repository = (IBaseRepository<T>)SafetyNetRepo;
            }
            else if (type == typeof(BFDAssociationHouseholdMembersMap))
            {
                repository = (IBaseRepository<T>)BFDAssociationHouseholdMembersMapRepo;
            }
            else if (type == typeof(DisabilityTypeHouseholdMembersMap))
            {
                repository = (IBaseRepository<T>)DisabilityTypeHouseholdMembersMapRepo;
            }
            else if (type == typeof(AnnualHouseholdExpenditure))
            {
                repository = (IBaseRepository<T>)AnnualHouseholdExpenditureRepo;
            }
            else if (type == typeof(ExpenditureType))
            {
                repository = (IBaseRepository<T>)ExpenditureTypeRepo;
            }
            else if (type == typeof(DistributedToBeneficiary))
            {
                repository = (IBaseRepository<T>)DistributedToBeneficiaryRepository;
            }
            else if (type == typeof(DistributionFundType))
            {
                repository = (IBaseRepository<T>)DistributionFundTypeRepository;
            }
            else if (type == typeof(DistributionPercentage))
            {
                repository = (IBaseRepository<T>)DistributionPercentageRepository;
            }
            else if (type == typeof(ShareDistribution))
            {
                repository = (IBaseRepository<T>)ShareDistributionRepository;
            }
            else if (type == typeof(Business))
            {
                repository = (IBaseRepository<T>)BusinessRepo;
            }
            else if (type == typeof(BusinessIncomeSourceType))
            {
                repository = (IBaseRepository<T>)BusinessIncomeSourceTypeRepo;
            }
            else if (type == typeof(Replantation))
            {
                repository = (IBaseRepository<T>)ReplantationRepository;
            }
            else if (type == typeof(ReplantationCostInfo))
            {
                repository = (IBaseRepository<T>)ReplantationCostInfoRepository;
            }
            else if (type == typeof(ReplantationInspectionMap))
            {
                repository = (IBaseRepository<T>)ReplantationInspectionMapRepository;
            }
            else if (type == typeof(ReplantationLaborInfo))
            {
                repository = (IBaseRepository<T>)ReplantationLaborInfoRepository;
            }
            else if (type == typeof(ReplantationNurseryInfo))
            {
                repository = (IBaseRepository<T>)ReplantationNurseryInfoRepository;
            }
            else if (type == typeof(ReplantationSocialForestryBeneficiaryMap))
            {
                repository = (IBaseRepository<T>)ReplantationSocialForestryBeneficiaryMapRepository;
            }
            else if (type == typeof(CuttingPlantation))
            {
                repository = (IBaseRepository<T>)CuttingPlantationRepository;
            }
            else if (type == typeof(LotWiseSellingInformation))
            {
                repository = (IBaseRepository<T>)LotWiseSellingInformationRepository;
            }
            else if (type == typeof(GrossMarginIncomeAndCostStatus))
            {
                repository = (IBaseRepository<T>)GrossMarginIncomeAndCostStatusRepo;
            }
            else if (type == typeof(ManualIncomeSourceType))
            {
                repository = (IBaseRepository<T>)ManualIncomeSourceTypeRepo;
            }
            else if (type == typeof(ManualPhysicalWork))
            {
                repository = (IBaseRepository<T>)ManualPhysicalWorkRepo;
            }
            else if (type == typeof(NaturalIncomeSourceType))
            {
                repository = (IBaseRepository<T>)NaturalIncomeSourceTypeRepo;
            }
            else if (type == typeof(NaturalResourcesIncomeAndCostStatus))
            {
                repository = (IBaseRepository<T>)NaturalResourcesIncomeAndCostStatusRepo;
            }
            else if (type == typeof(OtherIncomeSource))
            {
                repository = (IBaseRepository<T>)OtherIncomeSourceRepo;
            }
            else if (type == typeof(OtherIncomeSourceType))
            {
                repository = (IBaseRepository<T>)OtherIncomeSourceTypeRepo;
            }
            else if (type == typeof(VulnerabilitySituation))
            {
                repository = (IBaseRepository<T>)VulnerabilitySituationRepo;
            }
            else if (type == typeof(VulnerabilitySituationType))
            {
                repository = (IBaseRepository<T>)VulnerabilitySituationTypeRepo;
            }
            else if (type == typeof(Ngo))
            {
                repository = (IBaseRepository<T>)NgoRepo;
            }
            else if (type == typeof(Ethnicity))
            {
                repository = (IBaseRepository<T>)EthnicityRepo;
            }
            else if (type == typeof(Survey))
            {
                repository = (IBaseRepository<T>)SurveyRepo;
            }
            else if (type == typeof(SurveyIncident))
            {
                repository = (IBaseRepository<T>)SurveyIncidentRepo;
            }
            else if (type == typeof(Cip))
            {
                repository = (IBaseRepository<T>)CipRepository;
            }
            else if (type == typeof(CipFile))
            {
                repository = (IBaseRepository<T>)CipFileRepository;
            }
            else if (type == typeof(TypeOfHouse))
            {
                repository = (IBaseRepository<T>)TypeOfHouseRepository;
            }

            // Capacity
            else if (type == typeof(CommunityTrainingMember))
            {
                repository = (IBaseRepository<T>)CommunityTrainingMemberRepo;
            }
            else if (type == typeof(CommunityTrainingParticipentsMap))
            {
                repository = (IBaseRepository<T>)CommunityTrainingParticipentsMapRepo;
            }
            else if (type == typeof(CommunityTraining))
            {
                repository = (IBaseRepository<T>)CommunityTrainingRepo;
            }
            else if (type == typeof(CommunityTrainingFile))
            {
                repository = (IBaseRepository<T>)CommunityTrainingFileRepo;
            }
            else if (type == typeof(CommunityTrainingType))
            {
                repository = (IBaseRepository<T>)CommunityTrainingTypeRepo;
            }

            else if (type == typeof(DepartmentalTrainingMember))
            {
                repository = (IBaseRepository<T>)DepartmentalTrainingMemberRepo;
            }
            else if (type == typeof(DepartmentalTrainingParticipentsMap))
            {
                repository = (IBaseRepository<T>)DepartmentalTrainingParticipentsMapRepo;
            }
            else if (type == typeof(DepartmentalTraining))
            {
                repository = (IBaseRepository<T>)DepartmentalTrainingRepo;
            }
            else if (type == typeof(DepartmentalTrainingFile))
            {
                repository = (IBaseRepository<T>)DepartmentalTrainingFileRepo;
            }
            else if (type == typeof(DepartmentalTrainingType))
            {
                repository = (IBaseRepository<T>)DepartmentalTrainingTypeRepo;
            }
            else if (type == typeof(EventType))
            {
                repository = (IBaseRepository<T>)EventTypeRepo;
            }
            else if (type == typeof(TrainingOrganizer))
            {
                repository = (IBaseRepository<T>)TrainingOrganizerRepo;
            }
            else if (type == typeof(OtherCommitteeMember))
            {
                repository = (IBaseRepository<T>)OtherCommitteeMemberRepo;
            }
            //Student
            else if (type == typeof(Student))
            {
                repository = (IBaseRepository<T>)StudentRepo;
            }
            //Labour
            else if (type == typeof(OtherLabourMember))
            {
                repository = (IBaseRepository<T>)OtherLabourMemberRepo;
            }
            else if (type == typeof(LabourDatabase))
            {
                repository = (IBaseRepository<T>)LabourDatabaseRepo;
            }
            else if (type == typeof(LabourWork))
            {
                repository = (IBaseRepository<T>)LabourWorkRepo;
            }
            else if (type == typeof(LabourDatabaseFile))
            {
                repository = (IBaseRepository<T>)LabourDatabaseFileRepo;
            }
            //Trade
            else if (type == typeof(Trade))
            {
                repository = (IBaseRepository<T>)TradeRepo;
            }

            // Meeting
            else if (type == typeof(Meeting))
            {
                repository = (IBaseRepository<T>)MeetingRepo;
            }
            else if (type == typeof(MeetingFile))
            {
                repository = (IBaseRepository<T>)MeetingFileRepo;
            }
            else if (type == typeof(MeetingMember))
            {
                repository = (IBaseRepository<T>)MeetingMemberRepo;
            }
            else if (type == typeof(MeetingParticipantsMap))
            {
                repository = (IBaseRepository<T>)MeetingParticipantsMapRepo;
            }
            else if (type == typeof(MeetingType))
            {
                repository = (IBaseRepository<T>)MeetingTypeRepo;
            }

            // Transaction
            else if (type == typeof(Transaction))
            {
                repository = (IBaseRepository<T>)TransactionRepo;
            }
            else if (type == typeof(TransactionFiles))
            {
                repository = (IBaseRepository<T>)TransactionFilesRepository;
            }
            else if (type == typeof(FundType))
            {
                repository = (IBaseRepository<T>)FundTypeRepo;
            }

            //Beneficiary Savings Account
            else if (type == typeof(SavingsAccount))
            {
                repository = (IBaseRepository<T>)SavingsAccountRepo;
            }
            else if (type == typeof(SavingsAmountInformation))
            {
                repository = (IBaseRepository<T>)SavingsAmountInformationRepo;
            }
            else if (type == typeof(WithdrawAmountInformation))
            {
                repository = (IBaseRepository<T>)WithdrawAmountInformationRepo;
            }

            // AIG
            else if (type == typeof(AIGBasicInformation))
            {
                repository = (IBaseRepository<T>)AIGBasicInformationRepo;
            }
            else if (type == typeof(RepaymentLDF))
            {
                repository = (IBaseRepository<T>)RepaymentLDFRepo;
            }
            else if (type == typeof(FirstSixtyPercentageLDF))
            {
                repository = (IBaseRepository<T>)FirstSixtyPercentageLDFRepo;
            }
            else if (type == typeof(SecondFourtyPercentageLDF))
            {
                repository = (IBaseRepository<T>)SecondFourtyPercentageLDFRepo;
            }
            else if (type == typeof(LDFProgress))
            {
                repository = (IBaseRepository<T>)LDFProgressRepo;
            }
            else if (type == typeof(IndividualLDFInfoForm))
            {
                repository = (IBaseRepository<T>)IndividualLDFInfoFormRepository;
            }
            else if (type == typeof(IndividualGroupFormSetup))
            {
                repository = (IBaseRepository<T>)IndividualGroupFormSetupRepository;
            }
            else if (type == typeof(GroupLDFInfoForm))
            {
                repository = (IBaseRepository<T>)GroupLDFInfoFormRepository;
            }
            else if (type == typeof(GroupLDFInfoFormMember))
            {
                repository = (IBaseRepository<T>)GroupLDFInfoFormMemberRepository;
            }
            else if (type == typeof(RepaymentLDFHistory))
            {
                repository = (IBaseRepository<T>)RepaymentLDFHistoryRepository;
            }
            else if (type == typeof(RepaymentLDFFile))
            {
                repository = (IBaseRepository<T>)RepaymentLDFFileRepository;
            }

            // Patrolling
            else if (type == typeof(PatrollingScheduleInformetion))
            {
                repository = (IBaseRepository<T>)PatrollingScheduleInformetionRepo;
            }
            else if (type == typeof(OtherPatrollingMember))
            {
                repository = (IBaseRepository<T>)OtherPatrollingMemberRepo;
            }

            // InternalLoan
            else if (type == typeof(InternalLoanInformation))
            {
                repository = (IBaseRepository<T>)InternalLoanInformationRepo;
            }
            else if (type == typeof(RepaymentInternalLoan))
            {
                repository = (IBaseRepository<T>)RepaymentInternalLoanRepo;
            }
            else if (type == typeof(InternalLoanInformationFile))
            {
                repository = (IBaseRepository<T>)InternalLoanInformationFileRepo;
            }


            // PatrollingSchedulingInformetion
            else if (type == typeof(PatrollingSchedulingMember))
            {
                repository = (IBaseRepository<T>)PatrollingSchedulingMemberRepo;
            }
            else if (type == typeof(PatrollingSchedulingParticipentsMap))
            {
                repository = (IBaseRepository<T>)PatrollingSchedulingParticipentsMapRepo;
            }
            else if (type == typeof(PatrollingScheduling))
            {
                repository = (IBaseRepository<T>)PatrollingSchedulingRepo;
            }
            else if (type == typeof(PatrollingSchedulingFile))
            {
                repository = (IBaseRepository<T>)PatrollingSchedulingFileRepo;
            }
            else if (type == typeof(CommitteeManagement))
            {
                repository = (IBaseRepository<T>)CommitteeManagementRepository;
            }
            else if (type == typeof(CommitteeManagementMember))
            {
                repository = (IBaseRepository<T>)CommitteeManagementMemberRepository;
            }
            // Archive
            else if (type == typeof(RegistrationArchive))
            {
                repository = (IBaseRepository<T>)RegistrationArchiveRepository;
            }
            else if (type == typeof(RegistrationArchiveFile))
            {
                repository = (IBaseRepository<T>)RegistrationArchiveFileRepository;
            }
            // CipManagement
            else if (type == typeof(CipTeam))
            {
                repository = (IBaseRepository<T>)CipTeamRepository;
            }
            else if (type == typeof(CipTeamMember))
            {
                repository = (IBaseRepository<T>)CipTeamMemberRepository;
            }
            else if (type == typeof(SurveyDocument))
            {
                repository = (IBaseRepository<T>)SurveyDocumentRepository;
            }
            //NecessaryLinkManagement
            else if (type == typeof(NecessaryLink))
            {
                repository = (IBaseRepository<T>)NecessaryLinkRepository;
            }
            //CommitteeTypeConfiguration
            else if (type == typeof(CommitteeTypeConfiguration))
            {
                repository = (IBaseRepository<T>)CommitteeTypeConfigurationRepository;
            }
            else if (type == typeof(CommitteesConfiguration))
            {
                repository = (IBaseRepository<T>)CommitteesConfigurationRepository;
            }
            else if (type == typeof(CommitteeDesignationsConfiguration))
            {
                repository = (IBaseRepository<T>)CommitteeDesignationsConfigurationRepository;
            }
            //PermissionSettings
            else if (type == typeof(PermissionHeaderSettings))
            {
                repository = (IBaseRepository<T>)PermissionHeaderSettingsRepository;
            }
            else if (type == typeof(PermissionRowSettings))
            {
                repository = (IBaseRepository<T>)PermissionRowSettingsRepository;
            }
            else if (type == typeof(Account))
            {
                repository = (IBaseRepository<T>)AccountRepository;
            }
            //ApprovalLogForCfm
            else if (type == typeof(ApprovalLogForCfm))
            {
                repository = (IBaseRepository<T>)ApprovalLogForCfmRepository;
            }
            //Accounts User Tag Log
            else if (type == typeof(AccountsUserTagLog))
            {
                repository = (IBaseRepository<T>)AccountsUserTagLogRepository;
            }
            else if (type == typeof(SourceOfFund))
            {
                repository = (IBaseRepository<T>)SourceOfFundRepository;
            }
            else if (type == typeof(AccountTransfer))
            {
                repository = (IBaseRepository<T>)AccountTransferRepository;
            }
            else if (type == typeof(AccountTransferLog))
            {
                repository = (IBaseRepository<T>)AccountTransferLogRepository;
            }
            else if (type == typeof(AccountDeposit))
            {
                repository = (IBaseRepository<T>)AccountDepositRepository;
            }
            //Submission History For Mobile
            else if (type == typeof(BeneficiarySubmissionHistory))
            {
                repository = (IBaseRepository<T>)BeneficiarySubmissionHistoryRepository;
            }
            //Bank Accounts Information
            else if (type == typeof(BankAccountsInformation))
            {
                repository = (IBaseRepository<T>)BankAccountsInformationRepository;
            }
            //Social Forestry Training
            else if (type == typeof(EventTypeForTraining))
            {
                repository = (IBaseRepository<T>)EventTypeForTrainingRepository;
            }
            else if (type == typeof(TrainerDesignationForTraining))
            {
                repository = (IBaseRepository<T>)TrainerDesignationForTrainingRepository;
            }
            else if (type == typeof(TrainingOrganizerForTraining))
            {
                repository = (IBaseRepository<T>)TrainingOrganizerForTrainingRepository;
            }
            else if (type == typeof(FinancialYearForTraining))
            {
                repository = (IBaseRepository<T>)FinancialYearForTrainingRepository;
            }
            //Social Forestry Training(Main)
            else if (type == typeof(SocialForestryTraining))
            {
                repository = (IBaseRepository<T>)SocialForestryTrainingRepository;
            }
            else if (type == typeof(SocialForestryTrainingParticipentsMap))
            {
                repository = (IBaseRepository<T>)SocialForestryTrainingParticipentsMapRepository;
            }
            else if (type == typeof(SocialForestryTrainingFile))
            {
                repository = (IBaseRepository<T>)SocialForestryTrainingFileRepository;
            }
            else if (type == typeof(SocialForestryTrainingMember))
            {
                repository = (IBaseRepository<T>)SocialForestryTrainingMemberRepository;
            }
            //Social Forestry Meeting
            else if (type == typeof(MeetingTypeForSocialForestryMeeting))
            {
                repository = (IBaseRepository<T>)MeetingTypeForSocialForestryMeetingRepository;
            }
            //Social Forestry Meeting(Main)
            else if (type == typeof(SocialForestryMeetingMember))
            {
                repository = (IBaseRepository<T>)SocialForestryMeetingMemberRepository;
            }
            else if (type == typeof(SocialForestryMeetingParticipentsMap))
            {
                repository = (IBaseRepository<T>)SocialForestryMeetingParticipentsMapRepository;
            }
            else if (type == typeof(SocialForestryMeetingFile))
            {
                repository = (IBaseRepository<T>)SocialForestryMeetingFileRepository;
            }
            else if (type == typeof(SocialForestryMeeting))
            {
                repository = (IBaseRepository<T>)SocialForestryMeetingRepository;
            }

            #region Social Forestry
            else if (type == typeof(ConcernedOfficial))
            {
                repository = (IBaseRepository<T>)ConcernedOfficialRepository;
            }
            else if (type == typeof(CostInformation))
            {
                repository = (IBaseRepository<T>)CostInformationRepository;
            }
            else if (type == typeof(CostInformationFile))
            {
                repository = (IBaseRepository<T>)CostInformationFileRepository;
            }
            else if (type == typeof(CostType))
            {
                repository = (IBaseRepository<T>)CostTypeRepository;
            }
            else if (type == typeof(InspectionDetails))
            {
                repository = (IBaseRepository<T>)InspectionDetailsRepository;
            }
            else if (type == typeof(LaborCostType))
            {
                repository = (IBaseRepository<T>)LaborCostTypeRepository;
            }
            else if (type == typeof(LaborInformation))
            {
                repository = (IBaseRepository<T>)LaborInformationRepository;
            }
            else if (type == typeof(LaborInformationFile))
            {
                repository = (IBaseRepository<T>)LaborInformationFileRepository;
            }
            else if (type == typeof(LandOwningAgency))
            {
                repository = (IBaseRepository<T>)LandOwningAgencyRepository;
            }
            else if (type == typeof(NewRaisedPlantation))
            {
                repository = (IBaseRepository<T>)NewRaisedPlantationRepository;
            }
            else if (type == typeof(PlantationCauseOfDamage))
            {
                repository = (IBaseRepository<T>)PlantationCauseOfDamageRepository;
            }
            else if (type == typeof(PlantationDamageInformation))
            {
                repository = (IBaseRepository<T>)PlantationDamageInformationRepository;
            }
            else if (type == typeof(PlantationFile))
            {
                repository = (IBaseRepository<T>)PlantationFileRepository;
            }
            else if (type == typeof(PlantationPlant))
            {
                repository = (IBaseRepository<T>)PlantationPlantRepository;
            }
            else if (type == typeof(PlantationSocialForestryBeneficiaryMap))
            {
                repository = (IBaseRepository<T>)PlantationSocialForestryBeneficiaryMapRepository;
            }
            else if (type == typeof(PlantationTopography))
            {
                repository = (IBaseRepository<T>)PlantationTopographyRepository;
            }
            else if (type == typeof(PlantationType))
            {
                repository = (IBaseRepository<T>)PlantationTypeRepository;
            }
            else if (type == typeof(PlantationUnit))
            {
                repository = (IBaseRepository<T>)PlantationUnitRepository;
            }
            else if (type == typeof(ProjectType))
            {
                repository = (IBaseRepository<T>)ProjectTypeRepository;
            }
            else if (type == typeof(SocialForestryBeneficiary))
            {
                repository = (IBaseRepository<T>)SocialForestryBeneficiaryRepository;
            }
            else if (type == typeof(SocialForestryDesignation))
            {
                repository = (IBaseRepository<T>)SocialForestryDesignationRepository;
            }
            else if (type == typeof(SocialForestryNgo))
            {
                repository = (IBaseRepository<T>)SocialForestryNgoRepository;
            }
            else if (type == typeof(ZoneOrArea))
            {
                repository = (IBaseRepository<T>)ZoneOrAreaRepository;
            }

            // Nursery

            else if (type == typeof(NurseryType))
            {
                repository = (IBaseRepository<T>)NurseryTypeRepository;
            }
            else if (type == typeof(NurseryRaisingSector))
            {
                repository = (IBaseRepository<T>)NurseryRaisingSectorRepository;
            }
            else if (type == typeof(NurseryRaisedSeedlingInformation))
            {
                repository = (IBaseRepository<T>)NurseryRaisedSeedlingInformationRepository;
            }
            else if (type == typeof(NurseryInformation))
            {
                repository = (IBaseRepository<T>)NurseryInformationRepository;
            }
            else if (type == typeof(NurseryCostInformation))
            {
                repository = (IBaseRepository<T>)NurseryCostInformationRepository;
            }

            else if (type == typeof(NurseryCostInformationFile))
            {
                repository = (IBaseRepository<T>)NurseryCostInformationFileRepository;
            }

            else if (type == typeof(NurseryDistribution))
            {
                repository = (IBaseRepository<T>)NurseryDistributionRepository;
            }

            #endregion
            return repository;
        }

        public virtual async Task<(ExecutionState executionState, string message)> SaveAsync(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                if (Guid.TryParse(transaction.TransactionId.ToString(), out Guid transactionGuid))
                {
                    try
                    {
                        await WriteOnlyCtx.SaveChangesAsync();
                        return (executionState: ExecutionState.Success, message: "Transaction completed.");
                    }
                    catch (Exception ex)
                    {
                        return (executionState: ExecutionState.Failure, message: ex.Message);
                    }
                }
                else
                {
                    return (executionState: ExecutionState.Failure, message: "Transaction not found.");
                }
            }
            else
            {
                return (executionState: ExecutionState.Failure, message: "Transaction not found.");
            }
        }
        public async Task<(ExecutionState executionState, T entity, string message)> CreateAsync<T>(T entity) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select(entity);

            (ExecutionState executionState, T entity, string message) createdEntity = await repository.CreateAsync(entity);

            return createdEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) retrievedEntity = await repository.GetAsync(id);
            return retrievedEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> UpdateAsync<T>(T entity) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select(entity);
            (ExecutionState executionState, T entity, string message) updateEntity = await repository.UpdateAsync(entity);
            return updateEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> RemoveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) removeEntity = await repository.RemoveAsync(id);
            return removeEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> GetAsync<T>
            (FilterOptions<T> filterOptions, RetrievalPurpose retrievalPurpose = RetrievalPurpose.Consumption)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState retrievedEntityExecutionState, T retrievedEntity, string retrievedEntityMessage) =
                await repository.GetAsync(filterOptions, retrievalPurpose);

            return (executionState: retrievedEntityExecutionState, entity: retrievedEntity, message: retrievedEntityMessage);
        }
        public async Task<(ExecutionState executionState, IQueryable<T> entity, string message)> List<T>(QueryOptions<T> queryOptions = null) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState retrievedEntitiesExecutionState, IQueryable<T> retrievedEntities, string retrievedEntitiesMessage) =
                await repository.List(queryOptions);

            return (executionState: retrievedEntitiesExecutionState, entity: retrievedEntities, message: retrievedEntitiesMessage);
        }
        public async Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(FilterOptions<T> filterOptions)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState entitityExistsExecutionState, string entitityExistsMessage) =
                await repository.DoesExistAsync(filterOptions);

            return (executionState: entitityExistsExecutionState, message: entitityExistsMessage);
        }
        public async Task<(ExecutionState executionState, long entityCount, string message)> CountAsync<T>(CountOptions<T> countOptions = null)
            where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            (ExecutionState entitiesCountExecutionState, long entitiesCount, string entityCountMessage) =
                await repository.CountAsync(countOptions);

            return (executionState: entitiesCountExecutionState, entityCount: entitiesCount, message: entityCountMessage);
        }
        public async Task<(ExecutionState executionState, T entity, string message)> MarkAsActiveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) activeEntity = await repository.MarkAsActiveAsync(id);
            return activeEntity;
        }
        public async Task<(ExecutionState executionState, T entity, string message)> MarkAsInactiveAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, T entity, string message) inactiveEntity = await repository.MarkAsInactiveAsync(id);
            return inactiveEntity;
        }
        public async Task<(ExecutionState executionState, string message)> DoesExistAsync<T>(long id) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();
            (ExecutionState executionState, string message) doesExist = await repository.DoesExistAsync(id);
            return doesExist;
        }

        #endregion

        public void Dispose()
        {
            WriteOnlyCtx?.Dispose();
            ReadOnlyCtx?.Dispose();

            GC.SuppressFinalize(this);
        }

        public Task<(ExecutionState executionState, bool isDeleted, string message)> SoftDeleteAsync<T>(long id, long userId) where T : BaseEntity
        {
            IBaseRepository<T> repository = Select<T>();

            return repository.SoftDeleteAsync(id, userId);
        }

        public static implicit operator GENERICUnitOfWork(GENERICReadOnlyCtx v)
        {
            throw new NotImplementedException();
        }
    }
}
