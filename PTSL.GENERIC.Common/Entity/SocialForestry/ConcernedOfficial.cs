using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class ConcernedOfficial : BaseEntity
{
    public string OfficialName { get; set; } = string.Empty;
    public long DesignationId { get; set; }
    public SocialForestryDesignation? Designation { get; set; }
    public string? EmailAddress { get; set; } = string.Empty;
    public string? MobileNo { get; set; } = string.Empty;
    public List<ConcernedOfficialMap>? ConcernedOfficialMap { get; set; } = new List<ConcernedOfficialMap>();
}
