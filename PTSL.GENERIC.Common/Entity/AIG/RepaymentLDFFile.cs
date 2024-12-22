using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDFFile : BaseEntity
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }

    public long RepaymentLDFId { get; set; }
    public RepaymentLDF? RepaymentLDF { get; set; }
}

