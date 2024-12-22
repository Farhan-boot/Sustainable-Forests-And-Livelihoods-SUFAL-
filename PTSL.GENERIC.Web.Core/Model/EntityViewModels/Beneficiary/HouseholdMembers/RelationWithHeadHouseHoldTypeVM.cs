namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class RelationWithHeadHouseHoldTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<HouseholdMemberVM>? HouseholdMembers { get; set; }
    }
}