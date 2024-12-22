using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

public class NurseryCostInformationFileVM : BaseModel
{
    public long NurseryCostInformationId { get; set; }
    public NurseryCostInformationVM? CostInformation { get; set; }

    public string FileUrl { get; set; } = string.Empty;
    public FileType FileType { get; set; }
}
