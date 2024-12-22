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
    public class LaborInformationFileService : BaseService<LaborInformationFileVM, LaborInformationFile>, ILaborInformationFileService
    {
        public IMapper _mapper;

        public LaborInformationFileService(ILaborInformationFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override LaborInformationFile CastModelToEntity(LaborInformationFileVM model)
        {
            return _mapper.Map<LaborInformationFile>(model);
        }

        public override LaborInformationFileVM CastEntityToModel(LaborInformationFile entity)
        {
            return _mapper.Map<LaborInformationFileVM>(entity);
        }

        public override IList<LaborInformationFileVM> CastEntityToModel(IQueryable<LaborInformationFile> entity)
        {
            return _mapper.Map<IList<LaborInformationFileVM>>(entity).ToList();
        }
    }
}