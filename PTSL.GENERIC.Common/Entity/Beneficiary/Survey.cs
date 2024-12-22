using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Survey : BaseEntity
    {
        public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
        public List<ApprovalLogForCfm>? ApprovalLogForCfms { get; set; }
        public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }
        #region Forest Administration
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime SurveyDate { get; set; }
        public string? Deviceid { get; set; }
        public string? Subscriberid { get; set; }
        public string? Simserial { get; set; }
        public string? Phonenumber { get; set; }
        public string? DetailsInfo { get; set; }
        public long ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        public long? NgoId { get; set; }
        public Ngo? Ngo { get; set; }

        public string? ForestVillageName { get; set; }
        public string? ForestVillageNameBn { get; set; }
        public string BeneficiaryId { get; set; } = string.Empty;
        public string? BeneficiaryHouseholdSerialNo { get; set; }
        #endregion

        #region Profile & Documents
        public string? BeneficiaryProfileURL { get; set; }
        public string? BeneficiaryNIDFrontURL { get; set; }
        public string? BeneficiaryNIDBackURL { get; set; }
        public List<SurveyDocument>? SurveyDocuments { get; set; }
        #endregion

        #region General Information
        public string? BeneficiaryName { get; set; }
        public string? BeneficiaryNameBn { get; set; }
        public string? BeneficiaryNid { get; set; }
        public string? BeneficiaryPhone { get; set; }
        public string? BeneficiaryPhoneBn { get; set; }
        public Gender BeneficiaryGender { get; set; }
        public long? BeneficiaryEthnicityId { get; set; }
        public Ethnicity? BeneficiaryEthnicity { get; set; }
        public string? BeneficiaryEthnicityTxt { get; set; }
        public string? BeneficiaryAge { get; set; }
        public string? BeneficiaryAgeBn { get; set; }
        public string? BeneficiaryFatherName { get; set; }
        public string? BeneficiaryFatherNameBn { get; set; }
        public string? BeneficiaryMotherName { get; set; }
        public string? BeneficiaryMotherNameBn { get; set; }
        public string? BeneficiarySpouseName { get; set; }
        public string? BeneficiarySpouseNameBn { get; set; }
        public string? HeadOfHouseholdName { get; set; }
        public string? HeadOfHouseholdNameBn { get; set; }
        public Gender? HeadOfHouseholdGender { get; set; }
        public string? PresentVillageName { get; set; }
        public string? PresentVillageNameBn { get; set; }
        public string? PresentPostOfficeName { get; set; }
        public string? PresentPostOfficeNameBn { get; set; }
        public long PresentDivisionId { get; set; }
        public Division? PresentDivision { get; set; }
        public long PresentDistrictId { get; set; }
        public District? PresentDistrict { get; set; }
        public long PresentUpazillaId { get; set; }
        public Upazilla? PresentUpazilla { get; set; }

        public long? PresentUnionNewId { get; set; }
        public Union? PresentUnionNew { get; set; }

        public string? PresentUnion { get; set; }
        public bool IsPermanentSameAsPresent { get; set; }
        public string? PermanentVillageName { get; set; }
        public string? PermanentVillageNameBn { get; set; }
        public string? PermanentPostOfficeName { get; set; }
        public string? PermanentPostOfficeNameBn { get; set; }
        public long? PermanentDivisionId { get; set; }
        public Division? PermanentDivision { get; set; }
        public long? PermanentDistrictId { get; set; }
        public District? PermanentDistrict { get; set; }
        public long? PermanentUpazillaId { get; set; }
        public Upazilla? PermanentUpazilla { get; set; }

        public long? PermanentUnionNewId { get; set; }
        public Union? PermanentUnionNew { get; set; }

        public string? PermanentUnion { get; set; }
        public string? PermanentUnionBn { get; set; }
        public double? BeneficiaryLatitude { get; set; }
        public double? BeneficiaryLongitude { get; set; }
        public double? BeneficiaryAltitude { get; set; }
        public double? BeneficiaryPrecision { get; set; }
        public string? BeneficiaryHouseFrontImage { get; set; }
        public string? BeneficiaryHouseFrontImageURL { get; set; }
        #endregion

        #region Households Members Information
        public List<HouseholdMember>? HouseholdMembers { get; set; }
        #endregion

        #region Economic Status
        #region Land Occupancy
        public List<LandOccupancy>? LandOccupancy { get; set; }
        public double GrandTotalLandOccupancy { get; set; }
        #endregion

        #region Housing Condition
        public HouseType BeneficiaryHouseType { get; set; }

        public long? TypeOfHouseId { get; set; }
        public TypeOfHouse? TypeOfHouse { get; set; }
        #endregion

        #region MovableAssets
        public List<LiveStock>? LiveStocks { get; set; }
        public double GrandTotalLivestockCost { get; set; }
        #endregion
        public List<Asset>? Assets { get; set; }
        public double GrandTotalAssetsCost { get; set; }
        public List<ImmovableAsset>? ImmovableAssets { get; set; }
        public double GrandTotalImmovableAnnualReturn { get; set; }
        public List<EnergyUse>? EnergyUses { get; set; }
        public double GrandTotalEnergyUsesMonthly { get; set; }
        #endregion

        #region Access to Resources and Services
        #region Access to General Facilities
        public bool IsProblemToAccessHealthService { get; set; }
        public string? NearestHealthServiceLocation { get; set; }
        public double NearestHealthServiceDistance { get; set; }
        public bool IsProblemToAccessDrinkingWater { get; set; }
        public double NearestDrinkingWaterDistance { get; set; }
        public string? SourceofDrySeasonWaterEnumList { get; set; }
        public string? SourceofDrySeasonWaterTxt { get; set; }
        public string? SourceofWetSeasonWaterEnumList { get; set; }
        public string? SourceofWetSeasonWaterTxt { get; set; }
        public string? NearestGrowthCenter { get; set; }
        public double NearestGrowthCenterDistance { get; set; }
        public bool IsProblemToAccessEducation { get; set; }
        public bool HasEducationalInstituteNearby { get; set; }
        public double EducationalInstituteDistance { get; set; }
        public EducationalInstituteAccessibility EducationalInstituteAccessibilityEnum { get; set; }
        public SanitationFacilities SanitationFacilitiesEnum { get; set; }
        #endregion

        #region Existing Skills
        public List<ExistingSkill>? ExistingSkills { get; set; }
        #endregion

        #region Potential Skills
        public string? PotentialSkillName1 { get; set; }
        public string? PotentialSkillName2 { get; set; }
        public string? PotentialSkillName3 { get; set; }
        public string? PotentialSpecialSkill { get; set; }
        public string? PotentialSkillsRemarks { get; set; }
        #endregion
        #endregion

        #region Cross cutting issues
        #region Satisfaction of stakeholders
        public SatisfactionLevel ForestMngmtSatisfactionEnum { get; set; }
        public SatisfactionLevel ForestMngmtEffectivenessEnum { get; set; }
        public ForestDependency ForestDependencyEnum { get; set; }
        #endregion

        #region Awarness about Collaborative Forest management
        public bool IsHearedAboutCfm { get; set; }
        public bool IsParticipatedInCfm { get; set; }
        public bool WillCfmImproveForestMngmnt { get; set; }
        public bool WillCfmImproveWellBeing { get; set; }
        #endregion

        #region Gender & Ethnicity
        public GenderMf DicisionTakerEnum { get; set; }
        public GenderMf ProductiveAssetsOwnerGender { get; set; }
        public GenderMf CropTypeDecisionGender { get; set; }
        public GenderMf DecisionToTransferAssetsGender { get; set; }
        public GenderMf FamilyNeedsDeciderGender { get; set; }
        public GenderMf AccessorToCreditGender { get; set; }
        public GenderMf ControllerOfCreditGender { get; set; }
        public GenderMf OfficeBearerGender { get; set; }
        public GenderMf MorePaymentGetterGender { get; set; }
        public bool? CanAccessLegalSupportForGbv { get; set; }
        public bool? CanUnsufructsRights { get; set; }
        public bool? FaceLiveAndLivelihoodChallanges { get; set; }
        public bool? HasLlfmInterest { get; set; }
        #endregion
        #endregion

        #region Socio-economic status
        public List<GrossMarginIncomeAndCostStatus>? GrossMarginIncomeAndCostStatuses { get; set; }
        public double GrandTotalNetIncomeAgriculture { get; set; }
        public double GrandTotalLandArea { get; set; }
        public double GrandTotalGrossMarginAgriculture { get; set; }
        public List<ManualPhysicalWork>? ManualPhysicalWorks { get; set; }
        public double GrandTotalAnnualPhysicalIncome { get; set; }
        public List<NaturalResourcesIncomeAndCostStatus>? NaturalResourcesIncomeAndCostStatuses { get; set; }
        public double GrandTotalWildResourceIncome { get; set; }
        public List<OtherIncomeSource>? OtherIncomeSources { get; set; }
        public double GrandTotalOtherIncome { get; set; }
        public List<Business>? Businesses { get; set; }
        public double GrandTotalBusinessIncome { get; set; }
        #endregion

        #region Remittances
        #region Within the country: How many people live away from this household within Bangladesh but send an income
        public int NoOfMaleInsideCountry { get; set; }
        public double SentIncomeOfMaleInYearInsideCountry { get; set; }
        public int NoOfFemaleInsideCountry { get; set; }
        public double SentIncomeOfFemaleInYearInsideCountry { get; set; }
        #endregion

        #region Outside the Country: How many people live away from this household outside Bangladesh and send an income
        public int NoOfMaleOutsideCountry { get; set; }
        public double SentIncomeOfMaleInYearOutsideCountry { get; set; }
        public int NoOfFemaleOutsideCountry { get; set; }
        public double SentIncomeOfFemaleInYearOutsideCountry { get; set; }
        #endregion

        #region Access to finance of the households during last 12 months
        public double PersonalSavingsOfAllMembers { get; set; }
        public double HouseShareInSavings { get; set; }
        public double BorrowedFromBank { get; set; }
        public double BorrowedFromNGO { get; set; }
        public double GrantsFromNGO { get; set; }
        public double GrantsFromGob { get; set; }
        public double BorrowedFromCoOperatives { get; set; }
        public double BorrowedFromNonRelatives { get; set; }
        public double BorrowedFromRelatives { get; set; }
        public double SaleOfProducts { get; set; }
        public string? OtherFinanceName { get; set; }
        public double OtherFinanceAmount { get; set; }
        #endregion

        #region Annual household expenditure
        public List<AnnualHouseholdExpenditure>? AnnualHouseholdExpenditures { get; set; }
        public double GrandTotalHouseholdExpenditure { get; set; }
        #endregion
        #endregion

        #region Food Security
        #region FoodConsumption
        public FoodCondition? HouseholdFoodCondition { get; set; }
        public DateTime? FoodCrisisMonth { get; set; }
        public FamilyMemberType? FoodyPersonInFoodCrisis { get; set; }
        #endregion

        #region Food Security
        public List<FoodSecurityItem>? FoodSecurityItems { get; set; }
        #endregion
        #endregion

        #region Vulnerability situation during last one year
        public List<VulnerabilitySituation>? VulnerabilitySituations { get; set; }
        #endregion

        public string? NotesImage { get; set; }
        public string? NotesImageUrl { get; set; }
        public DateTime? FcvVcfAddedDate { get; set; }
        public RecipientStatus RecipientStatus { get; set; }

        #region Data collection information
        public string? NameOfTheEnumerator { get; set; }
        public string? CellPhoneNumber { get; set; } // Cell phone of the Enumerator
        public DateTime? DataCollectionDate { get; set; }
        #endregion

        #region Internal Logic related properties
        public BeneficiaryApproveStatus BeneficiaryApproveStatus { get; set; }
        public long? BeneficiaryApproveStatusById { get; set; }
        public User? BeneficiaryApproveStatusBy { get; set; }

        public long? CipId { get; set; }
        public Cip? Cip { get; set; }

        public List<CommunityTrainingParticipentsMap>? CommunityTrainingParticipentsMaps { get; set; }
        public List<PatrollingSchedulingParticipentsMap>? PatrollingSchedulingParticipentsMaps { get; set; }
        public List<MeetingParticipantsMap>? MeetingParticipantsMaps { get; set; }
        public List<InternalLoanInformation>? InternalLoanInformations { get; set; }
        public List<PatrollingPaymentInformetion>? PatrollingPaymentInformetions { get; set; }
        public List<SavingsAccount>? SavingsAccounts { get; set; }
        public List<LabourDatabase>? LabourDatabases { get; set; }
        public User? User { get; set; }
        public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
        public List<SurveyIncident>? SurveyIncidents { get; set; }

        [NotMapped]
        public List<long>? DeletedHouseholdMembers { get; set; }
        [NotMapped]
        public List<long>? DeletedLandOccupancy { get; set; }
        [NotMapped]
        public List<long>? DeletedLiveStocks { get; set; }
        [NotMapped]
        public List<long>? DeletedAssets { get; set; }
        [NotMapped]
        public List<long>? DeletedImmovableAssets { get; set; }
        [NotMapped]
        public List<long>? DeletedEnergyUses { get; set; }
        [NotMapped]
        public List<long>? DeletedExistingSkills { get; set; }
        [NotMapped]
        public List<long>? DeletedGrossMarginIncomeAndCostStatuses { get; set; }
        [NotMapped]
        public List<long>? DeletedManualPhysicalWorks { get; set; }
        [NotMapped]
        public List<long>? DeletedNaturalResourcesIncomeAndCostStatuses { get; set; }
        [NotMapped]
        public List<long>? DeletedOtherIncomeSources { get; set; }
        [NotMapped]
        public List<long>? DeletedBusinesses { get; set; }
        [NotMapped]
        public List<long>? DeletedAnnualHouseholdExpenditures { get; set; }
        [NotMapped]
        public List<long>? DeletedFoodSecurityItems { get; set; }
        [NotMapped]
        public List<long>? DeletedVulnerabilitySituations { get; set; }
        #endregion


        // Core entity logic
        public void GenerateBeneficiaryID()
        {
            this.BeneficiaryId = $"{ForestDivisionId}-{ForestRangeId}-{ForestBeatId}-{ForestFcvVcfId}-{BeneficiaryHouseholdSerialNo}";
        }
        public void CalculcateGrandTotals(
            double currentGrandTotalLandOccupancy = 0,
            double currentGrandTotalLivestockCost = 0,
            double currentGrandTotalAssetsCost = 0,
            double currentGrandTotalEnergyUsesMonthly = 0,
            double currentGrandTotalImmovableAnnualReturn = 0,
            double currentGrandTotalGrossMarginAgriculture = 0,
            double currentGrandTotalAnnualPhysicalIncome = 0,
            double currentGrandTotalWildResourceIncome = 0,
            double currentGrandTotalOtherIncome = 0,
            double currentGrandTotalBusinessIncome = 0,
            double currentGrandTotalHouseholdExpenditure = 0)
        {
            if (LandOccupancy != null && LandOccupancy.Count > 0)
            {
                LandOccupancy.ForEach(item => { item.Calculate(); });
                GrandTotalLandOccupancy = LandOccupancy.Sum(x => x.TotalLand);
            }
            else
            {
                GrandTotalLandOccupancy = currentGrandTotalLandOccupancy;
            }

            if (LiveStocks != null && LiveStocks.Count > 0)
            {
                GrandTotalLivestockCost = Math.Round(LiveStocks.Sum(x => x.LivestockCost), 2);
            }
            else
            {
                GrandTotalLivestockCost = currentGrandTotalLivestockCost;
            }

            if (Assets != null && Assets.Count > 0)
            {
                GrandTotalAssetsCost = Math.Round(Assets.Sum(x => x.AssetsCost), 2);
            }
            else
            {
                GrandTotalAssetsCost = currentGrandTotalAssetsCost;
            }

            if (ImmovableAssets != null && ImmovableAssets.Count > 0)
            {
                GrandTotalImmovableAnnualReturn = Math.Round(ImmovableAssets.Sum(x => x.ImmovableAnnualReturn), 2);
            }
            else
            {
                GrandTotalImmovableAnnualReturn = currentGrandTotalImmovableAnnualReturn;
            }

            if (EnergyUses != null && EnergyUses.Count > 0)
            {
                GrandTotalEnergyUsesMonthly = EnergyUses.Sum(x => x.EnergyUsesMonthly);
            }
            else
            {
                GrandTotalEnergyUsesMonthly = currentGrandTotalEnergyUsesMonthly;
            }

            if (GrossMarginIncomeAndCostStatuses != null && GrossMarginIncomeAndCostStatuses.Count > 0)
            {
                GrossMarginIncomeAndCostStatuses.ForEach(item => { item.Calculate(); });
                GrandTotalNetIncomeAgriculture = GrossMarginIncomeAndCostStatuses.Sum(x => x.TotalNetIncome);
                GrandTotalLandArea = GrossMarginIncomeAndCostStatuses.Sum(x => x.LandArea);
                GrandTotalGrossMarginAgriculture = Math.Round(GrandTotalNetIncomeAgriculture / GrandTotalLandArea, 2);
            }
            else
            {
                GrandTotalGrossMarginAgriculture = currentGrandTotalGrossMarginAgriculture;
            }

            if (ManualPhysicalWorks != null && ManualPhysicalWorks.Count > 0)
            {
                ManualPhysicalWorks.ForEach(item => { item.Calculate(); });
                GrandTotalAnnualPhysicalIncome = Math.Round(ManualPhysicalWorks.Sum(x => x.TotalAnnualIncome), 2);
            }
            else
            {
                GrandTotalAnnualPhysicalIncome = currentGrandTotalAnnualPhysicalIncome;
            }

            if (NaturalResourcesIncomeAndCostStatuses != null && NaturalResourcesIncomeAndCostStatuses.Count > 0)
            {
                NaturalResourcesIncomeAndCostStatuses.ForEach(item => { item.Calculate(); });
                GrandTotalWildResourceIncome = Math.Round(NaturalResourcesIncomeAndCostStatuses.Sum(x => x.TotalNetIncome), 2);
            }
            else
            {
                GrandTotalWildResourceIncome = currentGrandTotalWildResourceIncome;
            }

            if (OtherIncomeSources != null && OtherIncomeSources.Count > 0)
            {
                OtherIncomeSources.ForEach(item => { item.Calculate(); });
                GrandTotalOtherIncome = OtherIncomeSources.Sum(x => x.TotalNetIncome);
            }
            else
            {
                GrandTotalOtherIncome = currentGrandTotalOtherIncome;
            }

            if (Businesses != null && Businesses.Count > 0)
            {
                Businesses.ForEach(item => { item.Calculate(); });
                GrandTotalBusinessIncome = Businesses.Sum(x => x.TotalNetIncome);
            }
            else
            {
                GrandTotalBusinessIncome = currentGrandTotalBusinessIncome;
            }

            if (AnnualHouseholdExpenditures != null && AnnualHouseholdExpenditures.Count > 0)
            {
                GrandTotalHouseholdExpenditure = AnnualHouseholdExpenditures.Sum(x => x.ExpenditureCost);
            }
            else
            {
                GrandTotalHouseholdExpenditure = currentGrandTotalHouseholdExpenditure;
            }
        }
    }
}