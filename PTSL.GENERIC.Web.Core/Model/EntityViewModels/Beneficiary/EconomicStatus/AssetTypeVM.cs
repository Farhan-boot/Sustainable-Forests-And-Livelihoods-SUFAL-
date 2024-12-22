namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class AssetTypeVM : BaseModel
{
    public string Name { get; set; }
    public string NameBn { get; set; }

    public List<AssetVM>? Assets { get; set; }
}