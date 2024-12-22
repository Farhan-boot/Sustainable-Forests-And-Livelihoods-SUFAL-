using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.TransactionMangement
{
    public class TransactionService : BaseService<TransactionVM, Transaction>, ITransactionService
    {
        private readonly ITransactionBusiness _business;
        public IMapper _mapper;

        public TransactionService(ITransactionBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override Transaction CastModelToEntity(TransactionVM model)
        {
            return _mapper.Map<Transaction>(model);
        }

        public override TransactionVM CastEntityToModel(Transaction entity)
        {
            return _mapper.Map<TransactionVM>(entity);
        }

        public override IList<TransactionVM> CastEntityToModel(IQueryable<Transaction> entity)
        {
            return _mapper.Map<IList<TransactionVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, TransactionVM entity, string message)> GetDetails(long key)
        {
            var result = await _business.GetDetails(key);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: CastEntityToModel(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }

        public async Task<(ExecutionState executionState, List<TransactionVM> entity, string message)> GetByFilter(TransactionFilterVM filter)
        {
            var result = await _business.GetByFilter(filter);
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, entity: _mapper.Map<List<TransactionVM>>(result.entity), result.message);
            }

            return (result.executionState, entity: null, result.message);
        }
    }
}
