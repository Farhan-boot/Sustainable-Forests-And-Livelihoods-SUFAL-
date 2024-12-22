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
   public class SocialForestryMeetingParticipentsMapVM : BaseModel
    {
        public long SocialForestryMeetingMemberId { get; set; }
        public SocialForestryMeetingMemberVM? SocialForestryMeetingMember { get; set; }

        public long SocialForestryMeetingId { get; set; }
        public SocialForestryMeetingVM? SocialForestryMeeting { get; set; }
    }
}
