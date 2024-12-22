using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class IndividualGroupFormSetupVM : BaseModel
{
    public string IndividualDocument { get; set; } = string.Empty;
    public string GroupDocument { get; set; } = string.Empty;
}
