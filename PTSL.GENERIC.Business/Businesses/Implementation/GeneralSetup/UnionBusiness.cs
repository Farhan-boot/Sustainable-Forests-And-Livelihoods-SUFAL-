using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class UnionBusiness : BaseBusiness<Union>, IUnionBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;

        public UnionBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, Union entity, string message)> GetAsync(long UnionId)
        {
            var filterOptions = new FilterOptions<Union>();
            filterOptions.FilterExpression = e => e.Id == UnionId;
            filterOptions.IncludeExpression = e => e.Include(x => x.Upazilla!.District!);

            return base.GetAsync(filterOptions);
        }
        public override async Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> List(QueryOptions<Union> queryOptions = null)
        {
            (ExecutionState executionState, IQueryable<Union> entity, string message) returnResponse;

            queryOptions = new QueryOptions<Union>();
            queryOptions.IncludeExpression = e => e.Include(x => x.Upazilla!.District!.Division!);
            queryOptions.SortingExpression = x => x.OrderByDescending(y => y.Id);
            (ExecutionState executionState, IQueryable<Union> entity, string message) entityObject = await _unitOfWork.List<Union>(queryOptions);
            returnResponse = entityObject;

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> ListByUpazilla(long UpazillaId)
        {
            var queryOptions = new QueryOptions<Union>();
            queryOptions.FilterExpression = e => e.UpazillaId == UpazillaId;
            
            return await base.List(queryOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<Union> entity, string message)> ListByMultipleUpazilla(List<long> upazillas)
        {
            var queryOptions = new QueryOptions<Union>();
            queryOptions.FilterExpression = e => upazillas.Contains(e.UpazillaId);
            queryOptions.IncludeExpression = e => e.Include(x => x.Upazilla!);
            
            return await base.List(queryOptions);
        }
    }
}
