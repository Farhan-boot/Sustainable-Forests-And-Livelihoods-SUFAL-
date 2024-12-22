using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class CumulativeRecoveryRateFilterVM : ForestCivilLocationFilter
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
