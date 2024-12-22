using System;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class InspectionDetailsVM : BaseModel
{
    public string OfficialName { get; set; } = string.Empty;
    public long SocialForestryDesignationId { get; set; }
    public SocialForestryDesignationVM? SocialForestryDesignation { get; set; }

    public DateTime InspectionDate { get; set; }
    public string? Comments { get; set; } = string.Empty;
    public string? InspectionFile { get; set; }

    public List<InspectionDetailsMapVM>? InspectionDetailsMap { get; set; }
}
