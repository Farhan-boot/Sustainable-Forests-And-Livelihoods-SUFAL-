using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ICostInformationService
    {
        (ExecutionState executionState, List<CostInformationVM> entity, string message) List();
        (ExecutionState executionState, CostInformationVM entity, string message) Create(CostInformationVM model);
        (ExecutionState executionState, CostInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CostInformationVM entity, string message) Update(CostInformationVM model);
        (ExecutionState executionState, CostInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);

    }
}