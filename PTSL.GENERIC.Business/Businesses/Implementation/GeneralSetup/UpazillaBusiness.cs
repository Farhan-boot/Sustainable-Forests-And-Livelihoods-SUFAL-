using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class UpazillaBusiness : BaseBusiness<Upazilla>, IUpazillaBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;

        public UpazillaBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<Upazilla> entity, string message)> List(QueryOptions<Upazilla> queryOptions = null)
        {
            queryOptions = new QueryOptions<Upazilla>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id),
                IncludeExpression = x => x.Include(y => y.District!.Division!),
            };

            return base.List(queryOptions);
        }

        public override Task<(ExecutionState executionState, Upazilla entity, string message)> GetAsync(long UpazillaId)
        {
            var filterOptions = new FilterOptions<Upazilla>();
            filterOptions.FilterExpression = e => e.Id == UpazillaId;
            filterOptions.IncludeExpression = e => e.Include(x => x.District!);

            return base.GetAsync(filterOptions);
        }

        public async Task<(ExecutionState executionState, IQueryable<Upazilla> entity, string message)> ListByDistrict(long districtId)
        {
            var queryOptions = new QueryOptions<Upazilla>();
            queryOptions.FilterExpression = e => e.DistrictId == districtId;
            
            return await base.List(queryOptions);
        }
    }
}
