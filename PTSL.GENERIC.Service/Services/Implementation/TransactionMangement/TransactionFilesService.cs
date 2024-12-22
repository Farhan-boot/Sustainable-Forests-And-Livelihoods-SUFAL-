using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.TransactionMangement
{
    public class TransactionFilesService : BaseService<TransactionFilesVM, TransactionFiles>, ITransactionFilesService
    {
        public IMapper _mapper;

        public TransactionFilesService(ITransactionFilesBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TransactionFiles CastModelToEntity(TransactionFilesVM model)
        {
            return _mapper.Map<TransactionFiles>(model);
        }

        public override TransactionFilesVM CastEntityToModel(TransactionFiles entity)
        {
            return _mapper.Map<TransactionFilesVM>(entity);
        }

        public override IList<TransactionFilesVM> CastEntityToModel(IQueryable<TransactionFiles> entity)
        {
            return _mapper.Map<IList<TransactionFilesVM>>(entity).ToList();
        }
    }
}