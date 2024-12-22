using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

public class BorrowerCoverageFilterVM : ForestCivilLocationFilter
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }

    public bool HasFromDate => FromDate.HasValue && FromDate is not null;
    public bool HasToDate => ToDate.HasValue && ToDate is not null;
}
