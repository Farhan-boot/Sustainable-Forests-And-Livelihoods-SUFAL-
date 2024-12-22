using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationInspectionMapVM : BaseModel
{
    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public long InspectionDetailsId { get; set; }
    public InspectionDetailsVM? InspectionDetails { get; set; }
}
