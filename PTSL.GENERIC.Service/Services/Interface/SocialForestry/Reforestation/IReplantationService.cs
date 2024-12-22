using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Reforestation
{
    public interface IReplantationService : IBaseService<ReplantationVM, Replantation>
    {
        Task<(ExecutionState executionState, ReplantationVM data, string message)> GetDetails(long id);
    }
}