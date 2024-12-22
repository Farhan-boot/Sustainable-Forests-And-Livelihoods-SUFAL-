using PTSL.GENERIC.Web.Core.Model;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class IndividualGroupFormSetupVM : BaseModel
{
    public string IndividualDocument { get; set; } = string.Empty;
    public string GroupDocument { get; set; } = string.Empty;
}
