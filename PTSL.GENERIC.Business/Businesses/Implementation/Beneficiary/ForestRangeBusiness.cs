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
    public class ForestRangeBusiness : BaseBusiness<ForestRange>, IForestRangeBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public ForestRangeBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<ForestRange> entity, string message)> List(QueryOptions<ForestRange> queryOptions = null)
        {
            queryOptions = new QueryOptions<ForestRange>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = x => x.Include(y => y.ForestDivision!.ForestCircle!)
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, ForestRange entity, string message)> GetAsync(long forestRangeId)
        {
            var filterOptions = new FilterOptions<ForestRange>();
            filterOptions.FilterExpression = e => e.Id == forestRangeId;
            filterOptions.IncludeExpression = e => e.Include(x => x.ForestDivision!);

            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ForestRange> entity, string message)> ListByForestDivision(long forestDivisionId)
        {
            var queryOptions = new QueryOptions<ForestRange>();
            queryOptions.FilterExpression = e => e.ForestDivisionId == forestDivisionId;
            
            return await base.List(queryOptions);
        }
    }
}
