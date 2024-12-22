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
    public class LaborInformationService : BaseService<LaborInformationVM, LaborInformation>, ILaborInformationService
    {
        public IMapper _mapper;

        public LaborInformationService(ILaborInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LaborInformation CastModelToEntity(LaborInformationVM model)
        {
            return _mapper.Map<LaborInformation>(model);
        }

        public override LaborInformationVM CastEntityToModel(LaborInformation entity)
        {
            return _mapper.Map<LaborInformationVM>(entity);
        }

        public override IList<LaborInformationVM> CastEntityToModel(IQueryable<LaborInformation> entity)
        {
            return _mapper.Map<IList<LaborInformationVM>>(entity).ToList();
        }
    }
}