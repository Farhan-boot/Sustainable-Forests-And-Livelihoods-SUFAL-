using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.CommonEntity;

namespace PTSL.GENERIC.Common.Entity.SocialForestryTraining;

public class SocialForestryTrainingParticipentsMap : BaseEntity
{
    public long SocialForestryTrainingMemberId { get; set; }
    public SocialForestryTrainingMember? SocialForestryTrainingMember { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTraining? SocialForestryTraining { get; set; }
}

