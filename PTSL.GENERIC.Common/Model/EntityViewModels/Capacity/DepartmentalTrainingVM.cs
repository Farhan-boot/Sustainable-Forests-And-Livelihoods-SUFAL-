using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingVM : BaseModel
    {
        public string? TrainingTitle { get; set; }
        public string? TrainingTitleBn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TrainingDuration { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? LocationBn { get; set; }
        public string? TrainerName { get; set; }

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
        public List<DepartmentalTrainingFileVM>? DepartmentalTrainingFiles { get; set; }
    }
}
