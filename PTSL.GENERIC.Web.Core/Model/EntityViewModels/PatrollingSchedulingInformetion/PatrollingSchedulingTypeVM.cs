namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingTypeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }
        public List<PatrollingSchedulingVM>? PatrollingSchedulings { get; set; }
    }
}
