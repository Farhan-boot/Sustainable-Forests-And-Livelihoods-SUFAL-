using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class LaborInformationFileVM : BaseModel
{
    public long LaborInformationId { get; set; }
    public LaborInformationVM? LaborInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
