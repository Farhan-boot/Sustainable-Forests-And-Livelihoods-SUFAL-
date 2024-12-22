using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingFileVM : BaseModel
    {
        public string? FileName { get; set; }
        public string? FileNameUrl { get; set; }
        public FileType FileType { get; set; }

        public long PatrollingSchedulingId { get; set; }
        [SwaggerExclude]
        public PatrollingSchedulingVM? PatrollingScheduling { get; set; }
    }
}
