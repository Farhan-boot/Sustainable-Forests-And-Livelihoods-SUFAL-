using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class SurveyVM : BaseModel
    {
        [SwaggerExclude]
        public List<BeneficiarySubmissionHistory>? BeneficiarySubmissionHistorys { get; set; }
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

        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }

        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }

        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }

        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }

        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        public long? NgoId { get; set; }
        [SwaggerExclude]
        public NgoVM? Ngo { get; set; }

        public string? ForestVillageName { get; set; }
        public string? ForestVillageNameBn { get; set; }
        public string BeneficiaryId { get; set; } = string.Empty;
        public string? BeneficiaryHouseholdSerialNo { get; set; }
        #endregion

        #region Profile & Documents
        public string? BeneficiaryProfileURL { get; set; }
        public string? BeneficiaryNIDFrontURL { get; set; }
        public string? BeneficiaryNIDBackURL { get; set; }
        public List<SurveyDocumentVM>? SurveyDocuments { get; set; }
        #endregion
        public List<SurveyIncidentVM>? SurveyIncidents { get; set; }

        #region General Information
        public string? BeneficiaryName { get; set; }
        public string? BeneficiaryNameBn { get; set; }
        public string? BeneficiaryNid { get; set; }
        public string? BeneficiaryPhone { get; set; }
        public string? BeneficiaryPhoneBn { get; set; }
        public Gender BeneficiaryGender { get; set; }
        public string? BeneficiaryGenderString { get; set; }
        public long? BeneficiaryEthnicityId { get; set; }

        [SwaggerExclude]
        public EthnicityVM? BeneficiaryEthnicity { get; set; }
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

        [SwaggerExclude]
        public DivisionVM? PresentDivision { get; set; }
        public long PresentDistrictId { get; set; }

        [SwaggerExclude]
        public DistrictVM? PresentDistrict { get; set; }
        public long PresentUpazillaId { get; set; }

        [SwaggerExclude]
        public UpazillaVM? PresentUpazilla { get; set; }

        public long? PresentUnionNewId { get; set; }
        [SwaggerExclude]
        public UnionVM? PresentUnionNew { get; set; }

        public string? PresentUnion { get; set; }
        public bool IsPermanentSameAsPresent { get; set; }
        public string? PermanentVillageName { get; set; }
        public string? PermanentVillageNameBn { get; set; }
        public string? PermanentPostOfficeName { get; set; }
        public string? PermanentPostOfficeNameBn { get; set; }
        public long? PermanentDivisionId { get; set; }

        [SwaggerExclude]
        public DivisionVM? PermanentDivision { get; set; }
        public long? PermanentDistrictId { get; set; }

        [SwaggerExclude]
        public DistrictVM? PermanentDistrict { get; set; }
        public long? PermanentUpazillaId { get; set; }

        [SwaggerExclude]
        public UpazillaVM? PermanentUpazilla { get; set; }

        public long? PermanentUnionNewId { get; set; }
        [SwaggerExclude]
        public UnionVM? PermanentUnionNew { get; set; }

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
        public List<HouseholdMemberVM>? HouseholdMembers { get; set; }
        #endregion

        #region Economic Status
        #region Land Occupancy
        public List<LandOccupancyVM>? LandOccupancy { get; set; }
        public double GrandTotalLandOccupancy { get; set; }
        #endregion

        #region Housing Condition
        public HouseType BeneficiaryHouseType { get; set; }
        public long? TypeOfHouseId { get; set; }
        public TypeOfHouseVM? TypeOfHouse { get; set; }
        public string? BeneficiaryHouseTypeString { get; set; }
        #endregion

        #region MovableAssets
        public List<LiveStockVM>? LiveStocks { get; set; }
        public double GrandTotalLivestockCost { get; set; }
        #endregion

        public List<AssetVM>? Assets { get; set; }
        public double GrandTotalAssetsCost { get; set; }

        public List<ImmovableAssetVM>? ImmovableAssets { get; set; }
        public double GrandTotalImmovableAnnualReturn { get; set; }

        public List<EnergyUseVM>? EnergyUses { get; set; }
        public double GrandTotalEnergyUsesMonthly { get; set; }
        public RecipientStatus RecipientStatus { get; set; }
        #endregion

        #region Access to Resources and Services
        #region Access to General Facilities
        public bool IsProblemToAccessHealthService { get; set; }
        public string? NearestHealthServiceLocation { get; set; }
        public double NearestHealthServiceDistance { get; set; }
        public bool IsProblemToAccessDrinkingWater { get; set; }
        public double NearestDrinkingWaterDistance { get; set; }

        public IEnumerable<DropdownVM> SourceofDryWetSeasonWaterEnums => EnumHelper.GetEnumDropdowns<DrinkingWaterResource>();
        public string? SourceofDrySeasonWaterEnumList { get; set; }
        public string? SourceofDrySeasonWaterEnumListText
        {
            get
            {
                var splits = SourceofDrySeasonWaterEnumList?.Split(',') ?? Array.Empty<string>();
                var result = new List<string>();

                foreach (var item in splits)
                {
                    _ = int.TryParse(item, out var value);
                    result.Add(SourceofDryWetSeasonWaterEnums.FirstOrDefault(x => x.Id == value)?.Name ?? string.Empty);
                }

                return string.Join(", ", result);
            }
        }
        public string? SourceofDrySeasonWaterTxt { get; set; }
        public string? SourceofWetSeasonWaterEnumList { get; set; }
        public string? SourceofWetSeasonWaterEnumListText
        {
            get
            {
                var splits = SourceofWetSeasonWaterEnumList?.Split(',') ?? Array.Empty<string>();
                var result = new List<string>();

                foreach (var item in splits)
                {
                    _ = int.TryParse(item, out var value);
                    result.Add(SourceofDryWetSeasonWaterEnums.FirstOrDefault(x => x.Id == value)?.Name ?? string.Empty);
                }

                return string.Join(", ", result);
            }
        }
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
        public List<ExistingSkillVM>? ExistingSkills { get; set; }
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

        public List<GrossMarginIncomeAndCostStatusVM>? GrossMarginIncomeAndCostStatuses { get; set; }
        public double GrandTotalNetIncomeAgriculture { get; set; }
        public double GrandTotalLandArea { get; set; }
        private double _grandTotalGrossMarginAgriculture => Math.Round(GrandTotalNetIncomeAgriculture / GrandTotalLandArea, 2);
        public double GrandTotalGrossMarginAgriculture => double.IsNaN(_grandTotalGrossMarginAgriculture) ? 0 : _grandTotalGrossMarginAgriculture;

        public List<ManualPhysicalWorkVM>? ManualPhysicalWorks { get; set; }
        public double _grandTotalAnnualPhysicalIncome => Math.Round(ManualPhysicalWorks?.Sum(x => x.TotalAnnualIncome) ?? 0, 2);
        public double GrandTotalAnnualPhysicalIncome => double.IsNaN(_grandTotalAnnualPhysicalIncome) ? 0 : _grandTotalAnnualPhysicalIncome;

        public List<NaturalResourcesIncomeAndCostStatusVM>? NaturalResourcesIncomeAndCostStatuses { get; set; }
        public double _grandTotalWildResourceIncome => Math.Round(NaturalResourcesIncomeAndCostStatuses?.Sum(x => x.TotalNetIncome) ?? 0, 2);
        public double GrandTotalWildResourceIncome => double.IsNaN(_grandTotalWildResourceIncome) ? 0 : _grandTotalWildResourceIncome;

        public List<OtherIncomeSourceVM>? OtherIncomeSources { get; set; }
        public double _grandTotalOtherIncome => OtherIncomeSources?.Sum(x => x.TotalNetIncome) ?? 0;
        public double GrandTotalOtherIncome => double.IsNaN(_grandTotalOtherIncome) ? 0 : _grandTotalOtherIncome;

        public List<BusinessVM>? Businesses { get; set; }
        public double _grandTotalBusinessIncome => Businesses?.Sum(x => x.TotalNetIncome) ?? 0;
        public double GrandTotalBusinessIncome => double.IsNaN(_grandTotalBusinessIncome) ? 0 : _grandTotalBusinessIncome;
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
        public List<AnnualHouseholdExpenditureVM>? AnnualHouseholdExpenditures { get; set; }
        public double GrandTotalHouseholdExpenditure { get; set; }
        #endregion
        #endregion

        #region Food Security
        #region FoodConsumption
        public FoodCondition? HouseholdFoodCondition { get; set; }
        public string? HouseholdFoodConditionText => HouseholdFoodCondition?.GetEnumDisplayName();
        public DateTime? FoodCrisisMonth { get; set; }
        public FamilyMemberType? FoodyPersonInFoodCrisis { get; set; }
        public string? FoodyPersonInFoodCrisisText => FoodyPersonInFoodCrisis?.GetEnumDisplayName();
        #endregion

        #region Food Security
        public List<FoodSecurityItemVM>? FoodSecurityItems { get; set; }
        #endregion
        #endregion

        #region Vulnerability situation during last one year
        public List<VulnerabilitySituationVM>? VulnerabilitySituations { get; set; }
        #endregion

        public string? NotesImage { get; set; }
        public string? NotesImageUrl { get; set; }
        public DateTime? FcvVcfAddedDate { get; set; }

        #region Data collection information
        public string? NameOfTheEnumerator { get; set; }
        public string? CellPhoneNumber { get; set; } // Cell phone of the Enumerator
        public DateTime? DataCollectionDate { get; set; }
        #endregion

        #region Internal Logic related properties
        public BeneficiaryApproveStatus BeneficiaryApproveStatus { get; set; }
        public string? BeneficiaryApproveStatusString { get; set; }

        public long? CipId { get; set; }
        public CipVM? Cip { get; set; }

        public List<long>? DeletedHouseholdMembers { get; set; }
        public List<long>? DeletedLandOccupancy { get; set; }
        public List<long>? DeletedLiveStocks { get; set; }
        public List<long>? DeletedAssets { get; set; }
        public List<long>? DeletedImmovableAssets { get; set; }
        public List<long>? DeletedEnergyUses { get; set; }
        public List<long>? DeletedExistingSkills { get; set; }
        public List<long>? DeletedGrossMarginIncomeAndCostStatuses { get; set; }
        public List<long>? DeletedManualPhysicalWorks { get; set; }
        public List<long>? DeletedNaturalResourcesIncomeAndCostStatuses { get; set; }
        public List<long>? DeletedOtherIncomeSources { get; set; }
        public List<long>? DeletedBusinesses { get; set; }
        public List<long>? DeletedAnnualHouseholdExpenditures { get; set; }
        public List<long>? DeletedFoodSecurityItems { get; set; }
        public List<long>? DeletedVulnerabilitySituations { get; set; }
        #endregion
    }
}