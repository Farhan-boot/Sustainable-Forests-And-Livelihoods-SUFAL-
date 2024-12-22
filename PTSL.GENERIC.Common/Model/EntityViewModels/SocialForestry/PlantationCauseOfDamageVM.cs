using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationCauseOfDamageVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    [SwaggerExclude]
    public List<PlantationDamageInformationVM>? PlantationDamageInformation { get; set; }
}
