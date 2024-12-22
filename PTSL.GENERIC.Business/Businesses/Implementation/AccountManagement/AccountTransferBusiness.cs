using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Interface.PermissionSettings;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.QuerySerialize.Implementation;
using PTSL.GENERIC.DAL.UnitOfWork;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PTSL.GENERIC.Business.Businesses.Implementation.AccountManagement
{
    public class AccountTransferBusiness : BaseBusiness<AccountTransfer>, IAccountTransferBusiness
    {
        private readonly GENERICReadOnlyCtx _readOnlyCtx;
        private readonly GENERICWriteOnlyCtx _writeOnlyCtx;
        private readonly IPermissionRowSettingsBusiness _permissionRowSettingsBusiness;
        private readonly IUserRoleBusiness _userRoleBusiness;
        private readonly IBankAccountsInformationBusiness _bankAccountsInformationBusiness;

        public AccountTransferBusiness(
            GENERICUnitOfWork unitOfWork,
            GENERICReadOnlyCtx readOnlyCtx,
            GENERICWriteOnlyCtx writeOnlyCtx,
            IPermissionRowSettingsBusiness permissionRowSettingsBusiness,
            IUserRoleBusiness userRoleBusiness,
            IBankAccountsInformationBusiness bankAccountsInformationBusiness)
            : base(unitOfWork)
        {
            _readOnlyCtx = readOnlyCtx;
            _writeOnlyCtx = writeOnlyCtx;
            _permissionRowSettingsBusiness = permissionRowSettingsBusiness;
            _userRoleBusiness = userRoleBusiness;
            _bankAccountsInformationBusiness = bankAccountsInformationBusiness;
        }

        public override async Task<(ExecutionState executionState, IQueryable<AccountTransfer> entity, string message)> List(QueryOptions<AccountTransfer> queryOptions = null)
        {
            var result = _readOnlyCtx.Set<AccountTransfer>()
                .OrderByDescending(x => x.Id)
                .Include(x => x.FromAccount)
                .Include(x => x.ToAccount)
                .Include(x => x.FinancialYear)
                .AsSplitQuery();

            return (ExecutionState.Retrieved, result, "");
        }

        public async Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListForCashIn(long currentUserId)
        {
            var bankInfoResult = await _bankAccountsInformationBusiness.GetBankAccountsInformationByUserId(currentUserId, null);
            if (bankInfoResult.executionState != ExecutionState.Retrieved)
            {
                return (ExecutionState.Failure, null!, "Unable to load bank information for current user");
            }

            var bankIds = bankInfoResult.entity.Select(x => x.AccountId).ToArray();

            var result = await _readOnlyCtx.Set<AccountTransfer>()
                .OrderByDescending(x => x.Id)
                .Where(x => x.AccountTransferApprovalProcess == AccountTransferApprovalProcess.Completed)
                .Where(x => x.AccountTransferStatus == AccountTransferStatus.Pending || x.AccountTransferStatus == AccountTransferStatus.PendingModified)
                .Where(x => bankIds.Contains(x.ToAccountId))
                .Include(x => x.FromAccount)
                .Include(x => x.ToAccount)
                .Include(x => x.FinancialYear)
                .AsSplitQuery()
                .ToListAsync();

            return (ExecutionState.Failure, result, "Success");
        }

        public async Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId)
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

            IQueryable<AccountTransfer> query = _readOnlyCtx.Set<AccountTransfer>()
                .OrderByDescending(x => x.Id)
                .Where(x => x.AccountTransferApprovalProcess == AccountTransferApprovalProcess.Pending)
                .Where(x => x.AccountTransferStatus == AccountTransferStatus.Pending || x.AccountTransferStatus == AccountTransferStatus.PendingModified)
                .Include(x => x.FromAccount)
                .Include(x => x.ToAccount)
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

        public async Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountForwardRequestVM request)
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
                var accountTransfer = await _writeOnlyCtx.Set<AccountTransfer>().Include(x => x.AccountTransferApprovals).FirstOrDefaultAsync(x => x.Id == request.AccountTransferId);
                if (accountTransfer is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "No account transfer found");
                }

                if (accountTransfer.NextApprovalUserId is not null && accountTransfer.NextApprovalUserId != currentUserId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }
                if (accountTransfer.NextApprovalUserRoleId is not null && accountTransfer.NextApprovalUserRoleId != userRoleResult.roleId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }

                // Last approval of current account transfer
                var lastAccountTransferApproval = accountTransfer.AccountTransferApprovals?.MaxBy(x => x.Id);

                var permissionRowList = permissionRowListResult.entity;

                // Next requested permission row
                var nextRequestedPermissionRow = permissionRowList.FirstOrDefault(x => x.UserRoleId == request.NextRequestedUserRoleId);
                if (nextRequestedPermissionRow is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "Next permission row is not found");
                }

                if (nextRequestedPermissionRow.OrderId - accountTransfer.NextApprovalOrderNo > 1)
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

                var isForwarded = accountTransfer.NextApprovalOrderNo < nextRequestedPermissionRow?.OrderId;

                if (request.NextRequestedUserId is not null) accountTransfer.NextApprovalUserId = request.NextRequestedUserId;
                accountTransfer.NextApprovalUserRoleId = request.NextRequestedUserRoleId;
                accountTransfer.NextApprovalOrderNo = nextRequestedPermissionRow!.OrderId;

                if (isForwarded)
                {
                    accountTransfer.AccountTransferApprovals?.Add(new AccountTransferApproval
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
                    accountTransfer.AccountTransferApprovals?.Add(new AccountTransferApproval
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
                var accountTransfer = await _writeOnlyCtx.Set<AccountTransfer>().Include(x => x.AccountTransferApprovals).FirstOrDefaultAsync(x => x.Id == accountTransferId);
                if (accountTransfer is null)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, "No account transfer found");
                }

                if (accountTransfer.NextApprovalUserId is not null && accountTransfer.NextApprovalUserId != currentUserId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }
                if (accountTransfer.NextApprovalUserRoleId is not null && accountTransfer.NextApprovalUserRoleId != userRoleResult.roleId)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Success, "You are not allowed to forward request");
                }

                var lastPermissionRow = permissionRowListResult.entity.Last();
                if (lastPermissionRow.OrderId != accountTransfer.NextApprovalOrderNo)
                {
                    return (ExecutionState.Success, "You are not allowed to approve");
                }

                accountTransfer.AccountTransferApprovalProcess = AccountTransferApprovalProcess.Completed;

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

        public async Task<(ExecutionState executionState, AccountTransfer entity, string message)> Transfer(AccountTransfer entity, long userId, long permissionHeaderSettingsId)
        {
            if (permissionHeaderSettingsId < 1)
            {
                return (ExecutionState.Failure, null!, "Invalid permission header settings");
            }

            if (entity.FromAccountId == entity.ToAccountId)
            {
                return (ExecutionState.Failure, null!, "Can not transfer to same account");
            }

            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { entity.FromAccountId });
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

            // Last user role of approval process is current user role then no approval needed
            bool shouldAccept = false;
            if (lastApprovalSetting.UserRoleId == userRoleResult.roleId)
            {
                entity.AccountTransferApprovalProcess = AccountTransferApprovalProcess.Completed;
                entity.AccountTransferApprovals = new List<AccountTransferApproval>
                {
                    AccountTransferApproval.CreateForLastApproval(userId, userRoleResult.roleId, lastApprovalSetting)
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
                        entity.AccountTransferApprovals = new List<AccountTransferApproval>
                        {
                            AccountTransferApproval.CreateForFirstApproval(userId, userRoleResult.roleId, nextUserApprovalSetting)
                        };
                        entity.NextApprovalUserRoleId = nextUserApprovalSetting.UserRoleId;
                        entity.NextApprovalOrderNo = nextUserApprovalSetting.OrderId;
                    }
                }
                else
                {
                    entity.AccountTransferApprovals = new List<AccountTransferApproval>
                    {
                        AccountTransferApproval.CreateForFirstApproval(userId, userRoleResult.roleId, firstApprovalSetting)
                    };
                    entity.NextApprovalUserRoleId = firstApprovalSetting.UserRoleId;
                    entity.NextApprovalOrderNo = firstApprovalSetting.OrderId;
                }
            }

            try
            {
                var account = await _writeOnlyCtx.Set<Account>().Where(x => x.Id == entity.FromAccountId).FirstOrDefaultAsync();
                if (account is null)
                {
                    return (ExecutionState.Failure, null!, "Invalid account");
                }

                if (entity.AccountTransferDetails is not null && entity.AccountTransferDetails.Count > 0)
                {
                    entity.TransferAmount = entity.AccountTransferDetails.Sum(x => x.TransferDetailsAmount);
                }

                if (account.CurrentAvailableBalance - entity.TransferAmount < 0)
                {
                    return (ExecutionState.Failure, null!, "Account does not have available balance");
                }

                account.CurrentBlockAmount += entity.TransferAmount;
                entity.TransferTransactionTime = DateTime.Now;
                entity.TransferRequestedById = userId;

                if (entity.AccountTransferLogs is null)
                {
                    entity.AccountTransferLogs = new List<AccountTransferLog>();
                }
                entity.AccountTransferLogs.Add(AccountTransferLog.CreateForNewTransfer(entity, userId));

                _writeOnlyCtx.Set<AccountTransfer>().Add(entity);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                if (shouldAccept)
                {
                    await AcceptTransfer(entity.Id, userId);
                }

                return (ExecutionState.Created, null!, "Created successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, null!, "An unknown error has been occurred");
            }
        }

        public async Task<(ExecutionState executionState, string message)> AcceptTransfer(long accountTransferId, long userId)
        {
            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var accountTransfer = await _writeOnlyCtx.Set<AccountTransfer>()
                    .Where(x => x.Id == accountTransferId)
                    .FirstOrDefaultAsync();
                if (accountTransfer is null)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { accountTransfer.ToAccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, "Current user is not assigned to this account");
                }

                if (accountTransfer.AccountTransferApprovalProcess != AccountTransferApprovalProcess.Completed)
                {
                    return (ExecutionState.Failure, "Approval process is not completed yet");
                }

                if (AccountTransfer.IsStatusPending(accountTransfer.AccountTransferStatus) == false)
                {
                    return (ExecutionState.Failure, "Account status must be in pending");
                }

                var accounts = await _writeOnlyCtx.Set<Account>()
                    .Where(x => x.Id == accountTransfer.ToAccountId || x.Id == accountTransfer.FromAccountId)
                    .ToListAsync();
                if (accounts.Count != 2)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var toAccount = accounts.Single(x => x.Id == accountTransfer.ToAccountId);
                var fromAccount = accounts.Single(x => x.Id == accountTransfer.FromAccountId);

                var transferResult = AccountTransfer.AcceptTransfer(ref fromAccount, ref toAccount, accountTransfer.TransferAmount);
                if (transferResult.isSuccess == false)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, transferResult.errorMessage ?? "Failed to accept");
                }
                accountTransfer.AccountTransferStatus = AccountTransferStatus.Accepted;

                var log = AccountTransferLog.CreateForApproveTransfer(accountTransfer, userId);
                _writeOnlyCtx.Set<AccountTransferLog>().Add(log);

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

        public async Task<(ExecutionState executionState, string message)> CancelTransfer(long accountTransferId, long userId)
        {
            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var accountTransfer = await _writeOnlyCtx.Set<AccountTransfer>()
                    .Where(x => x.Id == accountTransferId)
                    .FirstOrDefaultAsync();
                if (accountTransfer is null)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { accountTransfer.ToAccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, "Current user is not assigned to this account");
                }

                if (accountTransfer.AccountTransferApprovalProcess != AccountTransferApprovalProcess.Completed)
                {
                    return (ExecutionState.Failure, "Approval process is not completed yet");
                }

                if (AccountTransfer.IsStatusPending(accountTransfer.AccountTransferStatus) == false)
                {
                    return (ExecutionState.Failure, "Account status must be in pending");
                }

                var accounts = await _writeOnlyCtx.Set<Account>()
                    .Where(x => x.Id == accountTransfer.ToAccountId || x.Id == accountTransfer.FromAccountId)
                    .ToListAsync();
                if (accounts.Count != 2)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var toAccount = accounts.Single(x => x.Id == accountTransfer.ToAccountId);
                var fromAccount = accounts.Single(x => x.Id == accountTransfer.FromAccountId);

                var cancelResult = AccountTransfer.Cancel(ref fromAccount, accountTransfer.TransferAmount);
                if (cancelResult.isSuccess == false)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, cancelResult.errorMessage ?? "Failed to accept");
                }
                accountTransfer.AccountTransferStatus = AccountTransferStatus.Cancel;

                var log = AccountTransferLog.CreateForCancelTransfer(accountTransfer, userId);

                _writeOnlyCtx.Set<AccountTransferLog>().Add(log);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, "Cancelled successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, "An unknown error has been occurred");
            }
        }

        public async Task<(ExecutionState executionState, string message)> RollbackTransfer(long accountTransferId, long userId)
        {
            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var accountTransfer = await _writeOnlyCtx.Set<AccountTransfer>()
                    .Where(x => x.Id == accountTransferId)
                    .FirstOrDefaultAsync();
                if (accountTransfer is null)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var isUserAssignedToBankAccount = await _bankAccountsInformationBusiness.IsUserAssignedToBankAccounts(userId, new long?[] { accountTransfer.ToAccountId });
                if (isUserAssignedToBankAccount == false)
                {
                    return (ExecutionState.Failure, "Current user is not assigned to this account");
                }

                if (accountTransfer.AccountTransferApprovalProcess != AccountTransferApprovalProcess.Completed)
                {
                    return (ExecutionState.Failure, "Approval process is not completed yet");
                }

                if (accountTransfer.AccountTransferStatus != AccountTransferStatus.Accepted)
                {
                    return (ExecutionState.Failure, "Account status must be in approved");
                }

                var accounts = await _writeOnlyCtx.Set<Account>()
                    .Where(x => x.Id == accountTransfer.ToAccountId || x.Id == accountTransfer.FromAccountId)
                    .ToListAsync();
                if (accounts.Count != 2)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                var toAccount = accounts.Single(x => x.Id == accountTransfer.ToAccountId);
                var fromAccount = accounts.Single(x => x.Id == accountTransfer.FromAccountId);

                var rollbackResult = AccountTransfer.RollbackTransfer(ref fromAccount, ref toAccount, accountTransfer.TransferAmount);
                if (rollbackResult.isSuccess == false)
                {
                    await transaction.RollbackAsync();
                    return (ExecutionState.Failure, rollbackResult.errorMessage ?? "Failed to accept");
                }
                accountTransfer.AccountTransferStatus = AccountTransferStatus.Rollback;

                if (toAccount.CurrentAvailableBalance < 0)
                {
                    return (ExecutionState.Failure, "Account does not have enough available balance to rollback");
                }

                var log = AccountTransferLog.CreateForRollbackTransfer(accountTransfer, userId);

                _writeOnlyCtx.Set<AccountTransferLog>().Add(log);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Created, "Rollback successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, "An unknown error has been occurred");
            }
        }

        public async Task<(ExecutionState executionState, string message)> ModifyTransfer(AccountTransfer entity, long userId)
        {
            if (entity.FromAccountId == entity.ToAccountId)
            {
                return (ExecutionState.Failure, "Can not transfer to same account");
            }

            await using var transaction = await _writeOnlyCtx.Database.BeginTransactionAsync();

            try
            {
                var currentAccountTransfer = await _writeOnlyCtx.Set<AccountTransfer>()
                    .Where(x => x.Id == entity.Id)
                    .FirstOrDefaultAsync();
                if (currentAccountTransfer is null)
                {
                    return (ExecutionState.Failure, "Invalid account transfer");
                }

                if (currentAccountTransfer.AccountTransferApprovalProcess == AccountTransferApprovalProcess.Completed)
                {
                    return (ExecutionState.Failure, "Approval process is already completed. You can not change now");
                }

                if (AccountTransfer.IsStatusPending(currentAccountTransfer.AccountTransferStatus) == false)
                {
                    return (ExecutionState.Failure, "Account status must be in pending to edit");
                }

                var fromAccount = await _writeOnlyCtx.Set<Account>().FirstOrDefaultAsync(x => x.Id == entity.FromAccountId);
                if (fromAccount is null)
                {
                    return (ExecutionState.Failure, "Account does not exists");
                }

                if (entity.AccountTransferDetails is not null && entity.AccountTransferDetails.Count > 0)
                {
                    entity.TransferAmount = entity.AccountTransferDetails.Sum(x => x.TransferDetailsAmount);
                }

                if ((fromAccount.CurrentAvailableBalance + currentAccountTransfer.TransferAmount) - entity.TransferAmount < 0)
                {
                    return (ExecutionState.Failure, "Account does not have enough available balance");
                }

                fromAccount.CurrentBlockAmount = (fromAccount.CurrentBlockAmount - currentAccountTransfer.TransferAmount) + entity.TransferAmount;

                entity.TransferTransactionTime = DateTime.Now;
                entity.TransferRequestedById = userId;
                entity.AccountTransferStatus = AccountTransferStatus.PendingModified;

                if (entity.AccountTransferLogs is null)
                {
                    entity.AccountTransferLogs = new List<AccountTransferLog>();
                }
                entity.AccountTransferLogs.Add(AccountTransferLog.CreateForModifyTransfer(currentAccountTransfer, userId, entity));

                _writeOnlyCtx.Set<AccountTransfer>().Update(entity);

                await _writeOnlyCtx.SaveChangesAsync();
                await transaction.CommitAsync();

                return (ExecutionState.Updated, "Modified successfully");
            }
            catch
            {
                await transaction.RollbackAsync();

                return (ExecutionState.Failure, "An unknown error has been occurred");
            }
        }

        public override Task<(ExecutionState executionState, AccountTransfer entity, string message)> CreateAsync(AccountTransfer entity)
        {
            throw new NotImplementedException();
        }

        public override Task<(ExecutionState executionState, AccountTransfer entity, string message)> UpdateAsync(AccountTransfer entity)
        {
            throw new NotImplementedException();
        }

        public override Task<(ExecutionState executionState, bool isDeleted, string message)> SoftDeleteAsync(long key, long userId)
        {
            throw new NotImplementedException();
        }


        ////Add Filter 
        //public async Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListByFilter(ExecutiveCommitteeFilterVM filterData)
        //{


        //    var query = await _writeOnlyCtx.Set<AccountTransfer>().ToListAsync();

        //    // Forest Administration
        //    if (filterData?.ForestCircleId != null && filterData?.ForestCircleId > 0)
        //    {
        //        query = query.Where(x => x.FromAccount.ForestCircleId == filterData.ForestCircleId);
        //    }
        //    if (filterData?.ForestDivisionId != null && filterData?.ForestDivisionId > 0)
        //    {
        //        query = query.Where(x => x.ForestDivisionId == filterData.ForestDivisionId);
        //    }
        //    if (filterData?.ForestRangeId != null && filterData?.ForestRangeId > 0)
        //    {
        //        query = query.Where(x => x.ForestRangeId == filterData.ForestRangeId);
        //    }
        //    if (filterData?.ForestBeatId != null && filterData?.ForestBeatId > 0)
        //    {
        //        query = query.Where(x => x.ForestBeatId == filterData.ForestBeatId);
        //    }


        //    // Civil Administration
        //    if (filterData?.DivisionId != null && filterData?.DivisionId > 0)
        //    {
        //        query = query.Where(x => x.DivisionId == filterData.DivisionId);
        //    }
        //    if (filterData?.DistrictId != null && filterData?.DistrictId > 0)
        //    {
        //        query = query.Where(x => x.DistrictId == filterData.DistrictId);
        //    }
        //    if (filterData?.UpazillaId != null && filterData?.UpazillaId > 0)
        //    {
        //        query = query.Where(x => x.UpazillaId == filterData.UpazillaId);
        //    }
        //    if (filterData?.UnionId != null && filterData?.UnionId > 0)
        //    {
        //        query = query.Where(x => x.UnionId == filterData.UnionId);
        //    }


        //    return (ExecutionState.Retrieved, result, "Data returned successfully");
        //}



        //New add filter
        public async Task<(ExecutionState executionState, List<AccountTransfer> entity, string message)> ListByFilter(ForestCivilLocationFilter filter)
        {
            try
            {

                IQueryable<AccountTransfer> query = _readOnlyCtx.Set<AccountTransfer>()
                .OrderByDescending(x => x.Id);

                query = query = query.WhereIf(filter.HasForestCircleId, x => x.FromAccount.ForestCircleId == filter.ForestCircleId || x.ToAccount.ForestCircleId == filter.ForestCircleId);
                query = query.WhereIf(filter.HasForestDivisionId, x => x.FromAccount.ForestDivisionId == filter.ForestDivisionId || x.ToAccount.ForestDivisionId == filter.ForestDivisionId);
                query = query.WhereIf(filter.HasForestRangeId, x => x.FromAccount.ForestRangeId == filter.ForestRangeId || x.FromAccount.ForestRangeId == filter.ForestRangeId);
                query = query.WhereIf(filter.HasForestBeatId, x => x.FromAccount.ForestBeatId == filter.ForestBeatId || x.ToAccount.ForestBeatId == filter.ForestBeatId);
                query = query.WhereIf(filter.HasForestFcvVcfId, x => x.FromAccount.ForestFcvVcfId == filter.ForestFcvVcfId || x.ToAccount.ForestFcvVcfId == filter.ForestFcvVcfId);

                //// Civil Administration
                //query = query.WhereIf(filter.HasDivisionId, x => x.TransferRequestedBy.DivisionId == filter.DivisionId);
                //query = query.WhereIf(filter.HasDistrictId, x => x.TransferRequestedBy.DistrictId == filter.DistrictId);
                //query = query.WhereIf(filter.HasUpazillaId, x => x.TransferRequestedBy.UpazillaId == filter.UpazillaId);
                //query = query.WhereIf(filter.HasUnionId, x => x.TransferRequestedBy.UnionId == filter.UnionId);

                //// Others
                //query = query.WhereIf(filter.HasGender, x => x.Gender == filter.Gender);
                //query = query.WhereIf(filter.HasCipWealth, x => x.CipWealth == filter.CipWealth);
                //query = query.WhereIf(filter.HasNID, x => x.NID == filter.NID);
                //query = query.WhereIf(filter.HasEthnicityId, x => x.EthnicityId == filter.EthnicityId);

                var result = await query.Include(x => x.FromAccount)
                .Include(x => x.ToAccount)
                .Include(x => x.FinancialYear).ToListAsync();


                return (ExecutionState.Retrieved, result, "Data returned successfully.");


                //return (ExecutionState.Retrieved, result, "Data returned successfully.");
            }
            catch (Exception)
            {
                return (ExecutionState.Failure, new List<AccountTransfer>()!, "Unexpected error occurred.");
            }
        }


        public override async Task<(ExecutionState executionState, AccountTransfer entity, string message)> GetAsync(long key)
        {

            return await base.GetAsync(new FilterOptions<AccountTransfer>
            {
                FilterExpression = e => e.Id == key,
                IncludeExpression = e => e.Include(x => x.FromAccount).
                                          ThenInclude(y => y.ForestCircle)
                                         .Include(x => x.ToAccount)
                                         .ThenInclude(y => y.ForestCircle)
                                         .Include(x => x.FinancialYear)
                                         .Include(e => e.AccountTransferDetails)
                                         .Include(e => e.AccountTransferLogs)
                                         .Include(e => e.AccountTransferApprovals)
            });
        }

    }
}