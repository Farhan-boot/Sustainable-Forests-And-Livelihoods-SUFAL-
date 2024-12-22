using System;

using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountDepositVM : BaseModel
{
    public long AccountId { get; set; }
    [SwaggerExclude]
    public AccountVM? Account { get; set; }

    public long FinancialYearId { get; set; }
    [SwaggerExclude]
    public FinancialYearVM? FinancialYear { get; set; }

    public long SourceOfFundId { get; set; }
    [SwaggerExclude]
    public SourceOfFundVM? SourceOfFund { get; set; }

    public DateTime DepositDate { get; set; }
    public double DepositAmount { get; set; }
    public DateTime DepositTransactionTime { get; set; } // Created time

    public long TransactionById { get; set; }
    [SwaggerExclude]
    public UserVM? TransactionBy { get; set; }
    [SwaggerExclude]
    public AccountDepositStatus AccountDepositStatus { get; set; }
    [SwaggerExclude]
    public AccountDepositApprovalProcess AccountDepositApprovalProcess { get; set; }

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
    public List<AccountDepositApprovalVM>? AccountDepositApprovals { get; set; }

    public bool ShouldEdit => AccountDepositApprovalProcess == AccountDepositApprovalProcess.Pending;

    public string? Remarks { get; set; }
}
