using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class AssetTypeVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        [SwaggerExclude]
        public List<AssetVM>? Assets { get; set; }
    }
}