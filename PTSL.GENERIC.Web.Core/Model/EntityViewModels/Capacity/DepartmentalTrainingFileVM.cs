using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class DepartmentalTrainingFileVM : BaseModel    {
        public string FileName { get; set; }
        public string FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTrainingVM? DepartmentalTraining { get; set; }
    }
}
