namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class AverageLoanSizeFilterVM : ForestCivilLocationFilter
{
    public int? Year { get; set; }
    public Months? Month { get; set; }

    public bool HasYear => Year is not null && Year > 1600;
    public bool HasMonth => Month.HasValue;
}
