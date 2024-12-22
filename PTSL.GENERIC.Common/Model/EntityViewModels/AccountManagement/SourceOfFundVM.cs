using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class SourceOfFundVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    [SwaggerExclude]
    public List<AccountDepositVM>? AccountDeposits { get; set; }
    [SwaggerExclude]
    public List<AccountTransferVM>? AccountTransfers { get; set; }
    [SwaggerExclude]
    public List<AccountTransferDetailsVM>? AccountTransferDetails { get; set; }
}
