using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Labour;

public interface ILabourDatabaseFileService
{
    (ExecutionState executionState, List<LabourDatabaseFileVM> entity, string message) List();
    (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Create(LabourDatabaseFileVM model);
    (ExecutionState executionState, LabourDatabaseFileVM entity, string message) GetById(long? id);
    (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Update(LabourDatabaseFileVM model);
    (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Delete(long? id);
    (ExecutionState executionState, string message) DoesExist(long? id);
    (ExecutionState executionState, bool isDelete, string message) SoftDelete(long id);
}
