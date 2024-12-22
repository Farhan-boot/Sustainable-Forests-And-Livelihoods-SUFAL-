using System;
using System.Linq;

using AutoMapper;

using Microsoft.OpenApi.Extensions;

using PTSL.GENERIC.Business;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Archive;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.Dashboard;
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
//using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.Students;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Common.Model.EntityViewModels.Archive;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Common.Model.EntityViewModels.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Model.EntityViewModels.PermissionSettings;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.Students;
using PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Model.EntityViewModels.Trade;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

namespace PTSL.GENERIC.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //general setup
            base.CreateMap<Category, CategoryVM>().ReverseMap();
            base.CreateMap<District, DistrictVM>().ReverseMap();
            base.CreateMap<Division, DivisionVM>()
                .ForMember(x => x.DistrictList, y => y.MapFrom(z => z.Districts)).ReverseMap();
            base.CreateMap<Upazilla, UpazillaVM>()
                .ForMember(x => x.District, y => y.MapFrom(z => z.District)).ReverseMap();

            //User Manager
            base.CreateMap<User, UserVM>().ReverseMap(); //Source to Destination
            base.CreateMap<UserGroup, UserGroupVM>().ReverseMap();

            base.CreateMap<Color, ColorVM>().ReverseMap();
            base.CreateMap<UserRole, UserRoleVM>().ReverseMap();
            base.CreateMap<Accesslist, AccesslistVM>().ReverseMap();
            base.CreateMap<AccessMapper, AccessMapperVM>().ReverseMap();
            base.CreateMap<Module, ModuleVM>().ReverseMap();
            base.CreateMap<PmsGroup, PmsGroupVM>().ReverseMap();
            //Marketing
            base.CreateMap<Marketing, MarketingVM>().ReverseMap();
            base.CreateMap<Union, UnionVM>().ReverseMap();
            base.CreateMap<FinancialYear, FinancialYearVM>()
                .ForMember(x => x.IsCurrent, y => y.MapFrom(z => z.StartYear <= DateTime.Now.Year && DateTime.Now.Year <= z.EndYear))
                .ReverseMap();
            //Trade
            base.CreateMap<Trade, TradeVM>().ReverseMap();
            //ForestManagement
            base.CreateMap<CommitteeDesignation, CommitteeDesignationVM>().ReverseMap();

            base.CreateMap<Cip, CipVM>().ReverseMap();
            base.CreateMap<CipFile, CipFileVM>().ReverseMap();
            base.CreateMap<PaginationResutl<Cip>, PaginationResutl<CipVM>>();


            base.CreateMap<OtherCommitteeMember, OtherCommitteeMemberVM>().ReverseMap();
            //Student
            base.CreateMap<Student, StudentVM>().ReverseMap();
            base.CreateMap<EconomicStatusModel, EconomicStatusModelVM>();
            base.CreateMap<SocioEconomicStatusModel, SocioEconomicStatusModelVM>();

            //Labour
            base.CreateMap<LabourDatabaseFile, LabourDatabaseFileVM>().ReverseMap();
            base.CreateMap<OtherLabourMember, OtherLabourMemberVM>().ReverseMap();
            base.CreateMap<LabourDatabase, LabourDatabaseVM>()
                .ForMember(x => x.OtherLabourMemberId, y => y.MapFrom(x => x.OtherLabourMemberId))
                .ForMember(x => x.OtherLabourMember, y => y.MapFrom(x => x.OtherLabourMember))
                .ReverseMap();
            base.CreateMap<LabourWork, LabourWorkVM>().ReverseMap();
            base.CreateMap<PaginationResutl<LabourDatabase>, PaginationResutl<LabourDatabaseVM>>();



            base.CreateMap<Meeting, MeetingVM>().ReverseMap();
            base.CreateMap<MeetingFile, MeetingFileVM>().ReverseMap();
            base.CreateMap<MeetingType, MeetingTypeVM>().ReverseMap();
            base.CreateMap<MeetingMember, MeetingMemberVM>()
                .ReverseMap();
            base.CreateMap<MeetingParticipantsMap, MeetingParticipantsMapVM>()
                .ReverseMap();
            base.CreateMap<PaginationResutl<Meeting>, PaginationResutl<MeetingVM>>();


            //Beneficiary Savings Account
            base.CreateMap<SavingsAccount, SavingsAccountVM>().ReverseMap();
            base.CreateMap<SavingsAmountInformation, SavingsAmountInformationVM>().ReverseMap();
            base.CreateMap<WithdrawAmountInformation, WithdrawAmountInformationVM>().ReverseMap();
            base.CreateMap<PaginationResutl<SavingsAccount>, PaginationResutl<SavingsAccountVM>>();


            // Patrolling
            base.CreateMap<PatrollingScheduleInformetion, PatrollingScheduleInformetionVM>().ReverseMap();
            base.CreateMap<OtherPatrollingMember, OtherPatrollingMemberVM>().ReverseMap();

            // InternalLoan
            base.CreateMap<InternalLoanInformation, InternalLoanInformationVM>().ReverseMap();
            base.CreateMap<RepaymentInternalLoan, RepaymentInternalLoanVM>().ReverseMap();
            base.CreateMap<InternalLoanInformationFile, InternalLoanInformationFileVM>().ReverseMap();
            base.CreateMap<PaginationResutl<InternalLoanInformation>, PaginationResutl<InternalLoanInformationVM>>();


            // PatrollingSchedulingInformation
            base.CreateMap<PatrollingSchedulingMember, PatrollingSchedulingMemberVM>().ReverseMap();
            base.CreateMap<PatrollingSchedulingParticipentsMap, PatrollingSchedulingParticipentsMapVM>().ReverseMap();
            base.CreateMap<PatrollingScheduling, PatrollingSchedulingVM>().ReverseMap();
            base.CreateMap<PatrollingSchedulingFile, PatrollingSchedulingFileVM>().ReverseMap();
            base.CreateMap<PaginationResutl<PatrollingScheduling>, PaginationResutl<PatrollingSchedulingVM>>();



            // Committee Management
            base.CreateMap<CommitteeManagement, CommitteeManagementVM>().ReverseMap();
            base.CreateMap<CommitteeManagementMember, CommitteeManagementMemberVM>().ReverseMap();
            base.CreateMap<PaginationResutl<CommitteeManagement>, PaginationResutl<CommitteeManagementVM>>();
             

            // Archive
            base.CreateMap<RegistrationArchive, RegistrationArchiveVM>().ReverseMap();
            base.CreateMap<RegistrationArchiveFile, RegistrationArchiveFileVM>().ReverseMap();

            // CipManagement
            base.CreateMap<CipTeam, CipTeamVM>().ReverseMap();
            base.CreateMap<CipTeamMember, CipTeamMemberVM>().ReverseMap();
            base.CreateMap<PaginationResutl<CipTeam>, PaginationResutl<CipTeamVM>>();



            // NecessaryLinkManagement
            base.CreateMap<NecessaryLink, Common.Model.EntityViewModels.NecessaryLinkManagement.NecessaryLinkVM>().ReverseMap();

            //CommitteeTypeConfiguration
            base.CreateMap<CommitteeTypeConfiguration, CommitteeTypeConfigurationVM>().ReverseMap();
            base.CreateMap<CommitteesConfiguration, CommitteesConfigurationVM>().ReverseMap();
            base.CreateMap<CommitteeDesignationsConfiguration, CommitteeDesignationsConfigurationVM>().ReverseMap();

            //PermissionSettings
            base.CreateMap<PermissionHeaderSettings, PermissionHeaderSettingsVM>().ReverseMap();
            base.CreateMap<PermissionRowSettings, PermissionRowSettingsVM>().ReverseMap();

            base.CreateMap<Account, AccountVM>().ReverseMap();
            base.CreateMap<AccountDeposit, AccountDepositVM>().ReverseMap();
            base.CreateMap<AccountTransfer, AccountTransferVM>().ReverseMap();
            base.CreateMap<AccountTransferDetails, AccountTransferDetailsVM>().ReverseMap();
            base.CreateMap<AccountTransferLog, AccountTransferLogVM>().ReverseMap();
            base.CreateMap<SourceOfFund, SourceOfFundVM>().ReverseMap();
            base.CreateMap<PaginationResutl<Account>, PaginationResutl<AccountVM>>();
            base.CreateMap<PaginationResutl<AccountDeposit>, PaginationResutl<AccountDepositVM>>();


            //ApprovalLogForCfm
            base.CreateMap<ApprovalLogForCfm, ApprovalLogForCfmVM>().ReverseMap();

            //Accounts User Tag Log
            base.CreateMap<AccountsUserTagLog, AccountsUserTagLogVM>().ReverseMap();

            //Beneficiary Submission History
            base.CreateMap<BeneficiarySubmissionHistory, BeneficiarySubmissionHistoryVM>().ReverseMap();


            //BankAccounts Information
            base.CreateMap<BankAccountsInformation, BankAccountsInformationVM>().ReverseMap();


            //Social Forestry Training
            base.CreateMap<EventTypeForTraining, EventTypeForTrainingVM>().ReverseMap();
            base.CreateMap<TrainerDesignationForTraining, TrainerDesignationForTrainingVM>().ReverseMap();
            base.CreateMap<TrainingOrganizerForTraining, TrainingOrganizerForTrainingVM>().ReverseMap();
            base.CreateMap<FinancialYearForTraining, FinancialYearForTrainingVM>().ReverseMap();
            //Social Forestry Training(Main)
            base.CreateMap<SocialForestryTraining, SocialForestryTrainingVM>().ReverseMap();
            base.CreateMap<SocialForestryTrainingParticipentsMap, SocialForestryTrainingParticipentsMapVM>().ReverseMap();
            base.CreateMap<SocialForestryTrainingFile, SocialForestryTrainingFileVM>().ReverseMap();
            base.CreateMap<SocialForestryTrainingMember, SocialForestryTrainingMemberVM>().ReverseMap();

            //Social Forestry Meeting
            base.CreateMap<MeetingTypeForSocialForestryMeeting, MeetingTypeForSocialForestryMeetingVM>().ReverseMap();
            //Social Forestry Meeting(Main)
            base.CreateMap<SocialForestryMeetingMember, SocialForestryMeetingMemberVM>().ReverseMap();
            base.CreateMap<SocialForestryMeetingParticipentsMap, SocialForestryMeetingParticipentsMapVM>().ReverseMap();
            base.CreateMap<SocialForestryMeetingFile, SocialForestryMeetingFileVM>().ReverseMap();
            base.CreateMap<SocialForestryMeeting, SocialForestryMeetingVM>().ReverseMap();

            base.CreateMap<Replantation, ReplantationVM>().ReverseMap();
            base.CreateMap<ReplantationCostInfo, ReplantationCostInfoVM>().ReverseMap();
            base.CreateMap<ReplantationInspectionMap, ReplantationInspectionMapVM>().ReverseMap();
            base.CreateMap<ReplantationLaborInfo, ReplantationLaborInfoVM>().ReverseMap();
            base.CreateMap<ReplantationNurseryInfo, ReplantationNurseryInfoVM>().ReverseMap();
            base.CreateMap<ReplantationSocialForestryBeneficiaryMap, ReplantationSocialForestryBeneficiaryMapVM>().ReverseMap();
            base.CreateMap<ReplantationDamageInfo, ReplantationDamageInfoVM>().ReverseMap();
            base.CreateMap<CuttingPlantation, CuttingPlantationVM>().ReverseMap();
            base.CreateMap<LotWiseSellingInformation, LotWiseSellingInformationVM>().ReverseMap();

            #region Social Forestry

            base.CreateMap<ConcernedOfficial, ConcernedOfficialVM>().ReverseMap();
            base.CreateMap<CostInformation, CostInformationVM>().ReverseMap();
            base.CreateMap<CostInformationFile, CostInformationFileVM>().ReverseMap();
            base.CreateMap<CostType, CostTypeVM>().ReverseMap();
            base.CreateMap<InspectionDetails, InspectionDetailsVM>().ReverseMap();
            base.CreateMap<LaborCostType, LaborCostTypeVM>().ReverseMap();
            base.CreateMap<LaborInformation, LaborInformationVM>().ReverseMap();
            base.CreateMap<LaborInformationFile, LaborInformationFileVM>().ReverseMap();
            base.CreateMap<LandOwningAgency, LandOwningAgencyVM>().ReverseMap();
            base.CreateMap<NewRaisedPlantation, NewRaisedPlantationVM>().ReverseMap();
            base.CreateMap<PlantationCauseOfDamage, PlantationCauseOfDamageVM>().ReverseMap();
            base.CreateMap<PlantationDamageInformation, PlantationDamageInformationVM>().ReverseMap();
            base.CreateMap<PlantationFile, PlantationFileVM>().ReverseMap();
            base.CreateMap<PlantationPlant, PlantationPlantVM>().ReverseMap();
            base.CreateMap<PlantationSocialForestryBeneficiaryMap, PlantationSocialForestryBeneficiaryMapVM>().ReverseMap();
            base.CreateMap<PlantationTopography, PlantationTopographyVM>().ReverseMap();
            base.CreateMap<PlantationType, PlantationTypeVM>().ReverseMap();
            base.CreateMap<PlantationUnit, PlantationUnitVM>().ReverseMap();
            base.CreateMap<ProjectType, ProjectTypeVM>().ReverseMap();
            base.CreateMap<SocialForestryBeneficiary, SocialForestryBeneficiaryVM>().ReverseMap();
            base.CreateMap<SocialForestryDesignation, SocialForestryDesignationVM>().ReverseMap();
            base.CreateMap<SocialForestryNgo, SocialForestryNgoVM>().ReverseMap();
            base.CreateMap<ZoneOrArea, ZoneOrAreaVM>().ReverseMap();

            base.CreateMap<NurseryCostInformation, NurseryCostInformationVM>().ReverseMap();
            base.CreateMap<NurseryCostInformationFile, NurseryCostInformationFileVM>().ReverseMap();
            base.CreateMap<NurseryInformation, NurseryInformationVM>().ReverseMap();
            base.CreateMap<ConcernedOfficialMap, ConcernedOfficialMapVM>().ReverseMap();
            base.CreateMap<InspectionDetailsMap, InspectionDetailsMapVM>().ReverseMap();

            base.CreateMap<DistributedToBeneficiary, DistributedToBeneficiaryVM>().ReverseMap();
            base.CreateMap<DistributionFundType, DistributionFundTypeVM>().ReverseMap();
            base.CreateMap<DistributionPercentage, DistributionPercentageVM>().ReverseMap();
            base.CreateMap<ShareDistribution, ShareDistributionVM>().ReverseMap();

            //Nursery

            base.CreateMap<NurseryType, NurseryTypeVM>().ReverseMap();
            base.CreateMap<NurseryRaisingSector, NurseryRaisingSectorVM>().ReverseMap();
            base.CreateMap<NurseryRaisedSeedlingInformation, NurseryRaisedSeedlingInformationVM>().ReverseMap();
            base.CreateMap<NurseryDistribution, NurseryDistributionVM>().ReverseMap();
            //base.CreateMap<NurseryDistributionDetails, NurseryDistributionDetailsVM>().ReverseMap();

            base.CreateMap<AccountTransferApproval, AccountTransferApprovalVM>().ReverseMap();
            #endregion


            BeneficiaryMappings();
            CapacityMappings();
            TransactionMappings();
            AIGMappings();
        }

        private void AIGMappings()
        {
            var currentDate = DateTime.Now;

            base.CreateMap<AIGBasicInformation, AIGBasicInformationVM>().ReverseMap();
            base.CreateMap<FirstSixtyPercentageLDF, FirstSixtyPercentageLDFVM>().ReverseMap();
            base.CreateMap<SecondFourtyPercentageLDF, SecondFourtyPercentageLDFVM>().ReverseMap();
            base.CreateMap<IndividualLDFInfoForm, IndividualLDFInfoFormVM>().ReverseMap();
            base.CreateMap<PaginationResutl<IndividualLDFInfoForm>, PaginationResutl<IndividualLDFInfoFormVM>>();
            base.CreateMap<PaginationResutl<AIGBasicInformation>, PaginationResutl<AIGBasicInformationVM>>();


            base.CreateMap<GroupLDFInfoForm, GroupLDFInfoFormVM>()
                .ForMember(x => x.GroupLDFInfoFormMembers, y => y.MapFrom(x => x.GroupLDFInfoFormMembers))
                .ReverseMap();
            base.CreateMap<GroupLDFInfoFormMember, GroupLDFInfoFormMemberVM>()
                .ForMember(x => x.GroupLDFInfoForm, opt => opt.Ignore())
                //.ForMember(x => x.IndividualLDFInfoForm, opt => opt.Ignore())
                .ReverseMap();
            base.CreateMap<LDFProgress, LDFProgressVM>()
                .ForMember(x => x.RepaymentLDF, y => y.MapFrom(z => z.RepaymentLDF))
                .ReverseMap();
            base.CreateMap<RepaymentLDF, RepaymentLDFVM>()
                .ForMember(x => x.RepaymentAmount, y => y.MapFrom(z => z.FirstSixtyPercentRepaymentAmount + z.SecondFortyPercentRepaymentAmount))
                .ForMember(x => x.IsPast, y => y.MapFrom(z => z.RepaymentEndDate < currentDate))
                .ForMember(x => x.IsFuture, y => y.MapFrom(z => z.RepaymentStartDate > currentDate))
                .ForMember(x => x.IsCurrent, y => y.MapFrom(z => z.RepaymentStartDate <= currentDate && currentDate <= z.RepaymentEndDate))
                .ReverseMap();
            base.CreateMap<IndividualGroupFormSetup, IndividualGroupFormSetupVM>().ReverseMap();
            base.CreateMap<RepaymentLDFHistory, RepaymentLDFHistoryVM>()
                .ForMember(x => x.RepaymentLDFEventTypeString, y => y.MapFrom(z => z.RepaymentLDFEventType.ToString()))
                .ReverseMap();

            base.CreateMap<RepaymentLDFFile, RepaymentLDFFileVM>().ReverseMap();
        }

        private void TransactionMappings()
        {
            base.CreateMap<FundType, FundTypeVM>().ReverseMap();
            base.CreateMap<Transaction, TransactionVM>().ReverseMap();
            base.CreateMap<TransactionFiles, TransactionFilesVM>().ReverseMap();
            base.CreateMap<ExpenseDetailsForCDF, ExpenseDetailsForCDFVM>().ReverseMap();
        }

        private void BeneficiaryMappings()
        {
            // Forest Location
            base.CreateMap<ForestCircle, ForestCircleVM>()
                .ForMember(x => x.ForestDivisions, y => y.MapFrom(z => z.ForestDivisions)).ReverseMap();
            base.CreateMap<ForestDivision, ForestDivisionVM>()
                .ForMember(x => x.ForestCircle, y => y.MapFrom(z => z.ForestCircle))
                .ForMember(x => x.ForestRanges, y => y.MapFrom(z => z.ForestRanges))
                .ForMember(x => x.Surveys, y => y.MapFrom(z => z.Surveys)).ReverseMap();
            base.CreateMap<ForestRange, ForestRangeVM>()
                .ForMember(x => x.ForestDivision, y => y.MapFrom(z => z.ForestDivision))
                .ForMember(x => x.ForestBeats, y => y.MapFrom(z => z.ForestBeats))
                .ForMember(x => x.Surveys, y => y.MapFrom(z => z.Surveys)).ReverseMap();
            base.CreateMap<ForestBeat, ForestBeatVM>()
                .ForMember(x => x.ForestFcvVcfs, y => y.MapFrom(z => z.ForestFcvVcfs))
                .ForMember(x => x.ForestRange, y => y.MapFrom(z => z.ForestRange))
                .ForMember(x => x.Surveys, y => y.MapFrom(z => z.Surveys)).ReverseMap();
            base.CreateMap<ForestFcvVcf, ForestFcvVcfVM>()
                .ForMember(x => x.ForestBeat, y => y.MapFrom(z => z.ForestBeat))
                .ForMember(x => x.Surveys, y => y.MapFrom(z => z.Surveys)).ReverseMap();

            // Access to Resources and Services
            base.CreateMap<ExistingSkill, ExistingSkillVM>()
                .ForMember(x => x.SkillLevelEnumString, y => y.MapFrom(z => z.SkillLevelEnum.GetDisplayName()))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();

            // Economic Status
            base.CreateMap<Asset, AssetVM>()
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<AssetType, AssetTypeVM>()
                .ForMember(x => x.Assets, y => y.MapFrom(z => z.Assets)).ReverseMap();
            base.CreateMap<EnergyType, EnergyTypeVM>()
                .ForMember(x => x.EnergyUses, y => y.MapFrom(z => z.EnergyUses)).ReverseMap();
            base.CreateMap<EnergyUse, EnergyUseVM>()
                .ForMember(x => x.EnergyType, y => y.MapFrom(z => z.EnergyType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<ImmovableAsset, ImmovableAssetVM>()
                .ForMember(x => x.ImmovableAssetType, y => y.MapFrom(z => z.ImmovableAssetType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<ImmovableAssetType, ImmovableAssetTypeVM>()
                .ForMember(x => x.ImmovableAssets, y => y.MapFrom(z => z.ImmovableAssets)).ReverseMap();
            base.CreateMap<LandOccupancy, LandOccupancyVM>()
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<LiveStock, LiveStockVM>()
                .ForMember(x => x.LiveStockType, y => y.MapFrom(z => z.LiveStockType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<LiveStockType, LiveStockTypeVM>()
                .ForMember(x => x.LiveStocks, y => y.MapFrom(z => z.LiveStocks)).ReverseMap();

            // Food Security
            base.CreateMap<FoodItem, FoodItemVM>()
                .ForMember(x => x.FoodSecurityItems, y => y.MapFrom(z => z.FoodSecurityItems)).ReverseMap();
            base.CreateMap<FoodSecurityItem, FoodSecurityItemVM>()
                .ForMember(x => x.FoodItem, y => y.MapFrom(z => z.FoodItem))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();

            // Household Member
            base.CreateMap<BFDAssociation, BFDAssociationVM>()
                .ForMember(x => x.BFDAssociationHouseholdMembersMap, y => y.MapFrom(z => z.BFDAssociationHouseholdMembers)).ReverseMap();
            base.CreateMap<SafetyNet, SafetyNetVM>()
                .ForMember(x => x.HouseholdMembers, y => y.MapFrom(z => z.HouseholdMembers)).ReverseMap();
            base.CreateMap<DisabilityType, DisabilityTypeVM>()
                .ForMember(x => x.DisabilityTypeHouseholdMembersMap, y => y.MapFrom(z => z.DisabilityTypeHouseholdMembers)).ReverseMap();
            base.CreateMap<HouseholdMember, HouseholdMemberVM>()
                .ForMember(x => x.RelationWithHeadHouseHoldType, y => y.MapFrom(z => z.RelationWithHeadHouseHoldType))
                .ForMember(x => x.MainOccupation, y => y.MapFrom(z => z.MainOccupation))
                .ForMember(x => x.BFDAssociationHouseholdMembersMap, y => y.MapFrom(z => z.BFDAssociationHouseholdMembers))
                .ForMember(x => x.DisabilityTypeHouseholdMembersMap, y => y.MapFrom(z => z.DisabilityTypeHouseholdMembers))
                .ForMember(x => x.SafetyNetType, y => y.MapFrom(z => z.SafetyNetType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<Occupation, OccupationVM>()
                .ForMember(x => x.HouseholdMembersMain, y => y.MapFrom(z => z.HouseholdMembersMain))
                .ForMember(x => x.HouseholdMembersSecondary, y => y.MapFrom(z => z.HouseholdMembersSecondary)).ReverseMap();
            base.CreateMap<RelationWithHeadHouseHoldType, RelationWithHeadHouseHoldTypeVM>()
                .ForMember(x => x.HouseholdMembers, y => y.MapFrom(z => z.HouseholdMembers)).ReverseMap();
            base.CreateMap<TypeOfHouse, TypeOfHouseVM>().ReverseMap();

            // Many to many maps
            base.CreateMap<BFDAssociationHouseholdMembersMap, BFDAssociationHouseholdMembersMapVM>()
                .ForMember(x => x.BFDAssociation, y => y.MapFrom(z => z.BFDAssociation))
                .ForMember(x => x.HouseholdMember, y => y.MapFrom(z => z.HouseholdMember)).ReverseMap();
            base.CreateMap<DisabilityTypeHouseholdMembersMap, DisabilityTypeHouseholdMembersMapVM>()
                .ForMember(x => x.DisabilityType, y => y.MapFrom(z => z.DisabilityType))
                .ForMember(x => x.HouseholdMember, y => y.MapFrom(z => z.HouseholdMember)).ReverseMap();

            // Remittances
            base.CreateMap<AnnualHouseholdExpenditure, AnnualHouseholdExpenditureVM>()
                .ForMember(x => x.ExpenditureType, y => y.MapFrom(z => z.ExpenditureType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<ExpenditureType, ExpenditureTypeVM>()
                .ForMember(x => x.AnnualHouseholdExpenditures, y => y.MapFrom(z => z.AnnualHouseholdExpenditures)).ReverseMap();

            // Socio Economic Status
            base.CreateMap<Common.Entity.Beneficiary.Business, BusinessVM>()
                .ForMember(x => x.BusinessIncomeSourceType, y => y.MapFrom(z => z.BusinessIncomeSourceType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<BusinessIncomeSourceType, BusinessIncomeSourceTypeVM>()
                .ForMember(x => x.Businesses, y => y.MapFrom(z => z.Businesses)).ReverseMap();
            base.CreateMap<GrossMarginIncomeAndCostStatus, GrossMarginIncomeAndCostStatusVM>()
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<ManualIncomeSourceType, ManualIncomeSourceTypeVM>()
                .ForMember(x => x.ManualPhysicalWorks, y => y.MapFrom(z => z.ManualPhysicalWorks)).ReverseMap();
            base.CreateMap<ManualPhysicalWork, ManualPhysicalWorkVM>()
                .ForMember(x => x.ManualIncomeSourceType, y => y.MapFrom(z => z.ManualIncomeSourceType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<NaturalIncomeSourceType, NaturalIncomeSourceTypeVM>()
                .ForMember(x => x.NaturalResourcesIncomeAndCostStatuses, y => y.MapFrom(z => z.NaturalResourcesIncomeAndCostStatuses)).ReverseMap();
            base.CreateMap<NaturalResourcesIncomeAndCostStatus, NaturalResourcesIncomeAndCostStatusVM>()
                .ForMember(x => x.NaturalIncomeSourceType, y => y.MapFrom(z => z.NaturalIncomeSourceType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<OtherIncomeSource, OtherIncomeSourceVM>()
                .ForMember(x => x.OtherIncomeSourceType, y => y.MapFrom(z => z.OtherIncomeSourceType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<OtherIncomeSourceType, OtherIncomeSourceTypeVM>()
                .ForMember(x => x.OtherIncomeSources, y => y.MapFrom(z => z.OtherIncomeSources)).ReverseMap();

            // Vulnerability Situation
            base.CreateMap<VulnerabilitySituation, VulnerabilitySituationVM>()
                .ForMember(x => x.VulnerabilitySituationType, y => y.MapFrom(z => z.VulnerabilitySituationType))
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey)).ReverseMap();
            base.CreateMap<VulnerabilitySituationType, VulnerabilitySituationTypeVM>()
                .ForMember(x => x.VulnerabilitySituations, y => y.MapFrom(z => z.VulnerabilitySituations)).ReverseMap();

            base.CreateMap<Ethnicity, EthnicityVM>()
                .ForMember(x => x.Surveys, y => y.MapFrom(z => z.Surveys)).ReverseMap();
            base.CreateMap<Ngo, NgoVM>()
                .ReverseMap();
            base.CreateMap<SurveyDocument, SurveyDocumentVM>().ReverseMap();

            base.CreateMap<SurveyChilds, SurveyChildsVM>().ReverseMap();

            base.CreateMap<SurveyDashboard, SurveyDashboardVM>().ReverseMap();

            base.CreateMap<SurveyIncident, SurveyIncidentVM>().ReverseMap();

            base.CreateMap<Survey, SurveyVM>()
                //.ForMember(x => x.SourceofDrySeasonWaterEnumListText, y => y.MapFrom(z => GetEnumStringForDrinkingWaterResource(z.SourceofDrySeasonWaterEnumList)))
                //.ForMember(x => x.SourceofWetSeasonWaterEnumListText, y => y.MapFrom(z => GetEnumStringForDrinkingWaterResource(z.SourceofWetSeasonWaterEnumList)))

                .ForMember(x => x.BeneficiaryGenderString, y => y.MapFrom(z => z.BeneficiaryGender.ToString()))
                .ForMember(x => x.BeneficiaryHouseTypeString, y => y.MapFrom(z => z.BeneficiaryHouseType.GetEnumDisplayName()))
                .ForMember(x => x.BeneficiaryApproveStatusString, y => y.MapFrom(z => z.BeneficiaryApproveStatus.ToString()))

                .ForMember(x => x.BeneficiaryName, y => y.MapFrom(z => string.IsNullOrEmpty(z.BeneficiaryName) ? z.BeneficiaryNameBn : z.BeneficiaryName))
                .ForMember(x => x.BeneficiaryPhone, y => y.MapFrom(z => string.IsNullOrEmpty(z.BeneficiaryPhone) ? z.BeneficiaryPhoneBn : z.BeneficiaryPhone))
                .ReverseMap();
        }

        private void CapacityMappings()
        {
            base.CreateMap<Realization, RealizationVM>().ReverseMap();
            base.CreateMap<CommunityTraining, CommunityTrainingVM>()
                .ForMember(x => x.ForestCircle, y => y.MapFrom(z => z.ForestCircle))
                .ForMember(x => x.ForestDivision, y => y.MapFrom(z => z.ForestDivision))
                .ForMember(x => x.ForestRange, y => y.MapFrom(z => z.ForestRange))
                .ForMember(x => x.ForestBeat, y => y.MapFrom(z => z.ForestBeat))
                .ForMember(x => x.ForestFcvVcf, y => y.MapFrom(z => z.ForestFcvVcf))
                .ForMember(x => x.Division, y => y.MapFrom(z => z.Division))
                .ForMember(x => x.District, y => y.MapFrom(z => z.District))
                .ForMember(x => x.Upazilla, y => y.MapFrom(z => z.Upazilla))
                .ForMember(x => x.EventType, y => y.MapFrom(z => z.EventType))
                .ForMember(x => x.CommunityTrainingType, y => y.MapFrom(z => z.CommunityTrainingType))
                .ForMember(x => x.CommunityTrainingParticipentsMaps, y => y.MapFrom(z => z.CommunityTrainingParticipentsMaps))
                .ForMember(x => x.TrainingOrganizer, y => y.MapFrom(z => z.TrainingOrganizer)).ReverseMap();

            base.CreateMap<CommunityTrainingParticipentsMap, CommunityTrainingParticipentsMapVM>()
                .ForMember(x => x.Survey, y => y.MapFrom(z => z.Survey))
                .ForMember(x => x.ParticipentTypeString, y => y.MapFrom(z => z.ParticipentType.ToString()))
                .ForMember(x => x.CommunityTrainingMember, y => y.MapFrom(z => z.CommunityTrainingMember)).ReverseMap();

            base.CreateMap<CommunityTrainingFile, CommunityTrainingFileVM>()
                .ForMember(x => x.CommunityTraining, y => y.MapFrom(z => z.CommunityTraining)).ReverseMap();

            base.CreateMap<CommunityTrainingType, CommunityTrainingTypeVM>()
                .ForMember(x => x.CommunityTrainings, y => y.MapFrom(z => z.CommunityTrainings)).ReverseMap();

            base.CreateMap<CommunityTrainingMember, CommunityTrainingMemberVM>()
                .ForMember(x => x.CommunityTrainingParticipentsMaps, y => y.MapFrom(z => z.CommunityTrainingParticipentsMaps)).ReverseMap();

            base.CreateMap<PaginationResutl<CommunityTraining>, PaginationResutl<CommunityTrainingVM>>();



            base.CreateMap<EventType, EventTypeVM>().ReverseMap();

            base.CreateMap<TrainingOrganizer, TrainingOrganizerVM>().ReverseMap();
            base.CreateMap<DepartmentalTraining, DepartmentalTrainingVM>().ReverseMap();
            base.CreateMap<DepartmentalTrainingFile, DepartmentalTrainingFileVM>().ReverseMap();
            base.CreateMap<DepartmentalTrainingMember, DepartmentalTrainingMemberVM>()
                .ForMember(x => x.MemberGenderString, y => y.MapFrom(z => z.MemberGender.ToString()))
                .ReverseMap();
            base.CreateMap<DepartmentalTrainingType, DepartmentalTrainingTypeVM>().ReverseMap();
            base.CreateMap<DepartmentalTrainingParticipentsMap, DepartmentalTrainingParticipentsMapVM>().ReverseMap();

            base.CreateMap<PaginationResutl<DepartmentalTraining>, PaginationResutl<DepartmentalTrainingVM>>();

        }

        private string GetEnumStringForDrinkingWaterResource(string str)
        {
            var ids = str.Split(',')
                .Select(id => id.Trim())
                .Where(id => !string.IsNullOrEmpty(id))
                .Select(id =>
                {
                    if (Enum.TryParse(typeof(DrinkingWaterResource), id, out var enumValue))
                    {
                        return ((DrinkingWaterResource)enumValue).ToString();
                    }
                    return null;
                })
                .Where(displayName => displayName != null);

            var xx = string.Join(", ", ids);

            return xx;
        }
    }
}
