using System;

using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum.AIG;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.AIG;

public class RepaymentLDFHistoryVM : BaseModel
{
    public long RepaymentLDFId { get; set; }
    public RepaymentLDFVM? RepaymentLDF { get; set; }

    public long EventUserId { get; set; }
    public UserVM? EventUser { get; set; }

    public DateTime EventOccurredDate { get; set; }
    public string? EventMessage { get; set; }

    public RepaymentLDFEventType RepaymentLDFEventType { get; set; }
    public string? RepaymentLDFEventTypeString { get; set; }
}
