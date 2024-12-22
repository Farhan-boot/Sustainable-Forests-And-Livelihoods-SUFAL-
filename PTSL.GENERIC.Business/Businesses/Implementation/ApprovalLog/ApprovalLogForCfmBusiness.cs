using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.ApprovalLog;
using PTSL.GENERIC.Common.Entity.ApprovalLog;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.ApprovalLog
{
    public class ApprovalLogForCfmBusiness : BaseBusiness<ApprovalLogForCfm>, IApprovalLogForCfmBusiness
    {
        public ApprovalLogForCfmBusiness(GENERICUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}