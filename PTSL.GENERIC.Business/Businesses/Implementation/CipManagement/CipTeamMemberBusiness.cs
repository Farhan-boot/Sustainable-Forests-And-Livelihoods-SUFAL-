using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.CipManagement;
using PTSL.GENERIC.Common.Entity.CipManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.CipManagement
{
    public class CipTeamMemberBusiness : BaseBusiness<CipTeamMember>, ICipTeamMemberBusiness
    {
        public CipTeamMemberBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}