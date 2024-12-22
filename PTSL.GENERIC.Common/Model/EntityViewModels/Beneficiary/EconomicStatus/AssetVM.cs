using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary
{
    public class AssetVM : BaseModel
    {
        public long AssetTypeId { get; set; }

        [SwaggerExclude]
        public AssetTypeVM? AssetType { get; set; }
        public string? AssetTypeTxt { get; set; }

        public double AssetQuantity { get; set; }
        public double AssetsCost { get; set; }

        public long SurveyId { get; set; }

        [SwaggerExclude]
        public SurveyVM? Survey { get; set; }
    }
}