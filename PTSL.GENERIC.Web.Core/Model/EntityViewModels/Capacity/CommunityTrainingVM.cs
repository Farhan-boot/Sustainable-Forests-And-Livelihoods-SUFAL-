using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingVM : BaseModel
    {
        public string? TrainingTitle { get; set; }
        public string? TrainingTitleBn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TrainingDuration { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? LocationBn { get; set; }
        public string? TrainerName { get; set; }

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

        public long EventTypeId { get; set; }
        public EventTypeVM? EventType { get; set; }
        public long? CommunityTrainingTypeId { get; set; }
        public CommunityTrainingTypeVM? CommunityTrainingType { get; set; }
        public long? TrainingOrganizerId { get; set; }
        public TrainingOrganizerVM? TrainingOrganizer { get; set; }
        public List<CommunityTrainingParticipentsMapVM>? CommunityTrainingParticipentsMaps { get; set; }

        public int TotalParticipants { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        [Required]
        public string CommunityTrainingParticipentsMapsJSON { get; set; } = string.Empty;
        public List<CommunityTrainingFileVM>? CommunityTrainingFiles { get; set; } = new List<CommunityTrainingFileVM>();
    }
}
