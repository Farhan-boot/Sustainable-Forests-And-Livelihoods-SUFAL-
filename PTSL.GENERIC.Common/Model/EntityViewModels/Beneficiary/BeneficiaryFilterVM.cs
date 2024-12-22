using PTSL.GENERIC.Common.Model.EntityViewModels.Common;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class BeneficiaryFilterVM 
{
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }
    public bool GetPendingAlso { get; set; }
    public string? BeneficiaryName { get; set; }
    public string? FcvVcfName { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
    public bool HasBeneficiaryName => string.IsNullOrWhiteSpace(BeneficiaryName) == false;
    public bool HasFcvVcfName => string.IsNullOrWhiteSpace(FcvVcfName) == false;

    public ForestCivilLocationVM? ForestCivilLocation { get; set; }

    // Backend Pagination
    public int? iDisplayStart { get; set; }
    public int? iDisplayLength { get; set; }
    public string? sSearch { get; set; }

}