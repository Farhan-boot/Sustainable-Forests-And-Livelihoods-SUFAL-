using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class DateWiseRepaymentReportFilterVM : ForestCivilLocationFilter
{
    public int? Year { get; set; }
    public Months? Month { get; set; }
    public DateTime? Date { get; set; }
    public bool? IsCompleted { get; set; }

    public bool HasYear => Year is not null && Year > 1600;
    public bool HasMonth => Month.HasValue;
    public bool HasDate => Date is not null && Date != default;
}
