using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class IndividualGroupFormSetup : BaseEntity
{
    public string IndividualDocument { get; set; } = string.Empty;
    public string GroupDocument { get; set; } = string.Empty;
}
