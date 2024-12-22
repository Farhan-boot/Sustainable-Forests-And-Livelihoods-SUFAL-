using System;

using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountTransferVM : BaseModel
{
    public long FromAccountId { get; set; }
    [SwaggerExclude]
    public AccountVM? FromAccount { get; set; }

    public long ToAccountId { get; set; }
    [SwaggerExclude]
    public AccountVM? ToAccount { get; set; }

    public long FinancialYearId { get; set; }
    [SwaggerExclude]
    public FinancialYearVM? FinancialYear { get; set; }

    public DateTime TransferDate { get; set; }
    public double TransferAmount { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public AccountTransferApprovalProcess AccountTransferApprovalProcess { get; set; }
    public DateTime TransferTransactionTime { get; set; } // Created time

    public long TransferRequestedById { get; set; }
    [SwaggerExclude]
    public UserVM? TransferRequestedBy { get; set; }

    public string? Remarks { get; set; }

    // Next approval
    public long? NextApprovalUserId { get; set; }
    [SwaggerExclude]
    public UserVM? NextApprovalUser { get; set; }
    public long? NextApprovalUserRoleId { get; set; }
    [SwaggerExclude]
    public UserRoleVM? NextApprovalUserRole { get; set; }
    public long? NextApprovalOrderNo { get; set; }
    // Next approval

    [SwaggerExclude]
    public List<AccountTransferDetailsVM>? AccountTransferDetails { get; set; }
    [SwaggerExclude]
    public List<AccountTransferLogVM>? AccountTransferLogs { get; set; }
}
