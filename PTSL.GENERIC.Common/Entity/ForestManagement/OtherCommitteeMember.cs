using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.ForestManagement
{
    public class OtherCommitteeMember : BaseEntity
    {
        public string? FullName { get; set; }
        public string? FatherOrSpouse { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? NID { get; set; }
        public string? Address { get; set; }

        // Forest Administration
        public long? ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public Division? Division { get; set; }
        public long? DistrictId { get; set; }
        public District? District { get; set; }
        public long? UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public Union? Union { get; set; }

        public long? EthnicityId { get; set; }
        public Ethnicity? Ethnicity { get; set; }

        public List<CommitteeManagementMember>? CommitteeManagementMembers { get; set; }
        public List<CipTeamMember>? CipTeamMembers { get; set; }
    }
}
