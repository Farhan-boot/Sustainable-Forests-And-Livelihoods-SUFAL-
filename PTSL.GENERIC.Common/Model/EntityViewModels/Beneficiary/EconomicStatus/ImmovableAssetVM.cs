using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class ImmovableAssetVM : BaseModel
    {
        public long ImmovableAssetTypeId { get; set; }

        [SwaggerExclude]
        public ImmovableAssetTypeVM? ImmovableAssetType { get; set; }
        public string? ImmovableAssetsTypeTxt { get; set; }

        public double ImmovableAnnualReturn { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}