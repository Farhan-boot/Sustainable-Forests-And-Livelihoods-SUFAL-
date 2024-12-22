using System.Linq;
using System.Threading.Tasks;
using System;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using System.Collections.Generic;
using PTSL.GENERIC.Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement
{
    public class AccountsUserTagLogBusiness : BaseBusiness<AccountsUserTagLog>, IAccountsUserTagLogBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyContext;
        public AccountsUserTagLogBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _readOnlyContext = readOnlyContext;
        }

        public async Task<(ExecutionState executionState, List<AccountsUserTagLog> entity, string message)> GetAccountsUserTagLogsByAccountId(long accountId)
        {
            try
            {
                IQueryable<AccountsUserTagLog> executiveQuery = _readOnlyContext.Set<AccountsUserTagLog>();
                var accountsUserTagLog = executiveQuery.Include(x=>x.Accounts).Include(x=>x.Users).Where(x => x.AccountsId == accountId).ToList() ?? new List<AccountsUserTagLog>();
                return (executionState: ExecutionState.Success, entity: accountsUserTagLog, message: "Success");
            }
            catch (Exception e)
            {
                return (ExecutionState.Failure, null!, "Unexpected");
            }
        }


    }
}