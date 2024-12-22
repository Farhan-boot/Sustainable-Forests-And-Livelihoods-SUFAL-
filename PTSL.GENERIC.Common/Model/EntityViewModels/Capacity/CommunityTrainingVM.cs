using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;

using System;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity
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
        [SwaggerExclude]
        public ForestCircleVM? ForestCircle { get; set; }
        public long ForestDivisionId { get; set; }
        [SwaggerExclude]
        public ForestDivisionVM? ForestDivision { get; set; }
        public long ForestRangeId { get; set; }
        [SwaggerExclude]
        public ForestRangeVM? ForestRange { get; set; }
        public long ForestBeatId { get; set; }
        [SwaggerExclude]
        public ForestBeatVM? ForestBeat { get; set; }
        public long ForestFcvVcfId { get; set; }
        [SwaggerExclude]
        public ForestFcvVcfVM? ForestFcvVcf { get; set; }

        // Civil administration
        public long DivisionId { get; set; }
        [SwaggerExclude]
        public DivisionVM? Division { get; set; }
        public long DistrictId { get; set; }
        [SwaggerExclude]
        public DistrictVM? District { get; set; }
        public long UpazillaId { get; set; }
        [SwaggerExclude]
        public UpazillaVM? Upazilla { get; set; }
        public long? UnionId { get; set; }
        [SwaggerExclude]
        public UnionVM? Union { get; set; }

        public long EventTypeId { get; set; }
        [SwaggerExclude]
        public EventTypeVM? EventType { get; set; }
        public long? CommunityTrainingTypeId { get; set; }
        [SwaggerExclude]
        public CommunityTrainingTypeVM? CommunityTrainingType { get; set; }
        public long? TrainingOrganizerId { get; set; }
        [SwaggerExclude] public TrainingOrganizerVM? TrainingOrganizer { get; set; }

        public int TotalParticipants { get; set; }
        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }

        public List<CommunityTrainingParticipentsMapVM>? CommunityTrainingParticipentsMaps { get; set; }
        public List<CommunityTrainingFileVM>? CommunityTrainingFiles { get; set; }
    }
}
