using PTSL.GENERIC.Common.Entity.CommonEntity;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class TrainingOrganizer : BaseEntity
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<CommunityTraining>? CommunityTrainings { get; set; }
        public List<DepartmentalTraining>? DepartmentalTrainings { get; set; }
    }
}
