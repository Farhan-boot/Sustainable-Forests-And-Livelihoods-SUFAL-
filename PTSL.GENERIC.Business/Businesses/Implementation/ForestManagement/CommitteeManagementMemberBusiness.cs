using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ForestManagement
{
    public class CommitteeManagementMemberBusiness : BaseBusiness<CommitteeManagementMember>, ICommitteeManagementMemberBusiness
    {
        public CommitteeManagementMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}