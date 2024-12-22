namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class DateWiseRepaymentReportVM
{
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryPhone { get; set; }
    public string? BeneficiaryNid { get; set; }

    public string? LDFCountInWord { get; set; }

    public double TotalAllocatedLoanAmount { get; set; }
    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }

    public double TotalRepaymentAmount { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public bool IsPaymentCompleted { get; set; }
}
