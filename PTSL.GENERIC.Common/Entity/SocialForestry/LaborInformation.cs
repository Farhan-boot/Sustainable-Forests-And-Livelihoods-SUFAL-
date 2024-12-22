using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class LaborInformation : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public long LaborCostTypeId { get; set; }
    public LaborCostType? LaborCostType { get; set; }

    public DateTime LaborCostDate { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }
    public string? Remarks { get; set; }

    public List<LaborInformationFile>? LaborInformationFiles { get; set; }
}
