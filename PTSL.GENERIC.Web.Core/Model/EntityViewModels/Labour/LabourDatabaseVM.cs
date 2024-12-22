using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour
{
    public class LabourDatabaseVM : BaseModel
    {
        // Forest administration
        public long? ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long? ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long? ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long? ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long? ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }

        public long? SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
        public long? OtherLabourMemberId { get; set; }
        public OtherLabourMemberVM? OtherLabourMember { get; set; }

        public string? CodeNo { get; set; }

        public List<LabourDatabaseFileVM>? LabourDatabaseFiles { get; set; } = new List<LabourDatabaseFileVM>();
        public List<LabourWorkVM>? LabourWorks { get; set; }

        //Add New Field
        public string? Address { get; set; }


        //Pagination fild
        public string? FullName { get; set; }
        public string? GenderName { get; set; }
        public string? NIDName { get; set; }
        public string? PhoneNumberName { get; set; }
        public string? UserTypeName { get; set; }

    }
}
