using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class CommunityTrainingTypeBusiness : BaseBusiness<CommunityTrainingType>, ICommunityTrainingTypeBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public CommunityTrainingTypeBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<CommunityTrainingType> entity, string message)> List(QueryOptions<CommunityTrainingType> queryOptions = null)
        {
            queryOptions = new QueryOptions<CommunityTrainingType>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
