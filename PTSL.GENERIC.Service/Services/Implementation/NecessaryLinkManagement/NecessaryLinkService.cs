using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Entity.NecessaryLinkManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.NecessaryLinkManagement;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.NecessaryLinkManagement
{
    public class NecessaryLinkService : BaseService<NecessaryLinkVM, NecessaryLink>, INecessaryLinkService
    {
        public IMapper _mapper;

        public NecessaryLinkService(INecessaryLinkBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NecessaryLink CastModelToEntity(NecessaryLinkVM model)
        {
            return _mapper.Map<NecessaryLink>(model);
        }

        public override NecessaryLinkVM CastEntityToModel(NecessaryLink entity)
        {
            return _mapper.Map<NecessaryLinkVM>(entity);
        }

        public override IList<NecessaryLinkVM> CastEntityToModel(IQueryable<NecessaryLink> entity)
        {
            return _mapper.Map<IList<NecessaryLinkVM>>(entity).ToList();
        }
    }
}