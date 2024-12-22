using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingVM : BaseModel
    {
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
        public long UnionId { get; set; }
      
        public UnionVM? Union { get; set; }
        //New
        public long? NgoId { get; set; }
     
        public NgoVM? Ngos { get; set; }

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
     
        public List<PatrollingSchedulingParticipentsMapVM>? PatrollingSchedulingParticipentsMaps { get; set; }

        public List<PatrollingSchedulingFileVM>? PatrollingSchedulingFiles = new List<PatrollingSchedulingFileVM>();

        [Required]
        public string PatrollingSchedulingParticipentsMapsJSON { get; set; }

    }
}
