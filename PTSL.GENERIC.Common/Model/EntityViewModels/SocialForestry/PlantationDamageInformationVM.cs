using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class PlantationDamageInformationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }

    public DateTime DateOfOccurrence { get; set; }
    public long PlantationCauseOfDamageId { get; set; }
    public PlantationCauseOfDamageVM? PlantationCauseOfDamage { get; set; }
    public string? DamageDescription { get; set; }
    public bool InspectedByAuthority { get; set; }
    public string? DamageUrl { get; set; }
    public string? InspectionReportUrl { get; set; }
    public string? ActionTaken { get; set; }
}
