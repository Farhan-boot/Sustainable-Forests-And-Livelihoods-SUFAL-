using System.Collections.Generic;

using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class NgoVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        public List<long>? ForestCircleIdList { get; set; }
        public List<long>? ForestDivisionIdList { get; set; }
        [SwaggerExclude]
        public List<ForestCircleVM>? ForestCircles { get; set; }
        [SwaggerExclude]
        public List<ForestDivisionVM>? ForestDivisions { get; set; }
    }
}