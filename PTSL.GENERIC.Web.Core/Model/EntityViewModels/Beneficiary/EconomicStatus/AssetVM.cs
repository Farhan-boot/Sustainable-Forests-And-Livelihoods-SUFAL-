namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

public class AssetVM : BaseModel
{
    public long AssetTypeId { get; set; }
    public AssetTypeVM? AssetType { get; set; }
    public string? AssetTypeTxt { get; set; }

    public double AssetQuantity { get; set; }
    public double AssetsCost { get; set; }

    public long SurveyId { get; set; }
    public SurveyVM? Survey { get; set; }
}
