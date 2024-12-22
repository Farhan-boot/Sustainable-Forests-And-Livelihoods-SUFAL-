using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.Labour
{
    public class LabourDatabase : BaseEntity
    {
        // Forest administration
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

        public long? SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public long? OtherLabourMemberId { get; set; }
        public OtherLabourMember? OtherLabourMember { get; set; }
        public string? CodeNo { get; set; }
        public List<LabourDatabaseFile>? LabourDatabaseFiles { get; set; }
        public List<LabourWork>? LabourWorks { get; set; }

        //Add New Field
        public string? Address { get; set; }
    }
}
