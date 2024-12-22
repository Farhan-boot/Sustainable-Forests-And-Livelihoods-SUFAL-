using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class InspectionDetailsMap : BaseEntity
{
    public long InspectionDetailsId { get; set; }
    public InspectionDetails? InspectionDetails { get; set; }
    public long? NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public long? NurseryInformationId { get; set; }
    public NurseryInformation? NurseryInformation { get; set; }
}
