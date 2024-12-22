using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class SurveyEssentialVM
    {
        public long Id { get; set; }
        public string BeneficiaryName { get; set; }
        public string BeneficiaryNameBn { get; set; }
        public string BeneficiaryNid { get; set; }
        public string BeneficiaryPhone { get; set; }
        public string BeneficiaryPhoneBn { get; set; }
        public Gender BeneficiaryGender { get; set; }
        public string BeneficiaryGenderString { get; set; }
        public long? BeneficiaryEthnicityId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        public EthnicityVM? BeneficiaryEthnicity { get; set; }
        public string BeneficiaryEthnicityTxt { get; set; }
        public string BeneficiaryAge { get; set; }
        public string BeneficiaryAgeBn { get; set; }
        public string BeneficiaryFatherName { get; set; }
        public string BeneficiaryFatherNameBn { get; set; }
        public string BeneficiaryMotherName { get; set; }
        public string BeneficiaryMotherNameBn { get; set; }
        public string BeneficiarySpouseName { get; set; }
        public string BeneficiarySpouseNameBn { get; set; }
        public string HeadOfHouseholdName { get; set; }
        public string HeadOfHouseholdNameBn { get; set; }
        public Gender? HeadOfHouseholdGender { get; set; }
        public string PresentVillageName { get; set; }
        public string PresentVillageNameBn { get; set; }
        public string PresentPostOfficeName { get; set; }
        public string PresentPostOfficeNameBn { get; set; }
        public long PresentDivisionId { get; set; }

        public DivisionVM? PresentDivision { get; set; }
        public long PresentDistrictId { get; set; }

        public DistrictVM? PresentDistrict { get; set; }
        public long PresentUpazillaId { get; set; }

        public UpazillaVM? PresentUpazilla { get; set; }
        public string PresentUnion { get; set; }
        public bool IsPermanentSameAsPresent { get; set; }
        public string PermanentVillageName { get; set; }
        public string PermanentVillageNameBn { get; set; }
        public string PermanentPostOfficeName { get; set; }
        public string PermanentPostOfficeNameBn { get; set; }
        public long? PermanentDivisionId { get; set; }

        public DivisionVM? PermanentDivision { get; set; }
        public long? PermanentDistrictId { get; set; }

        public DistrictVM PermanentDistrict { get; set; }
        public long? PermanentUpazillaId { get; set; }

        public UpazillaVM? PermanentUpazilla { get; set; }
        public string PermanentUnion { get; set; }
        public string PermanentUnionBn { get; set; }
        public double? BeneficiaryLatitude { get; set; }
        public double? BeneficiaryLongitude { get; set; }
        public double? BeneficiaryAltitude { get; set; }
        public double? BeneficiaryPrecision { get; set; }
        public string BeneficiaryHouseFrontImage { get; set; }
        public string BeneficiaryHouseFrontImageURL { get; set; }
        public HouseType BeneficiaryHouseType { get; set; }
        public string BeneficiaryHouseTypeString { get; set; }
        public double GrandTotalLivestockCost { get; set; }
        public double GrandTotalAssetsCost { get; set; }
        public double GrandTotalImmovableAnnualReturn { get; set; }
        public double GrandTotalEnergyUsesMonthly { get; set; }
        public double GrandTotalNetIncomeAgriculture { get; set; }
        public double GrandTotalLandArea { get; set; }
        public double GrandTotalGrossMarginAgriculture { get; set; }
        public BeneficiaryApproveStatus BeneficiaryApproveStatus { get; set; }
        public string BeneficiaryApproveStatusString { get; set; }

    }
}
