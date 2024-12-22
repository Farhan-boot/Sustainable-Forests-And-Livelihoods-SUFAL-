using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Cutting
{
    public class DistributedToBeneficiaryBusiness : BaseBusiness<DistributedToBeneficiary>, IDistributedToBeneficiaryBusiness
    {
        public DistributedToBeneficiaryBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}