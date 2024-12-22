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
    public class LaborCostTypeService : BaseService<LaborCostTypeVM, LaborCostType>, ILaborCostTypeService
    {
        public IMapper _mapper;

        public LaborCostTypeService(ILaborCostTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LaborCostType CastModelToEntity(LaborCostTypeVM model)
        {
            return _mapper.Map<LaborCostType>(model);
        }

        public override LaborCostTypeVM CastEntityToModel(LaborCostType entity)
        {
            return _mapper.Map<LaborCostTypeVM>(entity);
        }

        public override IList<LaborCostTypeVM> CastEntityToModel(IQueryable<LaborCostType> entity)
        {
            return _mapper.Map<IList<LaborCostTypeVM>>(entity).ToList();
        }
    }
}