using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Helper;

using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Ethnicity : BaseEntity
    {
        public List<SocialForestryMeetingMember>? SocialForestryMeetingMember { get; set; }
        public List<SocialForestryTrainingMember>? SocialForestryTrainingMember { get; set; }
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<Cip>? Cips { get; set; }
        public List<Survey>? Surveys { get; set; }
        public List<DepartmentalTrainingMember>? DepartmentalTrainingMember { get; set; }
        public List<OtherCommitteeMember>? OtherCommitteeMembers { get; set; }

        public List<OtherLabourMember>? OtherLabourMembers { get; set; }
        public List<LabourDatabase>? LabourDatabases { get; set; }

        [SwaggerExclude]
        public List<OtherPatrollingMember>? OtherPatrollingMembers { get; set; }

    }
}