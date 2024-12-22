using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.MeetingManagement
{
	public class Meeting : BaseEntity
	{
        public string? MeetingTitle { get; set; }
        public string? Venue { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long MeetingTypeId { get; set; }
        public MeetingType? MeetingType { get; set; }

        // Forest administration
        public long ForestCircleId { get; set; }
        public ForestCircle? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        public ForestDivision? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        public ForestRange? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        public ForestBeat? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        public ForestFcvVcf? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        public Division? Division { get; set; }
        public long DistrictId { get; set; }
        public District? District { get; set; }
        public long UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }
        public long? UnionId { get; set; }
        public Union? Union { get; set; }

        public long? NgoId { get; set; }
        public Ngo? Ngo { get; set; }

        public long? FinancialYearId { get; set; }
        public FinancialYear? FinancialYear { get; set; }

        public int TotalMembers { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<MeetingParticipantsMap>? MeetingParticipantsMaps { get; set; }
        public List<MeetingFile>? MeetingFiles { get; set; }
	}
}
