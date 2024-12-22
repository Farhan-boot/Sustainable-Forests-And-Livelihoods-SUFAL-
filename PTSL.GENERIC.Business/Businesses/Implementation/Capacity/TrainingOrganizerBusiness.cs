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
    public class TrainingOrganizerBusiness : BaseBusiness<TrainingOrganizer>, ITrainingOrganizerBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public TrainingOrganizerBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<TrainingOrganizer> entity, string message)> List(QueryOptions<TrainingOrganizer> queryOptions = null)
        {
            queryOptions = new QueryOptions<TrainingOrganizer>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
