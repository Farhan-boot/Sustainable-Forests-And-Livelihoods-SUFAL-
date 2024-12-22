using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Patrolling
{
    public class PatrollingScheduleInformetion : BaseEntity
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
        public long? FcvId { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public Division? Division { get; set; }
        public long? DistrictId { get; set; }
        public District? District { get; set; }
        public long? UpazillaId { get; set; }
        public Upazilla? Upazilla { get; set; }
        public long? NgoId { get; set; }
        public Ngo? Ngos { get; set; }
        public long? UnionId { get; set; }
        public Union? Union { get; set; }

        // Other Info
        public DateTime? Date { get; set; }
        public DateTime? PatrollingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PatrollingArea { get; set; }
        public string? AllocatedAmountMonth { get; set; }

        // Files
        public string? FilePath { get; set; }
        public string? PatrollingPlanningFile { get; set; }

        public string? Remark { get; set; }
        public List<PatrollingPaymentInformetion>? PatrollingPaymentInformetions { get; set; }
    }
}
