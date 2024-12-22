using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationNurseryInfoVM : BaseModel
{
    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public long NurseryInformationId { get; set; }
    public NurseryInformationVM? NurseryInformation { get; set; }

    public long? NurseryRaisedSeedlingInformationId { get; set; }
    public NurseryRaisedSeedlingInformationVM? NurseryRaisedSeedlingInformation { get; set; }

    public int NumberOfSeedlingPlanted { get; set; }
    public string? Remarks { get; set; }
}
