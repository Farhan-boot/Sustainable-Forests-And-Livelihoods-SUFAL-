using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationNurseryInfo : BaseEntity
{
    public long ReplantationId { get; set; }
    public Replantation? Replantation { get; set; }

    public long NurseryInformationId { get; set; }
    public NurseryInformation? NurseryInformation { get; set; }

    public long? NurseryRaisedSeedlingInformationId { get; set; }
    public NurseryRaisedSeedlingInformation? NurseryRaisedSeedlingInformation { get; set; }

    public int NumberOfSeedlingPlanted { get; set; }
    public string? Remarks { get; set; }
}
