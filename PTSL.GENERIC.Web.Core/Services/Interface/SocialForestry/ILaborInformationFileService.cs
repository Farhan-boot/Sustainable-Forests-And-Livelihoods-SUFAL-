using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ILaborInformationFileService
    {
        (ExecutionState executionState, List<LaborInformationFileVM> entity, string message) List();
        (ExecutionState executionState, LaborInformationFileVM entity, string message) Create(LaborInformationFileVM model);
        (ExecutionState executionState, LaborInformationFileVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LaborInformationFileVM entity, string message) Update(LaborInformationFileVM model);
        (ExecutionState executionState, LaborInformationFileVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}