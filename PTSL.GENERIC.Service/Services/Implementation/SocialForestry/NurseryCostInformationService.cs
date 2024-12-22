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
    public class NurseryCostInformationService : BaseService<NurseryCostInformationVM, NurseryCostInformation>, INurseryCostInformationService
    {
        public IMapper _mapper;

        public NurseryCostInformationService(INurseryCostInformationBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override NurseryCostInformation CastModelToEntity(NurseryCostInformationVM model)
        {
            return _mapper.Map<NurseryCostInformation>(model);
        }

        public override NurseryCostInformationVM CastEntityToModel(NurseryCostInformation entity)
        {
            return _mapper.Map<NurseryCostInformationVM>(entity);
        }

        public override IList<NurseryCostInformationVM> CastEntityToModel(IQueryable<NurseryCostInformation> entity)
        {
            return _mapper.Map<IList<NurseryCostInformationVM>>(entity).ToList();
        }
    }
}