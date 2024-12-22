using System;

using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountVM : BaseModel
{
    // Mandatory Forest Location 
    public long ForestCircleId { get; set; }
    [SwaggerExclude]
    public ForestCircleVM? ForestCircle { get; set; }
    public long ForestDivisionId { get; set; }
    [SwaggerExclude]
    public ForestDivisionVM? ForestDivision { get; set; }

    // Optional Forest Location
    public long? ForestRangeId { get; set; }
    [SwaggerExclude]
    public ForestRangeVM? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    [SwaggerExclude]
    public ForestBeatVM? ForestBeat { get; set; }
    public long? ForestFcvVcfId { get; set; }
    [SwaggerExclude]
    public ForestFcvVcfVM? ForestFcvVcf { get; set; }

    // Committee
    public long? CommitteeTypeId { get; set; }
    [SwaggerExclude]
    public CommitteeTypeConfigurationVM? CommitteeType { get; set; }
    public long? CommitteeId { get; set; }
    [SwaggerExclude]
    public CommitteesConfigurationVM? Committee { get; set; }

    // Account Balance
    public double CurrentAccountBalance { get; set; }
    public double CurrentBlockAmount { get; set; }
    public double CurrentAvailableBalance { get; set; } // please validate with this field

    // Account Information
    public string? BankAccountName { get; set; }
    public string? AccountNumber { get; set; }
    public AccountTypeForAccount AccountType { get; set; }
    public AccountAllowedFundExpense[] AccountAllowedFundExpenses { get; set; } = Array.Empty<AccountAllowedFundExpense>();
    public string? BankName { get; set; }
    public string? BranchName { get; set; }
    public DateTime? AccountOpeningDate { get; set; }
    public string? Remarks { get; set; }

    [SwaggerExclude]
    public List<UserVM>? Users { get; set; }
    [SwaggerExclude]
    public List<AccountTransferVM>? FromAccountTransfers { get; set; }
    [SwaggerExclude]
    public List<AccountTransferVM>? ToAccountTransfers { get; set; }
    [SwaggerExclude]
    public List<AccountDepositVM>? AccountDeposits { get; set; }
    [SwaggerExclude]
    public List<AccountsUserTagLogVM>? AccountsUserTagLogs { get; set; }
    [SwaggerExclude]
    public List<BankAccountsInformationVM>? BankAccountsInformations { get; set; }
}
