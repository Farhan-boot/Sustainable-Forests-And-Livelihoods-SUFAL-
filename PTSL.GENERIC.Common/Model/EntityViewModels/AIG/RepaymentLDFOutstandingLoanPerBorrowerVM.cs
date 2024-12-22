using System;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDFOutstandingLoanPerBorrowerVM
{
    public long ForestFcvVcfId { get; set; }
    public string? ForestFcvVcfName { get; set; }
    public string? ForestFcvVcfNameBn { get; set; }

    public double TotalExpectedRepayment { get; set; }
    public double TotalActualRepayment { get; set; }
    public double TotalBorrower { get; set; }

    public double Result => Math.Round((TotalExpectedRepayment - TotalActualRepayment) / TotalBorrower, 2);

    public int? Year { get; set; }
    public Months? Month { get; set; }
}

public class RepaymentLDFOutstandingLoanPerBorrowerResult 
{
    public long ForestFcvVcfId { get; set; }
    public string? ForestFcvVcfName { get; set; }
    public string? ForestFcvVcfNameBn { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }
    public double TotalRepaymentAmount => FirstSixtyPercentRepaymentAmount + SecondFortyPercentRepaymentAmount;

    public DateTime RepaymentEndDate { get; set; }

    public bool IsPaymentCompleted { get; set; }
}
