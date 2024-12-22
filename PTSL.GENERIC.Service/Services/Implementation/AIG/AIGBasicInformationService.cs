using AutoMapper;

using Azure;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class AIGBasicInformationService : BaseService<AIGBasicInformationVM, AIGBasicInformation>, IAIGBasicInformationService
    {
        private readonly IAIGBasicInformationBusiness _business;
        public IMapper _mapper;

        public AIGBasicInformationService(IAIGBasicInformationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override AIGBasicInformation CastModelToEntity(AIGBasicInformationVM model)
        {
            return _mapper.Map<AIGBasicInformation>(model);
        }

        public override AIGBasicInformationVM CastEntityToModel(AIGBasicInformation entity)
        {
            return _mapper.Map<AIGBasicInformationVM>(entity);
        }

        public override IList<AIGBasicInformationVM> CastEntityToModel(IQueryable<AIGBasicInformation> entity)
        {
            return _mapper.Map<IList<AIGBasicInformationVM>>(entity).ToList();
        }

        public IList<AIGBasicInformationVM> CastEntityListToModel(IList<AIGBasicInformation> entity)
        {
            return _mapper.Map<IList<AIGBasicInformationVM>>(entity);
        }

        public async Task<(ExecutionState executionState, AIGBasicInformationVM entity, string message)> GetIncludeFirstSecondAndBen(long aigId)
        {
            var result = await _business.GetIncludeFirstSecondAndBen(aigId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<AIGBasicInformationVM> entity, string message)> GetAIGByFilter(AIGBasicInformationFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<AIGBasicInformationVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PaginationResutl<AIGBasicInformation> entity, string message) result = await _business.GetAIGByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (result.executionState, _mapper.Map<PaginationResutl<AIGBasicInformationVM>>(result.entity), result.message);
                    //returnResponse = (result.executionState, CastEntityListToModel(result.entity), result.message);
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

        public async Task<(ExecutionState executionState, List<AIGBasicInformationVM> entity, string message)> RepaymentReport(RepaymentReportFilterVM filter)
        {
            var result = await _business.RepaymentReport(filter);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: _mapper.Map<List<AIGBasicInformationVM>>(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message)> BeneficiaryWiseRepaymentProgress(long surveyId)
        {
            var result = await _business.BeneficiaryWiseRepaymentProgress(surveyId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: _mapper.Map<IList<AIGBasicInformationVM>>(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }
    }
}