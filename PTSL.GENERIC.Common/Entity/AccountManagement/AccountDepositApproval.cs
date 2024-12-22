using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.PermissionSettings;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class AccountDepositApproval : BaseEntity, IApprovalEntity
{
    // Approved By
    public long? ApprovedById { get; set; }
    public User? ApprovedBy { get; set; }
    public long? ApprovedByRoleId { get; set; }
    public UserRole? ApprovedByRole { get; set; }

    // Forwarded By
    public long? ForwardedById { get; set; }
    public User? ForwardedBy { get; set; }
    public long? ForwardedByRoleId { get; set; }
    public UserRole? ForwardedByRole { get; set; }

    // Forwarded To
    public long? ForwardedToId { get; set; }
    public User? ForwardedTo { get; set; }
    public long? ForwardedToRoleId { get; set; }
    public UserRole? ForwardedToRole { get; set; }

    public DateTime? SendingDateTime { get; set; }

    public long OrderId { get; set; }

    public long RowId { get; set; }
    public AccountDeposit? Row { get; set; }

    public string? Remark { get; set; }

    public static AccountDepositApproval CreateForLastApproval(long userId, long userRoleId, PermissionRowSettings permissionRowSettings)
    {
        return new AccountDepositApproval
        {
            ApprovedById = userId,
            ApprovedByRoleId = userRoleId,
            OrderId = permissionRowSettings.OrderId,
            SendingDateTime = DateTime.Now,
            Remark = "Approved by last high authority",
        };
    }

    public static AccountDepositApproval CreateForFirstApproval(long userId, long userRoleId, PermissionRowSettings permissionRowSettings)
    {
        return new AccountDepositApproval
        {
            ForwardedToId = userId,
            ForwardedToRoleId = userRoleId,
            OrderId = permissionRowSettings.OrderId,
            SendingDateTime = DateTime.Now,
        };
    }
}
