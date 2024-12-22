using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class InternalLoanInformationFile : BaseEntity
{
    public long? InternalLoanInformationId { get; set; }
    public InternalLoanInformation? InternalLoanInformation { get; set; }

    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
}

