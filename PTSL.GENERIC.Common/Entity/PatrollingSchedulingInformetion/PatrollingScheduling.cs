using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;

using System;

namespace PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion
{
    public class PatrollingScheduling : BaseEntity, IHasForestLocation
    {
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
        public long UnionId { get; set; }
        public Union? Union { get; set; }
        //New
        public long? NgoId { get; set; }
        public Ngo? Ngos { get; set; }

        // Other Info
        public long? FcvId { get; set; }
        public DateTime? Date { get; set; }
        public string? PatrollingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PatrollingArea { get; set; }
        public string? AllocatedAmountMonth { get; set; }

        public int TotalParticipants { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public string? Remark { get; set; }

        public List<PatrollingSchedulingParticipentsMap>? PatrollingSchedulingParticipentsMaps { get; set; }
        public List<PatrollingSchedulingFile>? PatrollingSchedulingFiles { get; set; }
    }
}
