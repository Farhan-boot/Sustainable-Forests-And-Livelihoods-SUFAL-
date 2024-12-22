using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class SurveyIncidentBusiness : BaseBusiness<SurveyIncident>, ISurveyIncidentBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;

        public SurveyIncidentBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
        }

        public override Task<(ExecutionState executionState, IQueryable<SurveyIncident> entity, string message)> List(QueryOptions<SurveyIncident> queryOptions = null)
        {
            return base.List(new QueryOptions<SurveyIncident>
            {
                IncludeExpression = e => e.Include(x => x.Survey!)
            });
        }

        public async Task<(ExecutionState executionState, List<SurveyIncident> entity, string message)> ListByFilter(SurveyIncidentFilterVM filter)
        {
            var result = await _readOnlyCtx.Set<SurveyIncident>()
                .WhereIf(filter.HasSurveyId, x => x.SurveyId == filter.SurveyId)
                .WhereIf(filter.HasYearId, x => x.Year == filter.Year)
                .WhereIf(filter.HasMonthNo, x => x.MonthNo == filter.MonthNo)
                .WhereIf(filter.HasSurveyIncidentStatus, x => x.SurveyIncidentStatus == filter.SurveyIncidentStatus)

                .WhereIf(filter.HasGender, x => x.Survey!.BeneficiaryGender == filter.Gender)
                .WhereIf(filter.HasPhoneNumber, x => x.Survey!.BeneficiaryPhone == filter.PhoneNumber || x.Survey!.BeneficiaryPhoneBn == filter.PhoneNumber)
                .WhereIf(filter.HasNID, x => x.Survey!.BeneficiaryNid == filter.NID)
                .WhereIf(filter.HasNgoId, x => x.Survey!.NgoId == filter.NgoId)

                .FilterSurveyLocationGeneric(filter, x => x.Survey!)
                .Take(filter.Take ?? int.MaxValue)
                .Skip(0)
                .Include(x => x.Survey)
                .ToListAsync();

            return (ExecutionState.Retrieved, result, "Data returned successfully");
        }

        public override Task<(ExecutionState executionState, SurveyIncident entity, string message)> GetAsync(long key)
        {
            return base.GetAsync(new FilterOptions<SurveyIncident>
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e.Include(x => x.Survey!)
            });
        }
    }
}