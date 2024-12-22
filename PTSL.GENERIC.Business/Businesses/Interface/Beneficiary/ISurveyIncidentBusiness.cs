using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface ISurveyIncidentBusiness : IBaseBusiness<SurveyIncident>
    {
        Task<(ExecutionState executionState, List<SurveyIncident> entity, string message)> ListByFilter(SurveyIncidentFilterVM filter);
    }
}