using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class InternalLoanAvailableAmountVM : BaseModel
{
    // InternalLoanAvailableAmount
    public double? TotalAccountBalance { get; set; }
    public double? TotalLoanBalance { get; set; }
    public double? TotalAvailableBalance { get; set; }

}
