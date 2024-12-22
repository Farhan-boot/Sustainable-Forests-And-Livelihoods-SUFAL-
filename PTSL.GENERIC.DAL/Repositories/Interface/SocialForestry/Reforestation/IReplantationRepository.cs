using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Reforestation
{
    public interface IReplantationRepository : IBaseRepository<Replantation>
    {
        Task<(ExecutionState executionState, Replantation data, string message)> GetDetails(long id);
    }
}