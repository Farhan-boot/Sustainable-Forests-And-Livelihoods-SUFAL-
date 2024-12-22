using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount
{
    public class SavingsAccountService : BaseService<SavingsAccountVM, SavingsAccount>, ISavingsAccountService
    {
        private readonly ISavingsAccountBusiness _business;
        public IMapper _mapper;

        public SavingsAccountService(ISavingsAccountBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override SavingsAccount CastModelToEntity(SavingsAccountVM model)
        {
            try
            {
                return _mapper.Map<SavingsAccount>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override SavingsAccountVM CastEntityToModel(SavingsAccount entity)
        {
            try
            {
                var model = _mapper.Map<SavingsAccountVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<SavingsAccountVM> CastEntityToModel(IQueryable<SavingsAccount> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<SavingsAccountVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<SavingsAccountVM> CastEntityListToModel(List<SavingsAccount> entity)
        {
            return _mapper.Map<List<SavingsAccountVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<SavingsAccountVM> entity, string message)> GetByFilter(SavingsAccountFilterVM filterData)
        {
            var result = await _business.GetByFilter(filterData);

            if (result.entity is not null)
            {
                return (result.executionState, _mapper.Map<PaginationResutl<SavingsAccountVM>>(result.entity), result.message);
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new PaginationResutl<SavingsAccountVM>(), result.message);
            //return (result.executionState, new List<SavingsAccountVM>(), result.message);
        }
    }
}
