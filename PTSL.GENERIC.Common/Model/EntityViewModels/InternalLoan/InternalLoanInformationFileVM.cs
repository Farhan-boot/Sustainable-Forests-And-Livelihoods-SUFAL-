using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class InternalLoanInformationFileVM : BaseModel
{
    public long InternalLoanInformationId { get; set; }
    [SwaggerExclude]
    public InternalLoanInformationVM? InternalLoanInformation { get; set; }

    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
}

