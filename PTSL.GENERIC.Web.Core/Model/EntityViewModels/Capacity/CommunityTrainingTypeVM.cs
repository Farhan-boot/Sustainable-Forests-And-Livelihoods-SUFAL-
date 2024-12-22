namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<CommunityTrainingVM>? CommunityTrainings { get; set; }
    }
}
