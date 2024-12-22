using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

// UI Name: Raised Seedling Information
public class PlantationPlant : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public long NurseryInformationId { get; set; }
    public NurseryInformation? NurseryInformation { get; set; }

    public long NurseryRaisedSeedlingInformationId { get; set; }
    public NurseryRaisedSeedlingInformation? NurseryRaisedSeedlingInformation { get; set; }

    public int NumberOfSeedlingPlanted { get; set; }
    public string? Remarks { get; set; } = string.Empty;
}
