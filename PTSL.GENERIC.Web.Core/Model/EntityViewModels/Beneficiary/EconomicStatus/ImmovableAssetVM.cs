namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ImmovableAssetVM : BaseModel
    {
        public long ImmovableAssetTypeId { get; set; }
        public ImmovableAssetTypeVM? ImmovableAssetType { get; set; }
        public string? ImmovableAssetsTypeTxt { get; set; }

        public double ImmovableAnnualReturn { get; set; }

        public long SurveyId { get; set; }
        public SurveyVM? Survey { get; set; }
    }
}
