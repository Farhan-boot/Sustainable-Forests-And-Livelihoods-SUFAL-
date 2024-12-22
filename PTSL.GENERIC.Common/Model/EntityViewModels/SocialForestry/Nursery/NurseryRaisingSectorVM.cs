using PTSL.GENERIC.Common.Enum.SocialForestry;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

public class NurseryRaisingSectorVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }
    public RaisingSectorType? RaisingSectorType { get; set; }

    public List<NurseryInformationVM>? NurseryInformation { get; set; }
}
