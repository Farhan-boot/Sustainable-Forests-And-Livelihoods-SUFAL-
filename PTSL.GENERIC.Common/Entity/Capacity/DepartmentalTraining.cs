using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTraining : BaseEntity
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
        public FinancialYear? FinancialYear { get; set; }

        public long EventTypeId { get; set; }
        public EventType? EventType { get; set; }
        public long? DepartmentalTrainingTypeId { get; set; }
        public DepartmentalTrainingType? DepartmentalTrainingType { get; set; }
        public long TrainingOrganizerId { get; set; }
        public TrainingOrganizer? TrainingOrganizer { get; set; }
        public List<DepartmentalTrainingParticipentsMap>? DepartmentalTrainingParticipentsMaps { get; set; }
        public List<DepartmentalTrainingFile>? DepartmentalTrainingFiles { get; set; }
    }
}
