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
    public class ProjectTypeService : BaseService<ProjectTypeVM, ProjectType>, IProjectTypeService
    {
        public IMapper _mapper;

        public ProjectTypeService(IProjectTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ProjectType CastModelToEntity(ProjectTypeVM model)
        {
            return _mapper.Map<ProjectType>(model);
        }

        public override ProjectTypeVM CastEntityToModel(ProjectType entity)
        {
            return _mapper.Map<ProjectTypeVM>(entity);
        }

        public override IList<ProjectTypeVM> CastEntityToModel(IQueryable<ProjectType> entity)
        {
            return _mapper.Map<IList<ProjectTypeVM>>(entity).ToList();
        }
    }
}