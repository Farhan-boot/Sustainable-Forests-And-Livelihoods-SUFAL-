using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

public class CommitteeDesignationVM : BaseModel
{
    public CommitteeType CommitteeType { get; set; }
    public SubCommitteeType? SubCommitteeType { get; set; }
    public string? Name { get; set; }
    public string? NameBn { get; set; }
}
