namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;

public class RepaymentInternalLoanVM : BaseModel
{
    public long? InternalLoanInformationId { get; set; }
    public InternalLoanInformationVM? InternalLoanInformations { get; set; }

    public decimal? RepaymentAmount { get; set; }
    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int? RepaymentSerial { get; set; }
    public bool? IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool? IsPaymentCompletedLate { get; set; }
    public bool? IsLocked { get; set; }
}
