using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public class NurseryTypeService : BaseService<NurseryTypeVM, NurseryType>, INurseryTypeService
    {
        public IMapper _mapper;

        public NurseryTypeService(INurseryTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NurseryType CastModelToEntity(NurseryTypeVM model)
        {
            return _mapper.Map<NurseryType>(model);
        }

        public override NurseryTypeVM CastEntityToModel(NurseryType entity)
        {
            return _mapper.Map<NurseryTypeVM>(entity);
        }

        public override IList<NurseryTypeVM> CastEntityToModel(IQueryable<NurseryType> entity)
        {
            return _mapper.Map<IList<NurseryTypeVM>>(entity).ToList();
        }
    }
}