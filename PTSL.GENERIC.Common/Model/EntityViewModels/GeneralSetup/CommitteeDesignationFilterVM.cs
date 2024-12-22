using PTSL.GENERIC.Common.Enum.ForestManagement;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

public class CommitteeDesignationFilterVM
{
    public CommitteeType? CommitteeType { get; set; }
    public SubCommitteeType? SubCommitteeType { get; set; }

    public bool HasCommitteeType => CommitteeType.HasValue;
    public bool HasSubCommitteeType => SubCommitteeType.HasValue;
}

