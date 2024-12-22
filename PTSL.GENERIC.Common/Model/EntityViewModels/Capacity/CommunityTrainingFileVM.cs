using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingFileVM : BaseModel
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long CommunityTrainingId { get; set; }
        public CommunityTrainingVM? CommunityTraining { get; set; }
    }
}
