using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.InternalLoan;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.InternalLoan
{
    public class RepaymentInternalLoanService : BaseService<RepaymentInternalLoanVM, RepaymentInternalLoan>, IRepaymentInternalLoanService
    {
        private readonly IRepaymentInternalLoanBusiness _business;
        public IMapper _mapper;

        public RepaymentInternalLoanService(IRepaymentInternalLoanBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override RepaymentInternalLoan CastModelToEntity(RepaymentInternalLoanVM model)
        {
            return _mapper.Map<RepaymentInternalLoan>(model);
        }

        public override RepaymentInternalLoanVM CastEntityToModel(RepaymentInternalLoan entity)
        {
            return _mapper.Map<RepaymentInternalLoanVM>(entity);
        }

        public override IList<RepaymentInternalLoanVM> CastEntityToModel(IQueryable<RepaymentInternalLoan> entity)
        {
            return _mapper.Map<IList<RepaymentInternalLoanVM>>(entity).ToList();
        }

        public IList<RepaymentInternalLoanVM> CastEntityListToModel(IList<RepaymentInternalLoan> entity)
        {
            return _mapper.Map<IList<RepaymentInternalLoanVM>>(entity);
        }


        public async Task<(ExecutionState executionState, RepaymentInternalLoanVM entity, string message)> CompletePayment(long repaymentId, long userId)
        {
            var result = await _business.CompletePayment(repaymentId, userId);
            if (result.executionState == ExecutionState.Success)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

    }
}