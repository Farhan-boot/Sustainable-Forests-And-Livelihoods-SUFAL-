using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class AverageLoanSizeFilterVM : ForestCivilLocationFilter
{
    public int? Year { get; set; }
    public Months? Month { get; set; }
}
