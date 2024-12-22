using System;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

public class MeetingFilterVM : ForestCivilLocationFilter
{
    public long? NgoId { get; set; }
    public DateTime? MeetingDate { get; set; }
    public long? MeetingTypeId { get; set; }

    public bool HasNgoId => NgoId.HasValue && NgoId.Value > 0;
    public bool HasMeetingDate => MeetingDate.HasValue;
    public bool HasMeetingTypeId => MeetingTypeId.HasValue && MeetingTypeId.Value > 0;
}

