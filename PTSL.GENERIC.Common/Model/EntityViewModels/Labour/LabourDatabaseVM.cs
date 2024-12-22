using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Labour
{
    public class LabourDatabaseVM : BaseModel
    {
        // Forest administration
        public long? ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }

        public long? SurveyId { get; set; }
        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
        public long? OtherLabourMemberId { get; set; }
        [SwaggerExclude]
        public OtherLabourMemberVM? OtherLabourMember { get; set; }

        public string? CodeNo { get; set; }

        [SwaggerExclude]
        public List<LabourDatabaseFileVM>? LabourDatabaseFiles { get; set; } = new List<LabourDatabaseFileVM>();
        [SwaggerExclude]
        public List<LabourWorkVM>? LabourWorks { get; set; }

        //Add New Field
        public string? Address { get; set; }

    }
}

