using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class OtherIncomeSourceTypeBusiness : BaseBusiness<OtherIncomeSourceType>, IOtherIncomeSourceTypeBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public OtherIncomeSourceTypeBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<OtherIncomeSourceType> entity, string message)> List(QueryOptions<OtherIncomeSourceType> queryOptions = null)
        {
            queryOptions = new QueryOptions<OtherIncomeSourceType>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
