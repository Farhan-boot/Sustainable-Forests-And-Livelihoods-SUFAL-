using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class LiveStockVM : BaseModel
    {
        public long LiveStockTypeId { get; set; }

        [SwaggerExclude]
        public LiveStockTypeVM? LiveStockType { get; set; }
        public string? LivestockTypeTxt { get; set; }
        public double LiveStockQuantity { get; set; }
        public double LivestockCost { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}