using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestry
{
    public class PlantationDamageInformationBusiness : BaseBusiness<PlantationDamageInformation>, IPlantationDamageInformationBusiness
    {
        public PlantationDamageInformationBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}