using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.PermissionSettings;
using PTSL.GENERIC.Common.Entity.UserEntitys;

namespace PTSL.GENERIC.Common.Entity;

public class UserRole : BaseEntity
{
    public string RoleName { get; set; } = string.Empty;
    public string AccessList { get; set; } = string.Empty;

    public List<User>? Users { get; set; }
    public List<UserRolePermissionMap>? UserRolePermissionMaps { get; set; }

    public List<PermissionHeaderSettings>? PermissionHeaderSettings { get; set; }
    public List<PermissionRowSettings>? PermissionRowSettings { get; set; }

    public List<ApprovalLogForCfm>? ApprovalLogForCfmsSenderRole { get; set; }
    public List<ApprovalLogForCfm>? ApprovalLogForCfmsReceiverRole { get; set; }


}
