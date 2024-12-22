using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PTSL.GENERIC.Service.Services
{
	public class MeetingParticipantsMapService : BaseService<MeetingParticipantsMapVM, MeetingParticipantsMap>, IMeetingParticipantsMapService
	{
		public IMapper _mapper;

		public MeetingParticipantsMapService(IMeetingParticipantsMapBusiness business, IMapper mapper) : base(business)
		{
			_mapper = mapper;
		}

		public override MeetingParticipantsMap CastModelToEntity(MeetingParticipantsMapVM model)
		{
			try
			{
				return _mapper.Map<MeetingParticipantsMap>(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override MeetingParticipantsMapVM CastEntityToModel(MeetingParticipantsMap entity)
		{
			try
			{
				var model = _mapper.Map<MeetingParticipantsMapVM>(entity);
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public override IList<MeetingParticipantsMapVM> CastEntityToModel(IQueryable<MeetingParticipantsMap> entity)
		{
			try
			{
				var entityList = _mapper.Map<IList<MeetingParticipantsMapVM>>(entity).ToList();
				return entityList;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

