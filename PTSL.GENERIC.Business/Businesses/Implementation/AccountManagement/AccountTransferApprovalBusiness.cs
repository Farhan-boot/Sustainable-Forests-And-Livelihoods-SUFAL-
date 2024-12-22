using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement;

public class AccountTransferApprovalBusiness : BaseBusiness<AccountTransferApproval>, IAccountTransferApprovalBusiness
{
    public AccountTransferApprovalBusiness(GENERICUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }
}