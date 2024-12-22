using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountTransferVM : BaseModel
{
    public long FromAccountId { get; set; }
    public AccountVM? FromAccount { get; set; }

    public long ToAccountId { get; set; }
    public AccountVM? ToAccount { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }

    public DateTime TransferDate { get; set; }
    public double TransferAmount { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public AccountTransferApprovalProcess AccountTransferApprovalProcess { get; set; }
    public DateTime TransferTransactionTime { get; set; } // Created time

    public long TransferRequestedById { get; set; }
    public UserVM? TransferRequestedBy { get; set; }

    public string? Remarks { get; set; }

    // Next approval
    public long? NextApprovalUserId { get; set; }
    public UserVM? NextApprovalUser { get; set; }
    public long? NextApprovalUserRoleId { get; set; }
    public UserRoleVM? NextApprovalUserRole { get; set; }
    public long? NextApprovalOrderNo { get; set; }
    // Next approval

    public List<AccountTransferDetailsVM>? AccountTransferDetails { get; set; }
    public List<AccountTransferLogVM>? AccountTransferLogs { get; set; }
}
