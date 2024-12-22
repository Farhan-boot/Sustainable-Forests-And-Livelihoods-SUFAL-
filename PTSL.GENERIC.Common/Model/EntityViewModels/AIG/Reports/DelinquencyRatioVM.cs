using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;

public class DelinquencyRatioVM
{
    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }

    public double OverTimePaymentTk { get; set; }
    public double DuePaymentTk { get; set; }
    public double TotalPayableAmountTk { get; set; }
    public double AlreadyPayAmountTk { get; set; }

    public double DelinquencyRatio
    {
        get
        {
            var result = Math.Round(((OverTimePaymentTk - DuePaymentTk) / (TotalPayableAmountTk- AlreadyPayAmountTk)) * 100, 2);
            if (double.IsNaN(result))
            {
                result = 0;
            }
            return result <= 0 ? 0 : result;
        }
    }
}

public class DelinquencyRatioHelper
{
    public long AIGBasicInformationId { get; set; }
    public long SurveyId { get; set; }

    public long ForestCircleId { get; set; }
    public long ForestDivisionId { get; set; }
    public long ForestRangeId { get; set; }
    public long ForestBeatId { get; set; }
    public long ForestFcvVcfId { get; set; }

    public string? ForestCircle { get; set; }
    public string? ForestDivision { get; set; }
    public string? ForestRange { get; set; }
    public string? ForestBeat { get; set; }
    public string? ForestFcvVcf { get; set; }
    public bool? ForestFcvVcfIsFcv { get; set; }
    public double DelinquencyRatio { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }
    public double TotalRepaymentAmount => FirstSixtyPercentRepaymentAmount + SecondFortyPercentRepaymentAmount;

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool IsPaymentCompleted { get; set; }

    public bool IsAdvance { get; set; }
}
