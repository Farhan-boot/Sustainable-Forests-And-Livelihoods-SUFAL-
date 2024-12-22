using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

public class NurseryRaisedSeedlingInformation : BaseEntity
{
    public long NurseryInformationId { get; set; }
    public NurseryInformation? NurseryInformation { get; set; }
    public string SpeciesName { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public int SeedlingRaised { get; set; }
    public string? Remarks { get; set; }
}
