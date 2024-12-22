using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class IndividualLDFInfoFormService : BaseService<IndividualLDFInfoFormVM, IndividualLDFInfoForm>, IIndividualLDFInfoFormService
    {
        private readonly IIndividualLDFInfoFormBusiness _business;
        public IMapper _mapper;

        public IndividualLDFInfoFormService(IIndividualLDFInfoFormBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override IndividualLDFInfoForm CastModelToEntity(IndividualLDFInfoFormVM model)
        {
            return _mapper.Map<IndividualLDFInfoForm>(model);
        }

        public override IndividualLDFInfoFormVM CastEntityToModel(IndividualLDFInfoForm entity)
        {
            return _mapper.Map<IndividualLDFInfoFormVM>(entity);
        }

        public override IList<IndividualLDFInfoFormVM> CastEntityToModel(IQueryable<IndividualLDFInfoForm> entity)
        {
            return _mapper.Map<IList<IndividualLDFInfoFormVM>>(entity).ToList();
        }

        public IList<IndividualLDFInfoFormVM> CastEntityListToModel(IList<IndividualLDFInfoForm> entity)
        {
            return _mapper.Map<IList<IndividualLDFInfoFormVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<IndividualLDFInfoFormVM> entity, string message)> ListByFilter(IndividualLDFFilterVM filter)
        {
            var result = await _business.ListByFilter(filter);

            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, _mapper.Map<PaginationResutl<IndividualLDFInfoFormVM>>(result.entity), result.message);
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, null!, result.message);
        }
        public async Task<(ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message)> ListByFilterBasic(IndividualLDFFilterVM filter)
        {
            var result = await _business.ListByFilterBasic(filter);

            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, _mapper.Map<List<IndividualLDFInfoFormVM>>(result.entity), result.message);
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, null!, result.message);
        }

        public Task<(ExecutionState executionState, double amount, string message)> GetLDFAmountForBeneficiary(long beneficiaryId)
        {
            return _business.GetLDFAmountForBeneficiary(beneficiaryId);
        }
    }
}