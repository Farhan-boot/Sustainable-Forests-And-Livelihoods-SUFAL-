using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

public class RepaymentLDFVM : BaseModel
{
    public long? FirstSixtyPercentageLDFId { get; set; }
    public FirstSixtyPercentageLDFVM? FirstSixtyPercentageLDF { get; set; }
    public long? SecondFourtyPercentageLDFId { get; set; }
    public SecondFourtyPercentageLDFVM? SecondFourtyPercentageLDF { get; set; }
    public long AIGBasicInformationId { get; set; }
    public AIGBasicInformationVM? AIGBasicInformation { get; set; }

    public double FirstSixtyPercentRepaymentAmount { get; set; }
    public double SecondFortyPercentRepaymentAmount { get; set; }

    public double FirstSixtyPercentRepaymentAmountReceived { get; set; }
    public double SecondFortyPercentRepaymentAmountReceived { get; set; }
    public double TotalRepaymentAmountReceived { get; set; }

    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int RepaymentSerial { get; set; }

    public bool IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool IsPaymentCompletedLate { get; set; }
    public bool IsLocked { get; set; }

    public LDFProgressVM? LDFProgress { get; set; }
    public List<RepaymentLDFHistoryVM>? RepaymentLDFHistories { get; set; }

    // Computed
    public double RepaymentAmount { get; set; } // FirstSixtyPercentRepaymentAmount + SecondFortyPercentRepaymentAmount
    public bool IsPast { get; set; }
    public bool IsFuture { get; set; }
    public bool IsCurrent { get; set; }
    public string? PastFutureCurrentInString { get; set; }
}
