using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingFile : BaseEntity
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long PatrollingSchedulingId { get; set; }
        public PatrollingScheduling? PatrollingScheduling { get; set; }
    }
}
