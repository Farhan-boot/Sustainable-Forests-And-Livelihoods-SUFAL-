using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class FoodSecurityItemVM : BaseModel
    {
        public long FoodItemId { get; set; }

        [SwaggerExclude]
        public FoodItemVM? FoodItem { get; set; }
        public string? FoodItemTxt { get; set; }

        public double FoodAvilableMonthInYear { get; set; }
        public string? Remarks { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}