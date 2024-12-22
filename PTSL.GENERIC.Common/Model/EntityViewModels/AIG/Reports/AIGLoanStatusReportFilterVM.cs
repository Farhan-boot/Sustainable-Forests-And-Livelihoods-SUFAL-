using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

public class AIGLoanStatusReportFilterVM : ForestCivilLocationFilter
{
    public BadLoanType? BadLoanType { get; set; }

    public bool HasBadLoanType => BadLoanType.HasValue;
}
