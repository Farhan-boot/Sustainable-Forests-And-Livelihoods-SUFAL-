using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

public class ReplantationLaborInfo : BaseEntity
{
    public long ReplantationId { get; set; }
    public Replantation? Replantation { get; set; }

    public long LaborCostTypeId { get; set; }
    public LaborCostType? LaborCostType { get; set; }

    public DateTime LaborCostDate { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public string? Remarks { get; set; }
    public string? Attachment { get; set; }
}
