using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDFVM : BaseModel
{
    public long? FirstSixtyPercentageLDFId { get; set; }
    [SwaggerExclude]
    public FirstSixtyPercentageLDFVM? FirstSixtyPercentageLDF { get; set; }
    public long? SecondFourtyPercentageLDFId { get; set; }
    [SwaggerExclude]
    public SecondFourtyPercentageLDFVM? SecondFourtyPercentageLDF { get; set; }
    public long AIGBasicInformationId { get; set; }
    [SwaggerExclude]
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }

    public double FirstSixtyPercentRepaymentAmountReceived { get; set; }
    public double SecondFortyPercentRepaymentAmountReceived { get; set; }
    public double TotalRepaymentAmountReceived => FirstSixtyPercentRepaymentAmountReceived + SecondFortyPercentRepaymentAmountReceived;

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public bool IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool IsPaymentCompletedLate { get; set; }
    public bool IsLocked { get; set; }

    [SwaggerExclude]
    public LDFProgressVM? LDFProgress { get; set; }
    [SwaggerExclude]
    public List<RepaymentLDFHistoryVM>? RepaymentLDFHistories { get; set; }

    // Computed
    public double RepaymentAmount { get; set; } // FirstSixtyPercentRepaymentAmount + SecondFortyPercentRepaymentAmount
    public bool IsPast { get; set; }
    public bool IsFuture { get; set; }
    public bool IsCurrent { get; set; }
    public string PastFutureCurrentInString => IsPast ? "Past" : IsFuture ? "Upcoming" : "Current";
}
