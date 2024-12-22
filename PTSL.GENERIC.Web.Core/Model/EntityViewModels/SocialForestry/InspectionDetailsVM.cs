using System.ComponentModel.DataAnnotations;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class InspectionDetailsVM : BaseModel
{
    public long NewRaisedPlantationId { get; set; }

    public string OfficialName { get; set; } = string.Empty;
    public long SocialForestryDesignationId { get; set; }
    public SocialForestryDesignationVM? SocialForestryDesignation { get; set; }

    public DateTime InspectionDate { get; set; }
    public string? Comments { get; set; } = string.Empty;
    public string? InspectionFile { get; set; }

    public int Index { get; set; }
    public IFormFile? InspectionFormFile { get; set; }

    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }
}
