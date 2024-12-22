using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class DepartmentalTrainingParticipentsMapBusiness : BaseBusiness<DepartmentalTrainingParticipentsMap>, IDepartmentalTrainingParticipentsMapBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public DepartmentalTrainingParticipentsMapBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
