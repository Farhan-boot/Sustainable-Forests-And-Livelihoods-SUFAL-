using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting
{
    public interface ILotWiseSellingInformationBusiness : IBaseBusiness<LotWiseSellingInformation>
    {
        Task<(ExecutionState executionState, List<LotWiseSellingInformation> data, string message)> GetLotInfoByCuttingId(long id);
        Task<(ExecutionState executionState, LotWiseSellingInformation data, string message)> GetLotInfoByLotNumber(string lotNumber);
    }
}