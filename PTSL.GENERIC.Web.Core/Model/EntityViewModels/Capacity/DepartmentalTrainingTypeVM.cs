namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class DepartmentalTrainingTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<DepartmentalTrainingVM>? DepartmentalTrainings { get; set; }
    }
}
