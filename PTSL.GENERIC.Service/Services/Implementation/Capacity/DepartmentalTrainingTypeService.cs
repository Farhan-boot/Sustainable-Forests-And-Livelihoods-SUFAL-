using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class DepartmentalTrainingTypeService : BaseService<DepartmentalTrainingTypeVM, DepartmentalTrainingType>, IDepartmentalTrainingTypeService
    {
        public IMapper _mapper;

        public DepartmentalTrainingTypeService(IDepartmentalTrainingTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DepartmentalTrainingType CastModelToEntity(DepartmentalTrainingTypeVM model)
        {
            try
            {
                return _mapper.Map<DepartmentalTrainingType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DepartmentalTrainingTypeVM CastEntityToModel(DepartmentalTrainingType entity)
        {
            try
            {
                var model = _mapper.Map<DepartmentalTrainingTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<DepartmentalTrainingTypeVM> CastEntityToModel(IQueryable<DepartmentalTrainingType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DepartmentalTrainingTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
