using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
	public class MeetingTypeBusiness : BaseBusiness<MeetingType>, IMeetingTypeBusiness
	{
		public readonly GENERICUnitOfWork _unitOfWork;
		public MeetingTypeBusiness(GENERICUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public override Task<(ExecutionState executionState, IQueryable<MeetingType> entity, string message)> List(QueryOptions<MeetingType> queryOptions = null)
        {
            queryOptions = new QueryOptions<MeetingType>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}

