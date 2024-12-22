using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class TrainingOrganizerService : BaseService<TrainingOrganizerVM, TrainingOrganizer>, ITrainingOrganizerService
    {
        public IMapper _mapper;

        public TrainingOrganizerService(ITrainingOrganizerBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override TrainingOrganizer CastModelToEntity(TrainingOrganizerVM model)
        {
            try
            {
                return _mapper.Map<TrainingOrganizer>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override TrainingOrganizerVM CastEntityToModel(TrainingOrganizer entity)
        {
            try
            {
                var model = _mapper.Map<TrainingOrganizerVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<TrainingOrganizerVM> CastEntityToModel(IQueryable<TrainingOrganizer> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<TrainingOrganizerVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
