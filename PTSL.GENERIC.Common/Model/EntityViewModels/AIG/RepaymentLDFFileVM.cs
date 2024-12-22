using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class RepaymentLDFFileVM : BaseModel
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }

    public long RepaymentLDFId { get; set; }
    [SwaggerExclude]
    public RepaymentLDFVM? RepaymentLDF { get; set; }
}

