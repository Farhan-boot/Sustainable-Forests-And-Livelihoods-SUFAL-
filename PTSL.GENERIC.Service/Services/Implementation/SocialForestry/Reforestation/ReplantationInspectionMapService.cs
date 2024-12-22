using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Reforestation;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Reforestation
{
    public class ReplantationInspectionMapService : BaseService<ReplantationInspectionMapVM, ReplantationInspectionMap>, IReplantationInspectionMapService
    {
        public IMapper _mapper;

        public ReplantationInspectionMapService(IReplantationInspectionMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ReplantationInspectionMap CastModelToEntity(ReplantationInspectionMapVM model)
        {
            return _mapper.Map<ReplantationInspectionMap>(model);
        }

        public override ReplantationInspectionMapVM CastEntityToModel(ReplantationInspectionMap entity)
        {
            return _mapper.Map<ReplantationInspectionMapVM>(entity);
        }

        public override IList<ReplantationInspectionMapVM> CastEntityToModel(IQueryable<ReplantationInspectionMap> entity)
        {
            return _mapper.Map<IList<ReplantationInspectionMapVM>>(entity).ToList();
        }
    }
}