using System;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountDepositApprovalVM : BaseModel
{
    // Approved By
    public long? ApprovedById { get; set; }
    [SwaggerExclude]
    public UserVM? ApprovedBy { get; set; }
    public long? ApprovedByRoleId { get; set; }
    [SwaggerExclude]
    public UserRoleVM? ApprovedByRole { get; set; }

    // Forwarded By
    public long? ForwardedById { get; set; }
    [SwaggerExclude]
    public UserVM? ForwardedBy { get; set; }
    public long? ForwardedByRoleId { get; set; }
    [SwaggerExclude]
    public UserRoleVM? ForwardedByRole { get; set; }

    // Forwarded To
    public long? ForwardedToId { get; set; }
    [SwaggerExclude]
    public UserVM? ForwardedTo { get; set; }
    public long? ForwardedToRoleId { get; set; }
    [SwaggerExclude]
    public UserRoleVM? ForwardedToRole { get; set; }

    public DateTime? SendingDateTime { get; set; }

    public long OrderId { get; set; }

    public long RowId { get; set; }
    [SwaggerExclude]
    public AccountDepositVM? Row { get; set; }

    public string? Remark { get; set; }
}
