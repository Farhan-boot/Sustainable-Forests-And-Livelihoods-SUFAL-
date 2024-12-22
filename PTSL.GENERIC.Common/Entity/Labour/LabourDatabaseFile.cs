using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Common.Entity.Labour
{
    public class LabourDatabaseFile : BaseEntity
    {
        public long LabourDatabaseId { get; set; }
        public LabourDatabase? LabourDatabase { get; set; }
        public FileType FileType { get; set; }

        public string? FileName { get; set; }
        public string? FileUrl { get; set; }
    }
}
