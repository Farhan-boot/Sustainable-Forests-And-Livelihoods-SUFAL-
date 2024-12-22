using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation
{
    public interface IReplantationBusiness : IBaseBusiness<Replantation>
    {
        Task<(ExecutionState executionState, Replantation data, string message)> GetDetails(long id);
    }
}