using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingParticipentsMapVM : BaseModel
    {
        public long DepartmentalTrainingMemberId { get; set; }
        public DepartmentalTrainingMemberVM? DepartmentalTrainingMember { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTrainingVM? DepartmentalTraining { get; set; }
    }
}
