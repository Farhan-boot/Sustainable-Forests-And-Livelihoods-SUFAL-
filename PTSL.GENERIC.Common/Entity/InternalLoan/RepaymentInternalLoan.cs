using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class RepaymentInternalLoan : BaseEntity
{
    public long? InternalLoanInformationId { get; set; }
    public InternalLoanInformation? InternalLoanInformations { get; set; }
    public decimal? RepaymentAmount{ get; set; }
    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int? RepaymentSerial { get; set; }
    public bool? IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool? IsPaymentCompletedLate { get; set; }
    public bool? IsLocked { get; set; }
}
