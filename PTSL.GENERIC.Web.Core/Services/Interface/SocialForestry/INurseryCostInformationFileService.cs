using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface INurseryCostInformationFileService
    {
        (ExecutionState executionState, List<NurseryCostInformationFileVM> entity, string message) List();
        (ExecutionState executionState, NurseryCostInformationFileVM entity, string message) Create(NurseryCostInformationFileVM model);
        (ExecutionState executionState, NurseryCostInformationFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryCostInformationFileVM entity, string message) Update(NurseryCostInformationFileVM model);
        (ExecutionState executionState, NurseryCostInformationFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}