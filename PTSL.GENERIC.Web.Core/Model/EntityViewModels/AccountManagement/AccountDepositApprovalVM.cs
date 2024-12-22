using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountDepositApprovalVM : BaseModel
{
    // Approved By
    public long? ApprovedById { get; set; }
    public UserVM? ApprovedBy { get; set; }
    public long? ApprovedByRoleId { get; set; }
    public UserRoleVM? ApprovedByRole { get; set; }

    // Forwarded By
    public long? ForwardedById { get; set; }
    public UserVM? ForwardedBy { get; set; }
    public long? ForwardedByRoleId { get; set; }
    public UserRoleVM? ForwardedByRole { get; set; }

    // Forwarded To
    public long? ForwardedToId { get; set; }
    public UserVM? ForwardedTo { get; set; }
    public long? ForwardedToRoleId { get; set; }
    public UserRoleVM? ForwardedToRole { get; set; }

    public DateTime? SendingDateTime { get; set; }

    public long OrderId { get; set; }

    public long RowId { get; set; }
    public AccountDepositVM? Row { get; set; }

    public string? Remark { get; set; }
}
