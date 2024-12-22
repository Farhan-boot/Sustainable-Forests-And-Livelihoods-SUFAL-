using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.SocialForestry;

namespace PTSL.GENERIC.Service.Services.Implementation.SocialForestry
{
    public class NurseryCostInformationFileService : BaseService<NurseryCostInformationFileVM, NurseryCostInformationFile>, INurseryCostInformationFileService
    {
        public IMapper _mapper;

        public NurseryCostInformationFileService(INurseryCostInformationFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NurseryCostInformationFile CastModelToEntity(NurseryCostInformationFileVM model)
        {
            return _mapper.Map<NurseryCostInformationFile>(model);
        }

        public override NurseryCostInformationFileVM CastEntityToModel(NurseryCostInformationFile entity)
        {
            return _mapper.Map<NurseryCostInformationFileVM>(entity);
        }

        public override IList<NurseryCostInformationFileVM> CastEntityToModel(IQueryable<NurseryCostInformationFile> entity)
        {
            return _mapper.Map<IList<NurseryCostInformationFileVM>>(entity).ToList();
        }
    }
}