using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class AIGLoanStatusReportFilterVM : ForestCivilLocationFilter
{
    public BadLoanType? BadLoanType { get; set; }
}
