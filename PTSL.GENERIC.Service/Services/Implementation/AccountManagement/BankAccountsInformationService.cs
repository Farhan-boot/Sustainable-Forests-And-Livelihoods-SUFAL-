using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.ForestManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Enum.AccountManagement;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class BankAccountsInformationService : BaseService<BankAccountsInformationVM, BankAccountsInformation>, IBankAccountsInformationService
    {
        public IMapper _mapper;
        private readonly IBankAccountsInformationBusiness _business;

        public BankAccountsInformationService(IBankAccountsInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override BankAccountsInformation CastModelToEntity(BankAccountsInformationVM model)
        {
            return _mapper.Map<BankAccountsInformation>(model);
        }

        public override BankAccountsInformationVM CastEntityToModel(BankAccountsInformation entity)
        {
            return _mapper.Map<BankAccountsInformationVM>(entity);
        }

        public override IList<BankAccountsInformationVM> CastEntityToModel(IQueryable<BankAccountsInformation> entity)
        {
            return _mapper.Map<IList<BankAccountsInformationVM>>(entity).ToList();
        }

        public List<BankAccountsInformationVM> CastEntityListToModel(List<BankAccountsInformation> entity)
        {
            return _mapper.Map<List<BankAccountsInformationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, List<BankAccountsInformationVM> entity, string message)> GetBankAccountsInformationByUserId(long? userId, AccountAllowedFundExpense? accountAllowedFundExpense)
        {
            var result = await _business.GetBankAccountsInformationByUserId(userId, accountAllowedFundExpense);

            if (result.entity is not null)
            {
                return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new List<BankAccountsInformationVM>(), result.message);
        }

    }
}