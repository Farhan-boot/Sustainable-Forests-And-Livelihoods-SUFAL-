using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class TypeOfHouseService : BaseService<TypeOfHouseVM, TypeOfHouse>, ITypeOfHouseService
    {
        public IMapper _mapper;

        public TypeOfHouseService(ITypeOfHouseBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TypeOfHouse CastModelToEntity(TypeOfHouseVM model)
        {
            return _mapper.Map<TypeOfHouse>(model);
        }

        public override TypeOfHouseVM CastEntityToModel(TypeOfHouse entity)
        {
            return _mapper.Map<TypeOfHouseVM>(entity);
        }

        public override IList<TypeOfHouseVM> CastEntityToModel(IQueryable<TypeOfHouse> entity)
        {
            return _mapper.Map<IList<TypeOfHouseVM>>(entity).ToList();
        }
    }
}