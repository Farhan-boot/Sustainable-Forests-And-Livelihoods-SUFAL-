using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement
{
    public class OtherCommitteeMemberBusiness : BaseBusiness<OtherCommitteeMember>, IOtherCommitteeMemberBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;

        public OtherCommitteeMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public override Task<(ExecutionState executionState, IQueryable<OtherCommitteeMember> entity, string message)> List(QueryOptions<OtherCommitteeMember> queryOptions = null)
		{
            queryOptions = new QueryOptions<OtherCommitteeMember>()
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
		}

		public Task<(ExecutionState executionState, IQueryable<OtherCommitteeMember> entity, string message)> ListByForestFcvVcf(long id)
        {
            return base.List(new QueryOptions<OtherCommitteeMember>
            {
                FilterExpression = x => x.ForestFcvVcfId == id
            });
        }

        public override Task<(ExecutionState executionState, OtherCommitteeMember entity, string message)> GetAsync(long key)
        {
            var filterOptions = new FilterOptions<OtherCommitteeMember>()
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => 
					e
                    .Include(x => x.ForestCircle)
                    .Include(x => x.ForestDivision)
                    .Include(x => x.ForestRange)
                    .Include(x => x.ForestBeat)
                    .Include(x => x.ForestFcvVcf)
                    .Include(x => x.District)
                    .Include(x => x.Division)
                    .Include(x => x.Upazilla!)
                    .Include(x => x.Union!)
                    .Include(x => x.Ethnicity!)
            };

            return base.GetAsync(filterOptions);
        }
    }
}
