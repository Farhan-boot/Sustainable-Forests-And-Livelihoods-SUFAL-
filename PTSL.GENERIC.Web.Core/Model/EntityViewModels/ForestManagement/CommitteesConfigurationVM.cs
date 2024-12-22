using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

public class CommitteesConfigurationVM : BaseModel
{
    public long? CommitteeTypeConfigurationId { get; set; }
    public string? CommitteeName { get; set; }
    public CommitteeTypeConfigurationVM? CommitteeTypeConfiguration { get; set; }
}
