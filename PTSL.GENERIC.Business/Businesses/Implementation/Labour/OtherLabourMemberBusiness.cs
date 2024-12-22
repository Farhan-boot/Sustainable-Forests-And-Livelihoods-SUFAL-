using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Labour
{
    public class OtherLabourMemberBusiness : BaseBusiness<OtherLabourMember>, IOtherLabourMemberBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;

        public OtherLabourMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<OtherLabourMember> entity, string message)> List(QueryOptions<OtherLabourMember> queryOptions = null)
        {
            queryOptions = new QueryOptions<OtherLabourMember>()
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
