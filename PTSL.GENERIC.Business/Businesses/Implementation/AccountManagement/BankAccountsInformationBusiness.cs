using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.DAL.UnitOfWork;
using PTSL.GENERIC.Common.Enum;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement
{
    public class BankAccountsInformationBusiness : BaseBusiness<BankAccountsInformation>, IBankAccountsInformationBusiness
    {
        public readonly GENERICUnitOfWork _unitOfWork;
        private readonly GENERICReadOnlyCtx _readOnlyContext;

        public BankAccountsInformationBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public async Task<(ExecutionState executionState, List<BankAccountsInformation> entity, string message)> GetBankAccountsInformationByUserId(long? userId, AccountAllowedFundExpense? accountAllowedFundExpense)
        {
            try
            {
                var result = await _readOnlyContext.Set<BankAccountsInformation>()
                    .Where(x => x.UserId == userId)
                    .Where(x => x.Account!.IsDeleted == false && x.Account.IsActive)
                    .Include(y => y.Account)
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();

                if (accountAllowedFundExpense is not null)
                {
                    result = result.Where(x => x.Account!.AccountAllowedFundExpenses.Any(y => y == accountAllowedFundExpense)).ToList();
                }

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception ex)
            {
                return (ExecutionState.Failure, new List<BankAccountsInformation>()!, "Unexpected error occurred.");
            }
        }

        public Task<bool> IsUserAssignedToBankAccounts(long userId, long?[] accountIds)
        {
            try
            {
                return _readOnlyContext.Set<BankAccountsInformation>()
                    .Where(x => x.UserId == userId)
                    .Where(x => accountIds.Contains(x.AccountId))
                    .AnyAsync();
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}