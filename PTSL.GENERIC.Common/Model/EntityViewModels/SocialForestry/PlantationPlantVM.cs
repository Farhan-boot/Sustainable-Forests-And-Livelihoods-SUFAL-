using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationPlantVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    [SwaggerExclude]
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long NurseryInformationId { get; set; }
    [SwaggerExclude]
    public NurseryInformationVM? NurseryInformation { get; set; }

    public long NurseryRaisedSeedlingInformationId { get; set; }
    [SwaggerExclude]
    public NurseryRaisedSeedlingInformationVM? NurseryRaisedSeedlingInformation { get; set; }

    public int NumberOfSeedlingPlanted { get; set; }
    public string? Remarks { get; set; } = string.Empty;
}
