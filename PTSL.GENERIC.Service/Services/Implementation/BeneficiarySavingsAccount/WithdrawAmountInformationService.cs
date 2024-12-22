using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount
{
    public class WithdrawAmountInformationService : BaseService<WithdrawAmountInformationVM, WithdrawAmountInformation>, IWithdrawAmountInformationService
    {
        public IMapper _mapper;

        public WithdrawAmountInformationService(IWithdrawAmountInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override WithdrawAmountInformation CastModelToEntity(WithdrawAmountInformationVM model)
        {
            try
            {
                return _mapper.Map<WithdrawAmountInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override WithdrawAmountInformationVM CastEntityToModel(WithdrawAmountInformation entity)
        {
            try
            {
                var model = _mapper.Map<WithdrawAmountInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<WithdrawAmountInformationVM> CastEntityToModel(IQueryable<WithdrawAmountInformation> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<WithdrawAmountInformationVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
