using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class RepaymentLDFHistoryService : BaseService<RepaymentLDFHistoryVM, RepaymentLDFHistory>, IRepaymentLDFHistoryService
    {
        public IMapper _mapper;

        public RepaymentLDFHistoryService(IRepaymentLDFHistoryBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override RepaymentLDFHistory CastModelToEntity(RepaymentLDFHistoryVM model)
        {
            return _mapper.Map<RepaymentLDFHistory>(model);
        }

        public override RepaymentLDFHistoryVM CastEntityToModel(RepaymentLDFHistory entity)
        {
            return _mapper.Map<RepaymentLDFHistoryVM>(entity);
        }

        public override IList<RepaymentLDFHistoryVM> CastEntityToModel(IQueryable<RepaymentLDFHistory> entity)
        {
            return _mapper.Map<IList<RepaymentLDFHistoryVM>>(entity).ToList();
        }
    }
}