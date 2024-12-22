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
    public class DepartmentalTrainingParticipentsMapService : BaseService<DepartmentalTrainingParticipentsMapVM, DepartmentalTrainingParticipentsMap>, IDepartmentalTrainingParticipentsMapService
    {
        public IMapper _mapper;

        public DepartmentalTrainingParticipentsMapService(IDepartmentalTrainingParticipentsMapBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override DepartmentalTrainingParticipentsMap CastModelToEntity(DepartmentalTrainingParticipentsMapVM model)
        {
            try
            {
                return _mapper.Map<DepartmentalTrainingParticipentsMap>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DepartmentalTrainingParticipentsMapVM CastEntityToModel(DepartmentalTrainingParticipentsMap entity)
        {
            try
            {
                var model = _mapper.Map<DepartmentalTrainingParticipentsMapVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<DepartmentalTrainingParticipentsMapVM> CastEntityToModel(IQueryable<DepartmentalTrainingParticipentsMap> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DepartmentalTrainingParticipentsMapVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
