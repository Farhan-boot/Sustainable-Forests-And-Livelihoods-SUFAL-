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
    public class InspectionDetailsService : BaseService<InspectionDetailsVM, InspectionDetails>, IInspectionDetailsService
    {
        public IMapper _mapper;

        public InspectionDetailsService(IInspectionDetailsBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override InspectionDetails CastModelToEntity(InspectionDetailsVM model)
        {
            return _mapper.Map<InspectionDetails>(model);
        }

        public override InspectionDetailsVM CastEntityToModel(InspectionDetails entity)
        {
            return _mapper.Map<InspectionDetailsVM>(entity);
        }

        public override IList<InspectionDetailsVM> CastEntityToModel(IQueryable<InspectionDetails> entity)
        {
            return _mapper.Map<IList<InspectionDetailsVM>>(entity).ToList();
        }
    }
}