using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
	public class MeetingParticipantsMapBusiness : BaseBusiness<MeetingParticipantsMap>, IMeetingParticipantsMapBusiness
	{
		public readonly GENERICUnitOfWork _unitOfWork;
		public MeetingParticipantsMapBusiness(GENERICUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        public override Task<(ExecutionState executionState, IQueryable<MeetingParticipantsMap> entity, string message)> List(QueryOptions<MeetingParticipantsMap> queryOptions = null)
        {
            queryOptions = new QueryOptions<MeetingParticipantsMap>
            {
                IncludeExpression = e => e.Include(x => x.Meeting!),
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}


