using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class AccountService : BaseService<AccountVM, Account>, IAccountService
    {
        private readonly IAccountBusiness _business;
        public IMapper Mapper;

        public AccountService(IAccountBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            Mapper = mapper;
        }

        public override Account CastModelToEntity(AccountVM model)
        {
            return Mapper.Map<Account>(model);
        }

        public override AccountVM CastEntityToModel(Account entity)
        {
            return Mapper.Map<AccountVM>(entity);
        }

        public override IList<AccountVM> CastEntityToModel(IQueryable<Account> entity)
        {
            return Mapper.Map<IList<AccountVM>>(entity).ToList();
        }

        public PaginationResutl<AccountVM> CastPaginatedEntityListToModel(PaginationResutl<Account> entity)
        {
            return Mapper.Map<PaginationResutl<AccountVM>>(entity);
        }

        public List<AccountVM> CastEntityListToModel(List<Account> entity)
        {
            return Mapper.Map<List<AccountVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<AccountVM> entity, string message)> GetByFilter(AccountFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<AccountVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, PaginationResutl<Account> entity, string message) result = await _business.GetByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {

                    returnResponse = (result.executionState, CastPaginatedEntityListToModel(result.entity), result.message);
                }
                else
                {
                    returnResponse = (result.executionState, entity: null, result.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, List<AccountVM> entity, string message)> GetByFilterBasic(AccountFilterVM filterData)
        {
            (ExecutionState executionState, List<AccountVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, List<Account> entity, string message) result = await _business.GetByFilterBasic(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (result.executionState, CastEntityListToModel(result.entity), result.message);
                }
                else
                {
                    returnResponse = (result.executionState, entity: null, result.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public Task<(ExecutionState executionState, AccountCurrentBalanceVM data, string message)> GetCurrentBalance(long id)
        {
            return _business.GetCurrentBalance(id);
        }
    }
}