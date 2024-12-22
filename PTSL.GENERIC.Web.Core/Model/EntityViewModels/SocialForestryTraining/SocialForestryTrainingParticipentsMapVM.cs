namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;

public class SocialForestryTrainingParticipentsMapVM : BaseModel
{
    public long SocialForestryTrainingMemberId { get; set; }
    public SocialForestryTrainingMemberVM? SocialForestryTrainingMember { get; set; }

    public long SocialForestryTrainingId { get; set; }
    public SocialForestryTrainingVM? SocialForestryTraining { get; set; }
}

