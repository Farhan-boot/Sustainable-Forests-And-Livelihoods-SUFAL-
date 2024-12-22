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
    public class PlantationFileService : BaseService<PlantationFileVM, PlantationFile>, IPlantationFileService
    {
        public IMapper _mapper;

        public PlantationFileService(IPlantationFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override PlantationFile CastModelToEntity(PlantationFileVM model)
        {
            return _mapper.Map<PlantationFile>(model);
        }

        public override PlantationFileVM CastEntityToModel(PlantationFile entity)
        {
            return _mapper.Map<PlantationFileVM>(entity);
        }

        public override IList<PlantationFileVM> CastEntityToModel(IQueryable<PlantationFile> entity)
        {
            return _mapper.Map<IList<PlantationFileVM>>(entity).ToList();
        }
    }
}