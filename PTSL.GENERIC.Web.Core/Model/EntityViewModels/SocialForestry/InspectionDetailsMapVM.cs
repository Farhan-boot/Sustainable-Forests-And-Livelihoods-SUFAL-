using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class InspectionDetailsMapVM : BaseModel
{
    public long InspectionDetailsId { get; set; }
    public InspectionDetailsVM? InspectionDetails { get; set; }
    public long? NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long? NurseryInformationId { get; set; }
    public NurseryInformationVM? NurseryInformation { get; set; }
}
