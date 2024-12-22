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
    public class ForestCircleService : BaseService<ForestCircleVM, ForestCircle>, IForestCircleService
    {
        public IMapper _mapper;

        public ForestCircleService(IForestCircleBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override ForestCircle CastModelToEntity(ForestCircleVM model)
        {
            try
            {
                return _mapper.Map<ForestCircle>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override ForestCircleVM CastEntityToModel(ForestCircle entity)
        {
            try
            {
                var model = _mapper.Map<ForestCircleVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<ForestCircleVM> CastEntityToModel(IQueryable<ForestCircle> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<ForestCircleVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
