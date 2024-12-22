using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public interface ILotWiseSellingInformationService : IBaseService<LotWiseSellingInformationVM, LotWiseSellingInformation>
    {
        Task<(ExecutionState executionState, List<LotWiseSellingInformationVM> data, string message)> GetLotInfoByCuttingId(long id);
        Task<(ExecutionState executionState, LotWiseSellingInformationVM data, string message)> GetLotInfoByLotNumber(string lotNumber);
    }
}