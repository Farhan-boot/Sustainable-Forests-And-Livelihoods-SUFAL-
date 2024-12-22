using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;

public class TransactionFilesVM : BaseModel
{
    public long TransactionId { get; set; }
    public TransactionVM? Transaction { get; set; }

    public string? FileName { get; set; }
    public string? FileUrl { get; set; }

    public FileType FileType { get; set; }
}
