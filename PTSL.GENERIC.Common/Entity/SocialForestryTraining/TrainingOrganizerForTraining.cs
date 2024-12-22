using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class TrainingOrganizerForTraining : BaseEntity
{
    public string? Name { get; set; }
    public string? NameBn { get; set; }

    public List<SocialForestryTraining>? SocialForestryTrainings { get; set; }
}

