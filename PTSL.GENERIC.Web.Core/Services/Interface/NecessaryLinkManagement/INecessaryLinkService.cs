using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.CipManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.NecessaryLinkManagement;

namespace PTSL.GENERIC.Web.Core.Services.Interface.NecessaryLinkManagement
{
    public interface INecessaryLinkService
    {
        (ExecutionState executionState, List<NecessaryLinkVM> entity, string message) List();
        (ExecutionState executionState, NecessaryLinkVM entity, string message) Create(NecessaryLinkVM model);
        (ExecutionState executionState, NecessaryLinkVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NecessaryLinkVM entity, string message) Update(NecessaryLinkVM model);
        (ExecutionState executionState, NecessaryLinkVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}