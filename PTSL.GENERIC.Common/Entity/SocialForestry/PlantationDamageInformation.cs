using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class PlantationDamageInformation : BaseEntity
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantation? NewRaisedPlantation { get; set; }

    public DateTime DateOfOccurrence { get; set; }
    public long PlantationCauseOfDamageId { get; set; }
    public PlantationCauseOfDamage? PlantationCauseOfDamage { get; set; }
    public string? DamageDescription { get; set; }
    public bool InspectedByAuthority { get; set; }
    public string? DamageUrl { get; set; }
    public string? InspectionReportUrl { get; set; }
    public string? ActionTaken { get; set; }
}
