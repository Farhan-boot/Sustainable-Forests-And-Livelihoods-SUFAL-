using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum.AIG;

namespace PTSL.GENERIC.Common.Entity.AIG;

public class RepaymentLDFHistory : BaseEntity
{
    public long RepaymentLDFId { get; set; }
    public RepaymentLDF? RepaymentLDF { get; set; }

    public long EventUserId { get; set; }
    public User? EventUser { get; set; }

    public DateTime EventOccurredDate { get; set; }
    public string? EventMessage { get; set; }

    public RepaymentLDFEventType RepaymentLDFEventType { get; set; }
}
