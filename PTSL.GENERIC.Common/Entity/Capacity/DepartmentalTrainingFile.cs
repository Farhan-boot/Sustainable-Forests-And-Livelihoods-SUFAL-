using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingFile : BaseEntity
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long DepartmentalTrainingId { get; set; }
        public DepartmentalTraining? DepartmentalTraining { get; set; }
    }
}
