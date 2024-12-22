using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;

public class SocialForestryDesignationVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    [SwaggerExclude]
    public List<ConcernedOfficialVM>? ConcernedOfficials { get; set; }
}
