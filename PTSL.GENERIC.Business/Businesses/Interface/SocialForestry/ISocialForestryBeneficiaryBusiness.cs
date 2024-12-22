using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry
{
    public interface ISocialForestryBeneficiaryBusiness : IBaseBusiness<SocialForestryBeneficiary>
    {
        Task<(ExecutionState executionState, SocialForestryBeneficiary entity, string message)> GetByIdAsync(long id, FilterOptions<SocialForestryBeneficiary>? filterOptions = null);
        Task<(ExecutionState executionState, List<SocialForestryBeneficiary?> entity, string message)> GetBeneficiariesByNewRaisedId(long newRaisedId, bool hasPbsa = false);
    }
}
