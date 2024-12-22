using PTSL.GENERIC.Common.Entity.CommonEntity;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Entity.Capacity
{
    public class DepartmentalTrainingTypeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<DepartmentalTrainingVM>? DepartmentalTrainings { get; set; }
    }
}
