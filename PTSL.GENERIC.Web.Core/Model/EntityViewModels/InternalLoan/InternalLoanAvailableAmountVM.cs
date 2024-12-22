using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

public class InternalLoanAvailableAmountVM : BaseModel
{
    // InternalLoanAvailableAmount
    public double? TotalAccountBalance { get; set; }
    public double? TotalLoanBalance { get; set; }
    public double? TotalAvailableBalance { get; set; }
}
