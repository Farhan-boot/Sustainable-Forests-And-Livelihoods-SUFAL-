using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary
{
    public class GrossMarginIncomeAndCostStatusBusiness : BaseBusiness<GrossMarginIncomeAndCostStatus>, IGrossMarginIncomeAndCostStatusBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public GrossMarginIncomeAndCostStatusBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<GrossMarginIncomeAndCostStatus> entity, string message)> List(QueryOptions<GrossMarginIncomeAndCostStatus> queryOptions = null)
        {
            queryOptions = new QueryOptions<GrossMarginIncomeAndCostStatus>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
