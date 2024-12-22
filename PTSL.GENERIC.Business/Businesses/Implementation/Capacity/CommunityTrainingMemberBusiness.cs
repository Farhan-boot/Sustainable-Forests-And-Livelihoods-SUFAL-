using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class CommunityTrainingMemberBusiness : BaseBusiness<CommunityTrainingMember>, ICommunityTrainingMemberBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public CommunityTrainingMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
