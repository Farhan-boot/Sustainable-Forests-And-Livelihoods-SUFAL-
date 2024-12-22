using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class AccountsUserTagLogService : BaseService<AccountsUserTagLogVM, AccountsUserTagLog>, IAccountsUserTagLogService
    {
        public IMapper _mapper;
        private readonly IAccountsUserTagLogBusiness _business;

        public AccountsUserTagLogService(IAccountsUserTagLogBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override AccountsUserTagLog CastModelToEntity(AccountsUserTagLogVM model)
        {
            return _mapper.Map<AccountsUserTagLog>(model);
        }

        public override AccountsUserTagLogVM CastEntityToModel(AccountsUserTagLog entity)
        {
            return _mapper.Map<AccountsUserTagLogVM>(entity);
        }

        public override IList<AccountsUserTagLogVM> CastEntityToModel(IQueryable<AccountsUserTagLog> entity)
        {
            return _mapper.Map<IList<AccountsUserTagLogVM>>(entity).ToList();
        }

        public List<AccountsUserTagLogVM> CastEntityListToModel(List<AccountsUserTagLog> entity)
        {
            return _mapper.Map<List<AccountsUserTagLogVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<AccountsUserTagLogVM> entity, string message)> GetAccountsUserTagLogsByAccountId(long accountId)
        {
            var result = await _business.GetAccountsUserTagLogsByAccountId(accountId);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }
            return (result.executionState, new List<AccountsUserTagLogVM>(), result.message);
        }
    }
}