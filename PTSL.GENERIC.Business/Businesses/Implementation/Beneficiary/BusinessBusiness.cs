using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class BusinessBusiness : BaseBusiness<Common.Entity.Beneficiary.Business>, IBusinessBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public BusinessBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<Common.Entity.Beneficiary.Business> entity, string message)> List(QueryOptions<Common.Entity.Beneficiary.Business> queryOptions = null)
        {
            queryOptions = new QueryOptions<Common.Entity.Beneficiary.Business>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
