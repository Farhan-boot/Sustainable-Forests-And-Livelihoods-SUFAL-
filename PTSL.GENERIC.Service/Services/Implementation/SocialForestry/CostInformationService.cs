using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public class CostInformationService : BaseService<CostInformationVM, CostInformation>, ICostInformationService
    {
        public IMapper _mapper;

        public CostInformationService(ICostInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CostInformation CastModelToEntity(CostInformationVM model)
        {
            return _mapper.Map<CostInformation>(model);
        }

        public override CostInformationVM CastEntityToModel(CostInformation entity)
        {
            return _mapper.Map<CostInformationVM>(entity);
        }

        public override IList<CostInformationVM> CastEntityToModel(IQueryable<CostInformation> entity)
        {
            return _mapper.Map<IList<CostInformationVM>>(entity).ToList();
        }
    }
}