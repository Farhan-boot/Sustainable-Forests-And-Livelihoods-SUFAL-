using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class ForestDivisionBusiness : BaseBusiness<ForestDivision>, IForestDivisionBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public ForestDivisionBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<ForestDivision> entity, string message)> List(QueryOptions<ForestDivision> queryOptions = null)
        {
            queryOptions = new QueryOptions<ForestDivision>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = x => x.Include(y => y.ForestCircle),
            };

            return base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ForestDivision> entity, string message)> ListByForestCircle(long forestCircleId)
        {
            var queryOptions = new QueryOptions<ForestDivision>();
            queryOptions.FilterExpression = e => e.ForestCircleId == forestCircleId;
            
            return await base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<ForestDivision> entity, string message)> ListByMultipleForestCircle(List<long> forestCircleIds)
        {
            return await base.List(new QueryOptions<ForestDivision>
            {
                FilterExpression = e => forestCircleIds.Contains(e.ForestCircleId),
                IncludeExpression = e => e.Include(x => x.ForestCircle!)
            });
        }
    }
}
