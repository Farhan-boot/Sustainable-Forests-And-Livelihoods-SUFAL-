using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Patrolling;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Patrolling;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Patrolling
{
    public class PatrollingScheduleInformetionBusiness : BaseBusiness<PatrollingScheduleInformetion>, IPatrollingScheduleInformetionBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public readonly GENERICWriteOnlyCtx _context;
        public PatrollingScheduleInformetionBusiness(GENERICUnitOfWork unitOfWork, GENERICWriteOnlyCtx context)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public override Task<(ExecutionState executionState, PatrollingScheduleInformetion entity, string message)> GetAsync(long key)
        {
            var filterOptions = new FilterOptions<PatrollingScheduleInformetion>
            {
                IncludeExpression = x => x
                    .Include(x => x.PatrollingPaymentInformetions!).Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.ForestRange!)
                    .Include(x => x.ForestBeat!)
                    .Include(x => x.Division!)
                    .Include(x => x.District!)
                    .Include(x => x.Upazilla!)
                    .ThenInclude(o=>o.OtherPatrollingMembers!)
                    .Include(x => x.PatrollingPaymentInformetions!).ThenInclude(s=>s.Surveys!),
                FilterExpression = e => e.Id == key
            };

            return base.GetAsync(filterOptions);
        }


        public async Task<(ExecutionState executionState, List<PatrollingScheduleInformetion> entity, string message)> GetPatrollingScheduleInformetionByFilter(PatrollingScheduleFilterVM filterData)
        {
            var query = _context.Set<PatrollingScheduleInformetion>()
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderByDescending(x => x.Id)
                .AsQueryable();

            // Forest Administration
            if (filterData?.ForestCircleId != null && filterData?.ForestCircleId > 0)
            {
                query = query.Where(x => x.ForestCircleId == filterData.ForestCircleId);
            }
            if (filterData?.ForestDivisionId != null && filterData?.ForestDivisionId > 0)
            {
                query = query.Where(x => x.ForestDivisionId == filterData.ForestDivisionId);
            }
            if (filterData?.ForestRangeId != null && filterData?.ForestRangeId > 0)
            {
                query = query.Where(x => x.ForestRangeId == filterData.ForestRangeId);
            }
            if (filterData?.ForestBeatId != null && filterData?.ForestBeatId > 0)
            {
                query = query.Where(x => x.ForestBeatId == filterData.ForestBeatId);
            }
            if (filterData?.ForestFcvVcfId != null && filterData?.ForestFcvVcfId > 0)
            {
                query = query.Where(x => x.FcvId == filterData.ForestFcvVcfId);
            }

            // Civil Administration
            if (filterData?.DivisionId != null && filterData?.DivisionId > 0)
            {
                query = query.Where(x => x.DivisionId == filterData.DivisionId);
            }
            if (filterData?.DistrictId != null && filterData?.DistrictId > 0)
            {
                query = query.Where(x => x.DistrictId == filterData.DistrictId);
            }
            if (filterData?.UpazillaId != null && filterData?.UpazillaId > 0)
            {
                query = query.Where(x => x.UpazillaId == filterData.UpazillaId);
            }

            query = query.OrderByDescending(x => x.Id);

            var result = await query.ToListAsync();

            return (ExecutionState.Retrieved, result, "Data returned successfully.");
        }

        public override Task<(ExecutionState executionState, IQueryable<PatrollingScheduleInformetion> entity, string message)> List(QueryOptions<PatrollingScheduleInformetion> queryOptions = null)
        {
            var patrollingScheduleInformetion = new QueryOptions<PatrollingScheduleInformetion>();
            patrollingScheduleInformetion.IncludeExpression = x => x.OrderByDescending(x=>x.Id).Include(x => x.PatrollingPaymentInformetions);
            return base.List(patrollingScheduleInformetion);
        }
    }
}
