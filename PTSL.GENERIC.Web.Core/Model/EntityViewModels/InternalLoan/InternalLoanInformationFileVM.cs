using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

public class InternalLoanInformationFileVM : BaseModel
{
    public long InternalLoanInformationId { get; set; }
    public InternalLoanInformationVM? InternalLoanInformation { get; set; }
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }
}
