using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ICostInformationFileService
    {
        (ExecutionState executionState, List<CostInformationFileVM> entity, string message) List();
        (ExecutionState executionState, CostInformationFileVM entity, string message) Create(CostInformationFileVM model);
        (ExecutionState executionState, CostInformationFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, CostInformationFileVM entity, string message) Update(CostInformationFileVM model);
        (ExecutionState executionState, CostInformationFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}