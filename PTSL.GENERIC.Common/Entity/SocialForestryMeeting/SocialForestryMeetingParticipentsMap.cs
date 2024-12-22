﻿using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.Entity.SocialForestryMeeting;

public class SocialForestryMeetingParticipentsMap : BaseEntity
{
    public long SocialForestryMeetingMemberId { get; set; }
    public SocialForestryMeetingMember? SocialForestryMeetingMember { get; set; }

    public long SocialForestryMeetingId { get; set; }
    public SocialForestryMeeting? SocialForestryMeeting { get; set; }
}

