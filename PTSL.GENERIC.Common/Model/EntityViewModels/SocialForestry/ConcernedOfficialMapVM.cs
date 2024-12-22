using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class ConcernedOfficialMapVM : BaseModel
{
    
    public long ConcernedOfficialId { get; set; }
    public ConcernedOfficialVM? ConcernedOfficial { get; set; }

    public long? NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public long? NursaryInformationId { get; set; }
    public NurseryInformationVM? NursaryInformation { get; set; }
}

