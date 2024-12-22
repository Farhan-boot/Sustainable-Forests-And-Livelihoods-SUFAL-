using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;

namespace PTSL.GENERIC.Common.Entity.Students
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? RollNumber { get; set; }
        public string? AccountNumber { get; set; }
        public long? Batch { get; set; }
        public long? Semester { get; set; }
    }
}