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
    public class ConcernedOfficialService : BaseService<ConcernedOfficialVM, ConcernedOfficial>, IConcernedOfficialService
    {
        public IMapper _mapper;

        public ConcernedOfficialService(IConcernedOfficialBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ConcernedOfficial CastModelToEntity(ConcernedOfficialVM model)
        {
            return _mapper.Map<ConcernedOfficial>(model);
        }

        public override ConcernedOfficialVM CastEntityToModel(ConcernedOfficial entity)
        {
            return _mapper.Map<ConcernedOfficialVM>(entity);
        }

        public override IList<ConcernedOfficialVM> CastEntityToModel(IQueryable<ConcernedOfficial> entity)
        {
            return _mapper.Map<IList<ConcernedOfficialVM>>(entity).ToList();
        }
    }
}