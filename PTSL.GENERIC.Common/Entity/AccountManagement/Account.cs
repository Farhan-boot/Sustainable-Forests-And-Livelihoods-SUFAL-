using System;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Entity.AccountManagement;

public class Account : BaseEntity
{
    // Mandatory Forest Location 
    public long ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }

    // Optional Forest Location
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    public ForestFcvVcf? ForestFcvVcf { get; set; }

    // Committee
    public long? CommitteeTypeId { get; set; }
    public CommitteeTypeConfiguration? CommitteeType { get; set; }
    public long? CommitteeId { get; set; }
    public CommitteesConfiguration? Committee { get; set; }

    // Account Balance
    public double CurrentAccountBalance { get; set; }
    public double CurrentBlockAmount { get; set; }
    public double CurrentAvailableBalance => CurrentAccountBalance - CurrentBlockAmount;

    // Account Information
    public string? BankAccountName { get; set; }
    public string? AccountNumber { get; set; }
    public AccountTypeForAccount AccountType { get; set; }
    public AccountAllowedFundExpense[] AccountAllowedFundExpenses { get; set; } = Array.Empty<AccountAllowedFundExpense>();
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public DateTime? AccountOpeningDate { get; set; }
    public string? Remarks { get; set; }

    public List<User>? Users { get; set; }
    public List<AIGBasicInformation>? AIGBasicInformations { get; set; }
    public List<AccountTransfer>? FromAccountTransfers { get; set; }
    public List<AccountTransfer>? ToAccountTransfers { get; set; }
    public List<AccountDeposit>? AccountDeposits { get; set; }
    public List<AccountsUserTagLog>? AccountsUserTagLogs { get; set; }
    public List<BankAccountsInformation>? BankAccountsInformations { get; set; }
    public List<Transaction>? Transactions { get; set; }
}
