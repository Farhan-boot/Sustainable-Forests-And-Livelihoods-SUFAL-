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
    public class FoodItemService : BaseService<FoodItemVM, FoodItem>, IFoodItemService
    {
        public IMapper _mapper;

        public FoodItemService(IFoodItemBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override FoodItem CastModelToEntity(FoodItemVM model)
        {
            try
            {
                return _mapper.Map<FoodItem>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override FoodItemVM CastEntityToModel(FoodItem entity)
        {
            try
            {
                var model = _mapper.Map<FoodItemVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<FoodItemVM> CastEntityToModel(IQueryable<FoodItem> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<FoodItemVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
