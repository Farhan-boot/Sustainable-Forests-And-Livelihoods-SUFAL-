using System;

using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;

public class AccountTransferLogVM : BaseModel
{
    public long AccountTransferId { get; set; }
    [SwaggerExclude]
    public AccountTransferVM? AccountTransfer { get; set; }

    public long? AccountTransferDetailsId { get; set; }
    [SwaggerExclude]
    public AccountTransferDetailsVM? AccountTransferDetails { get; set; }
    public double? AmountChangedFrom { get; set; }
    public double? AmountChangedTo { get; set; }

    public long TransferStatusChangedById { get; set; }
    [SwaggerExclude]
    public UserVM? TransferStatusChangedBy { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public DateTime StatusCreatedDate { get; set; }
}
