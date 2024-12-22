namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountDepositForwardRequestVM
{
    public long AccountDepositId { get; set; }
    public long PermissionHeaderSettingsId { get; set; }
    public long NextRequestedUserRoleId { get; set; }
    public long? NextRequestedUserId { get; set; }
}
