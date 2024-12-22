using System.ComponentModel.DataAnnotations;

using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class DepartmentalTrainingVM : BaseModel
    {
        [Required]
        public string TrainingTitle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string TrainingDuration { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; }

        [Required]
        public string TrainerName { get; set; }

        public int TotalMembers { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public long? FinancialYearId { get; set; }
        public FinancialYearVM? FinancialYear { get; set; }

        public long EventTypeId { get; set; }
        public EventTypeVM? EventType { get; set; }
        public long? DepartmentalTrainingTypeId { get; set; }
        public DepartmentalTrainingTypeVM? DepartmentalTrainingType { get; set; }
        public long TrainingOrganizerId { get; set; }
        public TrainingOrganizerVM? TrainingOrganizer { get; set; }
        public List<DepartmentalTrainingParticipentsMapVM>? DepartmentalTrainingParticipentsMaps { get; set; }

        [Required]
        public string? DepartmentalTrainingParticipentsMapsJSON { get; set; }
        public List<DepartmentalTrainingFileVM>? DepartmentalTrainingFiles { get; set; } = new List<DepartmentalTrainingFileVM>();
    }
}
