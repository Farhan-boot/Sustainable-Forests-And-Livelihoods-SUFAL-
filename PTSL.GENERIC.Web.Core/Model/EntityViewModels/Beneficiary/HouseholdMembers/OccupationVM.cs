namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class OccupationVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<HouseholdMemberVM>? HouseholdMembersMain { get; set; }
    public List<HouseholdMemberVM>? HouseholdMembersSecondary { get; set; }
}