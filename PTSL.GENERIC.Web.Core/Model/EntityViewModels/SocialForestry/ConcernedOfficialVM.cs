namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class ConcernedOfficialVM : BaseModel
{
    public string OfficialName { get; set; } = string.Empty;
    public long DesignationId { get; set; }
    public SocialForestryDesignationVM? Designation { get; set; }
    public string? EmailAddress { get; set; } = string.Empty;
    public string? MobileNo { get; set; } = string.Empty;

    public List<NewRaisedPlantationVM>? NewRaisedPlantation { get; set; }
    public List<ConcernedOfficialMapVM>? ConcernedOfficialMap { get; set; }
}
