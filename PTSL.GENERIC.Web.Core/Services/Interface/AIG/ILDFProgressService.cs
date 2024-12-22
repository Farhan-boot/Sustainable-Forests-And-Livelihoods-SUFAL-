using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface ILDFProgressService
    {
        (ExecutionState executionState, List<LDFProgressVM> entity, string message) List();
        (ExecutionState executionState, LDFProgressVM entity, string message) Create(LDFProgressVM model);
        (ExecutionState executionState, LDFProgressVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LDFProgressVM entity, string message) Update(LDFProgressVM model);
        (ExecutionState executionState, LDFProgressVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}