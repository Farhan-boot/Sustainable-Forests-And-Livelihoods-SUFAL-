using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Dashboard;

public class DashboardLoanResponse
{
    public double TotalLDFLoanAmount { get; set; }
    public double TotalLDFRepaymentAmount { get; set; }

    public double TotalCDFCost { get; set; }
    public double TotalInternalSavingsAmount { get; set; }

    public double TotalInternalLoanAmount { get; set; }
    public double TotalInternalRepaymentAmount { get; set; }
}

public class DashboardLoanRequest : ForestCivilLocationFilter
{
    public int? Year { get; set; }
    public Months? Month { get; set; }
}

