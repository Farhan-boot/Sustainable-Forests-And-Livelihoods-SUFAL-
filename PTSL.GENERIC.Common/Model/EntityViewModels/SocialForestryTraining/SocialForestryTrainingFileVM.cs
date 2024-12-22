using System.Collections.Generic;

using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingFileVM : BaseModel
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTrainingVM? SocialForestryTraining { get; set; }
}

