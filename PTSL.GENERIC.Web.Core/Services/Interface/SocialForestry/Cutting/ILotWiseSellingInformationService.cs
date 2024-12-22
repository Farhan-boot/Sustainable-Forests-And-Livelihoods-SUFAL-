using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface ILotWiseSellingInformationService
    {
        (ExecutionState executionState, List<LotWiseSellingInformationVM> entity, string message) List();
        (ExecutionState executionState, LotWiseSellingInformationVM entity, string message) Create(LotWiseSellingInformationVM model);
        (ExecutionState executionState, LotWiseSellingInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LotWiseSellingInformationVM entity, string message) Update(LotWiseSellingInformationVM model);
        (ExecutionState executionState, LotWiseSellingInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<LotWiseSellingInformationVM> entity, string message) GetLotInfoByCuttingId(long id);
        (ExecutionState executionState, LotWiseSellingInformationVM entity, string message) GetLotInfoByLotNumber(string lotNumber);
    }
}