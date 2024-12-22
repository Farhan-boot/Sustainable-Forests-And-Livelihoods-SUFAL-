using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

public class CommitteeDesignationsConfigurationVM : BaseModel
{
    public long? CommitteesConfigurationId { get; set; }
    public string? DesignationName { get; set; }
    public CommitteesConfigurationVM? CommitteesConfiguration { get; set; }
}
