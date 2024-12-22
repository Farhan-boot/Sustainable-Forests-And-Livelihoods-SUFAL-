using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum.ForestManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting
{
   public class SocialForestryMeetingVM : BaseModel
    {
        public long? ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long? DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }
        //Add New
        public long? NgoId { get; set; }
        public NgoVM? Ngo { get; set; }

        public string? MeetingTitle { get; set; }
        public string? MeetingTitleBn { get; set; }
        public string? Venue { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime MeetingDate { get; set; }
        public string? MeetingOrganizer { get; set; }

        //ddl
        public long? MeetingTypeForSocialForestryMeetingId { get; set; }
        public MeetingTypeForSocialForestryMeetingVM? MeetingTypeForSocialForestryMeeting { get; set; }

        //extra
        public int TotalMembers { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<SocialForestryMeetingParticipentsMapVM>? SocialForestryMeetingParticipentsMaps { get; set; }
        public List<SocialForestryMeetingFileVM>? SocialForestryMeetingFiles { get; set; }
    }
}
