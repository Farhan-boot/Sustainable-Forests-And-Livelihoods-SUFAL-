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
    public class SavingsAmountInformationService : BaseService<SavingsAmountInformationVM, SavingsAmountInformation>, ISavingsAmountInformationService
    {
        public IMapper _mapper;

        public SavingsAmountInformationService(ISavingsAmountInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override SavingsAmountInformation CastModelToEntity(SavingsAmountInformationVM model)
        {
            try
            {
                return _mapper.Map<SavingsAmountInformation>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override SavingsAmountInformationVM CastEntityToModel(SavingsAmountInformation entity)
        {
            try
            {
                var model = _mapper.Map<SavingsAmountInformationVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<SavingsAmountInformationVM> CastEntityToModel(IQueryable<SavingsAmountInformation> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<SavingsAmountInformationVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
