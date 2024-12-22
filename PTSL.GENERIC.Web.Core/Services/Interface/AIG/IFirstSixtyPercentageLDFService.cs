using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface IFirstSixtyPercentageLDFService
    {
        (ExecutionState executionState, List<FirstSixtyPercentageLDFVM> entity, string message) List();
        (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) Create(FirstSixtyPercentageLDFVM model);
        (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) GetById(long? id);
        (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) Update(FirstSixtyPercentageLDFVM model);
        (ExecutionState executionState, FirstSixtyPercentageLDFVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}