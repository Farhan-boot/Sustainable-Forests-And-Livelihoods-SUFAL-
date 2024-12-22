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
    public class ImmovableAssetTypeService : BaseService<ImmovableAssetTypeVM, ImmovableAssetType>, IImmovableAssetTypeService
    {
        public IMapper _mapper;

        public ImmovableAssetTypeService(IImmovableAssetTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ImmovableAssetType CastModelToEntity(ImmovableAssetTypeVM model)
        {
            try
            {
                return _mapper.Map<ImmovableAssetType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ImmovableAssetTypeVM CastEntityToModel(ImmovableAssetType entity)
        {
            try
            {
                var model = _mapper.Map<ImmovableAssetTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ImmovableAssetTypeVM> CastEntityToModel(IQueryable<ImmovableAssetType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ImmovableAssetTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
