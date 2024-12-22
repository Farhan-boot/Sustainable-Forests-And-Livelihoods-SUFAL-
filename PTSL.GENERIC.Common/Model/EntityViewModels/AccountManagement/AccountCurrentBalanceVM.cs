namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountCurrentBalanceVM
{
    public long Id { get; set; }
    public double CurrentAccountBalance { get; set; }
    public double CurrentBlockAmount { get; set; }
    public double CurrentAvailableBalance => CurrentAccountBalance - CurrentBlockAmount;
}
