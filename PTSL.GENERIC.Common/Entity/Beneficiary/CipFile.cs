using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary;

public class CipFile : BaseEntity
{
    public long CipId { get; set; }
    public Cip? Cip { get; set; }

    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
}

