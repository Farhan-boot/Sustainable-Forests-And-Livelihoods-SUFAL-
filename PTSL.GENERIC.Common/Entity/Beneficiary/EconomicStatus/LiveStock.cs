using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class LiveStock : BaseEntity
    {
        public long LiveStockTypeId { get; set; }
        public LiveStockType? LiveStockType { get; set; }
        public string? LivestockTypeTxt { get; set; }
        public double LiveStockQuantity { get; set; }
        public double LivestockCost { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}