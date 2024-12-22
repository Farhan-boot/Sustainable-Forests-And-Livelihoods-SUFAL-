using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity
{
    public class CommunityTrainingFileVM : BaseModel
    {
        public string FileName { get; set; }
        public string FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long CommunityTrainingId { get; set; }
        public CommunityTrainingVM? CommunityTraining { get; set; }
    }
}
