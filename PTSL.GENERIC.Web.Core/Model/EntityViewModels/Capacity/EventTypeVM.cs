namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class EventTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }
        public bool HasTrainingType { get; set; }

        public List<CommunityTrainingVM>? CommunityTrainings { get; set; }
    }
}
