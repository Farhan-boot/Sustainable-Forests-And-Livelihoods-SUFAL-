using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class BFDAssociationHouseholdMembersMapVM : BaseModel
    {
        public long BFDAssociationId { get; set; }
        [SwaggerExclude]
        public BFDAssociationVM? BFDAssociation { get; set; }

        public long HouseholdMemberId { get; set; }
        [SwaggerExclude]
        public HouseholdMemberVM? HouseholdMember { get; set; }
    }
}
