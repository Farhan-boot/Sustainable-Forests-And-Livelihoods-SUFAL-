using PTSL.GENERIC.Web.Core.Helper.Enum.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

public class NurseryRaisingSectorVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public RaisingSectorType? RaisingSectorType { get; set; }

    public List<NurseryInformationVM>? NurseryInformation { get; set; }
}
