using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountVM : BaseModel
{
    // Mandatory Forest Location 
    public long ForestCircleId { get; set; }
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivisionVM? ForestDivision { get; set; }

    // Optional Forest Location
    public long? ForestRangeId { get; set; }
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Committee
    public long? CommitteeTypeId { get; set; }
    public CommitteeTypeConfigurationVM? CommitteeType { get; set; }
    public long? CommitteeId { get; set; }
    public CommitteesConfigurationVM? Committee { get; set; }

    // Account Balance
    public double CurrentAccountBalance { get; set; }
    public double CurrentBlockAmount { get; set; }
    public double CurrentAvailableBalance { get; set; } // please validate with this field

    // Account Information
    public string? BankAccountName { get; set; }
    public string? AccountNumber { get; set; }
    public AccountTypeForAccount AccountType { get; set; }
    public string AccountTypeDisplay => AccountType.GetEnumDisplayName();
    public AccountAllowedFundExpense[] AccountAllowedFundExpenses { get; set; } = Array.Empty<AccountAllowedFundExpense>();
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public DateTime? AccountOpeningDate { get; set; }
    public string? Remarks { get; set; }

    public string AccountFullInformation { get; set; } = string.Empty;

    public List<UserVM>? Users { get; set; }
    public List<AccountTransferVM>? FromAccountTransfers { get; set; }
    public List<AccountTransferVM>? ToAccountTransfers { get; set; }
    public List<AccountDepositVM>? AccountDeposits { get; set; }
    public List<AccountsUserTagLogVM>? AccountsUserTagLogs { get; set; }
    public List<BankAccountsInformationVM>? BankAccountsInformations { get; set; }

    //DataTable Get List using server site Pagination
    public string? AccountTypeText { get; set; }
    public string? CurrentAvailableBalanceBdtText { get; set; }
}
