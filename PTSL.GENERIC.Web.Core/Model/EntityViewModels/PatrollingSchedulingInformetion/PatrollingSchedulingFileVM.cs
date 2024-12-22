using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingFileVM : BaseModel
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long PatrollingSchedulingId { get; set; }
        public PatrollingSchedulingVM? PatrollingScheduling { get; set; }
    }
}
