using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.DAL.Repositories.Interface.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Beneficiary
{
    public class SurveyIncidentRepository : BaseRepository<SurveyIncident>, ISurveyIncidentRepository
    {
        public SurveyIncidentRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}