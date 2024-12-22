using System.Collections.Generic;

using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.BaseModels;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingParticipentsMapVM : BaseModel
{
    public long SocialForestryTrainingMemberId { get; set; }
    public SocialForestryTrainingMemberVM? SocialForestryTrainingMember { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTrainingVM? SocialForestryTraining { get; set; }
}

