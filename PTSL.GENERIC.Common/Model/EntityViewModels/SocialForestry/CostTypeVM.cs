using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class CostTypeVM : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;
    public string LabelName { get; set; } = string.Empty;
    public string LabelNameBn { get; set; } = string.Empty;
    
    [SwaggerExclude]
    public List<CostInformationVM>? CostInformation { get; set; }
}
