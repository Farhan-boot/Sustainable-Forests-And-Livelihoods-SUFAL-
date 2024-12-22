namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class BFDAssociationVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<BFDAssociationHouseholdMembersMapVM>? BFDAssociationHouseholdMembersMap { get; set; }
    }
}