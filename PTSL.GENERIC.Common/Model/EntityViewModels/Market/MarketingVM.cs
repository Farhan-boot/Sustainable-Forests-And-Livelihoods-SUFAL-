using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class MarketingVM : BaseModel
    {
        public string? MarketingName { get; set; }
        public string? MarketingNameBn { get; set; }
        public long? DistrictId { get; set; }
        [SwaggerExclude]
        public District? District { get; set; }
        public long? DivisionId { get; set; }
        [SwaggerExclude]
        public Division? Division { get; set; }
    }
}