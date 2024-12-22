using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class RepaymentLDFService : BaseService<RepaymentLDFVM, RepaymentLDF>, IRepaymentLDFService
    {
        private readonly IRepaymentLDFBusiness _business;
        public IMapper _mapper;

        public RepaymentLDFService(IRepaymentLDFBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override RepaymentLDF CastModelToEntity(RepaymentLDFVM model)
        {
            return _mapper.Map<RepaymentLDF>(model);
        }

        public override RepaymentLDFVM CastEntityToModel(RepaymentLDF entity)
        {
            return _mapper.Map<RepaymentLDFVM>(entity);
        }

        public override IList<RepaymentLDFVM> CastEntityToModel(IQueryable<RepaymentLDF> entity)
        {
            return _mapper.Map<IList<RepaymentLDFVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListByFirstLDFId(long ldfId)
        {
            var result = await _business.GetListByFirstLDFId(ldfId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListBySecondLDFId(long ldfId)
        {
            var result = await _business.GetListBySecondLDFId(ldfId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListByAIGId(long ldfId)
        {
            var result = await _business.GetListByAIGId(ldfId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFHistoryVM> entity, string message)> ListHistory(long repaymentId)
        {
            var result = await _business.ListHistory(repaymentId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: _mapper.Map<List<RepaymentLDFHistoryVM>>(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> CompletePayment(CompleteRepaymentVM completeRepayment, long userId)
        {
            var result = await _business.CompletePayment(completeRepayment, userId);
            if (result.executionState == ExecutionState.Success)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> RemovePayment(long repaymentId, long userId)
        {
            var result = await _business.RemovePayment(repaymentId, userId);
            if (result.executionState == ExecutionState.Success)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, RepaymentLDFVM entity, string message)> LockUnlockPayment(long repaymentId, long userId, bool shouldLock)
        {
            var result = await _business.LockUnlockPayment(repaymentId, userId, shouldLock);
            if (result.executionState == ExecutionState.Success)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, IList<RepaymentLDFVM> entity, string message)> GetListWithProgress(long aigId)
        {
            var result = await _business.GetListWithProgress(aigId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }
    }
}