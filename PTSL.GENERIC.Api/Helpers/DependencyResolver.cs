using Microsoft.Extensions.DependencyInjection;

using PTSL.GENERIC.Business.Businesses.Implementation;
using PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Implementation.AIG;
using PTSL.GENERIC.Business.Businesses.Implementation.ApprovalLog;
using PTSL.GENERIC.Business.Businesses.Implementation.Archive;
using PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Implementation.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Implementation.Capacity;
using PTSL.GENERIC.Business.Businesses.Implementation.CipManagement;
using PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Implementation.GeneralSetup;
using PTSL.GENERIC.Business.Businesses.Implementation.InternalLoan;
using PTSL.GENERIC.Business.Businesses.Implementation.Labour;
using PTSL.GENERIC.Business.Businesses.Implementation.Market;
using PTSL.GENERIC.Business.Businesses.Implementation.NecessaryLinkManagement;
using PTSL.GENERIC.Business.Businesses.Implementation.Patrolling;
using PTSL.GENERIC.Business.Businesses.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Business.Businesses.Implementation.PermissionSettings;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Reforestation;
//using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryMeeting;
//using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryPatrollingSchedule;
using PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryTraining;
using PTSL.GENERIC.Business.Businesses.Implementation.Students;
using PTSL.GENERIC.Business.Businesses.Implementation.SubmissionHistoryForMobile;
using PTSL.GENERIC.Business.Businesses.Implementation.SystemUser;
using PTSL.GENERIC.Business.Businesses.Implementation.Trades;
using PTSL.GENERIC.Business.Businesses.Implementation.TransactionMangement;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.ApprovalLog;
using PTSL.GENERIC.Business.Businesses.Interface.Archive;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.CipManagement;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Business.Businesses.Interface.GeneralSetup;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Business.Businesses.Interface.Market;
using PTSL.GENERIC.Business.Businesses.Interface.NecessaryLinkManagement;
using PTSL.GENERIC.Business.Businesses.Interface.Patrolling;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Business.Businesses.Interface.PermissionSettings;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
//using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting;
//using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryPatrollingSchedule;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Business.Businesses.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.Business.Businesses.Interface.SystemUser;
using PTSL.GENERIC.Business.Businesses.Interface.Trades;
using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Business.TokenHelper;
using PTSL.GENERIC.DAL.Repositories.Implementation;
using PTSL.GENERIC.DAL.Repositories.Implementation.AccountManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.AIG;
using PTSL.GENERIC.DAL.Repositories.Implementation.ApprovalLog;
using PTSL.GENERIC.DAL.Repositories.Implementation.Archive;
using PTSL.GENERIC.DAL.Repositories.Implementation.Beneficiary;
using PTSL.GENERIC.DAL.Repositories.Implementation.Capacity;
using PTSL.GENERIC.DAL.Repositories.Implementation.CipManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.ForestManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.GeneralSetup;
using PTSL.GENERIC.DAL.Repositories.Implementation.InternalLoan;
using PTSL.GENERIC.DAL.Repositories.Implementation.Labour;
using PTSL.GENERIC.DAL.Repositories.Implementation.NecessaryLinkManagement;
using PTSL.GENERIC.DAL.Repositories.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.Repositories.Implementation.PermissionSettings;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Reforestation;
//using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryMeeting;
//using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryPatrollingSchedule;
using PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Implementation.SubmissionHistoryForMobile;
using PTSL.GENERIC.DAL.Repositories.Implementation.SystemUser;
using PTSL.GENERIC.DAL.Repositories.Implementation.TransactionMangement;
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
//using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryMeeting;
//using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryPatrollingSchedule;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestryTraining;
using PTSL.GENERIC.DAL.Repositories.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.DAL.Repositories.Interface.SystemUser;
using PTSL.GENERIC.DAL.Repositories.Interface.TransactionMangement;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.AccountManagement;
using PTSL.GENERIC.Service.Services.AIG;
using PTSL.GENERIC.Service.Services.ApprovalLog;
using PTSL.GENERIC.Service.Services.Archive;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.CipManagement;
using PTSL.GENERIC.Service.Services.ForestManagement;
using PTSL.GENERIC.Service.Services.GeneralSetup;
using PTSL.GENERIC.Service.Services.Implementation;
using PTSL.GENERIC.Service.Services.Implementation.Capacity;
using PTSL.GENERIC.Service.Services.Implementation.Labour;
using PTSL.GENERIC.Service.Services.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Service.Services.Implementation.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.Services.Implementation.SystemUser;
using PTSL.GENERIC.Service.Services.Interface;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Service.Services.Interface.Labour;
using PTSL.GENERIC.Service.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Service.Services.Interface.SystemUser;
using PTSL.GENERIC.Service.Services.InternalLoan;
using PTSL.GENERIC.Service.Services.Labour;
using PTSL.GENERIC.Service.Services.Market;
using PTSL.GENERIC.Service.Services.NecessaryLinkManagement;
using PTSL.GENERIC.Service.Services.Patrolling;
using PTSL.GENERIC.Service.Services.PermissionSettings;
using PTSL.GENERIC.Service.Services.SocialForestry;
using PTSL.GENERIC.Service.Services.SocialForestry.Cutting;
using PTSL.GENERIC.Service.Services.SocialForestry.Nursery;
using PTSL.GENERIC.Service.Services.SocialForestry.Reforestation;
//using PTSL.GENERIC.Service.Services.SocialForestry;
using PTSL.GENERIC.Service.Services.SocialForestryMeeting;
//using PTSL.GENERIC.Service.Services.SocialForestryPatrollingSchedule;
using PTSL.GENERIC.Service.Services.SocialForestryTraining;
using PTSL.GENERIC.Service.Services.Students;
using PTSL.GENERIC.Service.Services.SubmissionHistoryForMobile;
using PTSL.GENERIC.Service.Services.Trades;
using PTSL.GENERIC.Service.Services.TransactionMangement;

namespace PTSL.GENERIC.Api.Helpers
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependecyResolver(this IServiceCollection services)
        {
            //UOW
            services.AddScoped<IGENERICUnitOfWork, GENERICUnitOfWork>();

            // Repository
            AddScopedForRepository(services);

            // Services
            AddScopedForService(services);

            // Business
            AddScopedForBusiness(services);

            services.AddSingleton<FileHelper>();
            services.AddSingleton<IGenerateJSONWebToken, GenerateJSONWebToken>();

            services.AddScoped<ISurveyDocumentService, SurveyDocumentService>();
            services.AddScoped<ISurveyDocumentBusiness, SurveyDocumentBusiness>();
            services.AddScoped<ISurveyDocumentRepository, SurveyDocumentRepository>();
            services.AddScoped<ITransactionFilesService, TransactionFilesService>();

            // Services
            services.AddScoped<IDistributedToBeneficiaryService, DistributedToBeneficiaryService>();
            services.AddScoped<IDistributionFundTypeService, DistributionFundTypeService>();
            services.AddScoped<IDistributionPercentageService, DistributionPercentageService>();
            services.AddScoped<IShareDistributionService, ShareDistributionService>();

            // Business
            services.AddScoped<IDistributedToBeneficiaryBusiness, DistributedToBeneficiaryBusiness>();
            services.AddScoped<IDistributionFundTypeBusiness, DistributionFundTypeBusiness>();
            services.AddScoped<IDistributionPercentageBusiness, DistributionPercentageBusiness>();
            services.AddScoped<IShareDistributionBusiness, ShareDistributionBusiness>();

            // Repository
            services.AddScoped<IDistributedToBeneficiaryRepository, DistributedToBeneficiaryRepository>();
            services.AddScoped<IDistributionFundTypeRepository, DistributionFundTypeRepository>();
            services.AddScoped<IDistributionPercentageRepository, DistributionPercentageRepository>();
            services.AddScoped<IShareDistributionRepository, ShareDistributionRepository>();

            services.AddScoped<IAccountTransferApprovalService, AccountTransferApprovalService>();
            services.AddScoped<IAccountTransferApprovalBusiness, AccountTransferApprovalBusiness>();
            services.AddScoped<IAccountTransferApprovalRepository, AccountTransferApprovalRepository>();

            return services;
        }

        private static void AddScopedForBusiness(IServiceCollection services)
        {
            services.AddScoped<IRealizationBusiness, RealizationBusiness>();
            services.AddScoped<IReplantationBusiness, ReplantationBusiness>();
            services.AddScoped<IReplantationCostInfoBusiness, ReplantationCostInfoBusiness>();
            services.AddScoped<IReplantationInspectionMapBusiness, ReplantationInspectionMapBusiness>();
            services.AddScoped<IReplantationLaborInfoBusiness, ReplantationLaborInfoBusiness>();
            services.AddScoped<IReplantationNurseryInfoBusiness, ReplantationNurseryInfoBusiness>();
            services.AddScoped<IReplantationSocialForestryBeneficiaryMapBusiness, ReplantationSocialForestryBeneficiaryMapBusiness>();
            services.AddScoped<IReplantationDamageInfoBusiness, ReplantationDamageInfoBusiness>();

            services.AddScoped<ICuttingPlantationBusiness, CuttingPlantationBusiness>();
            services.AddScoped<ILotWiseSellingInformationBusiness, LotWiseSellingInformationBusiness>();

            services.AddScoped<IRefreshTokenBusiness, RefreshTokenBusiness>();
            services.AddScoped<ITransactionFilesBusiness, TransactionFilesBusiness>();

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserGroupBusiness, UserGroupBusiness>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IDistrictBusiness, DistrictBusiness>();
            services.AddScoped<IDivisionBusiness, DivisionBusiness>();
            services.AddScoped<IUpazillaBusiness, UpazillaBusiness>();
            services.AddScoped<IColorBusiness, ColorBusiness>();
            services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
            services.AddScoped<IAccesslistBusiness, AccesslistBusiness>();
            services.AddScoped<IAccessMapperBusiness, AccessMapperBusiness>();
            services.AddScoped<IModuleBusiness, ModuleBusiness>();
            services.AddScoped<IPmsGroupBusiness, PmsGroupBusiness>();
            services.AddScoped<IMarketingBusiness, MarketingBusiness>();
            services.AddScoped<IUnionBusiness, UnionBusiness>();
            services.AddScoped<IFinancialYearBusiness, FinancialYearBusiness>();

            services.AddScoped<ICipBusiness, CipBusiness>();
            services.AddScoped<ICipFileBusiness, CipFileBusiness>();

            // Beneficiary
            services.AddScoped<IForestCircleBusiness, ForestCircleBusiness>();
            services.AddScoped<IForestBeatBusiness, ForestBeatBusiness>();
            services.AddScoped<IForestDivisionBusiness, ForestDivisionBusiness>();
            services.AddScoped<IForestRangeBusiness, ForestRangeBusiness>();
            services.AddScoped<IForestFcvVcfBusiness, ForestFcvVcfBusiness>();
            services.AddScoped<IExistingSkillBusiness, ExistingSkillBusiness>();
            services.AddScoped<IAssetBusiness, AssetBusiness>();
            services.AddScoped<IAssetTypeBusiness, AssetTypeBusiness>();
            services.AddScoped<IEnergyTypeBusiness, EnergyTypeBusiness>();
            services.AddScoped<IEnergyUseBusiness, EnergyUseBusiness>();
            services.AddScoped<IImmovableAssetBusiness, ImmovableAssetBusiness>();
            services.AddScoped<IImmovableAssetTypeBusiness, ImmovableAssetTypeBusiness>();
            services.AddScoped<ILandOccupancyBusiness, LandOccupancyBusiness>();
            services.AddScoped<ILiveStockBusiness, LiveStockBusiness>();
            services.AddScoped<ILiveStockTypeBusiness, LiveStockTypeBusiness>();
            services.AddScoped<IFoodItemBusiness, FoodItemBusiness>();
            services.AddScoped<IFoodSecurityItemBusiness, FoodSecurityItemBusiness>();
            services.AddScoped<IBFDAssociationBusiness, BFDAssociationBusiness>();
            services.AddScoped<IDisabilityTypeBusiness, DisabilityTypeBusiness>();
            services.AddScoped<IHouseholdMemberBusiness, HouseholdMemberBusiness>();
            services.AddScoped<IOccupationBusiness, OccupationBusiness>();
            services.AddScoped<IRelationWithHeadHouseHoldTypeBusiness, RelationWithHeadHouseHoldTypeBusiness>();
            services.AddScoped<ISafetyNetBusiness, SafetyNetBusiness>();
            services.AddScoped<IBFDAssociationHouseholdMembersMapBusiness, BFDAssociationHouseholdMembersMapBusiness>();
            services.AddScoped<IDisabilityTypeHouseholdMembersMapBusiness, DisabilityTypeHouseholdMembersMapBusiness>();
            services.AddScoped<IAnnualHouseholdExpenditureBusiness, AnnualHouseholdExpenditureBusiness>();
            services.AddScoped<IExpenditureTypeBusiness, ExpenditureTypeBusiness>();
            services.AddScoped<IBusinessBusiness, BusinessBusiness>();
            services.AddScoped<IBusinessIncomeSourceTypeBusiness, BusinessIncomeSourceTypeBusiness>();
            services.AddScoped<IGrossMarginIncomeAndCostStatusBusiness, GrossMarginIncomeAndCostStatusBusiness>();
            services.AddScoped<IManualIncomeSourceTypeBusiness, ManualIncomeSourceTypeBusiness>();
            services.AddScoped<IManualPhysicalWorkBusiness, ManualPhysicalWorkBusiness>();
            services.AddScoped<INaturalIncomeSourceTypeBusiness, NaturalIncomeSourceTypeBusiness>();
            services.AddScoped<INaturalResourcesIncomeAndCostStatusBusiness, NaturalResourcesIncomeAndCostStatusBusiness>();
            services.AddScoped<IOtherIncomeSourceBusiness, OtherIncomeSourceBusiness>();
            services.AddScoped<IOtherIncomeSourceTypeBusiness, OtherIncomeSourceTypeBusiness>();
            services.AddScoped<IVulnerabilitySituationBusiness, VulnerabilitySituationBusiness>();
            services.AddScoped<IVulnerabilitySituationTypeBusiness, VulnerabilitySituationTypeBusiness>();
            services.AddScoped<IEthnicityBusiness, EthnicityBusiness>();
            services.AddScoped<INgoBusiness, NgoBusiness>();
            services.AddScoped<ISurveyBusiness, SurveyBusiness>();
            services.AddScoped<ISurveyIncidentBusiness, SurveyIncidentBusiness>();
            services.AddScoped<ITypeOfHouseBusiness, TypeOfHouseBusiness>();

            // Capacity
            services.AddScoped<ICommunityTrainingBusiness, CommunityTrainingBusiness>();
            services.AddScoped<ICommunityTrainingFileBusiness, CommunityTrainingFileBusiness>();
            services.AddScoped<ICommunityTrainingMemberBusiness, CommunityTrainingMemberBusiness>();
            services.AddScoped<ICommunityTrainingParticipentsMapBusiness, CommunityTrainingParticipentsMapBusiness>();
            services.AddScoped<ICommunityTrainingTypeBusiness, CommunityTrainingTypeBusiness>();

            services.AddScoped<IDepartmentalTrainingBusiness, DepartmentalTrainingBusiness>();
            services.AddScoped<IDepartmentalTrainingFileBusiness, DepartmentalTrainingFileBusiness>();
            services.AddScoped<IDepartmentalTrainingMemberBusiness, DepartmentalTrainingMemberBusiness>();
            services.AddScoped<IDepartmentalTrainingParticipentsMapBusiness, DepartmentalTrainingParticipentsMapBusiness>();
            services.AddScoped<IDepartmentalTrainingTypeBusiness, DepartmentalTrainingTypeBusiness>();
            services.AddScoped<IEventTypeBusiness, EventTypeBusiness>();
            services.AddScoped<ITrainingOrganizerBusiness, TrainingOrganizerBusiness>();

            //ForestManagement
            services.AddScoped<IOtherCommitteeMemberBusiness, OtherCommitteeMemberBusiness>();
            services.AddScoped<ICommitteeDesignationBusiness, CommitteeDesignationBusiness>();
            //Student
            services.AddScoped<IStudentBusiness, StudentBusiness>();

            // Labour
            services.AddScoped<IOtherLabourMemberBusiness, OtherLabourMemberBusiness>();
            services.AddScoped<ILabourDatabaseBusiness, LabourDatabaseBusiness>();
            services.AddScoped<ILabourWorkBusiness, LabourWorkBusiness>();
            services.AddScoped<ILabourDatabaseFileBusiness, LabourDatabaseFileBusiness>();


            //Trade
            services.AddScoped<ITradeBusiness, TradeBusiness>();

            services.AddScoped<IMeetingBusiness, MeetingBusiness>();
            services.AddScoped<IMeetingTypeBusiness, MeetingTypeBusiness>();
            services.AddScoped<IMeetingMemberBusiness, MeetingMemberBusiness>();
            services.AddScoped<IMeetingFileBusiness, MeetingFileBusiness>();
            services.AddScoped<IMeetingParticipantsMapBusiness, MeetingParticipantsMapBusiness>();

            // Transaction
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();
            services.AddScoped<IFundTypeBusiness, FundTypeBusiness>();

            //Beneficiary Savings Account
            services.AddScoped<ISavingsAccountBusiness, SavingsAccountBusiness>();
            services.AddScoped<ISavingsAmountInformationBusiness, SavingsAmountInformationBusiness>();
            services.AddScoped<IWithdrawAmountInformationBusiness, WithdrawAmountInformationBusiness>();

            // AIG
            services.AddScoped<IAIGBasicInformationBusiness, AIGBasicInformationBusiness>();
            services.AddScoped<IRepaymentLDFBusiness, RepaymentLDFBusiness>();
            services.AddScoped<IFirstSixtyPercentageLDFBusiness, FirstSixtyPercentageLDFBusiness>();
            services.AddScoped<ISecondFourtyPercentageLDFBusiness, SecondFourtyPercentageLDFBusiness>();
            services.AddScoped<ILDFProgressBusiness, LDFProgressBusiness>();
            services.AddScoped<IIndividualLDFInfoFormBusiness, IndividualLDFInfoFormBusiness>();
            services.AddScoped<IGroupLDFInfoFormBusiness, GroupLDFInfoFormBusiness>();
            services.AddScoped<IGroupLDFInfoFormMemberBusiness, GroupLDFInfoFormMemberBusiness>();
            services.AddScoped<IIndividualGroupFormSetupBusiness, IndividualGroupFormSetupBusiness>();
            services.AddScoped<IRepaymentLDFHistoryBusiness, RepaymentLDFHistoryBusiness>();
            services.AddScoped<IRepaymentLDFFileBusiness, RepaymentLDFFileBusiness>();


            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionBusiness, PatrollingScheduleInformetionBusiness>();
            services.AddScoped<IOtherPatrollingMemberBusiness, OtherPatrollingMemberBusiness>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationBusiness, InternalLoanInformationBusiness>();
            services.AddScoped<IRepaymentInternalLoanBusiness, RepaymentInternalLoanBusiness>();
            services.AddScoped<IInternalLoanInformationFileBusiness, InternalLoanInformationFileBusiness>();

            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberBusiness, PatrollingSchedulingMemberBusiness>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapBusiness, PatrollingSchedulingParticipentsMapBusiness>();
            services.AddScoped<IPatrollingSchedulingBusiness, PatrollingSchedulingBusiness>();
            services.AddScoped<IPatrollingSchedulingFileBusiness, PatrollingSchedulingFileBusiness>();

            services.AddScoped<ICommitteeManagementBusiness, CommitteeManagementBusiness>();
            services.AddScoped<ICommitteeManagementMemberBusiness, CommitteeManagementMemberBusiness>();
            // Archive
            services.AddScoped<IRegistrationArchiveBusiness, RegistrationArchiveBusiness>();
            services.AddScoped<IRegistrationArchiveFileBusiness, RegistrationArchiveFileBusiness>();

            // CipManagement
            services.AddScoped<ICipTeamBusiness, CipTeamBusiness>();
            services.AddScoped<ICipTeamMemberBusiness, CipTeamMemberBusiness>();

            // NecessaryLinkManagement
            services.AddScoped<INecessaryLinkBusiness, NecessaryLinkBusiness>();

            // CommitteeTypeConfiguration
            services.AddScoped<ICommitteeTypeConfigurationBusiness, CommitteeTypeConfigurationBusiness>();
            services.AddScoped<ICommitteesConfigurationBusiness, CommitteesConfigurationBusiness>();
            services.AddScoped<ICommitteeDesignationsConfigurationBusiness, CommitteeDesignationsConfigurationBusiness>();

            // PermissionSettings
            services.AddScoped<IPermissionHeaderSettingsBusiness, PermissionHeaderSettingsBusiness>();
            services.AddScoped<IPermissionRowSettingsBusiness, PermissionRowSettingsBusiness>();
            services.AddScoped<IAccountBusiness, AccountBusiness>();

            //ApprovalLogForCfm
            services.AddScoped<IApprovalLogForCfmBusiness, ApprovalLogForCfmBusiness>();

            //Accounts User Tag Log
            services.AddScoped<IAccountsUserTagLogBusiness, AccountsUserTagLogBusiness>();
            services.AddScoped<ISourceOfFundBusiness, SourceOfFundBusiness>();
            services.AddScoped<IAccountTransferBusiness, AccountTransferBusiness>();
            services.AddScoped<IAccountTransferLogBusiness, AccountTransferLogBusiness>();
            services.AddScoped<IAccountDepositBusiness, AccountDepositBusiness>();

            //Beneficiary Submission History
            services.AddScoped<IBeneficiarySubmissionHistoryBusiness, BeneficiarySubmissionHistoryBusiness>();

            //Bank Accounts Information
            services.AddScoped<IBankAccountsInformationBusiness, BankAccountsInformationBusiness>();

            //Social Forestry Training
            services.AddScoped<IEventTypeForTrainingBusiness, EventTypeForTrainingBusiness>();
            services.AddScoped<ITrainerDesignationForTrainingBusiness, TrainerDesignationForTrainingBusiness>();
            services.AddScoped<ITrainingOrganizerForTrainingBusiness, TrainingOrganizerForTrainingBusiness>();
            services.AddScoped<IFinancialYearForTrainingBusiness, FinancialYearForTrainingBusiness>();
            //Social Forestry Training(Main)
            services.AddScoped<ISocialForestryTrainingBusiness, SocialForestryTrainingBusiness>();
            services.AddScoped<ISocialForestryTrainingParticipentsMapBusiness, SocialForestryTrainingParticipentsMapBusiness>();
            services.AddScoped<ISocialForestryTrainingFileBusiness, SocialForestryTrainingFileBusiness>();
            services.AddScoped<ISocialForestryTrainingMemberBusiness, SocialForestryTrainingMemberBusiness>();

            //Social Forestry Meeting
            services.AddScoped<IMeetingTypeForSocialForestryMeetingBusiness, MeetingTypeForSocialForestryMeetingBusiness>();
            //Social Forestry Meeting(Main)
            services.AddScoped<ISocialForestryMeetingMemberBusiness, SocialForestryMeetingMemberBusiness>();
            services.AddScoped<ISocialForestryMeetingParticipentsMapBusiness, SocialForestryMeetingParticipentsMapBusiness>();
            services.AddScoped<ISocialForestryMeetingFileBusiness, SocialForestryMeetingFileBusiness>();
            services.AddScoped<ISocialForestryMeetingBusiness, SocialForestryMeetingBusiness>();


            #region Social Forestry

            services.AddScoped<IConcernedOfficialBusiness, ConcernedOfficialBusiness>();
            services.AddScoped<ICostInformationBusiness, CostInformationBusiness>();
            services.AddScoped<ICostInformationFileBusiness, CostInformationFileBusiness>();
            services.AddScoped<ICostTypeBusiness, CostTypeBusiness>();
            services.AddScoped<IInspectionDetailsBusiness, InspectionDetailsBusiness>();
            services.AddScoped<ILaborCostTypeBusiness, LaborCostTypeBusiness>();
            services.AddScoped<ILaborInformationBusiness, LaborInformationBusiness>();
            services.AddScoped<ILaborInformationFileBusiness, LaborInformationFileBusiness>();
            services.AddScoped<ILandOwningAgencyBusiness, LandOwningAgencyBusiness>();
            services.AddScoped<INewRaisedPlantationBusiness, NewRaisedPlantationBusiness>();
            services.AddScoped<IPlantationCauseOfDamageBusiness, PlantationCauseOfDamageBusiness>();
            services.AddScoped<IPlantationDamageInformationBusiness, PlantationDamageInformationBusiness>();
            services.AddScoped<IPlantationFileBusiness, PlantationFileBusiness>();
            services.AddScoped<IPlantationPlantBusiness, PlantationPlantBusiness>();
            services.AddScoped<IPlantationSocialForestryBeneficiaryMapBusiness, PlantationSocialForestryBeneficiaryMapBusiness>();
            services.AddScoped<IPlantationTopographyBusiness, PlantationTopographyBusiness>();
            services.AddScoped<IPlantationTypeBusiness, PlantationTypeBusiness>();
            services.AddScoped<IPlantationUnitBusiness, PlantationUnitBusiness>();
            services.AddScoped<IProjectTypeBusiness, ProjectTypeBusiness>();
            services.AddScoped<ISocialForestryBeneficiaryBusiness, SocialForestryBeneficiaryBusiness>();
            services.AddScoped<ISocialForestryDesignationBusiness, SocialForestryDesignationBusiness>();
            services.AddScoped<ISocialForestryNgoBusiness, SocialForestryNgoBusiness>();
            services.AddScoped<IZoneOrAreaBusiness, ZoneOrAreaBusiness>();
            services.AddScoped<INurseryCostInformationBusiness, NurseryCostInformationBusiness>();
            services.AddScoped<INurseryCostInformationFileBusiness, NurseryCostInformationFileBusiness>();


            //Nursery

            services.AddScoped<INurseryTypeBusiness, NurseryTypeBusiness>();
            services.AddScoped<INurseryRaisingSectorBusiness, NurseryRaisingSectorBusiness>();
            services.AddScoped<INurseryRaisedSeedlingInformationBusiness, NurseryRaisedSeedlingInformationBusiness>();
            services.AddScoped<INurseryInformationBusiness, NurseryInformationBusiness>();
            services.AddScoped<INurseryDistributionBusiness, NurseryDistributionBusiness>();

            #endregion

        }

        private static void AddScopedForService(IServiceCollection services)
        {
            services.AddScoped<IRealizationService, RealizationService>();
            services.AddScoped<IReplantationService, ReplantationService>();
            services.AddScoped<IReplantationCostInfoService, ReplantationCostInfoService>();
            services.AddScoped<IReplantationInspectionMapService, ReplantationInspectionMapService>();
            services.AddScoped<IReplantationLaborInfoService, ReplantationLaborInfoService>();
            services.AddScoped<IReplantationNurseryInfoService, ReplantationNurseryInfoService>();
            services.AddScoped<IReplantationSocialForestryBeneficiaryMapService, ReplantationSocialForestryBeneficiaryMapService>();
            services.AddScoped<IReplantationDamageInfoService, ReplantationDamageInfoService>();

            services.AddScoped<ICuttingPlantationService, CuttingPlantationService>();
            services.AddScoped<ILotWiseSellingInformationService, LotWiseSellingInformationService>();

            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IUpazillaService, UpazillaService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IUnionService, UnionService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IAccesslistService, AccesslistService>();
            services.AddScoped<IAccessMapperService, AccessMapperService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IPmsGroupService, PmsGroupService>();
            services.AddScoped<IFinancialYearService, FinancialYearService>();

            services.AddScoped<ICipService, CipService>();
            services.AddScoped<ICipFileService, CipFileService>();

            // Beneficiary
            services.AddScoped<IForestCircleService, ForestCircleService>();
            services.AddScoped<IForestBeatService, ForestBeatService>();
            services.AddScoped<IForestDivisionService, ForestDivisionService>();
            services.AddScoped<IForestRangeService, ForestRangeService>();
            services.AddScoped<IForestFcvVcfService, ForestFcvVcfService>();
            services.AddScoped<IExistingSkillService, ExistingSkillService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IAssetTypeService, AssetTypeService>();
            services.AddScoped<IEnergyTypeService, EnergyTypeService>();
            services.AddScoped<IEnergyUseService, EnergyUseService>();
            services.AddScoped<IImmovableAssetService, ImmovableAssetService>();
            services.AddScoped<IImmovableAssetTypeService, ImmovableAssetTypeService>();
            services.AddScoped<ILandOccupancyService, LandOccupancyService>();
            services.AddScoped<ILiveStockService, LiveStockService>();
            services.AddScoped<ILiveStockTypeService, LiveStockTypeService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
            services.AddScoped<IFoodSecurityItemService, FoodSecurityItemService>();
            services.AddScoped<IBFDAssociationService, BFDAssociationService>();
            services.AddScoped<IDisabilityTypeService, DisabilityTypeService>();
            services.AddScoped<IHouseholdMemberService, HouseholdMemberService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IRelationWithHeadHouseHoldTypeService, RelationWithHeadHouseHoldTypeService>();
            services.AddScoped<ISafetyNetService, SafetyNetService>();
            services.AddScoped<IBFDAssociationHouseholdMembersMapService, BFDAssociationHouseholdMembersMapService>();
            services.AddScoped<IDisabilityTypeHouseholdMembersMapService, DisabilityTypeHouseholdMembersMapService>();
            services.AddScoped<IAnnualHouseholdExpenditureService, AnnualHouseholdExpenditureService>();
            services.AddScoped<IExpenditureTypeService, ExpenditureTypeService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IBusinessIncomeSourceTypeService, BusinessIncomeSourceTypeService>();
            services.AddScoped<IGrossMarginIncomeAndCostStatusService, GrossMarginIncomeAndCostStatusService>();
            services.AddScoped<IManualIncomeSourceTypeService, ManualIncomeSourceTypeService>();
            services.AddScoped<IManualPhysicalWorkService, ManualPhysicalWorkService>();
            services.AddScoped<INaturalIncomeSourceTypeService, NaturalIncomeSourceTypeService>();
            services.AddScoped<INaturalResourcesIncomeAndCostStatusService, NaturalResourcesIncomeAndCostStatusService>();
            services.AddScoped<IOtherIncomeSourceService, OtherIncomeSourceService>();
            services.AddScoped<IOtherIncomeSourceTypeService, OtherIncomeSourceTypeService>();
            services.AddScoped<IVulnerabilitySituationService, VulnerabilitySituationService>();
            services.AddScoped<IVulnerabilitySituationTypeService, VulnerabilitySituationTypeService>();
            services.AddScoped<IEthnicityService, EthnicityService>();
            services.AddScoped<INgoService, NgoService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IMarketingService, MarketingService>();
            services.AddScoped<ISurveyIncidentService, SurveyIncidentService>();
            services.AddScoped<ITypeOfHouseService, TypeOfHouseService>();

            // Capacity
            services.AddScoped<ICommunityTrainingService, CommunityTrainingService>();
            services.AddScoped<ICommunityTrainingFileService, CommunityTrainingFileService>();
            services.AddScoped<ICommunityTrainingTypeService, CommunityTrainingTypeService>();
            services.AddScoped<ICommunityTrainingMemberService, CommunityTrainingMemberService>();
            services.AddScoped<ICommunityTrainingParticipentsMapService, CommunityTrainingParticipentsMapService>();

            services.AddScoped<IDepartmentalTrainingService, DepartmentalTrainingService>();
            services.AddScoped<IDepartmentalTrainingFileService, DepartmentalTrainingFileService>();
            services.AddScoped<IDepartmentalTrainingTypeService, DepartmentalTrainingTypeService>();
            services.AddScoped<IDepartmentalTrainingMemberService, DepartmentalTrainingMemberService>();
            services.AddScoped<IDepartmentalTrainingParticipentsMapService, DepartmentalTrainingParticipentsMapService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<ITrainingOrganizerService, TrainingOrganizerService>();

            //ForestManagement
            services.AddScoped<IOtherCommitteeMemberService, OtherCommitteeMemberService>();
            services.AddScoped<ICommitteeDesignationService, CommitteeDesignationService>();

            //Student
            services.AddScoped<IStudentService, StudentService>();

            //Labour
            services.AddScoped<IOtherLabourMemberService, OtherLabourMemberService>();
            services.AddScoped<ILabourDatabaseService, LabourDatabaseService>();
            services.AddScoped<ILabourWorkService, LabourWorkService>();
            services.AddScoped<ILabourDatabaseFileService, LabourDatabaseFileService>();

            //Trade
            services.AddScoped<ITradeService, TradeService>();

            services.AddScoped<IMeetingService, MeetingService>();
            services.AddScoped<IMeetingTypeService, MeetingTypeService>();
            services.AddScoped<IMeetingMemberService, MeetingMemberService>();
            services.AddScoped<IMeetingFileService, MeetingFileService>();
            services.AddScoped<IMeetingParticipantsMapService, MeetingParticipantsMapService>();


            // Transaction
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IFundTypeService, FundTypeService>();

            //Beneficiary Savings Account
            services.AddScoped<ISavingsAccountService, SavingsAccountService>();
            services.AddScoped<ISavingsAmountInformationService, SavingsAmountInformationService>();
            services.AddScoped<IWithdrawAmountInformationService, WithdrawAmountInformationService>();

            // AIG
            services.AddScoped<IAIGBasicInformationService, AIGBasicInformationService>();
            services.AddScoped<IRepaymentLDFService, RepaymentLDFService>();
            services.AddScoped<IFirstSixtyPercentageLDFService, FirstSixtyPercentageLDFService>();
            services.AddScoped<ISecondFourtyPercentageLDFService, SecondFourtyPercentageLDFService>();
            services.AddScoped<ILDFProgressService, LDFProgressService>();
            services.AddScoped<IIndividualLDFInfoFormService, IndividualLDFInfoFormService>();
            services.AddScoped<IGroupLDFInfoFormService, GroupLDFInfoFormService>();
            services.AddScoped<IGroupLDFInfoFormMemberService, GroupLDFInfoFormMemberService>();
            services.AddScoped<IIndividualGroupFormSetupService, IndividualGroupFormSetupService>();
            services.AddScoped<IRepaymentLDFHistoryService, RepaymentLDFHistoryService>();
            services.AddScoped<IRepaymentLDFFileService, RepaymentLDFFileService>();

            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionService, PatrollingScheduleInformetionService>();
            services.AddScoped<IOtherPatrollingMemberService, OtherPatrollingMemberService>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationService, InternalLoanInformationService>();
            services.AddScoped<IRepaymentInternalLoanService, RepaymentInternalLoanService>();
            services.AddScoped<IInternalLoanInformationFileService, InternalLoanInformationFileService>();

            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberService, PatrollingSchedulingMemberService>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapService, PatrollingSchedulingParticipentsMapService>();
            services.AddScoped<IPatrollingSchedulingService, PatrollingSchedulingService>();
            services.AddScoped<IPatrollingSchedulingFileService, PatrollingSchedulingFileService>();

            services.AddScoped<ICommitteeManagementService, CommitteeManagementService>();
            services.AddScoped<ICommitteeManagementMemberService, CommitteeManagementMemberService>();

            // Archive
            services.AddScoped<IRegistrationArchiveService, RegistrationArchiveService>();
            services.AddScoped<IRegistrationArchiveFileService, RegistrationArchiveFileService>();

            // CipManagement
            services.AddScoped<ICipTeamService, CipTeamService>();
            services.AddScoped<ICipTeamMemberService, CipTeamMemberService>();

            // NecessaryLinkManagement
            services.AddScoped<INecessaryLinkService, NecessaryLinkService>();

            // CommitteeTypeConfiguration
            services.AddScoped<ICommitteeTypeConfigurationService, CommitteeTypeConfigurationService>();
            services.AddScoped<ICommitteesConfigurationService, CommitteesConfigurationService>();
            services.AddScoped<ICommitteeDesignationsConfigurationService, CommitteeDesignationsConfigurationService>();

            // PermissionSettings
            services.AddScoped<IPermissionHeaderSettingsService, PermissionHeaderSettingsService>();
            services.AddScoped<IPermissionRowSettingsService, PermissionRowSettingsService>();
            services.AddScoped<IAccountService, AccountService>();

            //ApprovalLogForCfm
            services.AddScoped<IApprovalLogForCfmService, ApprovalLogForCfmService>();

            //Accounts User Tag Log
            services.AddScoped<IAccountsUserTagLogService, AccountsUserTagLogService>();
            services.AddScoped<ISourceOfFundService, SourceOfFundService>();
            services.AddScoped<IAccountTransferService, AccountTransferService>();
            services.AddScoped<IAccountTransferLogService, AccountTransferLogService>();
            services.AddScoped<IAccountDepositService, AccountDepositService>();

            //Beneficiary Submission History
            services.AddScoped<IBeneficiarySubmissionHistoryService, BeneficiarySubmissionHistoryService>();

            //Bank Accounts Information
            services.AddScoped<IBankAccountsInformationService, BankAccountsInformationService>();

            //Social Forestry Training
            services.AddScoped<IEventTypeForTrainingService, EventTypeForTrainingService>();
            services.AddScoped<ITrainerDesignationForTrainingService, TrainerDesignationForTrainingService>();
            services.AddScoped<ITrainingOrganizerForTrainingService, TrainingOrganizerForTrainingService>();
            services.AddScoped<IFinancialYearForTrainingService, FinancialYearForTrainingService>();
            //Social Forestry Training(Main)
            services.AddScoped<ISocialForestryTrainingService, SocialForestryTrainingService>();
            services.AddScoped<ISocialForestryTrainingParticipentsMapService, SocialForestryTrainingParticipentsMapService>();
            services.AddScoped<ISocialForestryTrainingFileService, SocialForestryTrainingFileService>();
            services.AddScoped<ISocialForestryTrainingMemberService, SocialForestryTrainingMemberService>();

            //Social Forestry Meeting
            services.AddScoped<IMeetingTypeForSocialForestryMeetingService, MeetingTypeForSocialForestryMeetingService>();
            //Social Forestry Meeting(Main)
            services.AddScoped<ISocialForestryMeetingMemberService, SocialForestryMeetingMemberService>();
            services.AddScoped<ISocialForestryMeetingParticipentsMapService, SocialForestryMeetingParticipentsMapService>();
            services.AddScoped<ISocialForestryMeetingFileService, SocialForestryMeetingFileService>();
            services.AddScoped<ISocialForestryMeetingService, SocialForestryMeetingService>();

            #region Social Forestry

            services.AddScoped<IConcernedOfficialService, ConcernedOfficialService>();
            services.AddScoped<ICostInformationService, CostInformationService>();
            services.AddScoped<ICostInformationFileService, CostInformationFileService>();
            services.AddScoped<ICostTypeService, CostTypeService>();
            services.AddScoped<IInspectionDetailsService, InspectionDetailsService>();
            services.AddScoped<ILaborCostTypeService, LaborCostTypeService>();
            services.AddScoped<ILaborInformationService, LaborInformationService>();
            services.AddScoped<ILaborInformationFileService, LaborInformationFileService>();
            services.AddScoped<ILandOwningAgencyService, LandOwningAgencyService>();
            services.AddScoped<INewRaisedPlantationService, NewRaisedPlantationService>();
            services.AddScoped<IPlantationCauseOfDamageService, PlantationCauseOfDamageService>();
            services.AddScoped<IPlantationDamageInformationService, PlantationDamageInformationService>();
            services.AddScoped<IPlantationFileService, PlantationFileService>();
            services.AddScoped<IPlantationPlantService, PlantationPlantService>();
            services.AddScoped<IPlantationSocialForestryBeneficiaryMapService, PlantationSocialForestryBeneficiaryMapService>();
            services.AddScoped<IPlantationTopographyService, PlantationTopographyService>();
            services.AddScoped<IPlantationTypeService, PlantationTypeService>();
            services.AddScoped<IPlantationUnitService, PlantationUnitService>();
            services.AddScoped<IProjectTypeService, ProjectTypeService>();
            services.AddScoped<ISocialForestryBeneficiaryService, SocialForestryBeneficiaryService>();
            services.AddScoped<ISocialForestryDesignationService, SocialForestryDesignationService>();
            services.AddScoped<ISocialForestryNgoService, SocialForestryNgoService>();
            services.AddScoped<IZoneOrAreaService, ZoneOrAreaService>();

            services.AddScoped<INurseryCostInformationService, NurseryCostInformationService>();
            services.AddScoped<INurseryCostInformationFileService, NurseryCostInformationFileService>();

            //Nursery

            services.AddScoped<INurseryTypeService, NurseryTypeService>();
            services.AddScoped<INurseryRaisingSectorService, NurseryRaisingSectorService>();
            services.AddScoped<INurseryRaisedSeedlingInformationService, NurseryRaisedSeedlingInformationService>();
            services.AddScoped<INurseryInformationService, NurseryInformationService>();
            services.AddScoped<INurseryDistributionService, NurseryDistributionService>();

            #endregion

        }

        private static void AddScopedForRepository(IServiceCollection services)
        {
            services.AddScoped<IRealizationRepository, RealizationRepository>();
            services.AddScoped<IReplantationRepository, ReplantationRepository>();
            services.AddScoped<IReplantationCostInfoRepository, ReplantationCostInfoRepository>();
            services.AddScoped<IReplantationInspectionMapRepository, ReplantationInspectionMapRepository>();
            services.AddScoped<IReplantationLaborInfoRepository, ReplantationLaborInfoRepository>();
            services.AddScoped<IReplantationNurseryInfoRepository, ReplantationNurseryInfoRepository>();
            services.AddScoped<IReplantationSocialForestryBeneficiaryMapRepository, ReplantationSocialForestryBeneficiaryMapRepository>();
            services.AddScoped<IReplantationDamageInfoRepository, ReplantationDamageInfoRepository>();

            services.AddScoped<ICuttingPlantationRepository, CuttingPlantationRepository>();
            services.AddScoped<ILotWiseSellingInformationRepository, LotWiseSellingInformationRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ITransactionFilesRepository, TransactionFilesRepository>();

            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IUpazillaRepository, UpazillaRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IAccesslistRepository, AccesslistRepository>();
            services.AddScoped<IAccessMapperRepository, AccessMapperRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPmsGroupRepository, PmsGroupRepository>();
            services.AddScoped<IUnionRepository, UnionRepository>();
            services.AddScoped<IFinancialYearRepository, FinancialYearRepository>();

            services.AddScoped<ICipRepository, CipRepository>();
            services.AddScoped<ICipFileRepository, CipFileRepository>();

            // Beneficiary
            services.AddScoped<IForestCircleRepository, ForestCircleRepository>();
            services.AddScoped<IForestBeatRepository, ForestBeatRepository>();
            services.AddScoped<IForestDivisionRepository, ForestDivisionRepository>();
            services.AddScoped<IForestRangeRepository, ForestRangeRepository>();
            services.AddScoped<IForestFcvVcfRepository, ForestFcvVcfRepository>();
            services.AddScoped<IExistingSkillRepository, ExistingSkillRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
            services.AddScoped<IEnergyTypeRepository, EnergyTypeRepository>();
            services.AddScoped<IEnergyUseRepository, EnergyUseRepository>();
            services.AddScoped<IImmovableAssetRepository, ImmovableAssetRepository>();
            services.AddScoped<IImmovableAssetTypeRepository, ImmovableAssetTypeRepository>();
            services.AddScoped<ILandOccupancyRepository, LandOccupancyRepository>();
            services.AddScoped<ILiveStockRepository, LiveStockRepository>();
            services.AddScoped<ILiveStockTypeRepository, LiveStockTypeRepository>();
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IFoodSecurityItemRepository, FoodSecurityItemRepository>();
            services.AddScoped<IBFDAssociationRepository, BFDAssociationRepository>();
            services.AddScoped<IDisabilityTypeRepository, DisabilityTypeRepository>();
            services.AddScoped<IHouseholdMemberRepository, HouseholdMemberRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IRelationWithHeadHouseHoldTypeRepository, RelationWithHeadHouseHoldTypeRepository>();
            services.AddScoped<ISafetyNetRepository, SafetyNetRepository>();
            services.AddScoped<IBFDAssociationHouseholdMembersMapRepository, BFDAssociationHouseholdMembersMapRepository>();
            services.AddScoped<IDisabilityTypeHouseholdMembersMapRepository, DisabilityTypeHouseholdMembersMapRepository>();
            services.AddScoped<IAnnualHouseholdExpenditureRepository, AnnualHouseholdExpenditureRepository>();
            services.AddScoped<IExpenditureTypeRepository, ExpenditureTypeRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessIncomeSourceTypeRepository, BusinessIncomeSourceTypeRepository>();
            services.AddScoped<IGrossMarginIncomeAndCostStatusRepository, GrossMarginIncomeAndCostStatusRepository>();
            services.AddScoped<IManualIncomeSourceTypeRepository, ManualIncomeSourceTypeRepository>();
            services.AddScoped<IManualPhysicalWorkRepository, ManualPhysicalWorkRepository>();
            services.AddScoped<INaturalIncomeSourceTypeRepository, NaturalIncomeSourceTypeRepository>();
            services.AddScoped<INaturalResourcesIncomeAndCostStatusRepository, NaturalResourcesIncomeAndCostStatusRepository>();
            services.AddScoped<IOtherIncomeSourceRepository, OtherIncomeSourceRepository>();
            services.AddScoped<IOtherIncomeSourceTypeRepository, OtherIncomeSourceTypeRepository>();
            services.AddScoped<IVulnerabilitySituationRepository, VulnerabilitySituationRepository>();
            services.AddScoped<IVulnerabilitySituationTypeRepository, VulnerabilitySituationTypeRepository>();
            services.AddScoped<IEthnicityRepository, EthnicityRepository>();
            services.AddScoped<INgoRepository, NgoRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IMarketingRepository, MarketingRepository>();
            services.AddScoped<ISurveyIncidentRepository, SurveyIncidentRepository>();
            services.AddScoped<ITypeOfHouseRepository, TypeOfHouseRepository>();

            // Capacity
            services.AddScoped<ICommunityTrainingRepository, CommunityTrainingRepository>();
            services.AddScoped<ICommunityTrainingFileRepository, CommunityTrainingFileRepository>();
            services.AddScoped<ICommunityTrainingMemberRepository, CommunityTrainingMemberRepository>();
            services.AddScoped<ICommunityTrainingParticipentsMapRepository, CommunityTrainingParticipentsMapRepository>();
            services.AddScoped<ICommunityTrainingTypeRepository, CommunityTrainingTypeRepository>();

            services.AddScoped<IDepartmentalTrainingRepository, DepartmentalTrainingRepository>();
            services.AddScoped<IDepartmentalTrainingFileRepository, DepartmentalTrainingFileRepository>();
            services.AddScoped<IDepartmentalTrainingMemberRepository, DepartmentalTrainingMemberRepository>();
            services.AddScoped<IDepartmentalTrainingParticipentsMapRepository, DepartmentalTrainingParticipentsMapRepository>();
            services.AddScoped<IDepartmentalTrainingTypeRepository, DepartmentalTrainingTypeRepository>();
            services.AddScoped<IEventTypeRepository, EventTypeRepository>();
            services.AddScoped<ITrainingOrganizerRepository, TrainingOrganizerRepository>();

            //ForestManagement
            services.AddScoped<IOtherCommitteeMemberRepository, OtherCommitteeMemberRepository>();
            services.AddScoped<ISubCommitteeDesignationRepository, SubCommitteeDesignationRepository>();
            //Student
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Labour
            services.AddScoped<IOtherLabourMemberRepository, OtherLabourMemberRepository>();
            services.AddScoped<ILabourDatabaseRepository, LabourDatabaseRepository>();
            services.AddScoped<ILabourDatabaseFileRepository, LabourDatabaseFileRepository>();

            //Trade
            services.AddScoped<ITradeRepository, TradeRepository>();

            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddScoped<IMeetingTypeRepository, MeetingTypeRepository>();
            services.AddScoped<IMeetingMemberRepository, MeetingMemberRepository>();
            services.AddScoped<IMeetingFileRepository, MeetingFileRepository>();
            services.AddScoped<IMeetingParticipantsMapRepository, MeetingParticipantsMapRepository>();


            // Transaction
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IFundTypeRepository, FundTypeRepository>();

            //Beneficiary Savings Account
            services.AddScoped<ISavingsAccountRepository, SavingsAccountRepository>();
            services.AddScoped<ISavingsAmountInformationRepository, SavingsAmountInformationRepository>();
            services.AddScoped<IWithdrawAmountInformationRepository, WithdrawAmountInformationRepository>();

            // AIG
            services.AddScoped<IAIGBasicInformationRepository, AIGBasicInformationRepository>();
            services.AddScoped<IRepaymentLDFRepository, RepaymentLDFRepository>();
            services.AddScoped<IFirstSixtyPercentageLDFRepository, FirstSixtyPercentageLDFRepository>();
            services.AddScoped<ISecondFourtyPercentageLDFRepository, SecondFourtyPercentageLDFRepository>();
            services.AddScoped<ILDFProgressRepository, LDFProgressRepository>();
            services.AddScoped<IIndividualLDFInfoFormRepository, IndividualLDFInfoFormRepository>();
            services.AddScoped<IGroupLDFInfoFormRepository, GroupLDFInfoFormRepository>();
            services.AddScoped<IGroupLDFInfoFormMemberRepository, GroupLDFInfoFormMemberRepository>();
            services.AddScoped<IIndividualGroupFormSetupRepository, IndividualGroupFormSetupRepository>();
            services.AddScoped<IRepaymentLDFHistoryRepository, RepaymentLDFHistoryRepository>();
            services.AddScoped<IRepaymentLDFFileRepository, RepaymentLDFFileRepository>();

            // Patrolling
            services.AddScoped<IPatrollingScheduleInformetionRepository, PatrollingScheduleInformetionRepository>();
            services.AddScoped<ILabourWorkRepository, LabourWorkRepository>();
            services.AddScoped<IOtherPatrollingMemberRepository, OtherPatrollingMemberRepository>();

            // InternalLoan
            services.AddScoped<IInternalLoanInformationRepository, InternalLoanInformationRepository>();
            services.AddScoped<IRepaymentInternalLoanRepository, RepaymentInternalLoanRepository>();
            services.AddScoped<IInternalLoanInformationFileRepository, InternalLoanInformationFileRepository>();

            // PatrollingSchedulingInformetion
            services.AddScoped<IPatrollingSchedulingMemberRepository, PatrollingSchedulingMemberRepository>();
            services.AddScoped<IPatrollingSchedulingParticipentsMapRepository, PatrollingSchedulingParticipentsMapRepository>();
            services.AddScoped<IPatrollingSchedulingRepository, PatrollingSchedulingRepository>();
            services.AddScoped<IPatrollingSchedulingFileRepository, PatrollingSchedulingFileRepository>();

            services.AddScoped<ICommitteeManagementRepository, CommitteeManagementRepository>();
            services.AddScoped<ICommitteeManagementMemberRepository, CommitteeManagementMemberRepository>();
            // Archive
            services.AddScoped<IRegistrationArchiveRepository, RegistrationArchiveRepository>();
            services.AddScoped<IRegistrationArchiveFileRepository, RegistrationArchiveFileRepository>();
            // CipManagement
            services.AddScoped<ICipTeamRepository, CipTeamRepository>();
            services.AddScoped<ICipTeamMemberRepository, CipTeamMemberRepository>();

            // NecessaryLinkManagement
            services.AddScoped<INecessaryLinkRepository, NecessaryLinkRepository>();

            // CommitteeTypeConfiguration
            services.AddScoped<ICommitteeTypeConfigurationRepository, CommitteeTypeConfigurationRepository>();
            services.AddScoped<ICommitteesConfigurationRepository, CommitteesConfigurationRepository>();
            services.AddScoped<ICommitteeDesignationsConfigurationRepository, CommitteeDesignationsConfigurationRepository>();


            // PermissionSettings
            services.AddScoped<IPermissionHeaderSettingsRepository, PermissionHeaderSettingsRepository>();
            services.AddScoped<IPermissionRowSettingsRepository, PermissionRowSettingsRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            //ApprovalLogForCfm
            services.AddScoped<IApprovalLogForCfmRepository, ApprovalLogForCfmRepository>();

            //Accounts User Tag Log
            services.AddScoped<IAccountsUserTagLogRepository, AccountsUserTagLogRepository>();
            services.AddScoped<ISourceOfFundRepository, SourceOfFundRepository>();
            services.AddScoped<IAccountTransferRepository, AccountTransferRepository>();
            services.AddScoped<IAccountTransferLogRepository, AccountTransferLogRepository>();
            services.AddScoped<IAccountDepositRepository, AccountDepositRepository>();

            //Beneficiary Submission History
            services.AddScoped<IBeneficiarySubmissionHistoryRepository, BeneficiarySubmissionHistoryRepository>();

            //Bank Accounts Information
            services.AddScoped<IBankAccountsInformationRepository, BankAccountsInformationRepository>();

            //Social Forestry Training
            services.AddScoped<IEventTypeForTrainingRepository, EventTypeForTrainingRepository>();
            services.AddScoped<ITrainerDesignationForTrainingRepository, TrainerDesignationForTrainingRepository>();
            services.AddScoped<ITrainingOrganizerForTrainingRepository, TrainingOrganizerForTrainingRepository>();
            services.AddScoped<IFinancialYearForTrainingRepository, FinancialYearForTrainingRepository>();
            //Social Forestry Training(Main)
            services.AddScoped<ISocialForestryTrainingRepository, SocialForestryTrainingRepository>();
            services.AddScoped<ISocialForestryTrainingParticipentsMapRepository, SocialForestryTrainingParticipentsMapRepository>();
            services.AddScoped<ISocialForestryTrainingFileRepository, SocialForestryTrainingFileRepository>();
            services.AddScoped<ISocialForestryTrainingMemberRepository, SocialForestryTrainingMemberRepository>();

            //Social Forestry Meeting
            services.AddScoped<IMeetingTypeForSocialForestryMeetingRepository, MeetingTypeForSocialForestryMeetingRepository>();
            //Social Forestry Meeting(Main)
            services.AddScoped<ISocialForestryMeetingMemberRepository, SocialForestryMeetingMemberRepository>();
            services.AddScoped<ISocialForestryMeetingParticipentsMapRepository, SocialForestryMeetingParticipentsMapRepository>();
            services.AddScoped<ISocialForestryMeetingFileRepository, SocialForestryMeetingFileRepository>();
            services.AddScoped<ISocialForestryMeetingRepository, SocialForestryMeetingRepository>();


            #region Social Forestry

            services.AddScoped<IConcernedOfficialRepository, ConcernedOfficialRepository>();
            services.AddScoped<ICostInformationRepository, CostInformationRepository>();
            services.AddScoped<ICostInformationFileRepository, CostInformationFileRepository>();
            services.AddScoped<ICostTypeRepository, CostTypeRepository>();
            services.AddScoped<IInspectionDetailsRepository, InspectionDetailsRepository>();
            services.AddScoped<ILaborCostTypeRepository, LaborCostTypeRepository>();
            services.AddScoped<ILaborInformationRepository, LaborInformationRepository>();
            services.AddScoped<ILaborInformationFileRepository, LaborInformationFileRepository>();
            services.AddScoped<ILandOwningAgencyRepository, LandOwningAgencyRepository>();
            services.AddScoped<INewRaisedPlantationRepository, NewRaisedPlantationRepository>();
            services.AddScoped<IPlantationCauseOfDamageRepository, PlantationCauseOfDamageRepository>();
            services.AddScoped<IPlantationDamageInformationRepository, PlantationDamageInformationRepository>();
            services.AddScoped<IPlantationFileRepository, PlantationFileRepository>();
            services.AddScoped<IPlantationPlantRepository, PlantationPlantRepository>();
            services.AddScoped<IPlantationSocialForestryBeneficiaryMapRepository, PlantationSocialForestryBeneficiaryMapRepository>();
            services.AddScoped<IPlantationTopographyRepository, PlantationTopographyRepository>();
            services.AddScoped<IPlantationTypeRepository, PlantationTypeRepository>();
            services.AddScoped<IPlantationUnitRepository, PlantationUnitRepository>();
            services.AddScoped<IProjectTypeRepository, ProjectTypeRepository>();
            services.AddScoped<ISocialForestryBeneficiaryRepository, SocialForestryBeneficiaryRepository>();
            services.AddScoped<ISocialForestryDesignationRepository, SocialForestryDesignationRepository>();
            services.AddScoped<ISocialForestryNgoRepository, SocialForestryNgoRepository>();
            services.AddScoped<IZoneOrAreaRepository, ZoneOrAreaRepository>();
            services.AddScoped<INurseryCostInformationRepository, NurseryCostInformationRepository>();

            services.AddScoped<INurseryCostInformationFileRepository, NurseryCostInformationFileRepository>();


            //Nursery

            services.AddScoped<INurseryTypeRepository, NurseryTypeRepository>();
            services.AddScoped<INurseryRaisingSectorRepository, NurseryRaisingSectorRepository>();
            services.AddScoped<INurseryRaisedSeedlingInformationRepository, NurseryRaisedSeedlingInformationRepository>();
            services.AddScoped<INurseryInformationRepository, NurseryInformationRepository>();
            services.AddScoped<INurseryDistributionRepository, NurseryDistributionRepository>();

            #endregion
        }
    }
}
