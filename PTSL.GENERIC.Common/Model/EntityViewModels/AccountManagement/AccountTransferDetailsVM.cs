using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountTransferDetailsVM : BaseModel
{
    public long AccountTransferId { get; set; }
    [SwaggerExclude]
    public AccountTransferVM? AccountTransfer { get; set; }

    public long SourceOfFundId { get; set; }
    [SwaggerExclude]
    public SourceOfFundVM? SourceOfFund { get; set; }

    public double TransferDetailsAmount { get; set; }

    public string Purpose { get; set; } = string.Empty;

    [SwaggerExclude]
    public List<AccountTransferLogVM>? AccountTransferLogs { get; set; }
}
