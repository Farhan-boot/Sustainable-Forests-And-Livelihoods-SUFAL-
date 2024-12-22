using PTSL.GENERIC.Web.Core.Helper;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountCurrentBalanceVM
{
    public long Id { get; set; }
    public double CurrentAccountBalance { get; set; }
    public double CurrentBlockAmount { get; set; }
    public double CurrentAvailableBalance { get; set; }
    public string CurrentAvailableBalanceDisplay => CurrentAvailableBalance.ToBDTCurrency();
}
