namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class NaturalIncomeSourceTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<NaturalResourcesIncomeAndCostStatusVM>? NaturalResourcesIncomeAndCostStatuses { get; set; }
}
