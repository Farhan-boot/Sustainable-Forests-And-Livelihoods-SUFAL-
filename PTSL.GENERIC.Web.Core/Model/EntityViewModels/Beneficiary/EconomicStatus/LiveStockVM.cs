namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class LiveStockVM : BaseModel
    {
        public long LiveStockTypeId { get; set; }
        public LiveStockTypeVM? LiveStockType { get; set; }
        public string? LivestockTypeTxt { get; set; }
        public double LiveStockQuantity { get; set; }
        public double LivestockCost { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
