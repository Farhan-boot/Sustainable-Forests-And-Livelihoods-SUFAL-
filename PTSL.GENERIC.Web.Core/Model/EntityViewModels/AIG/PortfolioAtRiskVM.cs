using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class PortfolioAtRiskVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public double OnlyDefotdatLoanAmountTk { get; set; }
    public double AfterDefolderPayAmountTk { get; set; }
    public double TotalPayableAmountTk { get; set; }
    public double AlreadyPayAmountTk { get; set; }
    public double PortfolioAtRisk { get; set; }
}

