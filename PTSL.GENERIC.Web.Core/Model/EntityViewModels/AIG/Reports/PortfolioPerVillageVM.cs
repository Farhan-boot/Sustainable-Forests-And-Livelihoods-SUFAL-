namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;

public class PortfolioPerVillageVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public double TotalOutstandingLoanTk { get; set; }
    public long NoOfTotalVillage { get; set; }
    public double TotalPayableAmountTk { get; set; }
    public double AlreadyPayAmountTk { get; set; }
    public double PortfolioPerVillage { get; set; }
}
