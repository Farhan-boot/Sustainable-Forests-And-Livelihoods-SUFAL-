using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class RepaymentLDFOutstandingLoanPerBorrowerVM
{
    public long ForestFcvVcfId { get; set; }
    public string? ForestFcvVcfName { get; set; }
    public string? ForestFcvVcfNameBn { get; set; }

    public double TotalExpectedRepayment { get; set; }
    public double TotalActualRepayment { get; set; }
    public double TotalBorrower { get; set; }

    public double Result { get; set; }

    public int? Year { get; set; }
    public Months? Month { get; set; }
}

