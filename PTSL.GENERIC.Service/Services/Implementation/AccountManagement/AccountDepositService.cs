using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class AccountDepositService : BaseService<AccountDepositVM, AccountDeposit>, IAccountDepositService
    {
        private readonly IAccountDepositBusiness _business;
        public IMapper _mapper;

        public AccountDepositService(IAccountDepositBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override AccountDeposit CastModelToEntity(AccountDepositVM model)
        {
            return _mapper.Map<AccountDeposit>(model);
        }

        public override AccountDepositVM CastEntityToModel(AccountDeposit entity)
        {
            return _mapper.Map<AccountDepositVM>(entity);
        }

        public override IList<AccountDepositVM> CastEntityToModel(IQueryable<AccountDeposit> entity)
        {
            return _mapper.Map<IList<AccountDepositVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, AccountDepositVM entity, string message)> GetDetailsAsync(long id)
        {
            var (executionState, entity, message) = await _business.GetDetailsAsync(id);
            return (executionState, CastEntityToModel(entity), message);
        }

        public async Task<(ExecutionState executionState, AccountDepositVM entity, string message)> CreateAsync(AccountDepositVM model, long userId, long permissionHeaderSettingsId)
        {
            var (executionState, entity, message) = await _business.CreateAsync(CastModelToEntity(model), userId, permissionHeaderSettingsId);
            return (executionState, CastEntityToModel(entity), message);
        }

        public async Task<(ExecutionState executionState, List<AccountDepositVM> entity, string message)> ListForCashIn(long currentUserId)
        {
            var (executionState, entity, message) = await _business.ListForCashIn(currentUserId);
            return (executionState, _mapper.Map<List<AccountDepositVM>>(entity), message);
        }

        public async Task<(ExecutionState executionState, List<AccountDepositVM> entity, string message)> ListForRequestList(long permissionHeaderSettingsId, long currentUserId)
        {
            var (executionState, entity, message) = await _business.ListForRequestList(permissionHeaderSettingsId, currentUserId);
            return (executionState, _mapper.Map<List<AccountDepositVM>>(entity), message);
        }

        public Task<(ExecutionState executionState, string message)> ForwardApproval(long currentUserId, AccountDepositForwardRequestVM request)
        {
            return _business.ForwardApproval(currentUserId, request);
        }

        public Task<(ExecutionState executionState, string message)> LastStageApproval(long currentUserId, long accountTransferId, long permissionHeaderSettingsId)
        {
            return _business.LastStageApproval(currentUserId, accountTransferId, permissionHeaderSettingsId);
        }

        public Task<(ExecutionState executionState, string message)> AcceptDeposit(long accountTransferId, long userId)
        {
            return _business.AcceptDeposit(accountTransferId, userId);
        }

        public Task<(ExecutionState executionState, string message)> CancelDeposit(long accountTransferId, long userId)
        {
            return _business.CancelDeposit(accountTransferId, userId);
        }



        public async Task<(ExecutionState executionState, PaginationResutl<AccountDepositVM> data, string message)> ListByFilter(ForestCivilLocationFilter filter)
        {
            var data = await _business.ListByFilter(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<PaginationResutl<AccountDepositVM>>(data.entity), data.message);
            //return (data.executionState, _mapper.Map<List<AccountDepositVM>>(data.entity), data.message);
        }



    }
}
