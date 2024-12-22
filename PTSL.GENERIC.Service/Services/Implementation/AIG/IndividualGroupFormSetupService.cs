using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.AIG
{
    public class IndividualGroupFormSetupService : BaseService<IndividualGroupFormSetupVM, IndividualGroupFormSetup>, IIndividualGroupFormSetupService
    {
        public IMapper _mapper;

        public IndividualGroupFormSetupService(IIndividualGroupFormSetupBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override IndividualGroupFormSetup CastModelToEntity(IndividualGroupFormSetupVM model)
        {
            return _mapper.Map<IndividualGroupFormSetup>(model);
        }

        public override IndividualGroupFormSetupVM CastEntityToModel(IndividualGroupFormSetup entity)
        {
            return _mapper.Map<IndividualGroupFormSetupVM>(entity);
        }

        public override IList<IndividualGroupFormSetupVM> CastEntityToModel(IQueryable<IndividualGroupFormSetup> entity)
        {
            return _mapper.Map<IList<IndividualGroupFormSetupVM>>(entity).ToList();
        }
    }
}