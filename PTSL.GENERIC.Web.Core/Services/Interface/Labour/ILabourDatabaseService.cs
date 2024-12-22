using PTSL.GENERIC.Web.Core.Controllers.Labour;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Labour
{
    public interface ILabourDatabaseService
    {
        (ExecutionState executionState, List<LabourDatabaseVM> entity, string message) List();
        (ExecutionState executionState, LabourDatabaseVM entity, string message) Create(LabourDatabaseVM model);
        (ExecutionState executionState, LabourDatabaseVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LabourDatabaseVM entity, string message) Update(LabourDatabaseVM model);
        (ExecutionState executionState, LabourDatabaseVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) GetByFilter(LabourDatabaseFilterVM filter);

    }

}
