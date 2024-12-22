namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class BFDAssociationHouseholdMembersMapVM : BaseModel
{
    public long BFDAssociationId { get; set; }
    public BFDAssociationVM? BFDAssociation { get; set; }

    public long HouseholdMemberId { get; set; }
    public HouseholdMemberVM? HouseholdMember { get; set; }
}
