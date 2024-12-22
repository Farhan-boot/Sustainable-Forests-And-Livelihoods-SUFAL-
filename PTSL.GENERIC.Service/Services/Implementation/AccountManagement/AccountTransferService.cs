using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class AccountTransferService : BaseService<AccountTransferVM, AccountTransfer>, IAccountTransferService
    {
        private readonly IAccountTransferBusiness _business;
        public IMapper _mapper;

        public AccountTransferService(IAccountTransferBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override AccountTransfer CastModelToEntity(AccountTransferVM model)
        {
            return _mapper.Map<AccountTransfer>(model);
        }

        public override AccountTransferVM CastEntityToModel(AccountTransfer entity)
        {
            return _mapper.Map<AccountTransferVM>(entity);
        }

        public override IList<AccountTransferVM> CastEntityToModel(IQueryable<AccountTransfer> entity)
        {
            return _mapper.Map<IList<AccountTransferVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, AccountTransferVM entity, string message)> Transfer(AccountTransferVM model, long userId, long permissionHeaderSettingsId)
        {
            var entity = CastModelToEntity(model);
            var result = await _business.Transfer(entity, userId, permissionHeaderSettingsId);

            return (result.executionState, CastEntityToModel(result.entity), result.message);
        }

        public Task<(ExecutionState executionState, string message)> AcceptTransfer(long accountTransferId, long userId)
        {
            return _business.AcceptTransfer(accountTransferId, userId);
        }

        public Task<(ExecutionState executionState, string message)> CancelTransfer(long accountTransferId, long userId)
        {
            return _business.CancelTransfer(accountTransferId, userId);
        }

        public Task<(ExecutionState executionState, string message)> RollbackTransfer(long accountTransferId, long userId)
        {
            return _business.RollbackTransfer(accountTransferId, userId);
        }

        public Task<(ExecutionState executionState, string message)> ModifyTransfer(AccountTransferVM entity, long userId)
        {
            return _business.ModifyTransfer(CastModelToEntity(entity), userId);
        }

        public async Task<(ExecutionState executionState, List<AccountTransferVM> entity, string message)> ListForCashIn(long currentUserId)
        {
            var (executionState, entity, message) = await _business.ListForCashIn(currentUserId);
            return (executionState, _mapper.Map<List<AccountTransferVM>>(entity), message);
        }

        public async Task<(ExecutionState executionState, List<AccountTransferVM> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId)
        {
            var (executionState, entity, message) = await _business.ListForRequestList(permissionHeaderSettingsId, currentUserId);
            return (executionState, _mapper.Map<List<AccountTransferVM>>(entity), message);
        }

        public Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountForwardRequestVM request)
        {
            return _business.ForwardApproval(currentUserId, request);
        }

        public Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId)
        {
            return _business.LastStageApproval(currentUserId, accountTransferId, permissionHeaderSettingsId);
        }

        public async Task<(ExecutionState executionState, List<AccountTransferVM> data, string message)> ListByFilter(ForestCivilLocationFilter filter)
        {
            var data = await _business.ListByFilter(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<List<AccountTransferVM>>(data.entity), data.message);
        }
    }
}