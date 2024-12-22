using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public interface INurseryRaisedSeedlingInformationService : IBaseService<NurseryRaisedSeedlingInformationVM, NurseryRaisedSeedlingInformation>
    {
        Task<(ExecutionState executionState, List<NurseryRaisedSeedlingInformationVM> entity, string message)> GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution);
        Task<(ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message)> SeedlinUpdate(UpdateSeedlingInfoVM model);
    }
}