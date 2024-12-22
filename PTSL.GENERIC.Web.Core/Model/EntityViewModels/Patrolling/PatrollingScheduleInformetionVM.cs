using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling
{
    public class PatrollingScheduleInformetionVM : BaseModel
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
        public long? FcvId { get; set; }

        // Civil administration
        public long? DivisionId { get; set; }
        public DivisionVM? Division { get; set; }
        public long? DistrictId { get; set; }
        public DistrictVM? District { get; set; }
        public long? UpazillaId { get; set; }
        public UpazillaVM? Upazilla { get; set; }
        public long? NgoId { get; set; }
        public NgoVM? Ngos { get; set; }
        public long? UnionId { get; set; }
        public UnionVM? Union { get; set; }

        // Other Info
        public DateTime? Date { get; set; }
        public DateTime? PatrollingDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PatrollingArea { get; set; }
        public string? AllocatedAmountMonth { get; set; }

        // File path
        public string? FilePath { get; set; }
        public string? PatrollingPlanningFile { get; set; }

        public string? Remark { get; set; }

        [Required]
        public string? PatrollingPaymentInformetionMapsJSON { get; set; }
        public List<PatrollingPaymentInformetionVM>? PatrollingPaymentInformetions { get; set; }
    }
}
