using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class IndividualLDFFilterVM : ForestCivilLocationFilter
{
    public IndividualLDFInfoStatus? IndividualLDFInfoStatus { get; set; }
    public Gender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }
    public long? NgoId { get; set; }

    public bool HasIndividualLDFInfoStatus => IndividualLDFInfoStatus.HasValue;
    public bool HasGender => Gender.HasValue;
    public bool HasPhoneNumber => string.IsNullOrEmpty(PhoneNumber) == false;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;
    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
}
