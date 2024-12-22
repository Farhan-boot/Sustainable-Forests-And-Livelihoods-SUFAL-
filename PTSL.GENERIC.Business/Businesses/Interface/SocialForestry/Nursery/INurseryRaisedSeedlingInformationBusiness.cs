using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery
{
    public interface INurseryRaisedSeedlingInformationBusiness : IBaseBusiness<NurseryRaisedSeedlingInformation>
    {
        Task<(ExecutionState executionState, List<NurseryRaisedSeedlingInformation> entity, string message)> GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution);
        Task<(ExecutionState executionState, NurseryRaisedSeedlingInformation entity, string message)> SeedlinUpdate(UpdateSeedlingInfoVM model);
    }
}