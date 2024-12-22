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
    public class FoodSecurityItemService : BaseService<FoodSecurityItemVM, FoodSecurityItem>, IFoodSecurityItemService
    {
        public IMapper _mapper;

        public FoodSecurityItemService(IFoodSecurityItemBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FoodSecurityItem CastModelToEntity(FoodSecurityItemVM model)
        {
            try
            {
                return _mapper.Map<FoodSecurityItem>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override FoodSecurityItemVM CastEntityToModel(FoodSecurityItem entity)
        {
            try
            {
                var model = _mapper.Map<FoodSecurityItemVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<FoodSecurityItemVM> CastEntityToModel(IQueryable<FoodSecurityItem> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<FoodSecurityItemVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
