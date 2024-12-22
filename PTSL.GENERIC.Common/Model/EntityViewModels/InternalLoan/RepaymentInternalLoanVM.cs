using System;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.InternalLoan;

public class RepaymentInternalLoanVM : BaseModel
{
    public long? InternalLoanInformationId { get; set; }
    [SwaggerExclude]
    public InternalLoanInformation? InternalLoanInformations { get; set; }

    public decimal? RepaymentAmount { get; set; }
    public DateTime RepaymentStartDate { get; set; }
    public DateTime RepaymentEndDate { get; set; }
    public int? RepaymentSerial { get; set; }
    public bool? IsPaymentCompleted { get; set; }
    public DateTime? PaymentCompletedDateTime { get; set; }
    public bool? IsPaymentCompletedLate { get; set; }
    public bool? IsLocked { get; set; }
}
