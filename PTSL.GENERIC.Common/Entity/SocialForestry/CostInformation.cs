using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class CostInformation : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }
    public long CostTypeId { get; set; }
    public CostType? CostType { get; set; }
    public DateTime CostDate { get; set; }
    public double CostAmount { get; set; }
    public string Remarks { get; set; } = string.Empty;
    public List<CostInformationFile>? CostInformationFiles { get; set; }
}
