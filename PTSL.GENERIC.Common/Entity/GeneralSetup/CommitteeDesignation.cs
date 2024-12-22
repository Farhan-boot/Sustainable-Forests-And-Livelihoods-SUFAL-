using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum.ForestManagement;

namespace PTSL.GENERIC.Common.Entity.GeneralSetup;

public class CommitteeDesignation : BaseEntity
{
    public CommitteeType CommitteeType { get; set; }
    public SubCommitteeType? SubCommitteeType { get; set; }
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }
}

