using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

public class OnTimeRecoveryRateFilterVM : ForestCivilLocationFilter
{
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}
