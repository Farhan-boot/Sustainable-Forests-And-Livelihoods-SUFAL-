using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry;

public interface ISocialForestryBeneficiaryService : IBaseService<SocialForestryBeneficiaryVM, SocialForestryBeneficiary>
{
    Task<(ExecutionState executionState, List<SocialForestryBeneficiaryVM> entity, string message)> GetBeneficiariesByNewRaisedId(long newRaisedId, bool hasPbsa = false);
}
