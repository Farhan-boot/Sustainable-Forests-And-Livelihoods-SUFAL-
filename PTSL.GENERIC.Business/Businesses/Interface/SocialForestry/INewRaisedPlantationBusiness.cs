using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry
{
    public interface INewRaisedPlantationBusiness : IBaseBusiness<NewRaisedPlantation>
    {
        Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetails(long id);
        Task<(ExecutionState executionState, NewRaisedPlantation data, string message)> GetDetailsForEdit(long id);
        Task<(ExecutionState execution, string entity, string message)> GetNextRotationNo(long newRaisedPlantation);
        Task<(ExecutionState executionState, List<NewRaisedPlantation> entity, string message)> ListByFilter(NewRaisedPlantationFilter filter);
        Task<(ExecutionState executionState, IList<NewRaisedPlantation> entity, string message)> GetInformationAndDataOnNewlyRaisedPlantationReport(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<NewRaisedPlantation> entity, string message)> GetInformationAndDataOnPlantationsFelledOrCutReport(NurseryFilterVM model);
    }
}