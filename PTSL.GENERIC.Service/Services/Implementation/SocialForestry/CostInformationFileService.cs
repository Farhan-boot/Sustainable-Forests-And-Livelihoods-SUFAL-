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
    public class CostInformationFileService : BaseService<CostInformationFileVM, CostInformationFile>, ICostInformationFileService
    {
        public IMapper _mapper;

        public CostInformationFileService(ICostInformationFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override CostInformationFile CastModelToEntity(CostInformationFileVM model)
        {
            return _mapper.Map<CostInformationFile>(model);
        }

        public override CostInformationFileVM CastEntityToModel(CostInformationFile entity)
        {
            return _mapper.Map<CostInformationFileVM>(entity);
        }

        public override IList<CostInformationFileVM> CastEntityToModel(IQueryable<CostInformationFile> entity)
        {
            return _mapper.Map<IList<CostInformationFileVM>>(entity).ToList();
        }
    }
}