namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class ZoneOrAreaVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NewRaisedPlantationVM>? NewRaisedPlantations { get; set; }
}
