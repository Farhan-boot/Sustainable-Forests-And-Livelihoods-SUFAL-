using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class CommunityTrainingFile : BaseEntity
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long CommunityTrainingId { get; set; }
        public CommunityTraining? CommunityTraining { get; set; }
    }
}
