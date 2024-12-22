using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;

namespace PTSL.GENERIC.Web.Core.Services.Interface.AIG
{
    public interface ISecondFourtyPercentageLDFService
    {
        (ExecutionState executionState, List<SecondFourtyPercentageLDFVM> entity, string message) List();
        (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) Create(SecondFourtyPercentageLDFVM model);
        (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) Update(SecondFourtyPercentageLDFVM model);
        (ExecutionState executionState, SecondFourtyPercentageLDFVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}