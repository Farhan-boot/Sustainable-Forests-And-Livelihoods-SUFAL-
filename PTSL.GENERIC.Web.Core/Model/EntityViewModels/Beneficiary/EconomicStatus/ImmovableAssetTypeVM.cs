namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary
{
    public class ImmovableAssetTypeVM : BaseModel
    {
        public string Name { get; set; }
        public string NameBn { get; set; }

        public List<ImmovableAssetVM>? ImmovableAssets { get; set; }
    }
}