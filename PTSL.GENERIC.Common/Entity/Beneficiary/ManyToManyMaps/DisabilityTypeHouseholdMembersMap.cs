using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class DisabilityTypeHouseholdMembersMap : BaseEntity
    {
        public long DisabilityTypeId { get; set; }
        public DisabilityType? DisabilityType { get; set; }

        public long HouseholdMemberId { get; set; }
        public HouseholdMember? HouseholdMember { get; set; }
    }
}
