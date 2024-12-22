using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class BFDAssociationHouseholdMembersMap : BaseEntity
    {
        public long BFDAssociationId { get; set; }
        public BFDAssociation? BFDAssociation { get; set; }

        public long HouseholdMemberId { get; set; }
        public HouseholdMember? HouseholdMember { get; set; }
    }
}
