using PTSL.GENERIC.Web.Core.Helper.Enum;

namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingFileVM : BaseModel
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTrainingVM? SocialForestryTraining { get; set; }
}

