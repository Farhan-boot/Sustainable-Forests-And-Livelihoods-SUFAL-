using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;
using System.Collections.Generic;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class OccupationVM : BaseModel
    {
        public string? Name { get; set; }
        public string? NameBn { get; set; }

        [SwaggerExclude]
        public List<HouseholdMemberVM>? HouseholdMembersMain { get; set; }

        [SwaggerExclude]
        public List<HouseholdMemberVM>? HouseholdMembersSecondary { get; set; }
    }
}