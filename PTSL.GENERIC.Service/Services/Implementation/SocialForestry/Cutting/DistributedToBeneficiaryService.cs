using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class DistributedToBeneficiaryService : BaseService<DistributedToBeneficiaryVM, DistributedToBeneficiary>, IDistributedToBeneficiaryService
    {
        public IMapper _mapper;

        public DistributedToBeneficiaryService(IDistributedToBeneficiaryBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DistributedToBeneficiary CastModelToEntity(DistributedToBeneficiaryVM model)
        {
            return _mapper.Map<DistributedToBeneficiary>(model);
        }

        public override DistributedToBeneficiaryVM CastEntityToModel(DistributedToBeneficiary entity)
        {
            return _mapper.Map<DistributedToBeneficiaryVM>(entity);
        }

        public override IList<DistributedToBeneficiaryVM> CastEntityToModel(IQueryable<DistributedToBeneficiary> entity)
        {
            return _mapper.Map<IList<DistributedToBeneficiaryVM>>(entity).ToList();
        }
    }
}