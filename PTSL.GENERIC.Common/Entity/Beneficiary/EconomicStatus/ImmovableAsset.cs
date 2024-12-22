using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.Beneficiary
{
    public class ImmovableAsset : BaseEntity
    {
        public long ImmovableAssetTypeId { get; set; }
        public ImmovableAssetType? ImmovableAssetType { get; set; }
        public string? ImmovableAssetsTypeTxt { get; set; }

        public double ImmovableAnnualReturn { get; set; }

        public long SurveyId { get; set; }
        public Survey? Survey { get; set; }
    }
}