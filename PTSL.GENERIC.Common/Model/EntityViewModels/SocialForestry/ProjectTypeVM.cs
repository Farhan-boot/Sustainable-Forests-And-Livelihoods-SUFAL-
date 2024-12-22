using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

// Source of Funding / Name of Project
public class ProjectTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    [SwaggerExclude]
    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
}
