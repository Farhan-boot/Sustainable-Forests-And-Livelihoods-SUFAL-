namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class SurveySelectorEssential
{
    public static Survey Create(Survey survey)
    {
        var newSurvey = new Survey
        {
            Id = survey.Id,
            BeneficiaryName = survey.BeneficiaryName,
            BeneficiaryNameBn = survey.BeneficiaryNameBn,
            BeneficiaryNid = survey.BeneficiaryNid,
            BeneficiaryPhone = survey.BeneficiaryPhone,
            BeneficiaryPhoneBn = survey.BeneficiaryPhoneBn,
            BeneficiaryGender = survey.BeneficiaryGender,
            BeneficiaryEthnicityId = survey.BeneficiaryEthnicityId,
            BeneficiaryEthnicityTxt = survey.BeneficiaryEthnicityTxt,
            BeneficiaryAge = survey.BeneficiaryAge,
            BeneficiaryAgeBn = survey.BeneficiaryAgeBn,
            BeneficiaryFatherName = survey.BeneficiaryFatherName,
            BeneficiaryFatherNameBn = survey.BeneficiaryFatherNameBn,
            BeneficiaryMotherName = survey.BeneficiaryMotherName,
            BeneficiaryMotherNameBn = survey.BeneficiaryMotherNameBn,
            BeneficiarySpouseName = survey.BeneficiarySpouseName,
            BeneficiarySpouseNameBn = survey.BeneficiarySpouseNameBn,
            HeadOfHouseholdName = survey.HeadOfHouseholdName,
            HeadOfHouseholdNameBn = survey.HeadOfHouseholdNameBn,
            HeadOfHouseholdGender = survey.HeadOfHouseholdGender,
            PresentDivisionId = survey.PresentDivisionId,
            PresentDistrictId = survey.PresentDistrictId,
            PresentUpazillaId = survey.PresentUpazillaId,
            PresentUnion = survey.PresentUnion,
            IsPermanentSameAsPresent = survey.IsPermanentSameAsPresent,
            BeneficiaryHouseType = survey.BeneficiaryHouseType,
            BeneficiaryApproveStatus = survey.BeneficiaryApproveStatus
        };

        return newSurvey;
    }
}