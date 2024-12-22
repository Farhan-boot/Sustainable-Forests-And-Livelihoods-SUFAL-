namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class DisabilityTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<DisabilityTypeHouseholdMembersMapVM>? DisabilityTypeHouseholdMembersMap { get; set; }
}