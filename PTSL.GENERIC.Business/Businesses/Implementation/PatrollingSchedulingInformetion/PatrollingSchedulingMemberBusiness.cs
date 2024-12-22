using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.PatrollingSchedulingInformetion;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingMemberBusiness : BaseBusiness<PatrollingSchedulingMember>, IPatrollingSchedulingMemberBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public PatrollingSchedulingMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
