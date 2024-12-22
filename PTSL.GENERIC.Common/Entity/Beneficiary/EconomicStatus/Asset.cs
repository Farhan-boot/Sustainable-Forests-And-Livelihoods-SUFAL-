using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class Asset : BaseEntity
    {
        public long AssetTypeId { get; set; }
        public AssetType? AssetType { get; set; }
        public string? AssetTypeTxt { get; set; }

        public double AssetQuantity { get; set; }
        public double AssetsCost { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}