using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public class EventTypeForTrainingService : BaseService<EventTypeForTrainingVM, EventTypeForTraining>, IEventTypeForTrainingService
    {
        public IMapper _mapper;

        public EventTypeForTrainingService(IEventTypeForTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override EventTypeForTraining CastModelToEntity(EventTypeForTrainingVM model)
        {
            return _mapper.Map<EventTypeForTraining>(model);
        }

        public override EventTypeForTrainingVM CastEntityToModel(EventTypeForTraining entity)
        {
            return _mapper.Map<EventTypeForTrainingVM>(entity);
        }

        public override IList<EventTypeForTrainingVM> CastEntityToModel(IQueryable<EventTypeForTraining> entity)
        {
            return _mapper.Map<IList<EventTypeForTrainingVM>>(entity).ToList();
        }
    }
}