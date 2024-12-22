namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class PlantationDamageInformationVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }
    public NewRaisedPlantationVM? NewRaisedPlantation { get; set; }
    public int Index { get; set; }

    public DateTime DateOfOccurrence { get; set; }
    public long PlantationCauseOfDamageId { get; set; }
    public PlantationCauseOfDamageVM? PlantationCauseOfDamage { get; set; }
    public string? DamageDescription { get; set; }
    public bool InspectedByAuthority { get; set; }
    public string? DamageUrl { get; set; }
    public string? InspectionReportUrl { get; set; }
    public string? ActionTaken { get; set; }

    public IFormFile? DamageFormFile { get; set; }
    public IFormFile? InspectionFormFile { get; set; }
}
