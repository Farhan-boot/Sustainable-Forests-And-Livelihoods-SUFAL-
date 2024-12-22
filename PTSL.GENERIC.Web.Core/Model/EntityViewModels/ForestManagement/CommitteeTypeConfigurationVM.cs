using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

public class CommitteeTypeConfigurationVM : BaseModel
{
    public long? FcvOrVcfTypeId { get; set; }
    public string? CommitteeTypeName { get; set; }
    public List<CommitteesConfigurationVM>? CommitteesConfigurations { get; set; }
}
