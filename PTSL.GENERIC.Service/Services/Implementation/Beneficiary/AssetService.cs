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
    public class AssetService : BaseService<AssetVM, Asset>, IAssetService
    {
        public IMapper _mapper;

        public AssetService(IAssetBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override Asset CastModelToEntity(AssetVM model)
        {
            try
            {
                return _mapper.Map<Asset>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override AssetVM CastEntityToModel(Asset entity)
        {
            try
            {
                var model = _mapper.Map<AssetVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<AssetVM> CastEntityToModel(IQueryable<Asset> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<AssetVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
