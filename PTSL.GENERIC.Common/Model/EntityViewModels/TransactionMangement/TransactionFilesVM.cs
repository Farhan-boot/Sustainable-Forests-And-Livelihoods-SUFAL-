using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;

public class TransactionFilesVM : BaseModel
{
    public long TransactionId { get; set; }
    public TransactionVM? Transaction { get; set; }

    public string? FileName { get; set; }
    public string? FileUrl { get; set; }

    public FileType FileType { get; set; }
}
