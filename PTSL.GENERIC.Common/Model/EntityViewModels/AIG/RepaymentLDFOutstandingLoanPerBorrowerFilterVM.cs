using PTSL.GENERIC.Common.Model.EntityViewModels;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDFOutstandingLoanPerBorrowerFilterVM : ForestCivilLocationFilter
{
    public int? Year { get; set; }
    public Months? Month { get; set; }

    public bool HasYear => Year is not null && Year > 1600;
    public bool HasMonth => Month.HasValue;
}
