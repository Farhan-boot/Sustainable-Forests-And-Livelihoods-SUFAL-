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
    public class ImmovableAssetTypeBusiness : BaseBusiness<ImmovableAssetType>, IImmovableAssetTypeBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public ImmovableAssetTypeBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override Task<(ExecutionState executionState, IQueryable<ImmovableAssetType> entity, string message)> List(QueryOptions<ImmovableAssetType> queryOptions = null)
        {
            queryOptions = new QueryOptions<ImmovableAssetType>
            {
                SortingExpression = x => x.OrderByDescending(y => y.Id)
            };

            return base.List(queryOptions);
        }
    }
}
