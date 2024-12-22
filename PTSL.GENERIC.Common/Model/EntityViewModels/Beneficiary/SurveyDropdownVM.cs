using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class SurveyDropdownVM
{
    public long Id { get; set; }
    public string BeneficiaryId { get; set; } = string.Empty;
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryNameBn { get; set; }
    public string? BeneficiaryNid { get; set; }
    public string? BeneficiaryPhone { get; set; }
    public string? BeneficiaryPhoneBn { get; set; }
    public Gender BeneficiaryGender { get; set; }
    public string? BeneficiaryGenderString { get; set; }
    public long? BeneficiaryEthnicityId { get; set; }
    public BeneficiaryApproveStatus BeneficiaryApproveStatus { get; set; }
    public string? BeneficiaryApproveStatusString { get; set; }
    public double? IndividualLDFApprovedLoanAmount { get; set; }

    public SurveyDropdownVM()
    {
    }

    public SurveyDropdownVM(Survey? survey, IndividualLDFInfoForm? individualLDFInfoForm = null)
    {
        if (survey is not null)
        {
            this.Id = survey.Id;
            this.BeneficiaryId = survey.BeneficiaryId;
            this.BeneficiaryName = survey.BeneficiaryName;
            this.BeneficiaryNameBn = survey.BeneficiaryNameBn;
            this.BeneficiaryNid = survey.BeneficiaryNid;
            this.BeneficiaryPhone = survey.BeneficiaryPhone;
            this.BeneficiaryPhoneBn = survey.BeneficiaryPhoneBn;
            this.BeneficiaryGender = survey.BeneficiaryGender;
            this.BeneficiaryGenderString = survey.BeneficiaryGender.ToString();
            this.BeneficiaryEthnicityId = survey.BeneficiaryEthnicityId;
            this.BeneficiaryApproveStatus = survey.BeneficiaryApproveStatus;
            this.BeneficiaryApproveStatusString = survey.BeneficiaryApproveStatus.ToString();
            this.IndividualLDFApprovedLoanAmount = individualLDFInfoForm?.ApprovedLoanAmount ?? null;
        }
    }
}
