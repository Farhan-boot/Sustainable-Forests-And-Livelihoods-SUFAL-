using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class PlantationPlantVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long NurseryInformationId { get; set; }
    public NurseryInformationVM? NurseryInformation { get; set; }

    public long NurseryRaisedSeedlingInformationId { get; set; }
    public NurseryRaisedSeedlingInformationVM? NurseryRaisedSeedlingInformation { get; set; }

    public int NumberOfSeedlingPlanted { get; set; }
    public string? Remarks { get; set; } = string.Empty;
}
