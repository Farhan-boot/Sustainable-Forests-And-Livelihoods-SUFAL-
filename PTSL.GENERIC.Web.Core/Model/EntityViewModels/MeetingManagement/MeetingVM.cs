using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Entity.MeetingManagement
{
    public class MeetingVM : BaseModel
	{
        public string MeetingTitle { get; set; }
        public string Venue { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long MeetingTypeId { get; set; }
        public MeetingTypeVM? MeetingType { get; set; }

        // Forest administration
        public long ForestCircleId { get; set; }
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }
        public long? NgoId { get; set; }
        public NgoVM? Ngo { get; set; }

        public long? FinancialYearId { get; set; }
        public FinancialYearVM? FinancialYear { get; set; }

        public int TotalMembers { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<MeetingParticipantsMapVM>? MeetingParticipantsMaps { get; set; }
        public string MeetingParticipantsMapsJSON { get; set; } = string.Empty;
        public List<MeetingFileVM>? MeetingFiles { get; set; } = new List<MeetingFileVM>();

        //New add for pagination
        public string? Difference { get; set; }
        public string? DifferenceRedable { get; set; }

    }
}
