using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class CostInformationFileVM : BaseModel
{
    public long CostInformationId { get; set; }
    public CostInformationVM? CostInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
