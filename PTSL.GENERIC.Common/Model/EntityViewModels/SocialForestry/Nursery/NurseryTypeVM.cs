using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;

public class NurseryTypeVM : BaseModel
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<NurseryInformationVM>? NurseryInformation { get; set; }
}
