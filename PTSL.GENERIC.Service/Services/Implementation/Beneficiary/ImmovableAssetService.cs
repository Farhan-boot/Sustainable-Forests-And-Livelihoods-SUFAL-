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
    public class ImmovableAssetService : BaseService<ImmovableAssetVM, ImmovableAsset>, IImmovableAssetService
    {
        public IMapper _mapper;

        public ImmovableAssetService(IImmovableAssetBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ImmovableAsset CastModelToEntity(ImmovableAssetVM model)
        {
            try
            {
                return _mapper.Map<ImmovableAsset>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ImmovableAssetVM CastEntityToModel(ImmovableAsset entity)
        {
            try
            {
                var model = _mapper.Map<ImmovableAssetVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ImmovableAssetVM> CastEntityToModel(IQueryable<ImmovableAsset> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ImmovableAssetVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
