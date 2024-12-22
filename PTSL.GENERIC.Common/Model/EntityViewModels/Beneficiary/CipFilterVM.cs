using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.Beneficiary;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;

public class CipFilterVM : ForestCivilLocationFilter
{
    public Gender? Gender { get; set; }
    public CipWealth? CipWealth { get; set; }
    public string? NID { get; set; }
    public long? EthnicityId { get; set; }

    public bool HasGender => Gender.HasValue;
    public bool HasCipWealth => CipWealth.HasValue;
    public bool HasNID => string.IsNullOrEmpty(NID) == false;
    public bool HasEthnicityId => EthnicityId.HasValue && EthnicityId.Value > 0;
}
