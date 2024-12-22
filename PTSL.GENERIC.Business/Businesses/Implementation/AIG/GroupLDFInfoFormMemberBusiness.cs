using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AIG
{
    public class GroupLDFInfoFormMemberBusiness : BaseBusiness<GroupLDFInfoFormMember>, IGroupLDFInfoFormMemberBusiness
    {
        public GroupLDFInfoFormMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}