using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingParticipentsMap : BaseEntity
    {
        public long DepartmentalTrainingMemberId { get; set; }
        public DepartmentalTrainingMember? DepartmentalTrainingMember { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTraining? DepartmentalTraining { get; set; }
    }
}
