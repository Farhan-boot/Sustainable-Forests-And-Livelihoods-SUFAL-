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
    public class CostTypeService : BaseService<CostTypeVM, CostType>, ICostTypeService
    {
        public IMapper _mapper;

        public CostTypeService(ICostTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CostType CastModelToEntity(CostTypeVM model)
        {
            return _mapper.Map<CostType>(model);
        }

        public override CostTypeVM CastEntityToModel(CostType entity)
        {
            return _mapper.Map<CostTypeVM>(entity);
        }

        public override IList<CostTypeVM> CastEntityToModel(IQueryable<CostType> entity)
        {
            return _mapper.Map<IList<CostTypeVM>>(entity).ToList();
        }
    }
}