using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class ForestBeatBusiness : BaseBusiness<ForestBeat>, IForestBeatBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public ForestBeatBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<ForestBeat> entity, string message)> List(QueryOptions<ForestBeat> queryOptions = null)
        {
            queryOptions = new QueryOptions<ForestBeat>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = x => x.Include(y => y.ForestRange.ForestDivision.ForestCircle),
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, ForestBeat entity, string message)> GetAsync(long forestBeatId)
        {
            var filterOptions = new FilterOptions<ForestBeat>();
            filterOptions.FilterExpression = e => e.Id == forestBeatId;
            filterOptions.IncludeExpression = e => e.Include(x => x.ForestRange!.ForestDivision!);

            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ForestBeat> entity, string message)> ListByForestRange(long forestRangeId)
        {
            var queryOptions = new QueryOptions<ForestBeat>();
            queryOptions.FilterExpression = e => e.ForestRangeId == forestRangeId;
            
            return await base.List(queryOptions);
        }
    }
}
