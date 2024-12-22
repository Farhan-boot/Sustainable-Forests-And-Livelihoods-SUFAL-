using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.TransactionMangement
{
    public class TransactionBusiness : BaseBusiness<Transaction>, ITransactionBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;

        public TransactionBusiness(GENERICUnitOfWork unitOfWork, GENERICReadOnlyCtx readOnlyContext, GENERICWriteOnlyCtx writeOnlyCtx)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyContext;
            _writeOnlyCtx = writeOnlyCtx;
        }

        public async Task<(ExecutionState executionState, TransactionDashboardVM entity, string message)> DashboardData()
        {
            /*
            var totalExpense = await _readOnlyCtx.Set<TransactionExpense>().SumAsync(x => x.ExpenseAmount);
            var totalTarget = await _readOnlyCtx.Set<TransactionDetails>().SumAsync(x => x.TargetAmount);

            var currentMonth = DateTime.Now.Month;
            var monthlyExpense = await _readOnlyCtx.Set<TransactionExpense>()
                .Where(z => z.TransactionDetails!.Transaction!.FinancialYear!.StartYear <= DateTime.Now.Year
                    && DateTime.Now.Year <= z.TransactionDetails!.Transaction!.FinancialYear!.EndYear)
                .Where(x => (int)x.ExpenseMonth == currentMonth)
                .SumAsync(x => x.ExpenseAmount);
            var currentYearTarget = await _readOnlyCtx.Set<Transaction>()
                .Where(z => z.FinancialYear!.StartYear <= DateTime.Now.Year && DateTime.Now.Year <= z.FinancialYear!.EndYear)
                .Select(x => x.TransactionDetails)
                .ToListAsync();

            double currentProjectTarget = 0;
            foreach (var target in currentYearTarget)
            {
                currentProjectTarget += target?.Sum(x => x.TargetAmount) ?? 0;
            }

            var data = new TransactionDashboardVM
            {
                TotalProjectExpense = totalExpense,
                TotalProjectTarget = totalTarget,
                CurrentProjectTarget = currentProjectTarget,
                MonthlyProjectExpense = monthlyExpense,
                MonthlyExpensePercentage = Math.Round((monthlyExpense / currentProjectTarget) * 100, 1)
            };

            return (executionState: ExecutionState.Retrieved, entity: data, message: "Successfully retrieved data.");
            */
            return (executionState: ExecutionState.Retrieved, entity: new TransactionDashboardVM { }, message: "Successfully retrieved data.");
        }

        public override Task<(ExecutionState executionState, IQueryable<Transaction> entity, string message)> List(QueryOptions<Transaction> queryOptions = null)
        {
            return base.List(new QueryOptions<Transaction>
            {
                IncludeExpression = e => e
                    .Include(x => x.FinancialYear!)
                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!)
                    .Include(x => x.FundType!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public override async Task<(ExecutionState executionState, Transaction entity, string message)> GetAsync(long key)
        {
            var result = await _readOnlyCtx.Set<Transaction>()
                .Where(x => x.Id == key)
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestDivision)
                .Include(x => x.FinancialYear)
                //.Include(x => x.TransactionDetails!)
                //.ThenInclude(x => x.FundType)
                .FirstOrDefaultAsync();

            if (result is null)
                return (executionState: ExecutionState.Failure, null!, "Entity not found");

            return (executionState: ExecutionState.Retrieved, result!, "Entity is found");
        }

        public async Task<(ExecutionState executionState, Transaction entity, string message)> GetDetails(long key)
        {
            var result = await _readOnlyCtx.Set<Transaction>()
                .Where(x => x.Id == key)
                .Include(x => x.ForestCircle)
                .Include(x => x.ForestDivision)
                .Include(x => x.FinancialYear)
                .Include(x => x.ForestRange!)
                .Include(x => x.ForestBeat!)
                .Include(x => x.ForestFcvVcf!)
                .Include(x => x.ExpenseDetailsForCDFs!)
                .Include(x => x.FundType!)
                .Include(x => x.TransactionFiles!)
                .AsSplitQuery()
                .FirstOrDefaultAsync();

            if (result is null)
                return (executionState: ExecutionState.Failure, null!, "Entity not found");

            /*
            var details = await _readOnlyCtx.Set<TransactionDetails>()
                .Where(x => x.TransactionId == key)
                .Include(x => x.FundType)
                .Include(x => x.TransactionExpenses)
                .ToListAsync();
            result.TransactionDetails = details;
            */

            return (executionState: ExecutionState.Retrieved, result!, "Entity is found");
        }

        public async Task<(ExecutionState executionState, IList<TransactionDateVM> entity, string message)> ListDate(long financialYearId)
        {
            var result = await _readOnlyCtx.Set<Transaction>()
                .Where(x => x.FinancialYearId == financialYearId)
                .Select(x => new TransactionDateVM
                {
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    Id = x.Id
                })
                .ToListAsync();

            return (executionState: ExecutionState.Retrieved, result!, "Entity is found");
        }

        public Task<(ExecutionState executionState, Transaction entity, string message)> GetWithDetailsAsync(long key)
        {
            return base.GetAsync(new FilterOptions<Transaction>
            {
                //IncludeExpression = e => e.Include(x => x.TransactionDetails!).ThenInclude(x => x.FundType!)
            });
        }

        public async Task<(ExecutionState executionState, List<long> entity, string message)> DivisionListByFinancialYear(long financialYearId)
        {
            var list = await _readOnlyCtx.Set<Transaction>()
                .Where(x => x.FinancialYearId == financialYearId)
                .Select(x => x.ForestDivisionId)
                .Distinct()
                .ToListAsync();

            return (executionState: ExecutionState.Retrieved, entity: list, message: "Retrieved successfully");
        }

        public async Task<(ExecutionState executionState, IList<Transaction> entity, string message)> GetByFilter(TransactionFilterVM filter)
        {
            try
            {
                IQueryable<Transaction> query = _readOnlyCtx.Set<Transaction>()
                    .OrderByDescending(x => x.Id);

                query = query.WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasFinancialYearId, x => x.FinancialYearId == filter.FinancialYearId);

                query = query.WhereIf(filter.HasFromDate, x => x.FromDate >= filter.FromDate);
                query = query.WhereIf(filter.HasToDate, x => x.ToDate <= filter.ToDate);

                query = query
                    .Include(x => x.FinancialYear!)
                    .Include(x => x.ForestCircle!)
                    .Include(x => x.ForestDivision!);

                var result = await query.ToListAsync();

                return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, null!, "Unexpected error occurred.");
            }
        }

        public override async Task<(ExecutionState executionState, Transaction entity, string message)> CreateAsync(Transaction entity)
        {
            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var account = await _writeOnlyCtx.Set<Account>()
                    .Where(x => x.Id == entity.AccountId)
                    .FirstOrDefaultAsync();
                if (account is null)
                {
                    return (ExecutionState.Failure, null!, "Invalid account");
                }

                var isFundTypeCDF = await _writeOnlyCtx.Set<FundType>().Where(x => x.Id == entity.FundTypeId).Select(x => x.IsCdf).SingleAsync();
                if (isFundTypeCDF)
                {
                    entity.TotalExpense = entity.ExpenseDetailsForCDFs?.Sum(x => x.ExpenseAmount) ?? 0;
                }
                else
                {
                    entity.ExpenseDetailsForCDFs = null;
                }

                if (entity.TotalExpense > account.CurrentAvailableBalance)
                {
                    return (ExecutionState.Failure, null!, "Account does not have enough available balance");
                }

                entity.ExpenseDate = DateTime.Now;

                account.CurrentBlockAmount += entity.TotalExpense;

                _writeOnlyCtx.Set<Transaction>().Add(entity);

                await _writeOnlyCtx.SaveChangesAsync();

                await transaction.CommitAsync();

                return (ExecutionState.Success, null!, "Success");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, null!, "Unexpected error occurred");
            }
        }

        public override Task<(ExecutionState executionState, Transaction entity, string message)> UpdateAsync(Transaction entity)
        {
            //entity.TransactionDetails = null;

            return base.UpdateAsync(entity);
        }
    }
}
