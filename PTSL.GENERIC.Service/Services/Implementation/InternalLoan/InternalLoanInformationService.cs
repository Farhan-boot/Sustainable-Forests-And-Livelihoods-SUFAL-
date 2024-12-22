using AutoMapper;

using Azure;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.InternalLoan
{
    public class InternalLoanInformationService : BaseService<InternalLoanInformationVM, InternalLoanInformation>, IInternalLoanInformationService
    {
        private readonly IInternalLoanInformationBusiness _business;
        public IMapper _mapper;

        public InternalLoanInformationService(IInternalLoanInformationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override InternalLoanInformation CastModelToEntity(InternalLoanInformationVM model)
        {
            return _mapper.Map<InternalLoanInformation>(model);
        }

        public override InternalLoanInformationVM CastEntityToModel(InternalLoanInformation entity)
        {
            return _mapper.Map<InternalLoanInformationVM>(entity);
        }

        public override IList<InternalLoanInformationVM> CastEntityToModel(IQueryable<InternalLoanInformation> entity)
        {
            return _mapper.Map<IList<InternalLoanInformationVM>>(entity).ToList();
        }

        public IList<InternalLoanInformationVM> CastEntityListToModel(IList<InternalLoanInformation> entity)
        {
            return _mapper.Map<IList<InternalLoanInformationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, InternalLoanAvailableAmountVM entity, string message)> GetInternalLoanAvailableAmount(long fcvVcfId)
        {
            var result = await _business.GetInternalLoanAvailableAmount(fcvVcfId);
            

            return (result.executionState, result.entity, result.message);
        }


        public async Task<(ExecutionState executionState, PaginationResutl<InternalLoanInformationVM> entity, string message)> GetInternalLoanInformationByFilter(AIGBasicInformationFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<InternalLoanInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PaginationResutl<InternalLoanInformation> entity, string message) result = await _business.GetInternalLoanInformationByFilter(filterData);


                if (result.executionState == ExecutionState.Retrieved)
                {
                    //returnResponse = (result.executionState, CastEntityListToModel(result.entity), result.message);

                    returnResponse = (result.executionState, _mapper.Map<PaginationResutl<InternalLoanInformationVM>>(result.entity), result.message);
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

    }
}