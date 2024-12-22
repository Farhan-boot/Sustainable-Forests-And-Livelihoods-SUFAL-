using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingFileVM : BaseModel
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTrainingVM? DepartmentalTraining { get; set; }
    }
}
