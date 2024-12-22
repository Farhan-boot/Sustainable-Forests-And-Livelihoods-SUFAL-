using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
    public class MeetingVM : BaseModel
	{
        public string? MeetingTitle { get; set; }
        public string? Venue { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long MeetingTypeId { get; set; }

        [SwaggerExclude]
        public MeetingTypeVM? MeetingType { get; set; }

        // Forest administration
        public long ForestCircleId { get; set; }
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }
        public long? NgoId { get; set; }
        public NgoVM? Ngo { get; set; }

        public long? FinancialYearId { get; set; }
        public FinancialYearVM? FinancialYear { get; set; }

        public int TotalMembers { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<MeetingParticipantsMapVM>? MeetingParticipantsMaps { get; set; }
        public List<MeetingFileVM>? MeetingFiles { get; set; }
	}
}
