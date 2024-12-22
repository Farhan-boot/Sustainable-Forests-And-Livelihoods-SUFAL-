using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.NecessaryLinkManagement
{
    public class NecessaryLinkBusiness : BaseBusiness<NecessaryLink>, INecessaryLinkBusiness
    {
        public NecessaryLinkBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}