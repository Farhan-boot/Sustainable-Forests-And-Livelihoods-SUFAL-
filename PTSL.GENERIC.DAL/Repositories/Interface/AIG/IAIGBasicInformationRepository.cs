using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Interface.AIG
{
    public interface IAIGBasicInformationRepository : IBaseRepository<AIGBasicInformation>
    {
        Task<bool> IsLoanCleared(long surveyId, int ldfCount = 0);
    }
}