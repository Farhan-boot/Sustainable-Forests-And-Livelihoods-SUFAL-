using System;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Common.Entity.SocialForestry;

public class InspectionDetails : BaseEntity
{
    public string OfficialName { get; set; } = string.Empty;
    public long SocialForestryDesignationId { get; set; }
    public SocialForestryDesignation? SocialForestryDesignation { get; set; }

    public DateTime InspectionDate { get; set; }
    public string? Comments { get; set; } = string.Empty;
    public string? InspectionFile { get; set; } = string.Empty;

    public List<InspectionDetailsMap> InspectionDetailsMap { get; set; } = new List<InspectionDetailsMap>();
    public List<ReplantationInspectionMap>? ReplantationInspectionMaps { get; set; }
}
