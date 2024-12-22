namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationInspectionMapVM : BaseModel
{
    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public long InspectionDetailsId { get; set; }
    public InspectionDetailsVM? InspectionDetails { get; set; }
}
