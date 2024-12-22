using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
	public class SurveyEssentialVM
	{
        public long Id { get; set; }
        public string? BeneficiaryName { get; set; }
        public string? BeneficiaryNameBn { get; set; }
        public string? BeneficiaryNid { get; set; }
        public string? BeneficiaryPhone { get; set; }
        public string? BeneficiaryPhoneBn { get; set; }
        public Gender BeneficiaryGender { get; set; }
        public string? BeneficiaryGenderString { get; set; }
        public long? BeneficiaryEthnicityId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

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
        public string? PermanentUnion { get; set; }
        public string? PermanentUnionBn { get; set; }
        public double? BeneficiaryLatitude { get; set; }
        public double? BeneficiaryLongitude { get; set; }
        public double? BeneficiaryAltitude { get; set; }
        public double? BeneficiaryPrecision { get; set; }
        public string? BeneficiaryHouseFrontImage { get; set; }
        public string? BeneficiaryHouseFrontImageURL { get; set; }
        public HouseType BeneficiaryHouseType { get; set; }
        public string? BeneficiaryHouseTypeString { get; set; }
        public double GrandTotalLivestockCost { get; set; }
        public double GrandTotalAssetsCost { get; set; }
        public double GrandTotalImmovableAnnualReturn { get; set; }
        public double GrandTotalEnergyUsesMonthly { get; set; }
        public double GrandTotalNetIncomeAgriculture { get; set; }
        public double GrandTotalLandArea { get; set; }
        public double GrandTotalGrossMarginAgriculture { get; set; }
        public BeneficiaryApproveStatus BeneficiaryApproveStatus { get; set; }
        public string? BeneficiaryApproveStatusString { get; set; }

        public SurveyEssentialVM()
        {
        }

        public SurveyEssentialVM(Survey survey)
        {
            this.Id = survey.Id;
            this.BeneficiaryName = survey.BeneficiaryName;
            this.BeneficiaryNameBn = survey.BeneficiaryNameBn;
            this.BeneficiaryNid = survey.BeneficiaryNid;
            this.BeneficiaryPhone = survey.BeneficiaryPhone;
            this.BeneficiaryPhoneBn = survey.BeneficiaryPhoneBn;
            this.BeneficiaryGender = survey.BeneficiaryGender;
            this.BeneficiaryGenderString = survey.BeneficiaryGender.ToString();
            this.BeneficiaryEthnicityId = survey.BeneficiaryEthnicityId;
            this.BeneficiaryEthnicityTxt = survey.BeneficiaryEthnicityTxt;
            this.BeneficiaryAge = survey.BeneficiaryAge;
            this.BeneficiaryAgeBn = survey.BeneficiaryAgeBn;
            this.BeneficiaryFatherName = survey.BeneficiaryFatherName;
            this.BeneficiaryFatherNameBn = survey.BeneficiaryFatherNameBn;
            this.BeneficiaryMotherName = survey.BeneficiaryMotherName;
            this.BeneficiaryMotherNameBn = survey.BeneficiaryMotherNameBn;
            this.BeneficiarySpouseName = survey.BeneficiarySpouseName;
            this.BeneficiarySpouseNameBn = survey.BeneficiarySpouseNameBn;
            this.HeadOfHouseholdName = survey.HeadOfHouseholdName;
            this.HeadOfHouseholdNameBn = survey.HeadOfHouseholdNameBn;
            this.HeadOfHouseholdGender = survey.HeadOfHouseholdGender;
            this.PresentVillageName = survey.PresentVillageName;
            this.PresentVillageNameBn = survey.PresentVillageNameBn;
            this.PresentPostOfficeName = survey.PresentPostOfficeName;
            this.PresentPostOfficeNameBn = survey.PresentPostOfficeNameBn;
            this.PresentDivisionId = survey.PresentDivisionId;
            this.PresentDistrictId = survey.PresentDistrictId;
            this.PresentUpazillaId = survey.PresentUpazillaId;
            this.PresentUnion = survey.PresentUnion;
            this.IsPermanentSameAsPresent = survey.IsPermanentSameAsPresent;
            this.PermanentVillageName = survey.PermanentVillageName;
            this.PermanentVillageNameBn = survey.PermanentVillageNameBn;
            this.PermanentPostOfficeName = survey.PermanentPostOfficeName;
            this.PermanentPostOfficeNameBn = survey.PermanentPostOfficeNameBn;
            this.PermanentDivisionId = survey.PermanentDivisionId;
            this.PermanentDistrictId = survey.PermanentDistrictId;
            this.PermanentUpazillaId = survey.PermanentUpazillaId;
            this.PermanentUnion = survey.PermanentUnion;
            this.PermanentUnionBn = survey.PermanentUnionBn;
            this.BeneficiaryLatitude = survey.BeneficiaryLatitude;
            this.BeneficiaryLongitude = survey.BeneficiaryLongitude;
            this.BeneficiaryAltitude = survey.BeneficiaryAltitude;
            this.BeneficiaryPrecision = survey.BeneficiaryPrecision;
            this.BeneficiaryHouseFrontImage = survey.BeneficiaryHouseFrontImage;
            this.BeneficiaryHouseFrontImageURL = survey.BeneficiaryHouseFrontImageURL;
            this.BeneficiaryHouseType = survey.BeneficiaryHouseType;
            this.BeneficiaryHouseTypeString = survey.BeneficiaryHouseType.ToString();
            this.GrandTotalLivestockCost = survey.GrandTotalLivestockCost;
            this.GrandTotalAssetsCost = survey.GrandTotalAssetsCost;
            this.GrandTotalImmovableAnnualReturn = survey.GrandTotalImmovableAnnualReturn;
            this.GrandTotalEnergyUsesMonthly = survey.GrandTotalEnergyUsesMonthly;
            this.GrandTotalNetIncomeAgriculture = survey.GrandTotalNetIncomeAgriculture;
            this.GrandTotalLandArea = survey.GrandTotalLandArea;
            this.GrandTotalGrossMarginAgriculture = survey.GrandTotalGrossMarginAgriculture;
            this.BeneficiaryApproveStatus = survey.BeneficiaryApproveStatus;
            this.BeneficiaryApproveStatusString = survey.BeneficiaryApproveStatus.ToString();
        }
    }
}
