using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

public class NurseryRaisedSeedlingInformationVM : BaseModel
{
    public long NurseryInformationId { get; set; }
    public NurseryInformationVM? NurseryInformation { get; set; } 
    public string SpeciesName { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public int SeedlingRaised { get; set; }
    public string? Remarks { get; set; }
}
public class UpdateSeedlingInfoVM
{
    public long SeedlingId { get; set; }
    public long NurseryId { get; set; }
    public int SeedlingNumberToBeDistributed { get; set; }
    public bool IsAdd { get; set; }
}