using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Trades;
using PTSL.GENERIC.Common.Entity.Trades;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Trades
{
    public class TradeBusiness : BaseBusiness<Trade>, ITradeBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public TradeBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<Trade> entity, string message)> List(QueryOptions<Trade> queryOptions = null)
        {
            queryOptions = new QueryOptions<Trade>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
