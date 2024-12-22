using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ILaborInformationService
    {
        (ExecutionState executionState, List<LaborInformationVM> entity, string message) List();
        (ExecutionState executionState, LaborInformationVM entity, string message) Create(LaborInformationVM model);
        (ExecutionState executionState, LaborInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LaborInformationVM entity, string message) Update(LaborInformationVM model);
        (ExecutionState executionState, LaborInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}