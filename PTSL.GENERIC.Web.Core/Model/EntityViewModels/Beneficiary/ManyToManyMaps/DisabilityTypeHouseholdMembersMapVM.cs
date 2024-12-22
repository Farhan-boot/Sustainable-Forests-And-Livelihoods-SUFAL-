namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class DisabilityTypeHouseholdMembersMapVM : BaseModel
    {
        public long DisabilityTypeId { get; set; }
        public DisabilityTypeVM? DisabilityType { get; set; }

        public long HouseholdMemberId { get; set; }
        public HouseholdMemberVM? HouseholdMember { get; set; }
    }
}
