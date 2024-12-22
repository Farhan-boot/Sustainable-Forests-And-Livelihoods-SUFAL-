using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class SocialForestryDesignation : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<ConcernedOfficial>? ConcernedOfficials { get; set; }
}
