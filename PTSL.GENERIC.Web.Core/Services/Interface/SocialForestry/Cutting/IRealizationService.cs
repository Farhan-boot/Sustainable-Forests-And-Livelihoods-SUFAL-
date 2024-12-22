using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Cutting;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Cutting
{
    public interface IRealizationService
    {
        (ExecutionState executionState, List<RealizationVM> entity, string message) List();
        (ExecutionState executionState, RealizationVM entity, string message) Create(RealizationVM model);
        (ExecutionState executionState, RealizationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, RealizationVM entity, string message) Update(RealizationVM model);
        (ExecutionState executionState, RealizationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<RealizationVM> entity, string message) GetRealizationsByCuttingId(long id);
        (ExecutionState executionState, DefaultRealizationDataVM entity, string message) GetDefaultRealizationData(long id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}