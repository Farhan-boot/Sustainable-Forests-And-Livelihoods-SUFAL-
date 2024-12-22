using System.Linq;

using PTSL.GENERIC.Common.Entity.Capacity;

namespace PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;

public class CommunityTrainingParticipantsByBeneficiaryResultVM
{
    public string? BeneficiaryName { get; set; }
    public string? BeneficiaryPhone { get; set; }
    public string? BeneficiaryNid { get; set; }
    public IEnumerable<CommunityTraining> Trainings { get; set; } = Enumerable.Empty<CommunityTraining>();
}
