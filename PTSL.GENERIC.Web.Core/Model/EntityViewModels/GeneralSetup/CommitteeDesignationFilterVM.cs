using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

public class CommitteeDesignationFilterVM
{
    public CommitteeType? CommitteeType { get; set; }
    public SubCommitteeType? SubCommitteeType { get; set; }

    public bool HasCommitteeType => CommitteeType.HasValue;
    public bool HasSubCommitteeType => SubCommitteeType.HasValue;
}

