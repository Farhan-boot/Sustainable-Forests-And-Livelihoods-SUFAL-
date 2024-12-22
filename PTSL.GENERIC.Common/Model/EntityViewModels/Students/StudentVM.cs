using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Students
{
    public class StudentVM : BaseModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? RollNumber { get; set; }
        public string? AccountNumber { get; set; }
        public long? Batch { get; set; }
        public long? Semester { get; set; }
    }
}