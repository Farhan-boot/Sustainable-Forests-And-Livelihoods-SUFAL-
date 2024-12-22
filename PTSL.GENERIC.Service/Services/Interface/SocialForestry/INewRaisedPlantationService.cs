using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public interface INewRaisedPlantationService : IBaseService<NewRaisedPlantationVM, NewRaisedPlantation>
    {
        Task<(ExecutionState executionState, NewRaisedPlantationVM data, string message)> GetDetails(long id);
        Task<(ExecutionState executionState, NewRaisedPlantationVM data, string message)> GetDetailsForEdit(long id);
        Task<(ExecutionState execution, string entity, string message)> GetNextRotationNo(long newRaisedPlantationId);
        Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> ListByFilter(NewRaisedPlantationFilter filter);
        Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> GetInformationAndDataOnNewlyRaisedPlantationReport(NurseryFilterVM filter);
        Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> GetInformationAndDataOnPlantationsFelledOrCutReport(NurseryFilterVM filter);
    }
}