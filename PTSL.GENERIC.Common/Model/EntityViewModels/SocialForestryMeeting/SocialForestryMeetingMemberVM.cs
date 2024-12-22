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
   public class SocialForestryMeetingMemberVM : BaseModel
    {
        public string MemberName { get; set; } = string.Empty;
        public Gender MemberGender { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public string? MemberNID { get; set; }
        public string? MemberDesignation { get; set; }
        public string? MemberOrganization { get; set; }

        public long? EthnicityId { get; set; }
        public EthnicityVM? Ethnicity { get; set; }

        public string? MemberAddress { get; set; }

        public long? PlantationId { get; set; }
        public string? PlantationName { get; set; }

        public List<SocialForestryMeetingParticipentsMapVM>? SocialForestryTrainingParticipentsMaps { get; set; }
    }
}
