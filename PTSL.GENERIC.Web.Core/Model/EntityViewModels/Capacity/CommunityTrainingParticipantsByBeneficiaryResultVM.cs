namespace PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;

public class CommunityTrainingParticipantsByBeneficiaryResultVM
{
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryPhone { get; set; }
    public string? BeneficiaryNid { get; set; }
    public List<CommunityTrainingVM>? Trainings { get; set; }
}
