using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryTraining
{
    public class SocialForestryTrainingMemberBusiness : BaseBusiness<SocialForestryTrainingMember>, ISocialForestryTrainingMemberBusiness
    {
        public SocialForestryTrainingMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}