using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Labour
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
