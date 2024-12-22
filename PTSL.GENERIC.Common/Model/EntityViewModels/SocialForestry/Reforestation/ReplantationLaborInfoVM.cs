using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;

public class ReplantationLaborInfoVM : BaseModel
{
    public long ReplantationId { get; set; }
    public ReplantationVM? Replantation { get; set; }

    public long LaborCostTypeId { get; set; }
    public LaborCostTypeVM? LaborCostType { get; set; }

    public DateTime LaborCostDate { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public string? Remarks { get; set; }
    public string? Attachment { get; set; }
}
