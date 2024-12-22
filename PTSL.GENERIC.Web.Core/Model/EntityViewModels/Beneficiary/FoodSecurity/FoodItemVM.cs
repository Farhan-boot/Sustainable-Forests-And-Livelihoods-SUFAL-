namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class FoodItemVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<FoodSecurityItemVM>? FoodSecurityItems { get; set; }
}