using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

public class CommitteeDesignationVM : BaseModel
{
    public CommitteeType CommitteeType { get; set; }
    public SubCommitteeType? SubCommitteeType { get; set; }
    public string? Name { get; set; }
    public string? NameBn { get; set; }
}
