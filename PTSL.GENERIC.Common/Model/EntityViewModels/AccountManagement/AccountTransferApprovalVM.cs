using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountTransferApprovalVM : BaseModel
{
    public long? ApprovedById { get; set; }
    public UserVM? ApprovedBy { get; set; }
    public long? ForwardedToId { get; set; }
    public UserVM? ForwardedTo { get; set; }

    public long? ApprovedByRoleId { get; set; }
    public UserRoleVM? ApprovedByRole { get; set; }
    public long? ForwardedToRoleId { get; set; }
    public UserRoleVM? ForwardedToRole { get; set; }

    public DateTime? SendingDate { get; set; }
    public DateTime? SendingTime { get; set; }

    public long OrderId { get; set; }

    public long RowId { get; set; }
    public AccountTransferVM? Row { get; set; }

    public string? Remark { get; set; }
}
