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
    public class AccountTransferApprovalService : BaseService<AccountTransferApprovalVM, AccountTransferApproval>, IAccountTransferApprovalService
    {
        public IMapper _mapper;

        public AccountTransferApprovalService(IAccountTransferApprovalBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override AccountTransferApproval CastModelToEntity(AccountTransferApprovalVM model)
        {
            return _mapper.Map<AccountTransferApproval>(model);
        }

        public override AccountTransferApprovalVM CastEntityToModel(AccountTransferApproval entity)
        {
            return _mapper.Map<AccountTransferApprovalVM>(entity);
        }

        public override IList<AccountTransferApprovalVM> CastEntityToModel(IQueryable<AccountTransferApproval> entity)
        {
            return _mapper.Map<IList<AccountTransferApprovalVM>>(entity).ToList();
        }
    }
}