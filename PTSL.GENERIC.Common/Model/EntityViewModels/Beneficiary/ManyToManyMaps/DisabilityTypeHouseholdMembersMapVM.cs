using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class DisabilityTypeHouseholdMembersMapVM : BaseModel
    {
        public long DisabilityTypeId { get; set; }
        [SwaggerExclude]
        public DisabilityTypeVM? DisabilityType { get; set; }

        public long HouseholdMemberId { get; set; }
        [SwaggerExclude]
        public HouseholdMemberVM? HouseholdMember { get; set; }
    }
}
