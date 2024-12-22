using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationCostInfo : BaseEntity
{
    public long ReplantationId { get; set; }
    public Replantation? Replantation { get; set; }

    public long CostTypeId { get; set; }
    public CostType? CostType { get; set; }

    public DateTime CostDate { get; set; }
    public double CostAmount { get; set; }
    public string? Remarks { get; set; }
}
