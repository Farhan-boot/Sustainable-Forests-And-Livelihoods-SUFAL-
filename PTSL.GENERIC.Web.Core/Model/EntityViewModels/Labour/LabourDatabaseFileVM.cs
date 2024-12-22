
using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour
{
    public class LabourDatabaseFileVM : BaseModel
    {
        public long LabourDatabaseId { get; set; }
        public LabourDatabaseVM? LabourDatabase { get; set; }
        public FileType FileType { get; set; }

        public string? FileName { get; set; }
        public string? FileUrl { get; set; }
    }
}
