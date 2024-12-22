namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class DepartmentalTrainingParticipentsMapVM : BaseModel
    {
        public long DepartmentalTrainingMemberId { get; set; }
        public DepartmentalTrainingMemberVM? DepartmentalTrainingMember { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTrainingVM? DepartmentalTraining { get; set; }
    }
}
