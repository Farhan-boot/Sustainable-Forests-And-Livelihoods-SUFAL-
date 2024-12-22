using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Interface.PermissionSettings;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement
{
    public class AccountDepositBusiness : BaseBusiness<AccountDeposit>, IAccountDepositBusiness
    {
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly IBankAccountsInformationBusiness _bankAccountsInformationBusiness;
        private readonly IPermissionRowSettingsBusiness _permissionRowSettingsBusiness;
        private readonly IUserRoleBusiness _userRoleBusiness;

        public AccountDepositBusiness(
            GENERICUnitOfWork unitOfWork,
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx,
            IBankAccountsInformationBusiness bankAccountsInformationBusiness,
            IPermissionRowSettingsBusiness permissionRowSettingsBusiness,
            IUserRoleBusiness userRoleBusiness)
            : base(unitOfWork)
        {
            _writeOnlyCtx = writeOnlyCtx;
            _readOnlyCtx = readOnlyCtx;
            _bankAccountsInformationBusiness = bankAccountsInformationBusiness;
            _permissionRowSettingsBusiness = permissionRowSettingsBusiness;
            _userRoleBusiness = userRoleBusiness;
        }

        public override Task<(ExecutionState executionState, IQueryable<AccountDeposit> entity, string message)> List(QueryOptions<AccountDeposit>? queryOptions = null)
        {
            return base.List(new QueryOptions<AccountDeposit>
            {
                IncludeExpression = e => e.Include(x => x.SourceOfFund!).Include(x => x.Account!),
                SortingExpression = e => e.OrderByDescending(x => x.Id)
            });
        }

        public Task<(ExecutionState executionState, AccountDeposit entity, string message)> GetDetailsAsync(long id)
        {
            return base.GetAsync(new FilterOptions<AccountDeposit>
            {
                FilterExpression = e => e.Id == id,
                IncludeExpression = e => e
                    .Include(x => x.SourceOfFund!)
                    .Include(x => x.TransactionBy!)
                    .Include(x => x.FinancialYear!)
                    .Include(x => x.Account!)
            });
        }

        public override Task<(ExecutionState executionState, AccountDeposit entity, string message)> GetAsync(long id)
        {
            return base.GetAsync(new FilterOptions<AccountDeposit>
            {
                FilterExpression = e => e.Id == id,
            });
        }

        public async Task<(ExecutionState executionState, List<AccountDeposit> entity, string message)> ListForCashIn(long currentUserId)
        {
            var bankInfoResult = await _bankAccountsInformationBusiness.GetBankAccountsInformationByUserId(currentUserId, null);
            if (bankInfoResult.executionState != ExecutionState.Retrieved)
            {
                return (ExecutionState.Failure, null!, "Unable to load bank information for current user");
            }

            var bankIds = bankInfoResult.entity.Select(x => x.AccountId).ToArray();

            var result = await _readOnlyCtx.Set<AccountDeposit>()
                .OrderByDescending(x => x.Id)
                .Where(x => x.AccountDepositApprovalProcess == AccountDepositApprovalProcess.Completed)
                .Where(x => x.AccountDepositStatus == AccountDepositStatus.Pending || x.AccountDepositStatus == AccountDepositStatus.PendingModified)
                .Where(x => bankIds.Contains(x.AccountId))
                .Include(x => x.FinancialYear)
                .Include(x => x.Account)
                .AsSplitQuery()
                .ToListAsync();

            return (ExecutionState.Failure, result, "Success");
        }

        public async Task<(ExecutionState executionState, List<AccountDeposit> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId)
        {
            var permissionRowListResult = await _permissionRowSettingsBusiness.GetRowListByHeaderAscending(permissionHeaderSettingsId);
            if (permissionRowListResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, null!, "No approval system added");
            }

            var userRoleResult = await _userRoleBusiness.GetRoleIdByUserId(currentUserId);
            if (userRoleResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, null!, "User role not found");
            }

            IQueryable<AccountDeposit> query = _readOnlyCtx.Set<AccountDeposit>()
                .OrderByDescending(x => x.Id)
                .Where(x => x.AccountDepositApprovalProcess == AccountDepositApprovalProcess.Pending)
                .Where(x => x.AccountDepositStatus == AccountDepositStatus.Pending || x.AccountDepositStatus == AccountDepositStatus.PendingModified)
                .Include(x => x.Account)
                .Include(x => x.SourceOfFund!)
                .Include(x => x.FinancialYear);

            var result1 = await query
                .Where(x => x.NextApprovalUserId == currentUserId && x.NextApprovalUserRoleId == userRoleResult.roleId)
                .AsSplitQuery()
                .ToListAsync();
            var result2 = await query
                .Where(x => x.NextApprovalUserId == null && x.NextApprovalUserRoleId == userRoleResult.roleId)
                .AsSplitQuery()
                .ToListAsync();

            var result = result1.Except(result2).Concat(result2.Except(result1)).ToList();

            return (ExecutionState.Failure, result, "Success");
        }

        public async Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountDepositForwardRequestVM request)
        {
            // GET permission row list
            var permissionRowListResult = await _permissionRowSettingsBusiness.GetRowListByHeaderAscending(request.PermissionHeaderSettingsId);
            if (permissionRowListResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, "No approval system added");
            }

            // User role
            var userRoleResult = await _userRoleBusiness.GetRoleIdByUserId(currentUserId);
            if (userRoleResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, "User role not found");
            }

            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                // GET Account transfer
                var AccountDeposit = await _writeOnlyCtx.Set<AccountDeposit>().Include(x => x.AccountDepositApprovals).FirstOrDefaultAsync(x => x.Id == request.AccountDepositId);
                if (AccountDeposit is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "No account transfer found");
                }

                if (AccountDeposit.NextApprovalUserId is not null && AccountDeposit.NextApprovalUserId != currentUserId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }
                if (AccountDeposit.NextApprovalUserRoleId is not null && AccountDeposit.NextApprovalUserRoleId != userRoleResult.roleId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }

                // Last approval of current account transfer
                var lastAccountTransferApproval = AccountDeposit.AccountDepositApprovals?.MaxBy(x => x.Id);

                var permissionRowList = permissionRowListResult.entity;

                // Next requested permission row
                var nextRequestedPermissionRow = permissionRowList.FirstOrDefault(x => x.UserRoleId == request.NextRequestedUserRoleId);
                if (nextRequestedPermissionRow is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Next permission row is not found");
                }

                if (nextRequestedPermissionRow.OrderId - AccountDeposit.NextApprovalOrderNo > 1)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Can not forward without middle user approval");
                }

                // Check if next user requested role is not same as current last approval
                if (lastAccountTransferApproval?.ForwardedToRoleId == request.NextRequestedUserRoleId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Can not forward same user role");
                }

                var isForwarded = AccountDeposit.NextApprovalOrderNo < nextRequestedPermissionRow?.OrderId;

                if (request.NextRequestedUserId is not null) AccountDeposit.NextApprovalUserId = request.NextRequestedUserId;
                AccountDeposit.NextApprovalUserRoleId = request.NextRequestedUserRoleId;
                AccountDeposit.NextApprovalOrderNo = nextRequestedPermissionRow!.OrderId;

                if (isForwarded)
                {
                    AccountDeposit.AccountDepositApprovals?.Add(new AccountDepositApproval
                    {
                        SendingDateTime = DateTime.Now,

                        ApprovedById = currentUserId,
                        ApprovedByRoleId = userRoleResult.roleId,
                        ForwardedById = currentUserId,
                        ForwardedByRoleId = userRoleResult.roleId,
                        ForwardedToId = request.NextRequestedUserId,
                        ForwardedToRoleId = request.NextRequestedUserRoleId,

                        OrderId = nextRequestedPermissionRow!.OrderId
                    });
                }
                else
                {
                    AccountDeposit.AccountDepositApprovals?.Add(new AccountDepositApproval
                    {
                        SendingDateTime = DateTime.Now,

                        ForwardedById = currentUserId,
                        ForwardedByRoleId = userRoleResult.roleId,
                        ForwardedToId = request.NextRequestedUserId,
                        ForwardedToRoleId = request.NextRequestedUserRoleId,

                        OrderId = nextRequestedPermissionRow!.OrderId
                    });
                }

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Success, "Success");
            }
            catch
            {
                await transaction.RollbackAsync();
                return (ExecutionState.Failure, "Unexpected error occurred");
            }
        }

        public async Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId)
        {
            // GET permission row list
            var permissionRowListResult = await _permissionRowSettingsBusiness.GetRowListByHeaderAscending(permissionHeaderSettingsId);
            if (permissionRowListResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, "No approval system added");
            }

            // User role
            var userRoleResult = await _userRoleBusiness.GetRoleIdByUserId(currentUserId);
            if (userRoleResult.executionState != ExecutionState.Success)
            {
                return (ExecutionState.Failure, "User role not found");
            }

            var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                // GET Account transfer
                var AccountDeposit = await _writeOnlyCtx.Set<AccountDeposit>().Include(x => x.AccountDepositApprovals).FirstOrDefaultAsync(x => x.Id == accountTransferId);
                if (AccountDeposit is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "No account transfer found");
                }

                if (AccountDeposit.NextApprovalUserId is not null && AccountDeposit.NextApprovalUserId != currentUserId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }
                if (AccountDeposit.NextApprovalUserRoleId is not null && AccountDeposit.NextApprovalUserRoleId != userRoleResult.roleId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }

                var lastPermissionRow = permissionRowListResult.entity.Last();
                if (lastPermissionRow.OrderId != AccountDeposit.NextApprovalOrderNo)
                {
                    return (ExecutionState.Success, "You are not allowed to approve");
                }

                AccountDeposit.AccountDepositApprovalProcess = AccountDepositApprovalProcess.Completed;

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Success, "Success");
            }
            catch
            {
                await transaction.RollbackAsync();
                return (ExecutionState.Failure, "Unexpected error occurred");
            }
        }

        public async Task<(ExecutionState executionState, AccountDeposit entity, string message)> CreateAsync(AccountDeposit entity, long userId, long permissionHeaderSettingsId)
        {
            if (permissionHeaderSettingsId < 1)
            {
                return (ExecutionState.Failure, null!, "Invalid permission header settings");
            }

            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { entity.AccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, null!, "Current user is not assigned to this account");
                }

                var permissionRowListResult = await _permissionRowSettingsBusiness.GetRowListByHeaderAscending(permissionHeaderSettingsId);
                if (permissionRowListResult.executionState != ExecutionState.Success)
                {
                    return (ExecutionState.Failure, null!, "No approval system added");
                }

                var permissionRowList = permissionRowListResult.entity;
                var lastApprovalSetting = permissionRowList.Last();
                var firstApprovalSetting = permissionRowList.First();

                var userRoleResult = await _userRoleBusiness.GetRoleIdByUserId(userId);
                if (userRoleResult.executionState != ExecutionState.Success)
                {
                    return (ExecutionState.Failure, null!, "User role not found");
                }

                // Deposit
                // Last user role of approval process is current user role then no approval needed
                bool shouldAccept = false;
                if (lastApprovalSetting.UserRoleId == userRoleResult.roleId)
                {
                    entity.AccountDepositApprovalProcess = AccountDepositApprovalProcess.Completed;
                    entity.AccountDepositApprovals = new List<AccountDepositApproval>
                    {
                        AccountDepositApproval.CreateForLastApproval(userId, userRoleResult.roleId, lastApprovalSetting)
                    };
                    shouldAccept = true;
                }
                else
                {
                    var currentUserApprovalSetting = permissionRowList.Where(x => x.UserRoleId == userRoleResult.roleId).FirstOrDefault();
                    if (currentUserApprovalSetting is not null && lastApprovalSetting.OrderId - currentUserApprovalSetting.OrderId > 0)
                    {
                        var nextUserApprovalSetting = permissionRowList.Where(x => x.OrderId == currentUserApprovalSetting.OrderId + 1).FirstOrDefault();

                        if (nextUserApprovalSetting is not null)
                        {
                            entity.AccountDepositApprovals = new List<AccountDepositApproval>
                            {
                                AccountDepositApproval.CreateForFirstApproval(userId, userRoleResult.roleId, nextUserApprovalSetting)
                            };
                            entity.NextApprovalUserRoleId = nextUserApprovalSetting.UserRoleId;
                            entity.NextApprovalOrderNo = nextUserApprovalSetting.OrderId;
                        }
                    }
                    else
                    {
                        entity.AccountDepositApprovals = new List<AccountDepositApproval>
                        {
                            AccountDepositApproval.CreateForFirstApproval(userId, userRoleResult.roleId, firstApprovalSetting)
                        };
                        entity.NextApprovalUserRoleId = firstApprovalSetting.UserRoleId;
                        entity.NextApprovalOrderNo = firstApprovalSetting.OrderId;
                    }
                }
                // Deposit

                entity.TransactionById = userId;
                entity.DepositTransactionTime = DateTime.Now;

                var account = await _writeOnlyCtx.Set<Account>().FirstOrDefaultAsync(x => x.Id == entity.AccountId);
                if (account is null)
                {
                    return (ExecutionState.Failure, null!, "Account not found");
                }

                _writeOnlyCtx.Set<AccountDeposit>().Add(entity);
                await _writeOnlyCtx.SaveChangesAsync();

                await transaction.CommitAsync();

                if (shouldAccept)
                {
                    await AcceptDeposit(entity.Id, userId);
                }

                return (ExecutionState.Created, null!, "Created successfully");
            }
            catch
            {
                await transaction.RollbackAsync();
                return (ExecutionState.Failure, null!, "Failed");
            }
        }

        public override async Task<(ExecutionState executionState, AccountDeposit entity, string message)> UpdateAsync(AccountDeposit entity)
        {
            using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                /* TODO:
                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] {entity.AccountId});
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, null!, "Current user is not assigned to this account");
                }
                */

                var currentAccount = await _writeOnlyCtx.Set<Account>()
                    .Where(x => x.Id == entity.AccountId)
                    .FirstOrDefaultAsync();
                if (currentAccount == null)
                {
                    return (ExecutionState.Failure, null!, "Invalid account");
                }

                var currentDepositAmount = await _writeOnlyCtx.Set<AccountDeposit>()
                    .Where(x => x.Id == entity.Id)
                    .Select(x => x.DepositAmount)
                    .FirstOrDefaultAsync();
                var newAccountBalance = currentAccount.CurrentAvailableBalance - currentDepositAmount + entity.DepositAmount;
                if (newAccountBalance < 0)
                {
                    return (ExecutionState.Failure, null!, "New account balance can not be less than zero, please adjust deposit amount");
                }

                var entryState = _writeOnlyCtx.Set<AccountDeposit>().Attach(entity);

                entryState.State = EntityState.Modified;
                entryState.Property(x => x.CreatedAt).IsModified = false;
                entryState.Property(x => x.CreatedBy).IsModified = false;
                entryState.Property(x => x.TransactionBy).IsModified = false;
                entryState.Property(x => x.TransactionById).IsModified = false;

                var account = new Account
                {
                    Id = entity.AccountId
                };
                _writeOnlyCtx.Set<Account>().Attach(account);
                account.CurrentAccountBalance = newAccountBalance;

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Updated, null!, "Updated successfully");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ExecutionState.Failure, null!, ex.Message);
            }
        }

        public async Task<(ExecutionState executionState, string message)> AcceptDeposit(long accountTransferId, long userId)
        {
            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var accountDeposit = await _writeOnlyCtx.Set<AccountDeposit>()
                    .Where(x => x.Id == accountTransferId)
                    .FirstOrDefaultAsync();
                if (accountDeposit is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { accountDeposit.AccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Current user is not assigned to this account");
                }

                if (accountDeposit.AccountDepositApprovalProcess != AccountDepositApprovalProcess.Completed)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Approval process is not completed yet");
                }

                if (AccountDeposit.IsStatusPending(accountDeposit.AccountDepositStatus) == false)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Account status must be in pending");
                }

                var account = await _writeOnlyCtx.Set<Account>()
                    .FirstOrDefaultAsync(x => x.Id == accountDeposit.AccountId);
                if (account is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                account.CurrentAccountBalance += accountDeposit.DepositAmount;
                if (account.CurrentAvailableBalance < 0)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Account does not have enough available balance");
                }

                accountDeposit.AccountDepositStatus = AccountDepositStatus.Accepted;

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Success, "Approved successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, "An unknown error has been occurred");
            }
        }

        public async Task<(ExecutionState executionState, string message)> CancelDeposit(long accountTransferId, long userId)
        {
            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var accountDeposit = await _writeOnlyCtx.Set<AccountDeposit>()
                    .Where(x => x.Id == accountTransferId)
                    .FirstOrDefaultAsync();
                if (accountDeposit is null)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { accountDeposit.AccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, "Current user is not assigned to this account");
                }

                if (accountDeposit.AccountDepositApprovalProcess != AccountDepositApprovalProcess.Completed)
                {
                    return (ExecutionState.Failure, "Approval process is not completed yet");
                }

                if (AccountDeposit.IsStatusPending(accountDeposit.AccountDepositStatus) == false)
                {
                    return (ExecutionState.Failure, "Account status must be in pending");
                }

                var account = await _writeOnlyCtx.Set<Account>()
                    .FirstOrDefaultAsync(x => x.Id == accountDeposit.AccountId);
                if (account is null)
                {
                    return (ExecutionState.Failure, "Invalid account");
                }

                accountDeposit.AccountDepositStatus = AccountDepositStatus.Cancel;

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Success, "Cancelled successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, "An unknown error has been occurred");
            }
        }



        //New add filter
        public async Task<(ExecutionState executionState, PaginationResutl<AccountDeposit> entity, string message)> ListByFilter(ForestCivilLocationFilter filter)
        {
            try
            {
                //IQueryable<AccountDeposit> query = _writeOnlyCtx.Set<AccountDeposit>()
                //    .Include(x => x.Account!)
                //    .Include(x=>x.SourceOfFund!)
                //    .OrderByDescending(x => x.Id);


                if (filter.sSearch != null)
                {
                    IQueryable<AccountDeposit> queryTotalSearch = _readOnlyCtx.Set<AccountDeposit>()
                        .Include(x => x.Account!)
                        .Include(x => x.SourceOfFund!)
                        .OrderByDescending(x => x.Id);
                    IQueryable<AccountDeposit> querySearch = _readOnlyCtx.Set<AccountDeposit>()
                                     .Include(x => x.Account!)
                                     .Include(x => x.SourceOfFund!)
                                     .OrderByDescending(x => x.Id);

                    querySearch = querySearch.Where(x => x.Account.AccountNumber.Contains(filter.sSearch) || x.SourceOfFund.Name.Contains(filter.sSearch));
                    var resultSearch = await querySearch.ToListAsync();
                    return (ExecutionState.Retrieved, new PaginationResutl<AccountDeposit>
                    {
                        aaData = resultSearch,
                        iTotalDisplayRecords = await queryTotalSearch.CountAsync(),
                        iTotalRecords = await queryTotalSearch.CountAsync(),
                    }, "Data returned successfully.");
                }


                IQueryable<AccountDeposit> query;
                if (filter.iDisplayStart != null || filter.iDisplayLength != null)
                {
                    query = _readOnlyCtx.Set<AccountDeposit>()
                                      .Include(x => x.Account!)
                                      .Include(x => x.SourceOfFund!)
                                      .OrderByDescending(x => x.Id)
                                      .Skip(filter.iDisplayStart ?? 0)
                                      .Take(filter.iDisplayLength ?? 0);
                }
                else
                {
                    query = _readOnlyCtx.Set<AccountDeposit>()
                                      .Include(x => x.Account!)
                                      .Include(x => x.SourceOfFund!)
                                      .OrderByDescending(x => x.Id);
                }
                IQueryable<AccountDeposit> queryTotal = _readOnlyCtx.Set<AccountDeposit>()
                .OrderByDescending(x => x.Id);





                // Forest Administration
                query = query.WhereIf(filter.HasForestCircleId, x => x.Account.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.Account.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.Account.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.Account.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.Account.ForestFcvVcfId == filter.ForestFcvVcfId);

                // Civil Administration
                //query = query.WhereIf(filter.HasDivisionId, x => x.Account.DivisionId == filter.DivisionId);
                //query = query.WhereIf(filter.HasDistrictId, x => x.Account.DistrictId == filter.DistrictId);
                //query = query.WhereIf(filter.HasUpazillaId, x => x.Account.UpazillaId == filter.UpazillaId);
                //query = query.WhereIf(filter.HasUnionId, x => x.Account.UnionId == filter.UnionId);


                // Includes
                query = query
                    .Include(x=>x.Account!)
                    .Include(x=>x.SourceOfFund!);

                var result = await query
                    .AsSplitQuery()
                    .ToListAsync();


                return (ExecutionState.Retrieved, new PaginationResutl<AccountDeposit>
                {
                    aaData = result,
                    iTotalDisplayRecords = await queryTotal.CountAsync(),
                    iTotalRecords = await queryTotal.CountAsync(),
                }, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new PaginationResutl<AccountDeposit>()!, "Unexpected error occurred.");
            }
        }

    }
}
