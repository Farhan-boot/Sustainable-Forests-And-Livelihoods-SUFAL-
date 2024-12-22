using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountDepositVM : BaseModel
{
    public long AccountId { get; set; }
    public AccountVM? Account { get; set; }

    public long FinancialYearId { get; set; }
    public FinancialYearVM? FinancialYear { get; set; }

    public long SourceOfFundId { get; set; }
    public SourceOfFundVM? SourceOfFund { get; set; }

    public DateTime DepositDate { get; set; }
    public double DepositAmount { get; set; }
    public DateTime DepositTransactionTime { get; set; } // Created time

    public long TransactionById { get; set; }
    public UserVM? TransactionBy { get; set; }

    public AccountDepositStatus AccountDepositStatus { get; set; }
    public AccountDepositApprovalProcess AccountDepositApprovalProcess { get; set; }

    // Next approval
    public long? NextApprovalUserId { get; set; }
    public UserVM? NextApprovalUser { get; set; }
    public long? NextApprovalUserRoleId { get; set; }
    public UserRoleVM? NextApprovalUserRole { get; set; }
    public long? NextApprovalOrderNo { get; set; }
    // Next approval

    public List<AccountDepositApprovalVM>? AccountDepositApprovals { get; set; }

    public string? Remarks { get; set; }

    //DataTable Get List using server site Pagination
    public string? DepositAmountBDText { get; set; }
    public string? AccountDepositStatusText { get; set; }
    public string? AccountDepositApprovalProcessText { get; set; }

}
