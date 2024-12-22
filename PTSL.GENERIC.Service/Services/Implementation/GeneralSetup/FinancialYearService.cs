using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.GeneralSetup;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.GeneralSetup
{
    public class FinancialYearService : BaseService<FinancialYearVM, FinancialYear>, IFinancialYearService
    {
        public IMapper _mapper;

        public FinancialYearService(IFinancialYearBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FinancialYear CastModelToEntity(FinancialYearVM model)
        {
            return _mapper.Map<FinancialYear>(model);
        }

        public override FinancialYearVM CastEntityToModel(FinancialYear entity)
        {
            return _mapper.Map<FinancialYearVM>(entity);
        }

        public override IList<FinancialYearVM> CastEntityToModel(IQueryable<FinancialYear> entity)
        {
            return _mapper.Map<IList<FinancialYearVM>>(entity).ToList();
        }
    }
}
