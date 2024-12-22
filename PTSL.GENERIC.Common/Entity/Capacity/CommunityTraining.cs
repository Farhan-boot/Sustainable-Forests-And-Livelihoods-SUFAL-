using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class CommunityTraining : BaseEntity
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

        //
        public long EventTypeId { get; set; }
        public EventType? EventType { get; set; }
        public long? CommunityTrainingTypeId { get; set; }
        public CommunityTrainingType? CommunityTrainingType { get; set; }
        public long? TrainingOrganizerId { get; set; }
        public TrainingOrganizer? TrainingOrganizer { get; set; }

        public int TotalParticipants { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<CommunityTrainingParticipentsMap>? CommunityTrainingParticipentsMaps { get; set; }
        public List<CommunityTrainingFile>? CommunityTrainingFiles { get; set; }
    }
}
