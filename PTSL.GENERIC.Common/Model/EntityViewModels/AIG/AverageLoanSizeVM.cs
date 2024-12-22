using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

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

public class AverageLoanSizeResult
{
    public long AIGBasicInformationId { get; set; }
    public long ForestFcvVcfId { get; set; }
    public string? ForestFcvVcfName { get; set; }
    public string? ForestFcvVcfNameBn { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }
}
