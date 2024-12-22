using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation
{
    public class ColorBusiness : BaseBusiness<Color>, IColorBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        public ColorBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
