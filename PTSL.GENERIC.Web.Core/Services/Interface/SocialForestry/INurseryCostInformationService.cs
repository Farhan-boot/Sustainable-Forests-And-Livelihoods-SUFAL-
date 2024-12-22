using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface INurseryCostInformationService
    {
        (ExecutionState executionState, List<NurseryCostInformationVM> entity, string message) List();
        (ExecutionState executionState, NurseryCostInformationVM entity, string message) Create(NurseryCostInformationVM model);
        (ExecutionState executionState, NurseryCostInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryCostInformationVM entity, string message) Update(NurseryCostInformationVM model);
        (ExecutionState executionState, NurseryCostInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}