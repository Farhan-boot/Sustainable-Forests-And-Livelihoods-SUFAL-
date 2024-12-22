using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement;

public class AccountBusiness : BaseBusiness<Account>, IAccountBusiness
{
    private readonly GENERICReadOnlyCtx _readOnlyCtx;

    public AccountBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyCtx)
        : base(unitOfWork)
    {
        _readOnlyCtx = readOnlyCtx;
    }

    public override Task<(ExecutionState executionState, IQueryable<Account> entity, string message)> List(QueryOptions<Account> queryOptions = null)
    {
        return base.List(new QueryOptions<Account>
        {
            SortingExpression = e => e.OrderByDescending(x => x.Id)
        });
    }

    public async Task<(ExecutionState executionState, List<Account> entity, string message)> GetByFilterBasic(AccountFilterVM filter)
    {
        try
        {
            IQueryable<Account> query = _readOnlyCtx.Set<Account>();

            // Forest Administration
            query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
            query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
            query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
            query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
            query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

            // Common
            query = query.WhereIf(filter.HasCommittee, x => x.CommitteeId == filter.CommitteeId);
            query = query.WhereIf(filter.HasCommitteeType, x => x.CommitteeTypeId == filter.CommitteeTypeId);
            query = query.WhereIf(filter.HasAccountNumber, x => x.AccountNumber == filter.AccountNumber);
            query = query.WhereIf(filter.HasAccountType, x => x.AccountType == filter.AccountType);
            query = query.WhereIf(filter.HasBankAccountName, x => x.BankAccountName == filter.BankAccountName);

            var result = await query.ToListAsync();

            return (ExecutionState.Retrieved, result, "Success");
        }
        catch (Exception ex)
        {
            return (ExecutionState.Retrieved, new List<Account>(), "Success");
        }
    }

    public async Task<(ExecutionState executionState, PaginationResutl<Account> entity, string message)> GetByFilter(AccountFilterVM filter)
    {
        try
        {
            //IQueryable<Account> query = _readOnlyCtx.Set<Account>()
            //    .Include(x=>x.Committee)
            //    .Include(x=>x.CommitteeType)
            //    .OrderByDescending(x => x.Id);

            if (filter.sSearch != null)
            {
                IQueryable<Account> queryTotalSearch = _readOnlyCtx.Set<Account>()
                   .Include(x => x.Committee)
                   .Include(x => x.CommitteeType)
                   .OrderByDescending(x => x.Id);
                IQueryable<Account> querySearch = _readOnlyCtx.Set<Account>()
                                  .Include(x => x.Committee)
                                  .Include(x => x.CommitteeType)
                                  .Where(x => x.IsActive && !x.IsDeleted)
                                  .OrderByDescending(x => x.Id);

                querySearch = querySearch.Where(x => x.AccountNumber.Contains(filter.sSearch) || x.BankAccountName.Contains(filter.sSearch) || x.BranchName.Contains(filter.sSearch));
                var resultSearch = await querySearch.ToListAsync();
                return (ExecutionState.Retrieved, new PaginationResutl<Account>
                {
                    aaData = resultSearch,
                    iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                    iTotalRecords = await queryTotalSearch.CountAsync(),
                }, "Data returned successfully.");
            }


            IQueryable<Account> query;
            if (filter.iDisplayStart != null || filter.iDisplayLength != null)
            {
                query = _readOnlyCtx.Set<Account>()
                                  .Include(x => x.Committee)
                                  .Include(x=>x.CommitteeType)
                                  .OrderByDescending(x => x.Id)
                                  .Skip(filter.iDisplayStart ?? 0)
                                  .Take(filter.iDisplayLength ?? 0);
            }
            else
            {
                query = _readOnlyCtx.Set<Account>()
                                   .Include(x => x.Committee)
                                   .Include(x=>x.CommitteeType)
                                   .OrderByDescending(x => x.Id);
            }
            IQueryable<Account> queryTotal = _readOnlyCtx.Set<Account>()
            .Include(x => x.Committee)
            .Include(x=>x.CommitteeType)
            .OrderByDescending(x => x.Id);



            // Forest Administration
            query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
            query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
            query = query.WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId);
            query = query.WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId);
            query = query.WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId);

            // Common
            query = query.WhereIf(filter.HasCommittee, x => x.CommitteeId == filter.CommitteeId);
            query = query.WhereIf(filter.HasCommitteeType, x => x.CommitteeTypeId == filter.CommitteeTypeId);
            query = query.WhereIf(filter.HasAccountNumber, x => x.AccountNumber == filter.AccountNumber);
            query = query.WhereIf(filter.HasAccountType, x => x.AccountType == filter.AccountType);
            query = query.WhereIf(filter.HasBankAccountName, x => x.BankAccountName == filter.BankAccountName);

            if (filter.HasTake)
            {
                query = query.Take(filter.Take ?? Defaults.Take);
            }

            var result = await query.ToListAsync();



            return (ExecutionState.Retrieved, new PaginationResutl<Account>
            {
                aaData = result,
                iTotalDisplayRecords = await queryTotal.CountAsync(),
                iTotalRecords = await queryTotal.CountAsync(),
            }, "Data returned successfully.");



           // return (ExecutionState.Retrieved, result, "Data returned successfully.");
        }
        catch (Exception ex)
        {
            return (ExecutionState.Failure, new PaginationResutl<Account>()!, "Unexpected error occurred.");
        }
    }

    public override Task<(ExecutionState executionState, Account entity, string message)> GetAsync(long key)
    {
        return base.GetAsync(new FilterOptions<Account>
        {
            FilterExpression = e => e.Id == key,
            IncludeExpression = e => e
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestDivision)
                .Include(x => x.ForestBeat)
                .Include(x => x.ForestRange)
                .Include(x => x.ForestFcvVcf)
                .Include(x => x.CommitteeType)
                .Include(x => x.Committee!)
        });
    }

    public override async Task<(ExecutionState executionState, Account entity, string message)> CreateAsync(Account entity)
    {
        var (executionState, entityCount, message) = await base.CountAsync(new CountOptions<Account>
        {
            FilterExpression = e => e.AccountNumber == entity.AccountNumber,
        });
        if (entityCount > 0)
        {
            return (ExecutionState.Success, null!, "Account number already exists");
        }

        return await base.CreateAsync(entity);
    }

    public override async Task<(ExecutionState executionState, Account entity, string message)> UpdateAsync(Account entity)
    {
        var (executionState, entityCount, message) = await base.CountAsync(new CountOptions<Account>
        {
            FilterExpression = e => e.AccountNumber == entity.AccountNumber && e.Id != entity.Id,
        });
        if (entityCount > 0)
        {
            return (ExecutionState.Success, null!, "Account number already exists");
        }

        return await base.UpdateAsync(entity);
    }

    public async Task<(ExecutionState executionState, AccountCurrentBalanceVM data, string message)> GetCurrentBalance(long id)
    {
        var data = await _readOnlyCtx.Set<Account>().FirstOrDefaultAsync(x => x.Id == id);
        var result = new AccountCurrentBalanceVM
        {
            CurrentAccountBalance = data?.CurrentAccountBalance ?? 0,
            CurrentBlockAmount = data?.CurrentBlockAmount ?? 0,
        };

        return result is null
            ? (ExecutionState.Failure, null!, "Not found")
            : (ExecutionState.Success, result, "Ok done");
    }
}