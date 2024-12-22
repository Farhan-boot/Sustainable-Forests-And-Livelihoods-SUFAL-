using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class SocialForestryTrainingFile : BaseEntity
{
    public string? FileName { get; set; }
    public string? FileNameUrl { get; set; }
    public FileType FileType { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTraining? SocialForestryTraining { get; set; }
}

