using System;
using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;

namespace PTSL.GENERIC.Common.Entity.SocialForestryMeeting;

public class SocialForestryMeeting : BaseEntity
{
    public long? ForestCircleId { get; set; }
    public ForestCircle? ForestCircle { get; set; }
    public long? ForestDivisionId { get; set; }
    public ForestDivision? ForestDivision { get; set; }
    public long? ForestRangeId { get; set; }
    public ForestRange? ForestRange { get; set; }
    public long? ForestBeatId { get; set; }
    public ForestBeat? ForestBeat { get; set; }
    public long? DivisionId { get; set; }
    public Division? Division { get; set; }
    public long? DistrictId { get; set; }
    public District? District { get; set; }
    public long? UpazillaId { get; set; }
    public Upazilla? Upazilla { get; set; }
    public long? UnionId { get; set; }
    public Union? Union { get; set; }
    //Add New
    public long? NgoId { get; set; }
    public Ngo? Ngo { get; set; }

    public string? MeetingTitle { get; set; }
    public string? MeetingTitleBn { get; set; }
    public string? Venue { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime MeetingDate { get; set; }
    public string? MeetingOrganizer { get; set; }

    //ddl
    public long? MeetingTypeForSocialForestryMeetingId { get; set; }
    public MeetingTypeForSocialForestryMeeting? MeetingTypeForSocialForestryMeeting { get; set; }

    //extra
    public int TotalMembers { get; set; }
    public int TotalMale { get; set; }
    public int TotalFemale { get; set; }

    public List<SocialForestryMeetingParticipentsMap>? SocialForestryMeetingParticipentsMaps { get; set; }
    public List<SocialForestryMeetingFile>? SocialForestryMeetingFiles { get; set; }
}

