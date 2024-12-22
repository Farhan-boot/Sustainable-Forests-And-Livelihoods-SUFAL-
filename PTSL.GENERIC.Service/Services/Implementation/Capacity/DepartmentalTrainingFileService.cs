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
    public class DepartmentalTrainingFileService : BaseService<DepartmentalTrainingFileVM, DepartmentalTrainingFile>, IDepartmentalTrainingFileService
    {
        public IMapper _mapper;

        public DepartmentalTrainingFileService(IDepartmentalTrainingFileBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DepartmentalTrainingFile CastModelToEntity(DepartmentalTrainingFileVM model)
        {
            try
            {
                return _mapper.Map<DepartmentalTrainingFile>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DepartmentalTrainingFileVM CastEntityToModel(DepartmentalTrainingFile entity)
        {
            try
            {
                var model = _mapper.Map<DepartmentalTrainingFileVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<DepartmentalTrainingFileVM> CastEntityToModel(IQueryable<DepartmentalTrainingFile> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DepartmentalTrainingFileVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
