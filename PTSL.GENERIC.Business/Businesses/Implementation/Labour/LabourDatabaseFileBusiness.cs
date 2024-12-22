using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.Labour;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.Capacity
{
    public class LabourDatabaseFileBusiness : BaseBusiness<LabourDatabaseFile>, ILabourDatabaseFileBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public LabourDatabaseFileBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
