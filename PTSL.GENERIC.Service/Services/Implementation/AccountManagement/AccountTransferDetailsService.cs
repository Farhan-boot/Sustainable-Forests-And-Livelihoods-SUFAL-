using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AccountManagement;
using PTSL.GENERIC.Common.Entity.AccountManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.AccountManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AccountManagement
{
    public class AccountTransferDetailsService : BaseService<AccountTransferDetailsVM, AccountTransferDetails>, IAccountTransferDetailsService
    {
        public IMapper _mapper;

        public AccountTransferDetailsService(IAccountTransferDetailsBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override AccountTransferDetails CastModelToEntity(AccountTransferDetailsVM model)
        {
            return _mapper.Map<AccountTransferDetails>(model);
        }

        public override AccountTransferDetailsVM CastEntityToModel(AccountTransferDetails entity)
        {
            return _mapper.Map<AccountTransferDetailsVM>(entity);
        }

        public override IList<AccountTransferDetailsVM> CastEntityToModel(IQueryable<AccountTransferDetails> entity)
        {
            return _mapper.Map<IList<AccountTransferDetailsVM>>(entity).ToList();
        }
    }
}