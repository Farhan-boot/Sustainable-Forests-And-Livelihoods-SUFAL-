using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.SocialForestryMeeting
{
    public class SocialForestryMeetingMemberBusiness : BaseBusiness<SocialForestryMeetingMember>, ISocialForestryMeetingMemberBusiness
    {
        public SocialForestryMeetingMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}