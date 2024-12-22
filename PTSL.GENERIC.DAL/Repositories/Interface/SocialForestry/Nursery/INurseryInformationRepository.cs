using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery
{
    public interface INurseryInformationRepository : IBaseRepository<NurseryInformation>
    {
        Task<(ExecutionState executionState, NurseryInformation entity, string message)> GetNursaryInformationAsync(long id);
    }
}