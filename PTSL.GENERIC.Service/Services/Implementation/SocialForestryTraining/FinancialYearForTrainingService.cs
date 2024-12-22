using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public class FinancialYearForTrainingService : BaseService<FinancialYearForTrainingVM, FinancialYearForTraining>, IFinancialYearForTrainingService
    {
        public IMapper _mapper;

        public FinancialYearForTrainingService(IFinancialYearForTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FinancialYearForTraining CastModelToEntity(FinancialYearForTrainingVM model)
        {
            return _mapper.Map<FinancialYearForTraining>(model);
        }

        public override FinancialYearForTrainingVM CastEntityToModel(FinancialYearForTraining entity)
        {
            return _mapper.Map<FinancialYearForTrainingVM>(entity);
        }

        public override IList<FinancialYearForTrainingVM> CastEntityToModel(IQueryable<FinancialYearForTraining> entity)
        {
            return _mapper.Map<IList<FinancialYearForTrainingVM>>(entity).ToList();
        }
    }
}