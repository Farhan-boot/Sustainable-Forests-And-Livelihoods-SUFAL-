using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry.Reforestation
{
    public class ReplantationLaborInfoBusiness : BaseBusiness<ReplantationLaborInfo>, IReplantationLaborInfoBusiness
    {
        public ReplantationLaborInfoBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}