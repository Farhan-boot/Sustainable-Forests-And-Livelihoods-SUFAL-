namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class SocialForestryDesignationVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<ConcernedOfficialVM>? ConcernedOfficials { get; set; }
}
