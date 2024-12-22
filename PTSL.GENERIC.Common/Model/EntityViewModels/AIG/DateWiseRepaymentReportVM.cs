using System;

using Humanizer;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class DateWiseRepaymentReportVM
{
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryPhone { get; set; }
    public string? BeneficiaryNid { get; set; }

    public int LDFCount { get; set; }
    public string LDFCountInWord => LDFCount.Ordinalize();

    public double TotalAllocatedLoanAmount { get; set; }
    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }

    public double TotalRepaymentAmount => FirstSixtyPercentRepaymentAmount + SecondFortyPercentRepaymentAmount;

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public bool IsPaymentCompleted { get; set; }
}
