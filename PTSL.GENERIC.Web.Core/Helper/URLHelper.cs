namespace PTSL.GENERIC.Web.Core.Helper
{
    public static class URLHelper
    {
        public static string ApiBaseURL = ""; // ApiBaseURL

        public static string Login = "Account/Login";

        public static string UserGroupList = "UserGroup/List";
        public static string UserGroup = "UserGroup";

        public static string UserRole = "UserRole";
        public static string UserRoleSoftDelete = "UserRole/SoftDelete";
        public static string UserRoleList = "UserRole/List";
        public static string UserRoleCurrentUserRootMenu = "UserRole/CurrentUserRootMenu";
        public static string UserRoleListByRoleId = "UserRole/ListByRoleId";
        public static string UserRoleGetRolesByIds = "UserRole/GetRolesByIds";
        public static string UserRolePermissionList = "UserRole/PermissionList";
        public static string UserRoleDoesExist = "UserRole/DoesExist";
        public static string UserRoleSetAccessLists = "UserRole/SetAccessLists";
        public static string UserRoleSetPermissions = "UserRole/SetPermissions";
        public static string UserRoleAddRoleToUser = "UserRole/AddRoleToUser";
        public static string UserRoleCurrentUserHasPermissions = "UserRole/CurrentUserHasPermissions";

        public static string CategoryList = "Category/List";
        public static string Category = "Category";
        public static string RankList = "Rank/List";
        public static string Rank = "Rank";
        public static string DivisionList = "Division/List";
        public static string Division = "Division";
        public static string DistrictList = "District/List";
        public static string District = "District";
        public static string AccesslistList = "Accesslist/List";
        public static string AccesslistListForApproval = "Accesslist/ListForApproval";
        public static string Accesslist = "Accesslist";
        public static string AccessMapperList = "AccessMapper/List";
        public static string AccessMapper = "AccessMapper";
        public static string DegreeList = "Degree/List";
        public static string DegreeDoesExist = "Degree/DoesExist";
        public static string Degree = "Degree";

        public static string ForestCircleList = "ForestCircle/List";
        public static string ForestCircle = "ForestCircle";
        public static string ForestCircleDoesExist = "ForestCircle/DoesExist";

        //Trade
        public static string TradeList = "Trade/List";
        public static string Trade = "Trade";
        public static string TradeDoesExist = "Trade/DoesExist";

        //Accounts User Tag Log
        public static string AccountsUserTagLogList = "AccountsUserTagLog/List";
        public static string AccountsUserTagLog = "AccountsUserTagLog";
        public static string AccountsUserTagLogDoesExist = "AccountsUserTagLog/DoesExist";
        public static string GetAccountsUserTagLogByAccountId = "AccountsUserTagLog/GetAccountsUserTagLogsByAccountId";


        public static string CommitteeDesignationListByFilter = "CommitteeDesignation/ListByFilter";
        public static string CommitteeDesignationList = "CommitteeDesignation/List";
        public static string CommitteeDesignationSoftDelete = "CommitteeDesignation/SoftDelete";
        public static string CommitteeDesignation = "CommitteeDesignation";
        public static string CommitteeDesignationDoesExist = "CommitteeDesignation/DoesExist";

        public static string UpazillaList = "Upazilla/List";
        public static string Upazilla = "Upazilla";
        public static string UpazillaDoesExist = "Upazilla/DoesExist";

        public static string UnionList = "Union/List";
        public static string Union = "Union";
        public static string UnionDoesExist = "Union/DoesExist";
        public static string UnionListByMultipleUpazilla = "Union/ListByMultipleUpazilla";

        public static string FinancialYearList = "FinancialYear/List";
        public static string FinancialYear = "FinancialYear";
        public static string FinancialYearDoesExist = "FinancialYear/DoesExist";

        public static string MarketingList = "Marketing/List";
        public static string Marketing = "Marketing";
        public static string MarketingDoesExist = "Marketing/DoesExist";

        //Student
        public static string StudentsList = "Student/List";
        public static string Students = "Student";
        public static string StudentsDoesExist = "Student/DoesExist";

        // Labour Database

        public static string AssignmentList = "Assignment/List";
        public static string Assignment = "Assignment";
        public static string AssignmentDoesExist = "Assignment/DoesExist";

        public static string LabourRoleList = "LabourRole/List";
        public static string LabourRole = "LabourRole";
        public static string LabourRoleDoesExist = "LabourRole/DoesExist";

        public static string OtherLabourMemberList = "OtherLabourMember/List";
        public static string OtherLabourMember = "OtherLabourMember";
        public static string OtherLabourMemberDoesExist = "OtherLabourMember/DoesExist";
        public static string ListByForestFcvVcf2 = "OtherLabourMember/ListByForestFcvVcf2";

        public static string LabourDatabaseList = "LabourDatabase/List";
        public static string LabourDatabaseGetByFilter = "LabourDatabase/GetByFilter";
        public static string LabourDatabase = "LabourDatabase";
        public static string LabourDatabaseDoesExist = "LabourDatabase/DoesExist";



        public static string LabourWorkListByFilter = "LabourWork/ListByFilter";
        public static string LabourWorkSoftDelete = "LabourWork/SoftDelete";
        public static string LabourWorkList = "LabourWork/List";
        public static string LabourWork = "LabourWork";
        public static string LabourWorkDoesExist = "LabourWork/DoesExist";

        public static string LabourDatabaseFileList = "LabourDatabaseFile/List";
        public static string LabourDatabaseFile = "LabourDatabaseFile";
        public static string LabourDatabaseFileDoesExist = "LabourDatabaseFile/DoesExist";
        public static string LabourDatabaseFileSoftDelete = "LabourDatabaseFile/SoftDelete";

        // Registration Archive
        public static string RegistrationArchiveList = "RegistrationArchive/List";
        public static string RegistrationArchive = "RegistrationArchive";
        public static string RegistrationArchiveDoesExist = "RegistrationArchive/DoesExist";
        public static string RegistrationArchiveSoftDelete = "RegistrationArchive/SoftDelete";
        public static string RegistrationArchiveGetRegistrationArchiveByFilter = "RegistrationArchive/GetRegistrationArchiveByFilter";

        // Cip Team
        public static string CipTeamList = "CipTeam/List";
        public static string CipTeam = "CipTeam";
        public static string CipTeamDoesExist = "CipTeam/DoesExist";
        public static string CipTeamSoftDelete = "CipTeam/SoftDelete";
        public static string CipTeamGetByFilter = "CipTeam/GetByFilter";

        //Bank Accounts Information
        public static string BankAccountsInformationList = "BankAccountsInformation/List";
        public static string BankAccountsInformation = "BankAccountsInformation";
        public static string BankAccountsInformationDoesExist = "BankAccountsInformation/DoesExist";
        public static string GetBankAccountsInformationByUserId = "BankAccountsInformation/GetBankAccountsInformationByUserId";



        // Necessary Link Management
        public static string NecessaryLinkList = "NecessaryLink/List";
        public static string NecessaryLink = "NecessaryLink";
        public static string NecessaryLinkDoesExist = "NecessaryLink/DoesExist";
        public static string NecessaryLinkSoftDelete = "NecessaryLink/SoftDelete";


        //Beneficiary Submission History
        public static string BeneficiarySubmissionHistoryList = "BeneficiarySubmissionHistory/List";
        public static string BeneficiarySubmissionHistory = "BeneficiarySubmissionHistory";
        public static string BeneficiarySubmissionHistoryDoesExist = "BeneficiarySubmissionHistory/DoesExist";


        // Cip Team Member
        public static string CipTeamMemberList = "CipTeamMember/List";
        public static string CipTeamMember = "CipTeamMember";
        public static string CipTeamMemberDoesExist = "CipTeamMember/DoesExist";


        // Registration Archive File
        public static string RegistrationArchiveFileList = "RegistrationArchiveFile/List";
        public static string RegistrationArchiveFile = "RegistrationArchiveFile";
        public static string RegistrationArchiveFileDoesExist = "RegistrationArchiveFile/DoesExist";
        public static string RegistrationArchiveFileSoftDelete = "RegistrationArchiveFile/SoftDelete";


        //Capacity
        public static string TrainingOrganizerList = "TrainingOrganizer/List";
        public static string TrainingOrganizer = "TrainingOrganizer";
        public static string TrainingOrganizerDoesExist = "TrainingOrganizer/DoesExist";
        public static string TrainingOrganizerSoftDelete = "TrainingOrganizer/SoftDelete";

        public static string EventTypeList = "EventType/List";
        public static string EventType = "EventType";
        public static string EventTypeDoesExist = "EventType/DoesExist";

        public static string CommunityTrainingMemberList = "CommunityTrainingMember/List";
        public static string CommunityTrainingMember = "CommunityTrainingMember";
        public static string CommunityTrainingMemberDoesExist = "CommunityTrainingMember/DoesExist";

        public static string CommunityTrainingFileList = "CommunityTrainingFile/List";
        public static string CommunityTrainingFile = "CommunityTrainingFile";
        public static string CommunityTrainingFileDoesExist = "CommunityTrainingFile/DoesExist";
        public static string CommunityTrainingFileSoftDelete = "CommunityTrainingFile/SoftDelete";

        public static string TypeOfHouseList = "TypeOfHouse/List";
        public static string TypeOfHouse = "TypeOfHouse";
        public static string TypeOfHouseDoesExist = "TypeOfHouse/DoesExist";

        //PatrollingScheduling
        public static string PatrollingSchedulingMemberList = "PatrollingSchedulingMember/List";
        public static string PatrollingSchedulingMember = "PatrollingSchedulingMember";
        public static string PatrollingSchedulingMemberDoesExist = "PatrollingSchedulingMember/DoesExist";


        //PatrollingSchedulingFile
        public static string PatrollingSchedulingFileList = "PatrollingSchedulingFile/List";
        public static string PatrollingSchedulingFile = "PatrollingSchedulingFile";
        public static string PatrollingSchedulingFileDoesExist = "PatrollingSchedulingFile/DoesExist";


        //Social Forestry PatrollingSchedule
        public static string SocialForestyZoneOrAreaList = "SocialForestyZoneOrArea/List";
        public static string SocialForestyZoneOrArea = "SocialForestyZoneOrArea";
        public static string SocialForestyZoneOrAreaDoesExist = "SocialForestyZoneOrArea/DoesExist";


        //Social Foresty Ngo
        public static string SocialForestyNgoList = "SocialForestyNgo/List";
        public static string SocialForestyNgo = "SocialForestyNgo";
        public static string SocialForestyNgoDoesExist = "SocialForestyNgo/DoesExist";


        //Land Owning Agency
        public static string LandOwningAgencyList = "LandOwningAgency/List";
        public static string LandOwningAgency = "LandOwningAgency";
        public static string LandOwningAgencyDoesExist = "LandOwningAgency/DoesExist";

        //Cause Of Damage
        public static string CauseOfDamageList = "CauseOfDamage/List";
        public static string CauseOfDamage = "CauseOfDamage";
        public static string CauseOfDamageDoesExist = "CauseOfDamage/DoesExist";


        public static string CommunityTrainingTypeList = "CommunityTrainingType/List";
        public static string CommunityTrainingType = "CommunityTrainingType";
        public static string CommunityTrainingTypeDoesExist = "CommunityTrainingType/DoesExist";

        //PatrollingScheduling
        public static string PatrollingSchedulingTypeList = "PatrollingSchedulingType/List";
        public static string PatrollingSchedulingType = "PatrollingSchedulingType";
        public static string PatrollingSchedulingTypeDoesExist = "PatrollingSchedulingType/DoesExist";


        public static string DepartmentalTrainingTypeList = "DepartmentalTrainingType/List";
        public static string DepartmentalTrainingType = "DepartmentalTrainingType";
        public static string DepartmentalTrainingTypeDoesExist = "DepartmentalTrainingType/DoesExist";

        public static string CommunityTrainingList = "CommunityTraining/List";
        public static string CommunityTraining = "CommunityTraining";
        public static string CommunityTrainingSoftDelete = "CommunityTraining/SoftDelete";
        public static string CommunityTrainingGetTrainingByFilter = "CommunityTraining/GetTrainingByFilter";
        public static string CommunityTrainingDeleteParticipant = "CommunityTraining/DeleteParticipant";
        public static string CommunityTrainingDoesExist = "CommunityTraining/DoesExist";

        public static string CommunityTrainingParticipentsMapByFilter = "CommunityTraining/GetCommunityTrainingParticipentsMapByFilter";



        //PatrollingScheduling
        public static string PatrollingSchedulingList = "PatrollingScheduling/List";
        public static string PatrollingScheduling = "PatrollingScheduling";
        public static string PatrollingSchedulingGetTrainingByFilter = "PatrollingScheduling/GetTrainingByFilter";
        public static string PatrollingSchedulingDeleteParticipant = "PatrollingScheduling/DeleteParticipant";
        public static string PatrollingSchedulingDoesExist = "PatrollingScheduling/DoesExist";



        public static string DepartmentalTrainingList = "DepartmentalTraining/List";
        public static string DepartmentalTraining = "DepartmentalTraining";
        public static string DepartmentalTrainingSoftDelete = "DepartmentalTraining/SoftDelete";
        public static string DepartmentalTrainingGetByFilter = "DepartmentalTraining/GetByFilter";
        public static string DepartmentalTrainingGetByFilterVM = "DepartmentalTraining/GetByFilterVM";
        public static string DepartmentalTrainingDeleteParticipant = "DepartmentalTraining/DeleteParticipant";
        public static string DepartmentalTrainingDoesExist = "DepartmentalTraining/DoesExist";
        public static string DepartmentalTrainingFileList = "DepartmentalTrainingFile/List";
        public static string DepartmentalTrainingFile = "DepartmentalTrainingFile";
        public static string DepartmentalTrainingFileDoesExist = "DepartmentalTrainingFile/DoesExist";
        public static string DepartmentalTrainingFileSoftDelete = "DepartmentalTrainingFile/SoftDelete";

        public static string DepartmentalTrainingMemberList = "DepartmentalTrainingMember/List";
        public static string DepartmentalTrainingMember = "DepartmentalTrainingMember";
        public static string DepartmentalTrainingMemberDoesExist = "DepartmentalTrainingMember/DoesExist";

        public static string CommunityTrainingParticipentsMapList = "CommunityTrainingParticipentsMap/List";
        public static string CommunityTrainingParticipentsMap = "CommunityTrainingParticipentsMap";
        public static string CommunityTrainingParticipentsMapDoesExist = "CommunityTrainingParticipentsMap/DoesExist";

        //PatrollingScheduling
        public static string PatrollingSchedulingParticipentsMapList = "PatrollingSchedulingParticipentsMap/List";
        public static string PatrollingSchedulingParticipentsMap = "PatrollingSchedulingParticipentsMap";
        public static string PatrollingSchedulingParticipentsMapDoesExist = "PatrollingSchedulingParticipentsMap/DoesExist";


        public static string MeetingList = "Meeting/List";
        public static string MeetingSoftDelete = "Meeting/SoftDelete";
        public static string Meeting = "Meeting";
        public static string MeetingGetMeetingByFilter = "Meeting/GetMeetingByFilter";
        public static string MeetingDoesExist = "Meeting/DoesExist";
        public static string MeetingTrainingDeleteParticipant = "Meeting/DeleteParticipant";

        public static string MeetingFileList = "MeetingFile/List";
        public static string MeetingFile = "MeetingFile";
        public static string MeetingFileDoesExist = "MeetingFile/DoesExist";
        public static string MeetingFileSoftDelete = "MeetingFile/SoftDelete";

        public static string MeetingMemberList = "MeetingMember/List";
        public static string MeetingMember = "MeetingMember";
        public static string MeetingMemberDoesExist = "MeetingMember/DoesExist";

        public static string MeetingParticipantsMapList = "MeetingParticipantsMap/List";
        public static string MeetingParticipantsMap = "MeetingParticipantsMap";
        public static string MeetingParticipantsMapDoesExist = "MeetingParticipantsMap/DoesExist";

        public static string MeetingTypeList = "MeetingType/List";
        public static string MeetingType = "MeetingType";
        public static string MeetingTypeDoesExist = "MeetingType/DoesExist";

        //
        public static string ForestRangeList = "ForestRange/List";
        public static string ForestRange = "ForestRange";
        public static string ForestRangeDoesExist = "ForestRange/DoesExist";
        public static string ForestRangeSoftDelete = "ForestRange/SoftDelete";

        public static string ForestBeatList = "ForestBeat/List";
        public static string ForestBeat = "ForestBeat";
        public static string ForestBeatDoesExist = "ForestBeat/DoesExist";
        public static string ForestBeatSoftDelete = "ForestBeat/SoftDelete";


        // SavingsAccount
        public static string SavingsAccountList = "SavingsAccount/List";
        public static string SavingsAccountGetByFilter = "SavingsAccount/GetByFilter";
        public static string SavingsAccount = "SavingsAccount";
        public static string SavingsAccountDoesExist = "SavingsAccount/DoesExist";

        public static string RealizationList = "Realization/List";
        public static string Realization = "Realization";
        public static string RealizationDoesExist = "Realization/DoesExist";
        public static string RealizationGetRealizationsByCuttingId = "Realization/GetRealizationsByCuttingId";
        public static string RealizationGetDefaultRealizationData = "Realization/GetDefaultRealizationData";
        public static string RealizationSoftDelete = "Realization/SoftDelete";

        // SavingsAmountInformation
        public static string SavingsAmountInformationList = "SavingsAmountInformation/List";
        public static string SavingsAmountInformation = "SavingsAmountInformation";
        public static string SavingsAmountInformationDoesExist = "SavingsAmountInformation/DoesExist";


        // WithdrawAmountInformation
        public static string WithdrawAmountInformationList = "WithdrawAmountInformation/List";
        public static string WithdrawAmountInformation = "WithdrawAmountInformation";
        public static string WithdrawAmountInformationDoesExist = "WithdrawAmountInformation/DoesExist";



        //ForestManagement
        public static string FcvExecutiveCommitteeMemberList = "FcvExecutiveCommitteeMember/List";
        public static string FcvExecutiveCommitteeMember = "FcvExecutiveCommitteeMember";
        public static string FcvExecutiveCommitteeMemberDoesExist = "FcvExecutiveCommitteeMember/DoesExist";




        //ExecutiveCommittee
        public static string ExecutiveCommitteeList = "ExecutiveCommittee/List";
        public static string ExecutiveCommittee = "ExecutiveCommittee";
        public static string ExecutiveCommitteeGetByFilter = "ExecutiveCommittee/GetByFilter";
        public static string ExecutiveCommitteeDoesExist = "ExecutiveCommittee/DoesExist";
        public static string GetTotalFcvVcfAndExecutiveSubExecutive = "DashBoard/GetTotalFcvVcfAndExecutiveSubExecutives";
        public static string DashboardBeneficiaryDashboardData = "DashBoard/BeneficiaryDashboardData";


        //OtherCommitteeMembe
        public static string OtherCommitteeMemberList = "OtherCommitteeMember/List";
        public static string OtherCommitteeMember = "OtherCommitteeMember";
        public static string OtherCommitteeMemberDoesExist = "OtherCommitteeMember/DoesExist";
        public static string ListByForestFcvVcf = "OtherCommitteeMember/ListByForestFcvVcf";


        //Patrolling
        public static string OtherPatrollingMemberList = "OtherPatrollingMember/List";
        public static string OtherPatrollingMember = "OtherPatrollingMember";
        public static string OtherPatrollingMemberDoesExist = "OtherPatrollingMember/DoesExist";
        public static string OtherPatrollingMemberListByForestFcvVcf = "OtherPatrollingMember/ListByForestFcvVcf";


        //PatrollingScheduleInformetion
        public static string PatrollingScheduleInformetionList = "PatrollingScheduleInformetion/List";
        public static string PatrollingScheduleInformetion = "PatrollingScheduleInformetion";
        public static string PatrollingScheduleInformetionDoesExist = "PatrollingScheduleInformetion/DoesExist";
        public static string PatrollingScheduleInformetionListByForestFcvVcf = "PatrollingScheduleInformetion/PatrollingScheduleInformetionListByForestFcvVcf";
        public static string PatrollingScheduleInformetionByFilter = "PatrollingScheduleInformetion/GetPatrollingScheduleInformetionByFilter";





        public static string FundTypeList = "FundType/List";
        public static string FundType = "FundType";
        public static string FundTypeDoesExist = "FundType/DoesExist";

        public static string TransactionList = "Transaction/List";
        public static string TransactionGetByFilter = "Transaction/GetByFilter";
        public static string TransactionListDate = "Transaction/ListDate";
        public static string TransactionGetDetails = "Transaction/GetDetails";
        public static string Transaction = "Transaction";
        public static string TransactionDashboardData = "Transaction/DashboardData";
        public static string TransactionDoesExist = "Transaction/DoesExist";

        public static string TransactionFilesList = "TransactionFiles/List";
        public static string TransactionFiles = "TransactionFiles";
        public static string TransactionFilesDoesExist = "TransactionFiles/DoesExist";

        public static string TransactionExpenseList = "TransactionExpense/List";
        public static string TransactionExpense = "TransactionExpense";
        public static string TransactionExpenseDoesExist = "TransactionExpense/DoesExist";
        public static string GetExpenseForCDFReportByFilter = "TransactionExpense/GetExpenseForCDFReportByFilter";



        public static string TransactionDetailsList = "TransactionDetails/List";
        public static string TransactionDetails = "TransactionDetails";
        public static string TransactionDetailsGetByTransaction = "TransactionDetails/GetByTransaction";
        public static string TransactionDetailsDoesExist = "TransactionDetails/DoesExist";



        public static string ForestFcvVcfList = "ForestFcvVcf/List";
        public static string ForestFcvVcfListByForestBeatAndType = "ForestFcvVcf/ListByForestBeatAndType";
        public static string ForestFcvVcf = "ForestFcvVcf";
        public static string ForestFcvVcfSoftDelete = "ForestFcvVcf/SoftDelete";
        public static string ForestFcvVcfDoesExist = "ForestFcvVcf/DoesExist";
        public static string GetFcvVcfByType = "ForestFcvVcf/GetListOfFcvVcfByType";
        public static string MemberPerVillageList = "ForestFcvVcf/MemberPerVillage";


        public static string OccupationList = "Occupation/List";
        public static string Occupation = "Occupation";
        public static string OccupationDoesExist = "Occupation/DoesExist";

        public static string BFDAssociationList = "BFDAssociation/List";
        public static string BFDAssociation = "BFDAssociation";
        public static string BFDAssociationDoesExist = "BFDAssociation/DoesExist";

        public static string NgoList = "Ngo/List";
        public static string Ngo = "Ngo";
        public static string NgoDoesExist = "Ngo/DoesExist";
        public static string NgoListByForestDivisions = "Ngo/ListByForestDivisions";

        public static string CipList = "Cip/List";
        public static string Cip = "Cip";
        public static string CipDoesExist = "Cip/DoesExist";
        public static string CipListByFilter = "Cip/ListByFilter";
        public static string CipSoftDelete = "Cip/SoftDelete";
        public static string CipListByFilterForBeneficiary = "Cip/ListByFilterForBeneficiary";

        public static string CipFileList = "CipFile/List";
        public static string CipFile = "CipFile";
        public static string CipFileDoesExist = "CipFile/DoesExist";
        public static string CipFileSoftDelete = "CipFile/SoftDelete";

        public static string SurveyList = "Survey/List";
        public static string SurveyListNotHasAccountIncluding = "Survey/ListNotHasAccountIncluding";
        public static string SurveyLoadAllChilds = "Survey/LoadAllChilds";
        public static string SurveyListLatest = "Survey/ListLatest";
        public static string SurveyGetBeneficiaryByFilter = "Survey/GetBeneficiaryByFilter";
        public static string Survey = "Survey";
        public static string SurveyGetDetailsAsync = "Survey/GetDetailsAsync";
        public static string SurveyDoesExist = "Survey/DoesExist";
        public static string SurveyLoadMembers = "Survey/LoadMembers";
        public static string SurveyLoadVulnerabilitySituation = "Survey/LoadVulnerabilitySituation";
        public static string SurveyLoadFoodSecurityItem = "Survey/LoadFoodSecurityItem";
        public static string SurveyLoadAnnualHouseholdExpenditure = "Survey/LoadAnnualHouseholdExpenditure";
        public static string SurveyLoadExistingSkill = "Survey/LoadExistingSkill";

        public static string SurveyIncidentList = "SurveyIncident/List";
        public static string SurveyIncident = "SurveyIncident";
        public static string SurveyIncidentDoesExist = "SurveyIncident/DoesExist";
        public static string SurveyIncidentListByFilter = "SurveyIncident/ListByFilter";

        public static string SurveyPendingStatus = "Survey/PendingStatus";
        public static string SurveyApproveStatus = "Survey/ApproveStatus";
        public static string SurveyRejectStatus = "Survey/RequestStatus";
        public static string SurveyDeactivate = "Survey/Deactivate";
        public static string SurveyActivate = "Survey/Activate";

        public static string SurveyLoadGrossMarginIncomeAndCostStatus = "Survey/LoadGrossMarginIncomeAndCostStatus";
        public static string SurveyLoadManualPhysicalWork = "Survey/LoadManualPhysicalWork";
        public static string SurveyLoadNaturalResourcesIncomeAndCostStatus = "Survey/LoadNaturalResourcesIncomeAndCostStatus";
        public static string SurveyLoadOtherIncomeSource = "Survey/LoadOtherIncomeSource";
        public static string SurveyLoadBusiness = "Survey/LoadBusiness";
        public static string SurveyLoadLandOccupancy = "Survey/LoadLandOccupancy";
        public static string SurveyLoadLiveStock = "Survey/LoadLiveStock";
        public static string SurveyLoadAsset = "Survey/LoadAsset";
        public static string SurveyLoadImmovableAsset = "Survey/LoadImmovableAsset";
        public static string SurveyLoadEnergyUse = "Survey/LoadEnergyUse";

        public static string SurveyGetBeneficiaryByFcvVcf = "Survey/GetBeneficiaryByFcvVcf";
        public static string GetTotalBeneficiary = "DashBoard/GetTotalBeneficiary";
        public static string LoanStatusOverview = "DashBoard/LoanStatusOverview";
        public static string TotalHouseholdWithPercentage = "DashBoard/TotalHouseholdWithPercentage";
        public static string GetEnergyUsesPercentage = "DashBoard/GetEnergyUsesPercentage";
        public static string TotalDashboardSavingsAmount = "DashBoard/TotalDashboardSavingsAmount";
        public static string GetGetLoanData = "DashBoard/GetLoanData";
        public static string GetCIPDetails = "DashBoard/GetCIPDetails";


        public static string SafetyNetList = "SafetyNet/List";
        public static string SafetyNet = "SafetyNet";
        public static string SafetyNetDoesExist = "SafetyNet/DoesExist";

        public static string DisabilityTypeList = "DisabilityType/List";
        public static string DisabilityType = "DisabilityType";
        public static string DisabilityTypeDoesExist = "DisabilityType/DoesExist";

        public static string LiveStockTypeList = "LiveStockType/List";
        public static string LiveStockType = "LiveStockType";
        public static string LiveStockTypeDoesExist = "LiveStockType/DoesExist";

        public static string VulnerabilitySituationTypeList = "VulnerabilitySituationType/List";
        public static string VulnerabilitySituationType = "VulnerabilitySituationType";
        public static string VulnerabilitySituationTypeDoesExist = "VulnerabilitySituationType/DoesExist";

        public static string ImmovableAssetTypeList = "ImmovableAssetType/List";
        public static string ImmovableAssetType = "ImmovableAssetType";
        public static string ImmovableAssetTypeDoesExist = "ImmovableAssetType/DoesExist";

        public static string ForestDivisionList = "ForestDivision/List";
        public static string ForestDivision = "ForestDivision";
        public static string ForestDivisionDoesExist = "ForestDivision/DoesExist";
        public static string ForestDivisionListByMultipleForestCircle = "ForestDivision/ListByMultipleForestCircle";
        public static string ForestDivisionSoftDelete = "ForestDivision/SoftDelete";

        public static string EnergyTypeList = "EnergyType/List";
        public static string EnergyType = "EnergyType";
        public static string EnergyTypeDoesExist = "EnergyType/DoesExist";

        public static string EthnicityList = "Ethnicity/List";
        public static string Ethnicity = "Ethnicity";
        public static string EthnicityDoesExist = "Ethnicity/DoesExist";

        public static string ExpenditureTypeList = "ExpenditureType/List";
        public static string ExpenditureType = "ExpenditureType";
        public static string ExpenditureTypeDoesExist = "ExpenditureType/DoesExist";

        public static string AssetTypeList = "AssetType/List";
        public static string AssetType = "AssetType";
        public static string AssetTypeDoesExist = "AssetType/DoesExist";

        public static string FoodItemList = "FoodItem/List";
        public static string FoodItem = "FoodItem";
        public static string FoodItemDoesExist = "FoodItem/DoesExist";

        public static string ManualIncomeSourceTypeList = "ManualIncomeSourceType/List";
        public static string ManualIncomeSourceType = "ManualIncomeSourceType";
        public static string ManualIncomeSourceTypeDoesExist = "ManualIncomeSourceType/DoesExist";

        public static string OtherIncomeSourceTypeList = "OtherIncomeSourceType/List";
        public static string OtherIncomeSourceType = "OtherIncomeSourceType";
        public static string OtherIncomeSourceTypeDoesExist = "OtherIncomeSourceType/DoesExist";

        public static string NaturalIncomeSourceTypeList = "NaturalIncomeSourceType/List";
        public static string NaturalIncomeSourceType = "NaturalIncomeSourceType";
        public static string NaturalIncomeSourceTypeDoesExist = "NaturalIncomeSourceType/DoesExist";


        public static string BusinessIncomeSourceTypeList = "BusinessIncomeSourceType/List";
        public static string BusinessIncomeSourceType = "BusinessIncomeSourceType";
        public static string BusinessIncomeSourceTypeDoesExist = "BusinessIncomeSourceType/DoesExist";

        public static string RelationWithHeadHouseHoldTypeList = "RelationWithHeadHouseHoldType/List";
        public static string RelationWithHeadHouseHoldType = "RelationWithHeadHouseHoldType";
        public static string RelationWithHeadHouseHoldTypeDoesExist = "RelationWithHeadHouseHoldType/DoesExist";

        // New AIG
        public static string AIGBasicInformationAverageLoanSizeFilter = "AIGBasicInformation/AverageLoanSizeFilter";
        public static string AIGBasicInformationList = "AIGBasicInformation/List";
        public static string AIGBasicInformationAIGBeneficiaryCheckEligibility = "AIGBasicInformation/AIGBeneficiaryCheckEligibility";
        public static string AIGBasicInformationGetAIGByFilter = "AIGBasicInformation/GetAIGByFilter";
        public static string AIGBasicInformationAIGLoanStatusReport = "AIGBasicInformation/AIGLoanStatusReport";
        public static string AIGBasicInformation = "AIGBasicInformation";
        public static string AIGBasicInformationDoesExist = "AIGBasicInformation/DoesExist";
        public static string AIGBasicInformationGetIncludeFirstSecondAndBen = "AIGBasicInformation/GetIncludeFirstSecondAndBen";
        public static string AIGBasicInformationRepaymentReport = "AIGBasicInformation/RepaymentReport";
        public static string AIGBasicInformationBeneficiaryWiseRepaymentProgress = "AIGBasicInformation/BeneficiaryWiseRepaymentProgress";
        public static string CumulativeRecoveryRateReportList = "AIGBasicInformation/CumulativeRecoveryRateReport";
        public static string OnTimeRecoveryRateList = "AIGBasicInformation/OnTimeRecoveryRate";
        public static string PortfolioAtRiskList = "AIGBasicInformation/PortfolioAtRisk";
        public static string DelinquencyRatioList = "AIGBasicInformation/DelinquencyRatio";
        public static string AIGBasicInformationBorrowerPerVillageReport = "AIGBasicInformation/BorrowerPerVillageReport";
        public static string AIGBasicInformationBorrowerCoverageReport = "AIGBasicInformation/BorrowerCoverageReport";
        public static string PortfolioPerVillageList = "AIGBasicInformation/PortfolioPerVillage";


        public static string RepaymentLDFFileList = "RepaymentLDFFile/List";
        public static string RepaymentLDFFile = "RepaymentLDFFile";
        public static string RepaymentLDFFileDoesExist = "RepaymentLDFFile/DoesExist";
        public static string GetRepaymentLDFFileByRepaymentId = "RepaymentLDFFile/GetRepaymentLDFFileByRepaymentId";


        // InternalLoan
        public static string InternalLoanInformationList = "InternalLoanInformation/List";
        public static string InternalLoanInformationGetAIGByFilter = "InternalLoanInformation/GetInternalLoanInformationByFilter";
        public static string InternalLoanInformation = "InternalLoanInformation";
        public static string InternalLoanInformationDoesExist = "InternalLoanInformation/DoesExist";
        public static string InternalLoanInformationGetInternalLoanAvailableAmount = "InternalLoanInformation/GetInternalLoanAvailableAmount";


        // RepaymentInternalLoan
        public static string RepaymentInternalLoanList = "RepaymentInternalLoan/List";
        public static string RepaymentInternalLoan = "RepaymentInternalLoan";
        public static string RepaymentInternalLoanDoesExist = "RepaymentInternalLoan/DoesExist";
        public static string RepaymentInternalLoanCompletePayment = "RepaymentInternalLoan/CompletePayment";


        // InternalLoanInformationFile
        public static string InternalLoanInformationFileList = "InternalLoanInformationFile/List";
        public static string InternalLoanInformationFile = "InternalLoanInformationFile";
        public static string InternalLoanInformationFileDoesExist = "InternalLoanInformationFile/DoesExist";


        public static string RepaymentLDFDateWiseRepaymentReport = "RepaymentLDF/DateWiseRepaymentReport";
        public static string RepaymentLDFOutstandingLoanPerBorrowerList = "RepaymentLDF/OutstandingLoanPerBorrowerList";
        public static string RepaymentLDFList = "RepaymentLDF/List";
        public static string RepaymentLDF = "RepaymentLDF";
        public static string RepaymentLDFDoesExist = "RepaymentLDF/DoesExist";
        public static string RepaymentLDFListHistory = "RepaymentLDF/ListHistory";
        public static string RepaymentLDFGetListByFirstLDFId = "RepaymentLDF/GetListByFirstLDFId";
        public static string RepaymentLDFGetListBySecondLDFId = "RepaymentLDF/GetListBySecondLDFId";
        public static string RepaymentLDFGetListByAIGId = "RepaymentLDF/GetListByAIGId";
        public static string RepaymentLDFCompletePayment = "RepaymentLDF/CompletePayment";
        public static string RepaymentLDFLockUnlockPayment = "RepaymentLDF/LockUnlockPayment";
        public static string RepaymentLDFRemovePayment = "RepaymentLDF/RemovePayment";
        public static string RepaymentLDFGetListWithProgress = "RepaymentLDF/GetListWithProgress";

        public static string FirstSixtyPercentageLDFList = "FirstSixtyPercentageLDF/List";
        public static string FirstSixtyPercentageLDF = "FirstSixtyPercentageLDF";
        public static string FirstSixtyPercentageLDFDoesExist = "FirstSixtyPercentageLDF/DoesExist";

        public static string SecondFourtyPercentageLDFList = "SecondFourtyPercentageLDF/List";
        public static string SecondFourtyPercentageLDF = "SecondFourtyPercentageLDF";
        public static string SecondFourtyPercentageLDFDoesExist = "SecondFourtyPercentageLDF/DoesExist";

        public static string LDFProgressList = "LDFProgress/List";
        public static string LDFProgress = "LDFProgress";
        public static string LDFProgressDoesExist = "LDFProgress/DoesExist";

        public static string IndividualLDFInfoFormList = "IndividualLDFInfoForm/List";
        public static string IndividualLDFInfoFormListByFilter = "IndividualLDFInfoForm/ListByFilter";
        public static string IndividualLDFInfoFormListByFilterBasic = "IndividualLDFInfoForm/ListByFilterBasic";
        public static string IndividualLDFInfoFormListByFilterBeneficiary = "IndividualLDFInfoForm/ListByFilterBeneficiary";
        public static string IndividualLDFInfoForm = "IndividualLDFInfoForm";
        public static string IndividualLDFInfoFormDoesExist = "IndividualLDFInfoForm/DoesExist";
        public static string IndividualLDFInfoFormApproveLDF = "IndividualLDFInfoForm/ApproveLDF";

        public static string GroupLDFInfoFormList = "GroupLDFInfoForm/List";
        public static string GroupLDFInfoFormListByFilter = "GroupLDFInfoForm/ListByFilter";
        public static string GroupLDFInfoForm = "GroupLDFInfoForm";
        public static string GroupLDFInfoFormGetDetails = "GroupLDFInfoForm/GetDetails";
        public static string GroupLDFInfoFormDoesExist = "GroupLDFInfoForm/DoesExist";

        public static string GroupLDFInfoFormMemberList = "GroupLDFInfoFormMember/List";
        public static string GroupLDFInfoFormMember = "GroupLDFInfoFormMember";
        public static string GroupLDFInfoFormMemberDoesExist = "GroupLDFInfoFormMember/DoesExist";

        public static string BadLoanTypeList = "BadLoanType/List";
        public static string BadLoanType = "BadLoanType";
        public static string BadLoanTypeDoesExist = "BadLoanType/DoesExist";

        public static string IndividualGroupFormSetupList = "IndividualGroupFormSetup/List";
        public static string IndividualGroupFormSetup = "IndividualGroupFormSetup";
        public static string IndividualGroupFormSetupDoesExist = "IndividualGroupFormSetup/DoesExist";

        // Social Forestry
        /*
        public static string CuttingPlantationList = "CuttingPlantation/List";
        public static string CuttingPlantation = "CuttingPlantation";
        public static string CuttingPlantationDoesExist = "CuttingPlantation/DoesExist";
        public static string CuttingPlantationListByFilter = "CuttingPlantation/ListByFilter";
        public static string CuttingPlantationGetRotationNo = "CuttingPlantation/GetRotationNo";
        */

        public static string NewRaisedPlantationUnionMapList = "NewRaisedPlantationUnionMap/List";
        public static string NewRaisedPlantationUnionMap = "NewRaisedPlantationUnionMap";
        public static string NewRaisedPlantationUnionMapDoesExist = "NewRaisedPlantationUnionMap/DoesExist";

        public static string PlantationProjectList = "PlantationProject/List";
        public static string PlantationProject = "PlantationProject";
        public static string PlantationProjectDoesExist = "PlantationProject/DoesExist";

        public static string PlantationTypeRevenuePercentageList = "PlantationTypeRevenuePercentage/List";
        public static string PlantationTypeRevenuePercentage = "PlantationTypeRevenuePercentage";
        public static string PlantationTypeRevenuePercentageDoesExist = "PlantationTypeRevenuePercentage/DoesExist";

        public static string NewRaisedPlantationList = "NewRaisedPlantation/List";
        public static string NewRaisedPlantation = "NewRaisedPlantation";
        public static string NewRaisedPlantationDoesExist = "NewRaisedPlantation/DoesExist";
        public static string NewRaisedPlantationListByFilter = "NewRaisedPlantation/ListByFilter";
        public static string NewRaisedPlantationGetDetails = "NewRaisedPlantation/GetDetails";
        public static string NewRaisedPlantationGetDetailsForEdit = "NewRaisedPlantation/GetDetailsForEdit";
        public static string GetInformationAndDataOnNewlyRaisedPlantationReport = "NewRaisedPlantation/GetInformationAndDataOnNewlyRaisedPlantationReport";
        public static string GetInformationAndDataOnPlantationsFelledOrCutReport = "NewRaisedPlantation/GetInformationAndDataOnPlantationsFelledOrCutReport";




        public static string NewRaisedPlantationUpazillaMapList = "NewRaisedPlantationUpazillaMap/List";
        public static string NewRaisedPlantationUpazillaMap = "NewRaisedPlantationUpazillaMap";
        public static string NewRaisedPlantationUpazillaMapDoesExist = "NewRaisedPlantationUpazillaMap/DoesExist";

        public static string PlantationTypeList = "PlantationType/List";
        public static string PlantationType = "PlantationType";
        public static string PlantationTypeDoesExist = "PlantationType/DoesExist";
        public static string PlantationTypeListByHasStripType = "PlantationType/ListByHasStripType";

        public static string ReforestationList = "Reforestation/List";
        public static string Reforestation = "Reforestation";
        public static string ReforestationDoesExist = "Reforestation/DoesExist";
        public static string ReforestationListByFilter = "Reforestation/ListByFilter";
        public static string ReforestationGetRotationNo = "Reforestation/GetRotationNo";

        public static string StripTypeList = "StripType/List";
        public static string StripType = "StripType";
        public static string StripTypeDoesExist = "StripType/DoesExist";
        public static string StripTypeListByPlantationType = "StripType/ListByPlantationType";

        public static string BankDepositList = "BankDeposit/List";
        public static string BankDeposit = "BankDeposit";
        public static string BankDepositDoesExist = "BankDeposit/DoesExist";

        public static string DistributedOrRevenueDepositAmountList = "DistributedOrRevenueDepositAmount/List";
        public static string DistributedOrRevenueDepositAmount = "DistributedOrRevenueDepositAmount";
        public static string DistributedOrRevenueDepositAmountDoesExist = "DistributedOrRevenueDepositAmount/DoesExist";

        public static string RevenueList = "Revenue/List";
        public static string Revenue = "Revenue";
        public static string RevenueDoesExist = "Revenue/DoesExist";

        public static string RevenueDistributionList = "RevenueDistribution/List";
        public static string RevenueDistribution = "RevenueDistribution";
        public static string RevenueDistributionDoesExist = "RevenueDistribution/DoesExist";



        //Social Forestry Training (EventTypeForTraining)
        public static string EventTypeForTrainingList = "EventTypeForTraining/List";
        public static string EventTypeForTraining = "EventTypeForTraining";
        public static string EventTypeForTrainingDoesExist = "EventTypeForTraining/DoesExist";

        //Social Forestry Training (TrainerDesignationForTraining)
        public static string TrainerDesignationForTrainingList = "TrainerDesignationForTraining/List";
        public static string TrainerDesignationForTraining = "TrainerDesignationForTraining";
        public static string TrainerDesignationForTrainingDoesExist = "TrainerDesignationForTraining/DoesExist";

        //Social Forestry Training (TrainingOrganizerForTraining)
        public static string TrainingOrganizerForTrainingList = "TrainingOrganizerForTraining/List";
        public static string TrainingOrganizerForTraining = "TrainingOrganizerForTraining";
        public static string TrainingOrganizerForTrainingDoesExist = "TrainingOrganizerForTraining/DoesExist";

        //Social Forestry Training (FinancialYearForTraining)
        public static string FinancialYearForTrainingList = "FinancialYearForTraining/List";
        public static string FinancialYearForTraining = "FinancialYearForTraining";
        public static string FinancialYearForTrainingDoesExist = "FinancialYearForTraining/DoesExist";
        //Social Forestry Training (Main)
        public static string SocialForestryTrainingList = "SocialForestryTraining/List";
        public static string SocialForestryTraining = "SocialForestryTraining";
        public static string SocialForestryTrainingDoesExist = "SocialForestryTraining/DoesExist";
        public static string SocialForestryTrainingDeleteParticipant = "SocialForestryTraining/DeleteParticipant";
        public static string SocialForestryTrainingSoftDelete = "SocialForestryTraining/SoftDelete";
        public static string SocialForestryTrainingGetByFilterVM = "SocialForestryTraining/GetByFilterVM";




        public static string SocialForestryTrainingParticipentsMapList = "SocialForestryTrainingParticipentsMap/List";
        public static string SocialForestryTrainingParticipentsMap = "SocialForestryTrainingParticipentsMap";
        public static string SocialForestryTrainingParticipentsMapDoesExist = "SocialForestryTrainingParticipentsMap/DoesExist";

        public static string SocialForestryTrainingFileList = "SocialForestryTrainingFile/List";
        public static string SocialForestryTrainingFile = "SocialForestryTrainingFile";
        public static string SocialForestryTrainingFileDoesExist = "SocialForestryTrainingFile/DoesExist";
        public static string SocialForestryTrainingFileSoftDelete = "SocialForestryTrainingFile/SoftDelete";


        //Social Forestry Meeting(Main)
        public static string SocialForestryMeetingMemberList = "SocialForestryMeetingMember/List";
        public static string SocialForestryMeetingMember = "SocialForestryMeetingMember";
        public static string SocialForestryMeetingMemberDoesExist = "SocialForestryMeetingMember/DoesExist";

        public static string SocialForestryMeetingParticipentsMapList = "SocialForestryMeetingParticipentsMap/List";
        public static string SocialForestryMeetingParticipentsMap = "SocialForestryMeetingParticipentsMap";
        public static string SocialForestryMeetingParticipentsMapDoesExist = "SocialForestryMeetingParticipentsMap/DoesExist";

        public static string SocialForestryMeetingFileList = "SocialForestryMeetingFile/List";
        public static string SocialForestryMeetingFile = "SocialForestryMeetingFile";
        public static string SocialForestryMeetingFileDoesExist = "SocialForestryMeetingFile/DoesExist";
        public static string SocialForestryMeetingFileSoftDelete = "SocialForestryMeetingFile/SoftDelete";


        public static string SocialForestryMeetingList = "SocialForestryMeeting/List";
        public static string SocialForestryMeeting = "SocialForestryMeeting";
        public static string SocialForestryMeetingDoesExist = "SocialForestryMeeting/DoesExist";
        public static string SocialForestryMeetingSoftDelete = "SocialForestryMeeting/SoftDelete";
        public static string SocialForestryMeetingDeleteParticipant = "SocialForestryMeeting/DeleteParticipant";


        public static string SocialForestryTrainingMemberList = "SocialForestryTrainingMember/List";
        public static string SocialForestryTrainingMember = "SocialForestryTrainingMember";
        public static string SocialForestryTrainingMemberDoesExist = "SocialForestryTrainingMember/DoesExist";


        // Account Management
        public static string AccountList = "Accounts/List";
        public static string Account = "Accounts";
        public static string AccountDoesExist = "Accounts/DoesExist";
        public static string AccountSoftDelete = "Accounts/SoftDelete";
        public static string AccountGetCurrentBalance = "Accounts/GetCurrentBalance";
        public static string AccountGetByFilter = "Accounts/GetByFilter";
        public static string AccountGetByFilterBasic = "Accounts/GetByFilterBasic";

        public static string SourceOfFundList = "SourceOfFund/List";
        public static string SourceOfFund = "SourceOfFund";
        public static string SourceOfFundDoesExist = "SourceOfFund/DoesExist";
        public static string SourceOfFundSoftDelete = "SourceOfFund/SoftDelete";

        public static string AccountTransferList = "AccountTransfer/List";
        public static string AccountTransferLastStageApproval = "AccountTransfer/LastStageApproval";
        public static string AccountTransferForwardApproval = "AccountTransfer/ForwardApproval";
        public static string AccountTransferListForCashIn = "AccountTransfer/ListForCashIn";
        public static string AccountTransferListForRequestList = "AccountTransfer/ListForRequestList";

        public static string AccountTransferAcceptTransfer = "AccountTransfer/AcceptTransfer";
        public static string AccountTransferCancelTransfer = "AccountTransfer/CancelTransfer";
        public static string AccountTransferRollbackTransfer = "AccountTransfer/RollbackTransfer";
        public static string AccountTransferModifyTransfer = "AccountTransfer/ModifyTransfer";

        public static string AccountTransfer = "AccountTransfer";
        public static string AccountTransferTransfer = "AccountTransfer/Transfer";
        public static string AccountTransferDoesExist = "AccountTransfer/DoesExist";
        public static string AccountTransferSoftDelete = "AccountTransfer/SoftDelete";

        public static string AccountTransferLogList = "AccountTransferLog/List";
        public static string AccountTransferLog = "AccountTransferLog";
        public static string AccountTransferLogDoesExist = "AccountTransferLog/DoesExist";
        public static string AccountTransferLogSoftDelete = "AccountTransferLog/SoftDelete";

        public static string AccountDepositList = "AccountDeposit/List";
        public static string AccountDepositCreate = "AccountDeposit/Create";
        public static string AccountDepositGetDetails = "AccountDeposit/GetDetails";
        public static string AccountDeposit = "AccountDeposit";
        public static string AccountDepositDoesExist = "AccountDeposit/DoesExist";
        public static string AccountDepositSoftDelete = "AccountDeposit/SoftDelete";
        public static string AccountDepositAcceptDeposit = "AccountDeposit/AcceptDeposit";
        public static string AccountDepositCancelDeposit = "AccountDeposit/CancelDeposit";
        public static string AccountDepositLastStageApproval = "AccountDeposit/LastStageApproval";
        public static string AccountDepositForwardApproval = "AccountDeposit/ForwardApproval";
        public static string AccountDepositListForRequestList = "AccountDeposit/ListForRequestList";
        public static string AccountDepositListForCashIn = "AccountDeposit/ListForCashIn";
        public static string AccountDepositListByFilter = "AccountDeposit/ListByFilter";
        public static string AccountTransferListByFilter = "AccountTransfer/ListByFilter";


        public static string DesignationList = "Designation/List";
        public static string Designation = "Designation";
        public static string DesignationClassList = "DesignationClass/List";
        public static string DesignationClass = "DesignationClass";
        public static string EmployeeStatusList = "EmployeeStatus/List";
        public static string EmployeeStatus = "EmployeeStatus";
        public static string PoliceStationList = "PoliceStation/List";
        public static string PoliceStation = "PoliceStation";
        public static string PostingList = "Posting/List";
        public static string Posting = "Posting";
        public static string PostingTypeList = "PostingType/List";
        public static string PostingType = "PostingType";
        public static string PostResponsibilityList = "PostResponsibility/List";
        public static string PostResponsibility = "PostResponsibility";
        public static string PresentStatusList = "PresentStatus/List";
        public static string PresentStatus = "PresentStatus";
        public static string PromtionNatureList = "PromtionNature/List";
        public static string PromtionNature = "PromtionNature";
        public static string ModuleList = "Module/List";
        public static string Module = "Module";
        public static string PmsGroupList = "PmsGroup/List";
        public static string PmsGroup = "PmsGroup";
        public static string EmployeeInformationList = "EmployeeInformation/List";
        public static string EmployeeList = "EmployeeInformation/EmployeeList";
        public static string EmployeeInformation = "EmployeeInformation";
        public static string EmployeeInformationGetEmployeeFullInfoById = "EmployeeInformation/GetEmployeeFullInfoById";
        public static string EmployeeInformationGetEmployeeBasicInfoByEmployeeCode = "EmployeeInformation/GetEmployeeBasicInfoByEmployeeCode";
        public static string EmployeeInformationGetFilterData = "EmployeeInformation/GetFilterData";
        public static string EmployeeInformationEmployeeListBySP = "EmployeeInformation/EmployeeListBySP";
        public static string EmployeeInformationGetEmployeeByEmail = "EmployeeInformation/GetEmployeeByEmail";
        public static string EmployeeInformationGetEmployeeByEmailWithAllIncluding = "EmployeeInformation/GetEmployeeByEmailWithAllIncluding";
        public static string EmployeeInformationGetEmployeeList = "EmployeeInformation/GetEmployeeList";
        public static string UpdateExistingEmployeeData = "EmployeeInformation/UpdateExistingEmployeeData";
        public static string SpouseInformationList = "SpouseInformation/List";
        public static string SpouseInformation = "SpouseInformation";
        public static string SpouseInformationGetFilterData = "SpouseInformation/GetFilterData";
        public static string ChildrenInformationList = "ChildrenInformation/List";
        public static string ChildrenInformation = "ChildrenInformation";
        public static string ChildrenInformationGetFilterData = "ChildrenInformation/GetFilterData";
        public static string DisciplinaryActionsAndCriminalProsecutionList = "DisciplinaryActionsAndCriminalProsecution/List";
        public static string DisciplinaryActionsAndCriminalProsecution = "DisciplinaryActionsAndCriminalProsecution";
        public static string DisciplinaryActionsAndCriminalProsecutionGetFilterData = "DisciplinaryActionsAndCriminalProsecution/GetFilterData";

        public static string EducationalQualificationList = "EducationalQualification/List";
        public static string EducationalQualification = "EducationalQualification";
        public static string EducationalQualificationGetFilterData = "EducationalQualification/GetFilterData";
        public static string EmployeeTransferList = "EmployeeTransfer/List";
        public static string EmployeeTransfer = "EmployeeTransfer";
        public static string EmployeeTransferGetFilterData = "EmployeeTransfer/GetFilterData";
        public static string OfficialInformationList = "OfficialInformation/List";
        public static string OfficialInformation = "OfficialInformation";
        public static string OfficialInformationGetFilterData = "OfficialInformation/GetFilterData";
        public static string PermanentAddressList = "PermanentAddress/List";
        public static string PermanentAddress = "PermanentAddress";
        public static string PermanentAddressGetFilterData = "PermanentAddress/GetFilterData";
        public static string PostingRecordsList = "PostingRecords/List";
        public static string PostingRecords = "PostingRecords";
        public static string PostingRecordsGetFilterData = "PostingRecords/GetFilterData";
        public static string PresentAddressList = "PresentAddress/List";
        public static string PresentAddress = "PresentAddress";
        public static string PresentAddressGetFilterData = "PresentAddress/GetFilterData";
        public static string PromotionPartcularsList = "PromotionPartculars/List";
        public static string PromotionPartculars = "PromotionPartculars";
        public static string PromotionPartcularsGetFilterData = "PromotionPartculars/GetFilterData";
        public static string ServiceHistoryList = "ServiceHistory/List";
        public static string ServiceHistory = "ServiceHistory";
        public static string ServiceHistoryGetFilterData = "ServiceHistory/GetFilterData";
        public static string TrainingInformationList = "TrainingInformation/List";
        public static string TrainingInformation = "TrainingInformation";
        public static string TrainingInformationGetFilterData = "TrainingInformation/GetFilterData";
        public static string JobCategoryList = "JobCategory/List";
        public static string JobCategory = "JobCategory";
        public static string GradationTypeList = "GradationType/List";
        public static string GradationType = "GradationType";
        public static string EmployeeTypeList = "EmployeeType/List";
        public static string EmployeeType = "EmployeeType";
        public static string UserList = "Account/List";
        public static string UserGetUserInfoByUserRoleId = "Account/GetUserInfoByUserRoleId";
        public static string User = "Account";
        public static string UserLogin = "Account/Login";
        public static string UserGetBeneficiaryByFilter = "Account/GetBeneficiaryByFilter";
        public static string UserGenerateSurveyAccounts = "Account/GenerateSurveyAccounts";
        public static string UserListSurveyAccounts = "Account/ListSurveyAccounts";

        public static string CategoryDoesExist = "Category/DoesExist";
        public static string DesignationClassDoesExist = "DesignationClass/DoesExist";
        public static string DesignationDoesExist = "Designation/DoesExist";
        public static string DistrictDoesExist = "District/DoesExist";
        public static string DivisionDoesExist = "Division/DoesExist";
        public static string EmployeeStatusDoesExist = "EmployeeStatus/DoesExist";
        public static string EmployeeTypeDoesExist = "EmployeeType/DoesExist";
        public static string GradationTypeDoesExist = "GradationType/DoesExist";
        public static string JobCategoryDoesExist = "JobCategory/DoesExist";
        public static string PoliceStationDoesExist = "PoliceStation/DoesExist";
        public static string PostingDoesExist = "Posting/DoesExist";
        public static string PostingTypeDoesExist = "PostingType/DoesExist";
        public static string PostResponsibilityDoesExist = "PostResponsibility/DoesExist";
        public static string PresentStatusDoesExist = "PresentStatus/DoesExist";
        public static string PromtionNatureDoesExist = "PromtionNature/DoesExist";
        public static string RankDoesExist = "Rank/DoesExist";
        public static string LanguageDoesExist = "Language/DoesExist";
        public static string LanguageList = "Language/List";
        public static string Language = "Language";
        public static string LanguageInformationDoesExist = "LanguageInformation/DoesExist";
        public static string LanguageInformationList = "LanguageInformation/List";
        public static string LanguageInformation = "LanguageInformation";
        public static string LanguageInformationGetFilterData = "LanguageInformation/GetFilterData";
        public static string YearsDoesExist = "Years/DoesExist";
        public static string YearsList = "Years/List";
        public static string Years = "Years";
        public static string SpecialHolydaySetupDoesExist = "SpecialHolydaySetup/DoesExist";
        public static string SpecialHolydaySetupList = "SpecialHolydaySetup/List";
        public static string SpecialHolydaySetup = "SpecialHolydaySetup";
        public static string WeeklyHolydaySetupDoesExist = "WeeklyHolydaySetup/DoesExist";
        public static string WeeklyHolydaySetupList = "WeeklyHolydaySetup/List";
        public static string WeeklyHolydaySetup = "WeeklyHolydaySetup";

        public static string LeaveTypeInformationDoesExist = "LeaveTypeInformation/DoesExist";
        public static string LeaveTypeInformationList = "LeaveTypeInformation/List";
        public static string LeaveTypeInformation = "LeaveTypeInformation";

        public static string CalculationMethodDoesExist = "CalculationMethod/DoesExist";
        public static string CalculationMethodList = "CalculationMethod/List";
        public static string CalculationMethod = "CalculationMethod";
        public static string LeaveApplicationDoesExist = "LeaveApplication/DoesExist";
        public static string LeaveApplicationList = "LeaveApplication/List";
        public static string LeaveApplication = "LeaveApplication";
        public static string PayScaleYearInfoList = "PayScaleYearInfo/List";
        public static string PayScaleYearInfo = "PayScaleYearInfo";
        public static string PayScaleYearInfoDoesExist = "PayScaleYearInfo/DoesExist";
        public static string LeaveApplicationGetByEmployeeId = "LeaveApplication/GetByEmployeeId";
        public static string LeaveApplicationGetFilterData = "LeaveApplication/GetFilterData";
        public static string TrainingManagementTypeDoesExist = "TrainingManagementType/DoesExist";
        public static string TrainingManagementTypeList = "TrainingManagementType/List";
        public static string TrainingManagementType = "TrainingManagementType";
        public static string TrainingInformationManagementDoesExist = "TrainingInformationManagement/DoesExist";
        public static string TrainingInformationManagementList = "TrainingInformationManagement/List";
        public static string TrainingInformationManagement = "TrainingInformationManagement";
        public static string GetByTrainingInformationManagementMasterId = "TrainingInformationManagement/GetByTrainingInformationManagementMasterId";
        public static string TrainingInformationManagementGetFilterData = "TrainingInformationManagement/GetFilterData";
        public static string TrainingInformationManagementMasterDoesExist = "TrainingInformationManagementMaster/DoesExist";
        public static string TrainingInformationManagementMasterList = "TrainingInformationManagementMaster/List";
        public static string TrainingInformationManagementMaster = "TrainingInformationManagementMaster";
        public static string TrainingInformationManagementMasterGetFilterData = "TrainingInformationManagementMaster/GetFilterData";
        public static string GetTrainingInformationByTrainingManagementTypeId = "TrainingInformationManagementMaster/GetTrainingInformationByTrainingManagementTypeId";

        public static string PromotionManagementList = "PromotionManagement/List";
        public static string GetPromotionList = "PromotionManagement/PromotionList";
        public static string PromotionManagement = "PromotionManagement";
        public static string PromotionManagementGetFilterData = "PromotionManagement/GetFilterData";

        public static string EmployeeInformationCountList = "EmployeeInformationCount/List";
        public static string EmployeeInformationCount = "EmployeeInformationCount";
        public static string EmployeeInformationCountDoesExist = "EmployeeInformationCount/DoesExist";
        public static string OrganogramList = "Organogram/List";
        public static string Organogram = "Organogram";
        public static string OrganogramDoesExist = "Organogram/DoesExist";


        // CommitteeTypeConfiguration
        public static string CommitteeTypeConfigurationList = "CommitteeTypeConfiguration/List";
        public static string CommitteeTypeConfiguration = "CommitteeTypeConfiguration";
        public static string CommitteeTypeConfigurationDoesExist = "CommitteeTypeConfiguration/DoesExist";
        public static string CommitteeTypeConfigurationGetCommitteeTypeConfigurationByFcvOrVcfId = "CommitteeTypeConfiguration/GetCommitteeTypeConfigurationByFcvOrVcfId";


        //SocialForestryMeeting
        public static string MeetingTypeForSocialForestryMeetingList = "MeetingTypeForSocialForestryMeeting/List";
        public static string MeetingTypeForSocialForestryMeeting = "MeetingTypeForSocialForestryMeeting";
        public static string MeetingTypeForSocialForestryMeetingDoesExist = "MeetingTypeForSocialForestryMeeting/DoesExist";


        // CommitteesConfiguration
        public static string CommitteesConfigurationList = "CommitteesConfiguration/List";
        public static string CommitteesConfiguration = "CommitteesConfiguration";
        public static string CommitteesConfigurationDoesExist = "CommitteesConfiguration/DoesExist";
        public static string CommitteesConfigurationSoftDelete = "CommitteesConfiguration/SoftDelete";
        public static string CommitteesConfigurationGetCommitteesConfigurationByCommitteeTypeConfigurationId = "CommitteesConfiguration/GetCommitteesConfigurationByCommitteeTypeConfigurationId";



        // CommitteeDesignationsConfiguration
        public static string CommitteeDesignationsConfigurationList = "CommitteeDesignationsConfiguration/List";
        public static string CommitteeDesignationsConfiguration = "CommitteeDesignationsConfiguration";
        public static string CommitteeDesignationsConfigurationDoesExist = "CommitteeDesignationsConfiguration/DoesExist";
        public static string CommitteeDesignationsConfigurationGetCommitteeDesignationsConfigurationByCommitteesConfigurationId = "CommitteeDesignationsConfiguration/GetCommitteeDesignationsConfigurationByCommitteesConfigurationId";


        // Committee Management
        public static string CommitteeManagementList = "CommitteeManagement/List";
        public static string CommitteeManagement = "CommitteeManagement";
        public static string CommitteeManagementDoesExist = "CommitteeManagement/DoesExist";
        public static string CommitteeManagementGetByFilter = "CommitteeManagement/GetByFilter";
        public static string CommitteeManagementSoftDelete = "CommitteeManagement/SoftDelete";


        // Committee Management Member
        public static string CommitteeManagementMemberList = "CommitteeManagementMember/List";
        public static string CommitteeManagementMember = "CommitteeManagementMember";
        public static string CommitteeManagementMemberDoesExist = "CommitteeManagementMember/DoesExist";


        // Permission Header Settings
        public static string PermissionHeaderSettingsList = "PermissionHeaderSettings/List";
        public static string PermissionHeaderSettingsGetPermissionHeaderId = "PermissionHeaderSettings/GetPermissionHeaderIdByControllerName";
        public static string PermissionHeaderSettings = "PermissionHeaderSettings";
        public static string PermissionHeaderSettingsDoesExist = "PermissionHeaderSettings/DoesExist";
        public static string GetUserNameByUserRoleIdPermissionHeaderSettings = "PermissionHeaderSettings/GetUserNameByUserRoleId";
        public static string GetPermissionHeaderSettingsByModuleEnumIdPermissionHeaderSettings = "PermissionHeaderSettings/GetPermissionHeaderSettingsByModuleEnumId";
        public static string PermissionHeaderSettingsGetFilterByForestId = "PermissionHeaderSettings/GetFilterByForestId";
        public static string PermissionHeaderSettingsSoftDelete = "PermissionHeaderSettings/SoftDelete";
        public static string PermissionHeaderSettingsGetByFilter = "PermissionHeaderSettings/GetByFilter";


        // Permission Row Settings
        public static string PermissionRowSettingsList = "PermissionRowSettings/List";
        public static string PermissionRowSettings = "PermissionRowSettings";
        public static string PermissionRowSettingsDoesExist = "PermissionRowSettings/DoesExist";
        public static string PermissionRowSettingsGetPermissionRowsByControllerName = "PermissionRowSettings/GetPermissionRowsByControllerName";


        //ApprovalLogForCfmList
        public static string ApprovalLogForCfmList = "ApprovalLogForCfm/List";
        public static string ApprovalLogForCfm = "ApprovalLogForCfm";
        public static string ApprovalLogForCfmDoesExist = "ApprovalLogForCfm/DoesExist";

        public static string CuttingPlantationList = "CuttingPlantation/List";
        public static string CuttingPlantation = "CuttingPlantation";
        public static string CuttingPlantationDoesExist = "CuttingPlantation/DoesExist";
        public static string CuttingPlantationListByNewRaised = "CuttingPlantation/ListByNewRaised";
        public static string CuttingPlantationListByFilter = "CuttingPlantation/ListByFilter";

        public static string LotWiseSellingInformationList = "LotWiseSellingInformation/List";
        public static string LotWiseSellingInformation = "LotWiseSellingInformation";
        public static string LotWiseSellingInformationDoesExist = "LotWiseSellingInformation/DoesExist";
        public static string LotWiseSellingInformationGetLotInfoByCuttingId = "LotWiseSellingInformation/GetLotInfoByCuttingId";
        public static string LotWiseSellingInformationGetLotInfoByLotNumber = "LotWiseSellingInformation/GetLotInfoByLotNumber";

        public static string ReplantationList = "Replantation/List";
        public static string Replantation = "Replantation";
        public static string ReplantationDoesExist = "Replantation/DoesExist";
        public static string ReplantationGetDetails = "Replantation/GetDetails";

        public static string ReplantationCostInfoList = "ReplantationCostInfo/List";
        public static string ReplantationCostInfo = "ReplantationCostInfo";
        public static string ReplantationCostInfoDoesExist = "ReplantationCostInfo/DoesExist";

        public static string ReplantationDamageInfoList = "ReplantationDamageInfo/List";
        public static string ReplantationDamageInfo = "ReplantationDamageInfo";
        public static string ReplantationDamageInfoDoesExist = "ReplantationDamageInfo/DoesExist";

        public static string ReplantationInspectionMapList = "ReplantationInspectionMap/List";
        public static string ReplantationInspectionMap = "ReplantationInspectionMap";
        public static string ReplantationInspectionMapDoesExist = "ReplantationInspectionMap/DoesExist";

        public static string ReplantationLaborInfoList = "ReplantationLaborInfo/List";
        public static string ReplantationLaborInfo = "ReplantationLaborInfo";
        public static string ReplantationLaborInfoDoesExist = "ReplantationLaborInfo/DoesExist";

        public static string ReplantationNurseryInfoList = "ReplantationNurseryInfo/List";
        public static string ReplantationNurseryInfo = "ReplantationNurseryInfo";
        public static string ReplantationNurseryInfoDoesExist = "ReplantationNurseryInfo/DoesExist";

        public static string ReplantationSocialForestryBeneficiaryMapList = "ReplantationSocialForestryBeneficiaryMap/List";
        public static string ReplantationSocialForestryBeneficiaryMap = "ReplantationSocialForestryBeneficiaryMap";
        public static string ReplantationSocialForestryBeneficiaryMapDoesExist = "ReplantationSocialForestryBeneficiaryMap/DoesExist";


        #region Social Forestry

        public static string ConcernedOfficialList = "ConcernedOfficial/List";
        public static string ConcernedOfficial = "ConcernedOfficial";
        public static string ConcernedOfficialDoesExist = "ConcernedOfficial/DoesExist";

        public static string CostInformationList = "CostInformation/List";
        public static string CostInformation = "CostInformation";
        public static string CostInformationDoesExist = "CostInformation/DoesExist";
        public static string CostInformationSoftDelete = "CostInformation/SoftDelete";


        public static string CostInformationFileList = "CostInformationFile/List";
        public static string CostInformationFile = "CostInformationFile";
        public static string CostInformationFileDoesExist = "CostInformationFile/DoesExist";

        public static string CostTypeList = "CostType/List";
        public static string CostType = "CostType";
        public static string CostTypeDoesExist = "CostType/DoesExist";

        public static string InspectionDetailsList = "InspectionDetails/List";
        public static string InspectionDetails = "InspectionDetails";
        public static string InspectionDetailsDoesExist = "InspectionDetails/DoesExist";

        public static string LaborCostTypeList = "LaborCostType/List";
        public static string LaborCostType = "LaborCostType";
        public static string LaborCostTypeDoesExist = "LaborCostType/DoesExist";

        public static string LaborInformationList = "LaborInformation/List";
        public static string LaborInformation = "LaborInformation";
        public static string LaborInformationDoesExist = "LaborInformation/DoesExist";

        public static string DistributedToBeneficiaryList = "DistributedToBeneficiary/List";
        public static string DistributedToBeneficiary = "DistributedToBeneficiary";
        public static string DistributedToBeneficiaryDoesExist = "DistributedToBeneficiary/DoesExist";

        public static string DistributionFundTypeList = "DistributionFundType/List";
        public static string DistributionFundType = "DistributionFundType";
        public static string DistributionFundTypeDoesExist = "DistributionFundType/DoesExist";

        public static string DistributionPercentageList = "DistributionPercentage/List";
        public static string DistributionPercentage = "DistributionPercentage";
        public static string DistributionPercentageByPlantationType = "DistributionPercentage/GetByPlantationType";
        public static string DistributionPercentageCreateRange = "DistributionPercentage/CreateRangeAsync";
        public static string DistributionPercentageUpdateRange = "DistributionPercentage/UpdateRangeAsync";
        public static string DistributionPercentageDoesExist = "DistributionPercentage/DoesExist";

        public static string ShareDistributionList = "ShareDistribution/List";
        public static string ShareDistribution = "ShareDistribution";
        public static string ShareDistributionDoesExist = "ShareDistribution/DoesExist";
        public static string ShareDistributionGetDefaultDistributionData = "ShareDistribution/GetDefaultDistributionData";
        public static string ShareDistributionListByCuttingPlantation = "ShareDistribution/ListByCuttingPlantation";

        public static string LaborInformationFileList = "LaborInformationFile/List";
        public static string LaborInformationFile = "LaborInformationFile";
        public static string LaborInformationFileDoesExist = "LaborInformationFile/DoesExist";

        public static string PlantationList = "Plantation/List";
        public static string Plantation = "Plantation";
        public static string PlantationDoesExist = "Plantation/DoesExist";

        public static string PlantationCauseOfDamageList = "PlantationCauseOfDamage/List";
        public static string PlantationCauseOfDamage = "PlantationCauseOfDamage";
        public static string PlantationCauseOfDamageDoesExist = "PlantationCauseOfDamage/DoesExist";

        public static string PlantationDamageInformationList = "PlantationDamageInformation/List";
        public static string PlantationDamageInformation = "PlantationDamageInformation";
        public static string PlantationDamageInformationDoesExist = "PlantationDamageInformation/DoesExist";

        public static string PlantationFileList = "PlantationFile/List";
        public static string PlantationFile = "PlantationFile";
        public static string PlantationFileDoesExist = "PlantationFile/DoesExist";

        public static string PlantationPlantList = "PlantationPlant/List";
        public static string PlantationPlant = "PlantationPlant";
        public static string PlantationPlantDoesExist = "PlantationPlant/DoesExist";

        public static string PlantationSocialForestryBeneficiaryMapList = "PlantationSocialForestryBeneficiaryMap/List";
        public static string PlantationSocialForestryBeneficiaryMap = "PlantationSocialForestryBeneficiaryMap";
        public static string PlantationSocialForestryBeneficiaryMapDoesExist = "PlantationSocialForestryBeneficiaryMap/DoesExist";

        public static string PlantationTopographyList = "PlantationTopography/List";
        public static string PlantationTopography = "PlantationTopography";
        public static string PlantationTopographyDoesExist = "PlantationTopography/DoesExist";

        public static string PlantationUnitList = "PlantationUnit/List";
        public static string PlantationUnitListByType = "PlantationUnit/ListByType";
        public static string PlantationUnit = "PlantationUnit";
        public static string PlantationUnitDoesExist = "PlantationUnit/DoesExist";

        public static string ProjectTypeList = "ProjectType/List";
        public static string ProjectType = "ProjectType";
        public static string ProjectTypeDoesExist = "ProjectType/DoesExist";

        public static string SocialForestryBeneficiaryList = "SocialForestryBeneficiary/List";
        public static string SocialForestryBeneficiary = "SocialForestryBeneficiary";
        public static string SocialForestryBeneficiaryDoesExist = "SocialForestryBeneficiary/DoesExist";
        public static string SocialForestryBeneficiaryGetBeneficiariesByNewRaisedId = "SocialForestryBeneficiary/GetBeneficiariesByNewRaisedId";

        public static string SocialForestryDesignationList = "SocialForestryDesignation/List";
        public static string SocialForestryDesignation = "SocialForestryDesignation";
        public static string SocialForestryDesignationDoesExist = "SocialForestryDesignation/DoesExist";

        public static string SocialForestryNgoList = "SocialForestryNgo/List";
        public static string SocialForestryNgo = "SocialForestryNgo";
        public static string SocialForestryNgoDoesExist = "SocialForestryNgo/DoesExist";

        public static string ZoneOrAreaList = "ZoneOrArea/List";
        public static string ZoneOrArea = "ZoneOrArea";
        public static string ZoneOrAreaDoesExist = "ZoneOrArea/DoesExist";

        public static string NurseryCostInformationList = "NurseryCostInformation/List";
        public static string NurseryCostInformation = "NurseryCostInformation";
        public static string NurseryCostInformationDoesExist = "NurseryCostInformation/DoesExist";

        public static string NurseryCostInformationFileList = "NurseryCostInformationFile/List";
        public static string NurseryCostInformationFile = "NurseryCostInformationFile";
        public static string NurseryCostInformationFileDoesExist = "NurseryCostInformationFile/DoesExist";


        //Nursery

        public static string NurseryTypeList = "NurseryType/List";
        public static string NurseryType = "NurseryType";
        public static string NurseryTypeDoesExist = "NurseryType/DoesExist";

        public static string NurseryRaisingSectorList = "NurseryRaisingSector/List";
        public static string NurseryRaisingSector = "NurseryRaisingSector";
        public static string NurseryRaisingSectorDoesExist = "NurseryRaisingSector/DoesExist";

        public static string NurseryRaisedSeedlingInformationList = "NurseryRaisedSeedlingInformation/List";
        public static string NurseryRaisedSeedlingInformation = "NurseryRaisedSeedlingInformation";
        public static string SeedlingInformationUpate = "NurseryRaisedSeedlingInformation/SeedlingUpdate";
        public static string NurseryRaisedSeedlingInformationDoesExist = "NurseryRaisedSeedlingInformation/DoesExist";
        public static string NurseryRaisedSeedlingInformationGetSeedlingByNurseryId = "NurseryRaisedSeedlingInformation/GetSeedlingByNurseryId";
        public static string NurseryRaisedSeedlingInformationSoftDelete = "NurseryRaisedSeedlingInformation/SoftDelete";


        public static string NurseryInformationList = "NurseryInformation/List";
        public static string NurseryInformation = "NurseryInformation";
        public static string NurseryInformationDoesExist = "NurseryInformation/DoesExist";
        public static string NurseryInformationFilterData = "NurseryInformation/GetFilterData";
        public static string NurseryInformationReport= "NurseryInformation/GetNurseryReport";
        public static string NurseryDistributionReport= "NurseryInformation/GetNurseryDistributionReport";
        public static string BeneficiaryWiseDistribution= "NurseryInformation/BeneficiaryWiseDistribution";
        public static string NurseryInformationSoftDelete = "NurseryInformation/SoftDelete";
        


        public static string NurseryDistributionList = "NurseryDistribution/List";
        public static string NurseryDistribution = "NurseryDistribution";
        public static string NurseryDistributionCreateRange = "NurseryDistribution/CreateRangeAsync";
        public static string NurseryDistributionUpdateRange = "NurseryDistribution/UpdateRangeAsync";
        public static string NurseryDistributionByNurseryId = "NurseryDistribution/Nursery";
        public static string NurseryDistributionByDistributionId = "NurseryDistribution/Distribution";
        public static string NurseryDistributionDoesExist = "NurseryDistribution/DoesExist";
        public static string NurseryDistributionFilterData = "NurseryDistribution/GetFilterData";
        public static string NurseryDistributionFilterByDate = "NurseryDistribution/GetByDate";
        #endregion

    }

    public static class ResponseHelper
    {
        public static string AvailableProductResponse = "{  \"data\": [{    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"INTERNET JOUR 100 Mo\",        \"ar\": \"INTERNET يوم\",        \"en\": \"INTERNET DAY 100 Mb Today\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"100 Mo\",        \"ar\": \"100 Mo\",        \"en\": \"100 Mo\"      },      \"code\": \"INTSPEEDHOURSPOST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">60 minutes </span><br /><strong>24 Hrs</strong><br>\\r\\nHoraire de disponibilité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">100 Mo </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\" > دقيقة </span><span style=\\\"color: #ff0000;\\\" >&nbsp 60</span></br>مدة الصلاحية</br><strong>24 Hrs</strong><br>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">ميغا</span><span style=\\\"color: #ff0000;\\\">&nbsp 100</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">60 minutes </span><br /><strong>24 Hrs</strong><br></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">100 Mb </span><br />Internet Offers</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/542/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/542/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/542/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/542/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/542/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/542\"    },    \"id\": \"542\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"SPEED HEURE ILLIMITE\",        \"ar\": \"SPEED ساعة غير محدودة\",        \"en\": \"SPEED Hour UNLLIMITED\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"SPEED HEURE\",        \"ar\": \"SPEED HEURE\",        \"en\": \"SPEED HEURE\"      },      \"code\": \"INTSPEEDHOURSPOSTUNL\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">60 min </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">illimité </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\"> دقيقة </span><span style=\\\"color: #ff0000;\\\"> &nbsp60  </span></br>مدة الصلاحية<br /><strong>من 00:00 الي07:00 </strong><br>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">غير محدود</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">60 min </span><br />Validity <br /><strong>from 00h00 to 07h00</strong><br></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">unlimited </span><br />Internet Offers</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/544/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/544/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/544/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/544/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/544/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/544\"    },    \"id\": \"544\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"INTERNET JOUR 250 Mo\",        \"ar\": \"INTERNET يوم\",        \"en\": \"INTERNET DAY 250 Mb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"250 Mo\",        \"ar\": \"250 Mo\",        \"en\": \"250 Mo\"      },      \"code\": \"INTSPEEDDAY1POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">24h </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">250 Mo </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">ساعة  </span><span style=\\\"color: #ff0000;\\\" > &nbsp 24 </span><br/><strong>مدة الصلاحية</strong><br>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;color: #ff0000;\\\"><span style=\\\"color: #ff0000;\\\"  dir=\\\"rtl\\\">  ميغا  </span> &nbsp 250 <br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">24h </span><br />Validity</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">250 Mb </span><br />Internet Offers</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/546/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/546/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/546/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/546/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/546/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/546\"    },    \"id\": \"546\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 2,      \"name\": {        \"fr\": \"SPEED 300 Mo\",        \"ar\": \"<p> SPEED <span dir=\\\"ltr\\\"> ميغا </span> &nbsp 300</p>\",        \"en\": \"SPEED 300 Mb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"INTSPEEDDAY2POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">2 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">300 Mo </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\"> يومين </span><br/><strong>مدة الصلاحية</strong><br>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;color: #ff0000;\\\"><span style=\\\"color: #ff0000;\\\"  dir=\\\"rtl\\\">  ميغا </span> &nbsp 300 <br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">2 Days</span><br />Validity</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">300 Mb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/550/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/550/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/550/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/550/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/550/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/550\"    },    \"id\": \"550\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 4,      \"name\": {        \"fr\": \"SPEED 600 Mo\",        \"ar\": \"<p> SPEED <span dir=\\\"ltr\\\"> ميغا </span> &nbsp 600</p>\",        \"en\": \"SPEED 600 Mb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"INTSPEEDDAY4POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">4 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">600 Mo </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\" ><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\" >  ايام </span><span style=\\\"color: #ff0000;\\\" >&nbsp 4</span><br/><strong>مدة الصلاحية</strong><br>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;color: #ff0000;\\\"><span style=\\\"color: #ff0000;\\\"  dir=\\\"rtl\\\">  ميغا </span> &nbsp 600 <br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">4 Days </span><br />Validity</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">600 Mb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/552/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/552/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/552/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/552/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/552/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/552\"    },    \"id\": \"552\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"INTERNET MOIS 1Go\",        \"ar\": \"INTERNET شهر1  جيغا\",        \"en\": \"INTERNET MONTH 1Gb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"1Go\",        \"ar\": \"1Go\",        \"en\": \"1Go\"      },      \"code\": \"INTSPEEDMONTH1POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">1 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">  يوم </span><span style=\\\"color: #ff0000;\\\"> &nbsp 30 </span><br/>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">جيغا </span><span style=\\\"color: #ff0000;\\\"> &nbsp 1</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Days</span><br />Validity</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">1 Gb</span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/554/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/554/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/554/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/554/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/554/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/554\"    },    \"id\": \"554\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"SPEED 2,5Go\",        \"ar\": \"<p> SPEED <span dir=\\\"ltr\\\"> جيغا </span> &nbsp 2.5</p>\",        \"en\": \"SPEED 2,5Gb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"INTSPEEDMONTH2n5POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validté</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">2.5 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">  يوم </span><span style=\\\"color: #ff0000;\\\"> &nbsp 30 </span><br/>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">جيغا </span><span style=\\\"color: #ff0000;\\\"> &nbsp 2.5</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Days</span><br />Validity\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">2.5 Gb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/558/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/558/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/558/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/558/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/558/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/558\"    },    \"id\": \"558\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"INTERNET MOIS 6 Go\",        \"ar\": \"INTERNET شهر6  جيغا\",        \"en\": \"INTERNET MONTH 6 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"6 Go\",        \"ar\": \"6 Go\",        \"en\": \"6 Go\"      },      \"code\": \"INTSPEEDMONTH5POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">6 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">  يوم </span><span style=\\\"color: #ff0000;\\\"> &nbsp 30 </span><br/>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">جيغا </span><span style=\\\"color: #ff0000;\\\"> &nbsp 6</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Days</span><br />Validity\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">6 Gb</span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/560/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/560/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/560/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/560/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/560/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/560\"    },    \"id\": \"560\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"SPEED 10Go\",        \"ar\": \"<p> SPEED <span dir=\\\"ltr\\\"> جيغا </span> &nbsp 10</p>\",        \"en\": \"SPEED 10Gb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"INTSPEEDMONTH10POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">10 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">  يوم </span><span style=\\\"color: #ff0000;\\\"> &nbsp 30 </span><br/>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">جيغا </span><span style=\\\"color: #ff0000;\\\"> &nbsp 10</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validity\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">10 Gb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/562/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/562/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/562/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/562/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/562/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/562\"    },    \"id\": \"562\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"SPEED 20Go\",        \"ar\": \"<p> SPEED <span dir=\\\"ltr\\\"> جيغا </span> &nbsp 20</p>\",        \"en\": \"SPEED 20Gb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"INTSPEEDMONTH20POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Jours </span><br />Validité</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">20 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">  يوم </span><span style=\\\"color: #ff0000;\\\"> &nbsp 30 </span><br/>\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">جيغا </span><span style=\\\"color: #ff0000;\\\"> &nbsp 20</span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">30 Days</span><br />Validity</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">20 Gb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/566/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/566/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/566/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/566/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/566/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/566\"    },    \"id\": \"566\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"INTERNET JOUR  50 Mo\",        \"ar\": \"<p> INTERNET<span dir =\\\"ltr\\\">يوم</span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 50</p>\",        \"en\": \"INTERNET DAY 50 Mo\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"50 Mo\",        \"ar\": \"50 Mo\",        \"en\": \"50 Mo\"      },      \"code\": \"INTAMIGO1POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO jour</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">50 Mo</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">24H </span><br />Validité</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO يوم</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\"dir=\\\"rtl\\\">ميغا</span><span style=\\\"color: #ff0000;\\\">&nbsp 50</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">ساعة</span><span style=\\\"color: #ff0000;\\\">&nbsp 24</span><br /></p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO Day</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">50 Mb</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">24H </span><br />Validity\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/582/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/582/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/582/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/582/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/582/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/582\"    },    \"id\": \"582\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"INTERNET SEMAINE 200 Mo\",        \"ar\": \"<p> INTERNET <span dir =\\\"ltr\\\">اسبوع </span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 200</p>\",        \"en\": \"INTERNET WEEK 200 Mb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"200 Mo\",        \"ar\": \"200 Mo\",        \"en\": \"200 Mo\"      },      \"code\": \"INTAMIGO7POST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO Semaine</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">200 Mo</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">7 Jours </span><br />Validité</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO اسبوع</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\"dir=\\\"rtl\\\">ميغا</span><span style=\\\"color: #ff0000;\\\">&nbsp 200</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><strong>مدة الصلاحية</strong><br><span style=\\\"color: #ff0000;\\\" dir=\\\"rtl\\\">ايام</span><span style=\\\"color: #ff0000;\\\">&nbsp 7</span><br /></p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><strong><span style=\\\"color: #ff0000;\\\">AMIGO Week</span></strong></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">200 Mb</span><br />Facebook, Twitter & WhatsApp</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">7 Days </span><br />Validity\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"a\",        \"ar\": \"a\",        \"en\": \"a\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/584/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/584/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/584/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/584/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/584/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/584\"    },    \"id\": \"584\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Verso+\",        \"ar\": \"فيرسو+\",        \"en\": \"Verso+\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"VMN\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/772/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/772/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/772/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/772/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/772/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/772\"    },    \"id\": \"772\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roaming Data Limit 1\",        \"ar\": \"Roaming Data Limit 1\",        \"en\": \"Roaming Data Limit 1\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 1\"      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATA1\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 1\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 1\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/820/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/820/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/820/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/820/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/820/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/820\"    },    \"id\": \"820\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roaming Data Limit 2\",        \"ar\": \"Roaming Data Limit 2\",        \"en\": \"Roaming Data Limit 2\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 2\"      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATA2\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 2\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 2\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/823/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/823/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/823/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/823/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/823/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/823\"    },    \"id\": \"823\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roaming Data Limit 3\",        \"ar\": \"Roaming Data Limit 3\",        \"en\": \"Roaming Data Limit 3\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 3\"      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATA3\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 3\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 3\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/826/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/826/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/826/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/826/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/826/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/826\"    },    \"id\": \"826\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roaming Data Limit 4\",        \"ar\": \"Roaming Data Limit 4\",        \"en\": \"Roaming Data Limit 4\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 4\"      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATA4\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 4\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Waiting Djezzy\",        \"ar\": \"Waiting Djezzy\",        \"en\": \"Roaming Data Limit 4\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/829/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/829/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/829/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/829/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/829/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/829\"    },    \"id\": \"829\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roaming Data Limit 5\",        \"ar\": \"Roaming Data Limit 5\",        \"en\": \"Roaming Data Limit 5\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": \"Roaming Data Limit 5\",        \"ar\": \"Roaming Data Limit 5\",        \"en\": \"Roaming Data Limit 5\"      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATA5\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Roaming Data Limit 5\",        \"ar\": \"Roaming Data Limit 5\",        \"en\": \"Roaming Data Limit 5\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Roaming Data Limit 5\",        \"ar\": \"Roaming Data Limit 5\",        \"en\": \"Roaming Data Limit 5\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/832/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/832/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/832/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/832/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/832/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/832\"    },    \"id\": \"832\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Hide Number Free\",        \"ar\": \"Hide Number Free\",        \"en\": \"Hide Number Free\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"APPELMASQUE\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Hide Number Free\",        \"ar\": \"Hide Number Free\",        \"en\": \"Hide Number Free\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1336/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1336/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1336/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"46\"        },        \"links\": {          \"related\": \"/api/v1/products/1336/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1336/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1336\"    },    \"id\": \"1336\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"CLIP+\",        \"ar\": \"CLIP+\",        \"en\": \"CLIP+\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"MCN\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"CLIP+\",        \"ar\": \"CLIP+\",        \"en\": \"CLIP+\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1366/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1366/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1366/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"46\"        },        \"links\": {          \"related\": \"/api/v1/products/1366/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1366/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1366\"    },    \"id\": \"1366\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Djezzy Scoop\",        \"ar\": \"جازي سكوب\",        \"en\": \"Djezzy Scoop\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"DJEZZYSCOOP\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Djezzy Scoop\",        \"ar\": \"Djezzy Scoop\",        \"en\": \"Djezzy Scoop\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1372/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1372/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1372/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/1372/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1372/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1372\"    },    \"id\": \"1372\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Ranati\",        \"ar\": \"رنتي\",        \"en\": \"Ranati\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"RANATI\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Ranati\",        \"ar\": \"Ranati\",        \"en\": \"Ranati\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1375/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1375/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1375/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/1375/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1375/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1375\"    },    \"id\": \"1375\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Parental control\",        \"ar\": \"الرقابة الأبوية لجازي\",        \"en\": \"Parental control\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"PARENTALCONTROL\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Parental control\",        \"ar\": \"Parental control\",        \"en\": \"Parental control\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1384/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1384/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1384/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/1384/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1384/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1384\"    },    \"id\": \"1384\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Boite vocale\",        \"ar\": \"البريد الصوتي\",        \"en\": \"Voice mail\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"VMS\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"VMS\",        \"ar\": \"VMS\",        \"en\": \"VMS\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1423/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1423/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1423/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/1423/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1423/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1423\"    },    \"id\": \"1423\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Appels nationaux\",        \"ar\": \"Appels nationaux\",        \"en\": \"Appels nationaux\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": \"-\",        \"ar\": \"-\",        \"en\": \"-\"      },      \"code\": \"VOICEOFFNET90MINPOST\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">90 min</h4>\\r\\nAppels nationaux  <br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\",        \"ar\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">90 min</h4>\\r\\nAppels nationaux  <br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\",        \"en\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">90 min</h4>\\r\\nAppels nationaux  <br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"-\",        \"ar\": \"-\",        \"en\": \"-\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1708/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1708/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1708/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"34\"        },        \"links\": {          \"related\": \"/api/v1/products/1708/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1708/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1708\"    },    \"id\": \"1708\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"SMART OPTION INTERNET 10 Go\",        \"ar\": \"SMART انترنت 10 جيغا\",        \"en\": \"SMART INTERNET  OPTION 10 Gb\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"DATA1MONTH10POST\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">Valable durant le mois de facturation </span><br />Validit&eacute;</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">10 Go </span><br />Forfait Internet</p>\",        \"ar\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">صالح خلال شهر الفاتورة </span><br /></p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">10 جيغا </span><br />عروض الانترنت</p>\",        \"en\": \"<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\"> Available during the billing month </span><br />Validity\\r\\n</p>\\r\\n<p style=\\\"text-align: left;\\\"><span style=\\\"color: #ff0000;\\\">10 Gb </span><br />Internet Offers\\r\\n</p>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"SMART OPTION INTERNET 10 Go\",        \"ar\": \"SMART انترنت 10 جيغا\",        \"en\": \"SMART INTERNET  OPTION 10 Gb\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1711/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1711/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1711/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/1711/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1711/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1711\"    },    \"id\": \"1711\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"FLEXILY\",        \"ar\": \"فليكسيلي\",        \"en\": \"FLEXILY\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"FLEXILY\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"FLEXILY\",        \"ar\": \"FLEXILY\",        \"en\": \"FLEXILY\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1778/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1778/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1778/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/1778/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1778/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1778\"    },    \"id\": \"1778\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Pay as You Go service\",        \"ar\": \"Pay as You Go service\",        \"en\": \"Pay as You Go service\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": \"4.99 DA /MB\",        \"ar\": \"4.99 DA /MB\",        \"en\": \"4.99 DA /MB\"      },      \"code\": \"RCPAGDATAHP\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"4.99 DA /MB\",        \"ar\": \"4.99 DA /MB\",        \"en\": \"4.99 DA /MB\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Pay as You Go service\",        \"ar\": \"Pay as You Go service\",        \"en\": \"Pay as You Go service\"      },      \"display-order\": 500    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1951/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1951/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1951/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/1951/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1951/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1951\"    },    \"id\": \"1951\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"100 MMS\",        \"ar\": \"100 MMS.\",        \"en\": \"100 MMS.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB25MMS\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"100 MMS\",        \"ar\": \"100 MMS.\",        \"en\": \"100 MMS.\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1954/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1954/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1954/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1954/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1954/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1954\"    },    \"id\": \"1954\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"10 Go/mois\",        \"ar\": \"10 Go monthly\",        \"en\": \"10 Go monthly\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB26DATA\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"10 Go/mois\",        \"ar\": \"10 Go monthly\",        \"en\": \"10 Go monthly\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1957/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1957/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1957/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1957/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1957/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1957\"    },    \"id\": \"1957\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"150 Minutes\",        \"ar\": \"150 Minutes.\",        \"en\": \"150 Minutes.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB27VOICE\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"150 Minutes\",        \"ar\": \"150 Minutes.\",        \"en\": \"150 Minutes.\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1960/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1960/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1960/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1960/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1960/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1960\"    },    \"id\": \"1960\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"200 Minutes\",        \"ar\": \"200 Minutes.\",        \"en\": \"200 Minutes.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB28VOICE\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"200 Minutes\",        \"ar\": \"200 Minutes.\",        \"en\": \"200 Minutes.\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1963/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1963/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1963/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1963/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1963/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1963\"    },    \"id\": \"1963\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"220 SMS\",        \"ar\": \"220 SMS.\",        \"en\": \"220 SMS.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB29SMS\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"220 SMS\",        \"ar\": \"220 SMS.\",        \"en\": \"220 SMS.\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1966/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1966/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1966/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1966/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1966/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1966\"    },    \"id\": \"1966\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"250 SMS\",        \"ar\": \"250 SMS.\",        \"en\": \"250 SMS.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB30SMS\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"250 SMS\",        \"ar\": \"250 SMS.\",        \"en\": \"250 SMS.\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/1969/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/1969/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/1969/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/1969/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/1969/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/1969\"    },    \"id\": \"1969\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"DATA FREE   3Go POST MONTH\",        \"ar\": \"DATA FREE   3Go POST MONTH\",        \"en\": \"DATA FREE   3Go POST MONTH\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"DATA FREE   3Go POST MONTH\",        \"ar\": \"DATA FREE   3Go POST MONTH\",        \"en\": \"DATA FREE   3Go POST MONTH\"      },      \"code\": \"BTLBONUSMARTS\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"DATA FREE   3Go POST MONTH\",        \"ar\": \"DATA FREE   3Go POST MONTH\",        \"en\": \"DATA FREE   3Go POST MONTH\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2053/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2053/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2053/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2053/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2053/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2053\"    },    \"id\": \"2053\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Bill itemization 200\",        \"ar\": \"Bill itemization 200\",        \"en\": \"Bill itemization 200\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"BILLITEMIZ\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Bill itemization 200\",        \"ar\": \"Bill itemization 200\",        \"en\": \"Bill itemization 200\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2054/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2054/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2054/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"34\"        },        \"links\": {          \"related\": \"/api/v1/products/2054/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2054/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2054\"    },    \"id\": \"2054\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Bill Amnex\",        \"ar\": \"Bill Amnex\",        \"en\": \"Bill Amnex\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"BILLANNEX\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Bill Amnex\",        \"ar\": \"Bill Amnex\",        \"en\": \"Bill Amnex\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2055/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2055/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2055/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"34\"        },        \"links\": {          \"related\": \"/api/v1/products/2055/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2055/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2055\"    },    \"id\": \"2055\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"DATA FREE   8Go POST MONTH\",        \"ar\": \"DATA FREE   8Go POST MONTH\",        \"en\": \"DATA FREE   8Go POST MONTH\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"DATA FREE   8Go POST MONTH\",        \"ar\": \"DATA FREE   8Go POST MONTH\",        \"en\": \"DATA FREE   8Go POST MONTH\"      },      \"code\": \"BTLBONUSMARTM\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"DATA FREE   8Go POST MONTH\",        \"ar\": \"DATA FREE   8Go POST MONTH\",        \"en\": \"DATA FREE   8Go POST MONTH\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2056/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2056/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2056/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2056/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2056/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2056\"    },    \"id\": \"2056\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"DATA FREE  14Go POST  MONTH\",        \"ar\": \"DATA FREE  14Go POST  MONTH\",        \"en\": \"DATA FREE  14Go POST  MONTH\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"DATA FREE  14Go POST  MONTH\",        \"ar\": \"DATA FREE  14Go POST  MONTH\",        \"en\": \"DATA FREE  14Go POST  MONTH\"      },      \"code\": \"BTLBONUSMARTL\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"DATA FREE  14Go POST  MONTH\",        \"ar\": \"DATA FREE  14Go POST  MONTH\",        \"en\": \"DATA FREE  14Go POST  MONTH\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2057/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2057/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2057/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2057/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2057/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2057\"    },    \"id\": \"2057\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"FLXY\",        \"ar\": \"FLXY\",        \"en\": \"FLXY\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"FLXY\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"FLXY\",        \"ar\": \"FLXY\",        \"en\": \"FLXY\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2066/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2066/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2066/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/2066/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2066/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2066\"    },    \"id\": \"2066\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"INTERNET JOUR  50 Mo\",        \"ar\": \"<p> INTERNET<span dir =\\\"ltr\\\">يوم</span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 50</p>\",        \"en\": \"INTERNET DAY 50 Mo\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"50 Mo\",        \"ar\": \"50 Mo\",        \"en\": \"50 Mo\"      },      \"code\": \"INTAMIGO1DATADEFAULTPOST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"INTERNET JOUR  50 Mo\",        \"ar\": \"<p> INTERNET<span dir =\\\"ltr\\\">يوم</span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 50</p>\",        \"en\": \"INTERNET DAY 50 Mo\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2095/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2095/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2095/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/2095/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2095/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2095\"    },    \"id\": \"2095\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 168,      \"name\": {        \"fr\": \"INTERNET 200 Mo  SEMAINE\",        \"ar\": \"<p> INTERNET <span dir =\\\"ltr\\\">اسبوع </span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 200</p>\",        \"en\": \"INTERNET 200 Mb WEEK\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"200 Mo\",        \"ar\": \"200 Mo\",        \"en\": \"200 Mo\"      },      \"code\": \"INTAMIGO7DATADEFAULTPOST\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"INTERNET 200 Mo  SEMAINE\",        \"ar\": \"<p> INTERNET <span dir =\\\"ltr\\\">اسبوع </span> <span dir=\\\"rtl\\\">  ميغا </span> &nbsp 200</p>\",        \"en\": \"INTERNET 200 Mb WEEK\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2096/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2096/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2096/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"4\"        },        \"links\": {          \"related\": \"/api/v1/products/2096/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2096/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2096\"    },    \"id\": \"2096\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"Dormant offer new\",        \"ar\": \"Dormant offer new\",        \"en\": \"Dormant offer new\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"months\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"DORMANTOFFERNEW\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_24_months\",      \"medium-description\": {        \"fr\": \"Dormant offer new\",        \"ar\": \"Dormant offer new\",        \"en\": \"Dormant offer new\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2151/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2151/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2151/option-group\"        }      },      \"product-family\": {        \"links\": {          \"related\": \"/api/v1/products/2151/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2151/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2151\"    },    \"id\": \"2151\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Balance transfer SOS_600\",        \"ar\": \"Balance transfer SOS_600\",        \"en\": \"Balance transfer SOS_600\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"RCSOS600\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Balance transfer SOS_600\",        \"ar\": \"Balance transfer SOS_600\",        \"en\": \"Balance transfer SOS_600\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2158/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2158/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2158/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"34\"        },        \"links\": {          \"related\": \"/api/v1/products/2158/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2158/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2158\"    },    \"id\": \"2158\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 720,      \"name\": {        \"fr\": \"DATA  BONUS 4Go POST MONTH\",        \"ar\": \"DATA  BONUS 4Go POST MONTH\",        \"en\": \"DATA  BONUS 4Go POST MONTH\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB31DATA\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"DATA  BONUS 4Go POST MONTH\",        \"ar\": \"DATA  BONUS 4Go POST MONTH\",        \"en\": \"DATA  BONUS 4Go POST MONTH\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2198/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2198/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2198/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2198/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2198/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2198\"    },    \"id\": \"2198\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 720,      \"name\": {        \"fr\": \"DATA  BONUS 6Go POST MONTH\",        \"ar\": \"DATA  BONUS 6Go POST MONTH\",        \"en\": \"DATA  BONUS 6Go POST MONTH\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"CMSB32DATA\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"DATA  BONUS 6Go POST MONTH\",        \"ar\": \"DATA  BONUS 6Go POST MONTH\",        \"en\": \"DATA  BONUS 6Go POST MONTH\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2199/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2199/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2199/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2199/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2199/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2199\"    },    \"id\": \"2199\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"100 Mo FLEXY NET\",        \"ar\": \"100 Mo FLEXY NET\",        \"en\": \"100 Mo FLEXY NET\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"100 Mo\",        \"ar\": \"100 Mo\",        \"en\": \"100 Mo\"      },      \"code\": \"TransferInternet100Mo\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Transfer internet 100 Mo\",        \"ar\": \"Transfer internet 100 Mo\",        \"en\": \"Transfer internet 100 Mo\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2218/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2218/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2218/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/2218/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2218/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2218\"    },    \"id\": \"2218\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"200 Mo FLEXY NET\",        \"ar\": \"200 Mo FLEXY NET\",        \"en\": \"200 Mo FLEXY NET\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"200 Mo\",        \"ar\": \"200 Mo\",        \"en\": \"200 Mo\"      },      \"code\": \"TransferInternet200Mo\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Transfer internet 200 Mo\",        \"ar\": \"Transfer internet 200 Mo\",        \"en\": \"Transfer internet 200 Mo\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2219/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2219/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2219/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/2219/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2219/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2219\"    },    \"id\": \"2219\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 24,      \"name\": {        \"fr\": \"500 Mo FLEXY NET\",        \"ar\": \"500 Mo FLEXY NET\",        \"en\": \"500 Mo FLEXY NET\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"hours\",      \"short-description\": {        \"fr\": \"500 Mo\",        \"ar\": \"500 Mo\",        \"en\": \"500 Mo\"      },      \"code\": \"TransferInternet500Mo\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Transfer internet 500 Mo\",        \"ar\": \"Transfer internet 500 Mo\",        \"en\": \"Transfer internet 500 Mo\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2220/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2220/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2220/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"25\"        },        \"links\": {          \"related\": \"/api/v1/products/2220/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2220/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2220\"    },    \"id\": \"2220\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"Quiz bonus 10 GB\",        \"ar\": \"Quiz bonus 10 GB\",        \"en\": \"Quiz bonus 10 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"10Go\",        \"ar\": \"10Go\",        \"en\": \"10Go\"      },      \"code\": \"QUIZBONUS10\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 10 GB\",        \"ar\": \"Quiz bonus 10 GB\",        \"en\": \"Quiz bonus 10 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2222/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2222/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2222/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2222/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2222/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2222\"    },    \"id\": \"2222\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"Quiz bonus 8 GB\",        \"ar\": \"Quiz bonus 8 GB\",        \"en\": \"Quiz bonus 8 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"8Go\",        \"ar\": \"8Go\",        \"en\": \"8Go\"      },      \"code\": \"QUIZBONUS8\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 8 GB\",        \"ar\": \"Quiz bonus 8 GB\",        \"en\": \"Quiz bonus 8 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2228/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2228/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2228/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2228/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2228/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2228\"    },    \"id\": \"2228\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"Quiz bonus 6 GB\",        \"ar\": \"Quiz bonus 6 GB\",        \"en\": \"Quiz bonus 6 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"6Go\",        \"ar\": \"6Go\",        \"en\": \"6Go\"      },      \"code\": \"QUIZBONUS6\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 6 GB\",        \"ar\": \"Quiz bonus 6 GB\",        \"en\": \"Quiz bonus 6 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2229/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2229/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2229/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2229/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2229/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2229\"    },    \"id\": \"2229\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 30,      \"name\": {        \"fr\": \"Quiz bonus 5 GB\",        \"ar\": \"Quiz bonus 5 GB\",        \"en\": \"Quiz bonus 5 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"5Go\",        \"ar\": \"5Go\",        \"en\": \"5Go\"      },      \"code\": \"QUIZBONUS5\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 5 GB\",        \"ar\": \"Quiz bonus 5 GB\",        \"en\": \"Quiz bonus 5 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2230/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2230/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2230/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2230/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2230/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2230\"    },    \"id\": \"2230\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"Quiz bonus 4 GB\",        \"ar\": \"Quiz bonus 4 GB\",        \"en\": \"Quiz bonus 4 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"4Go\",        \"ar\": \"4Go\",        \"en\": \"4Go\"      },      \"code\": \"QUIZBONUS4\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 4 GB\",        \"ar\": \"Quiz bonus 4 GB\",        \"en\": \"Quiz bonus 4 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2231/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2231/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2231/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2231/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2231/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2231\"    },    \"id\": \"2231\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"Quiz bonus 3 GB\",        \"ar\": \"Quiz bonus 3 GB\",        \"en\": \"Quiz bonus 3 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"3Go\",        \"ar\": \"3Go\",        \"en\": \"3Go\"      },      \"code\": \"QUIZBONUS3\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 3 GB\",        \"ar\": \"Quiz bonus 3 GB\",        \"en\": \"Quiz bonus 3 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2232/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2232/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2232/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2232/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2232/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2232\"    },    \"id\": \"2232\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"Quiz bonus 2 GB\",        \"ar\": \"Quiz bonus 2 GB\",        \"en\": \"Quiz bonus 2 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"2Go\",        \"ar\": \"2Go\",        \"en\": \"2Go\"      },      \"code\": \"QUIZBONUS2\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 2 GB\",        \"ar\": \"Quiz bonus 2 GB\",        \"en\": \"Quiz bonus 2 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2233/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2233/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2233/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2233/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2233/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2233\"    },    \"id\": \"2233\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"Quiz bonus 1 GB\",        \"ar\": \"Quiz bonus 1 GB\",        \"en\": \"Quiz bonus 1 GB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"1Go\",        \"ar\": \"1Go\",        \"en\": \"1Go\"      },      \"code\": \"QUIZBONUS1\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 1 GB\",        \"ar\": \"Quiz bonus 1 GB\",        \"en\": \"Quiz bonus 1 GB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2234/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2234/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2234/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2234/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2234/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2234\"    },    \"id\": \"2234\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 7,      \"name\": {        \"fr\": \"Quiz bonus 500MB\",        \"ar\": \"Quiz bonus 500MB\",        \"en\": \"Quiz bonus 500MB\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"days\",      \"short-description\": {        \"fr\": \"500MB\",        \"ar\": \"500MB\",        \"en\": \"500MB\"      },      \"code\": \"QUIZBONUS500\",      \"allow-re-activation\": true,      \"long-description\": {      },      \"info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"Quiz bonus 500MB\",        \"ar\": \"Quiz bonus 500MB\",        \"en\": \"Quiz bonus 500MB\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2235/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2235/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2235/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"22\"        },        \"links\": {          \"related\": \"/api/v1/products/2235/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2235/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2235\"    },    \"id\": \"2235\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Appels Internationaux.\",        \"ar\": \"Appels Internationaux.\",        \"en\": \"Appels Internationaux.\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"VOICEINTL30MNTPOST\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">30 min</h4>\\r\\nvers 10 destinations<br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\",        \"ar\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">30 min</h4>\\r\\nvers 10 destinations<br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\",        \"en\": \"<div align=\\\"center\\\">\\r\\n<h4 style=\\\"color: #ff0000\\\">30 min</h4>\\r\\nvers 10 destinations<br>\\r\\n-- <br>\\r\\nValable durant le mois de facturation<br>\\r\\n</div>\"      },      \"charge-type\": \"one_time\",      \"medium-description\": {        \"fr\": \"VOICE INTL 30 MNT POST\",        \"ar\": \"VOICE INTL 30 MNT POST\",        \"en\": \"VOICE INTL 30 MNT POST\"      },      \"display-order\": 100    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2242/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2242/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2242/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"34\"        },        \"links\": {          \"related\": \"/api/v1/products/2242/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2242/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2242\"    },    \"id\": \"2242\",    \"type\": \"products\"  }, {    \"attributes\": {      \"periodic-amount\": 1,      \"name\": {        \"fr\": \"Roam Data No Limit\",        \"ar\": \"Roam Data No Limit\",        \"en\": \"Roam Data No Limit\"      },      \"is-configurable\": false,      \"long-info-text\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"periodic-unit\": \"bill_period\",      \"short-description\": {        \"fr\": null,        \"ar\": null,        \"en\": null      },      \"code\": \"ROAMDATANOLIMIT\",      \"allow-re-activation\": false,      \"long-description\": {      },      \"info-text\": {        \"fr\": \"Roam Data No Limit\",        \"ar\": \"Roam Data No Limit\",        \"en\": \"Roam Data No Limit\"      },      \"charge-type\": \"rec_bill_period\",      \"medium-description\": {        \"fr\": \"Roam Data No Limit\",        \"ar\": \"Roam Data No Limit\",        \"en\": \"Roam Data No Limit\"      },      \"display-order\": 999    },    \"relationships\": {      \"services\": {        \"links\": {          \"related\": \"/api/v1/products/2253/services\"        }      },      \"traffic-bundles\": {        \"links\": {          \"related\": \"/api/v1/products/2253/traffic-bundles\"        }      },      \"option-group\": {        \"links\": {          \"related\": \"/api/v1/products/2253/option-group\"        }      },      \"product-family\": {        \"data\": {          \"type\": \"product-families\",          \"id\": \"47\"        },        \"links\": {          \"related\": \"/api/v1/products/2253/product-family\"        }      },      \"fees\": {        \"links\": {          \"related\": \"/api/v1/products/2253/fees\"        }      }    },    \"links\": {      \"self\": \"/api/v1/products/2253\"    },    \"id\": \"2253\",    \"type\": \"products\"  }]}";
        public static string ProductFeesResponse = "{  \"data\": [{    \"attributes\": {      \"fee\": 50.000000,      \"fee-type\": \"single\",      \"tax-inclusive\": true    },    \"relationships\": {      \"billing-item\": {        \"data\": {          \"type\": \"billing-items\",          \"id\": \"OTINTSPEEDHOURSPOST\"        },        \"links\": {          \"related\": \"/api/v1/fees/582/billing-item\"        }      }    },    \"links\": {      \"self\": \"/api/v1/fees/582\"    },    \"id\": \"582\",    \"type\": \"fees\"  }]}";
        public static string ProductFamilyResponse = "{  \"data\": {    \"type\": \"product-families\",    \"attributes\": {      \"name\": {        \"ru\": \"Другие пакеты\",        \"ka\": \"სხვა პაკეტები\",        \"en\": \"Other bundles\"      },      \"max-choices\": 0,      \"info-text\": {        \"ru\": \"Другие пакеты\",        \"ka\": \"სხვა პაკეტები\",        \"en\": \"Other bundles\"      },      \"min-choices\": 0,      \"display-order\": 99    },    \"id\": \"5\",    \"links\": {      \"self\": \"/api/v1/product-families/5\"    }  }}";
        public static string ProductTrafficBundlesResponse = "{  \"data\": [{    \"type\": \"traffic-bundles\",    \"attributes\": {      \"dedicated-account-id\": 271,      \"external-dedicated-account-id\": 1037,      \"usage-unit\": \"MB\",      \"recurrence\": \"non_recurrent\",      \"commercial-name\": {        \"fr\": \"Internet\",        \"ar\": \"الإنترنت\",        \"en\": \"Internet\"      },      \"free-usage-amount\": 100,      \"usage-type\": \"data\"    },    \"id\": \"DATAHOME100MB\",    \"links\": {      \"self\": \"/api/v1/traffic-bundles/DATAHOME100MB\"    }  }]}";
    }
}
