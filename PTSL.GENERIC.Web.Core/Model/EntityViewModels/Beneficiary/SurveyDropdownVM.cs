using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

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
}

