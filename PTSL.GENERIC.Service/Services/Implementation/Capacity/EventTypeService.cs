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
    public class EventTypeService : BaseService<EventTypeVM, EventType>, IEventTypeService
    {
        public IMapper _mapper;

        public EventTypeService(IEventTypeBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
        }

        public override EventType CastModelToEntity(EventTypeVM model)
        {
            try
            {
                return _mapper.Map<EventType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override EventTypeVM CastEntityToModel(EventType entity)
        {
            try
            {
                var model = _mapper.Map<EventTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<EventTypeVM> CastEntityToModel(IQueryable<EventType> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<EventTypeVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
