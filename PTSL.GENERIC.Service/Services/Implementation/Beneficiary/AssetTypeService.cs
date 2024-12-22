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
    public class AssetTypeService : BaseService<AssetTypeVM, AssetType>, IAssetTypeService
    {
        public IMapper _mapper;

        public AssetTypeService(IAssetTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override AssetType CastModelToEntity(AssetTypeVM model)
        {
            try
            {
                return _mapper.Map<AssetType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override AssetTypeVM CastEntityToModel(AssetType entity)
        {
            try
            {
                var model = _mapper.Map<AssetTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<AssetTypeVM> CastEntityToModel(IQueryable<AssetType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<AssetTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
