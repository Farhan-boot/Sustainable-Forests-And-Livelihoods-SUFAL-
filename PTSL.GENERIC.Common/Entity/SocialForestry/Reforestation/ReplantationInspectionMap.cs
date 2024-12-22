using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationInspectionMap : BaseEntity
{
    public long ReplantationId { get; set; }
    public Replantation? Replantation { get; set; }

    public long InspectionDetailsId { get; set; }
    public InspectionDetails? InspectionDetails { get; set; }
}
