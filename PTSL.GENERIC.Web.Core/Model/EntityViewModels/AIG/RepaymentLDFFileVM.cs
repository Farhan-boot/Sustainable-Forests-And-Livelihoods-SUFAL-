using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class RepaymentLDFFileVM : BaseModel
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
    public long RepaymentLDFId { get; set; }
    public RepaymentLDFVM? RepaymentLDF { get; set; }

}
