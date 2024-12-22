using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class FoodSecurityItem : BaseEntity
    {
        public long FoodItemId { get; set; }
        public FoodItem? FoodItem { get; set; }
        public string? FoodItemTxt { get; set; }

        public double FoodAvilableMonthInYear { get; set; }
        public string? Remarks { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}