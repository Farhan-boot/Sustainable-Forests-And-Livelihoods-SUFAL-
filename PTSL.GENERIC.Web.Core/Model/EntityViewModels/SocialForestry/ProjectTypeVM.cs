namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

// Source of Funding / Name of Project
public class ProjectTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
}
