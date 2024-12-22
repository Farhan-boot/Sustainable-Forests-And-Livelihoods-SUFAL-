using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class AverageLoanSizeVM
{
    public long ForestFcvVcfId { get; set; }
    public string? ForestFcvVcfName { get; set; }
    public string? ForestFcvVcfNameBn { get; set; }

    public double TotalLoanDisbursementAmount { get; set; }
    public double TotalLoanDisbursement { get; set; }

    public double Result => Math.Round(TotalLoanDisbursementAmount / TotalLoanDisbursement, 2);

    public int? Year { get; set; }
    public Months? Month { get; set; }
}

