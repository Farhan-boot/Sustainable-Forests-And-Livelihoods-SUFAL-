using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class EnergyTypeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        [SwaggerExclude]
        public List<EnergyUseVM>? EnergyUses { get; set; }
    }
}