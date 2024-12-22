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
    public class AccountTransferLogService : BaseService<AccountTransferLogVM, AccountTransferLog>, IAccountTransferLogService
    {
        public IMapper _mapper;

        public AccountTransferLogService(IAccountTransferLogBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override AccountTransferLog CastModelToEntity(AccountTransferLogVM model)
        {
            return _mapper.Map<AccountTransferLog>(model);
        }

        public override AccountTransferLogVM CastEntityToModel(AccountTransferLog entity)
        {
            return _mapper.Map<AccountTransferLogVM>(entity);
        }

        public override IList<AccountTransferLogVM> CastEntityToModel(IQueryable<AccountTransferLog> entity)
        {
            return _mapper.Map<IList<AccountTransferLogVM>>(entity).ToList();
        }
    }
}