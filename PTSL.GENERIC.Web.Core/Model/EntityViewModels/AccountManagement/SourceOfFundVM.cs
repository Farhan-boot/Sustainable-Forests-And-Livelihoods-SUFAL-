namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class SourceOfFundVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<AccountDepositVM>? AccountDeposits { get; set; }
    public List<AccountTransferVM>? AccountTransfers { get; set; }
    public List<AccountTransferDetailsVM>? AccountTransferDetails { get; set; }
}
