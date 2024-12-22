using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;

namespace PTSL.GENERIC.Common.Entity.SocialForestryMeeting;

public class MeetingTypeForSocialForestryMeeting : BaseEntity
{
    public List<SocialForestryMeeting>? SocialForestryMeetings { get; set; }
    public string? Name { get; set; }
    public string? NameBn { get; set; }
}

