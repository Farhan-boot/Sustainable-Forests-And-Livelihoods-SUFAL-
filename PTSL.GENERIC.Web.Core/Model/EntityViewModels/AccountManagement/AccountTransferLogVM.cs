using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AccountManagement;

public class AccountTransferLogVM : BaseModel
{
    public long AccountTransferId { get; set; }
    public AccountTransferVM? AccountTransfer { get; set; }

    public long? AccountTransferDetailsId { get; set; }
    public AccountTransferDetailsVM? AccountTransferDetails { get; set; }
    public double? AmountChangedFrom { get; set; }
    public double? AmountChangedTo { get; set; }

    public long TransferStatusChangedById { get; set; }
    public UserVM? TransferStatusChangedBy { get; set; }

    public AccountTransferStatus AccountTransferStatus { get; set; }
    public DateTime StatusCreatedDate { get; set; }
}
