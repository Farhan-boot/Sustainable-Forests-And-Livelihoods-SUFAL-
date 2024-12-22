namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class FoodSecurityItemVM : BaseModel
{
    public long FoodItemId { get; set; }
    public FoodItemVM? FoodItem { get; set; }
    public string FoodItemTxt { get; set; }

    public double FoodAvilableMonthInYear { get; set; }
    public string Remarks { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}