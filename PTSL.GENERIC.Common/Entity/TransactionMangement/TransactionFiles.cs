using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.TransactionMangement;

public class TransactionFiles : BaseEntity
{
    public long TransactionId { get; set; }
    public Transaction? Transaction { get; set; }

    public string? FileName { get; set; }
    public string? FileUrl { get; set; }

    public FileType FileType { get; set; }
}
