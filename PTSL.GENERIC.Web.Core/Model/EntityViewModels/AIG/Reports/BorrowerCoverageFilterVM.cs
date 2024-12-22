namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class BorrowerCoverageFilterVM : ForestCivilLocationFilter
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
