using PTSL.GENERIC.Common.Enum.AccountManagement;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountFilterVM : ForestCivilLocationFilter
{
    public long? CommitteeTypeId { get; set; }
    public long? CommitteeId { get; set; }
    public string? BankAccountName { get; set; }
    public string? AccountNumber { get; set; }
    public AccountTypeForAccount? AccountType { get; set; }

    public bool HasCommitteeType => CommitteeTypeId is not null && CommitteeTypeId > 0;
    public bool HasCommittee => CommitteeId is not null && CommitteeId > 0;
    public bool HasBankAccountName => string.IsNullOrWhiteSpace(BankAccountName) == false;
    public bool HasAccountNumber => string.IsNullOrWhiteSpace(AccountNumber) == false;
    public bool HasAccountType => AccountType is not null;
}
