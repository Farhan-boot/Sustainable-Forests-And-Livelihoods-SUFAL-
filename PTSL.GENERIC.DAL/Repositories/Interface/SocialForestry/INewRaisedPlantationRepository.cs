using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry
{
    public interface INewRaisedPlantationRepository : IBaseRepository<NewRaisedPlantation>
    {
        Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetails(long id);
        Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetailsForEdit(long id);
    }
}