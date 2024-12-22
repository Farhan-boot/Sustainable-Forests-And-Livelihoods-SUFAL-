using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

public class PatrollingScheduleFilterVM
{
    // Forest administration
    public long? ForestCircleId { get; set; }
    public long? ForestDivisionId { get; set; }
    public long? ForestRangeId { get; set; }
    public long? ForestBeatId { get; set; }
    public long? ForestFcvVcfId { get; set; }

    // Civil administration
    public long? DivisionId { get; set; }
    public long? DistrictId { get; set; }
    public long? UpazillaId { get; set; }
}
