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
	public class MeetingTypeService : BaseService<MeetingTypeVM, MeetingType>, IMeetingTypeService
	{
		public IMapper _mapper;

		public MeetingTypeService(IMeetingTypeBusiness business, IMapper mapper) : base(business)
		{
			_mapper = mapper;
		}

		public override MeetingType CastModelToEntity(MeetingTypeVM model)
		{
			try
			{
				return _mapper.Map<MeetingType>(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override MeetingTypeVM CastEntityToModel(MeetingType entity)
		{
			try
			{
				var model = _mapper.Map<MeetingTypeVM>(entity);
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public override IList<MeetingTypeVM> CastEntityToModel(IQueryable<MeetingType> entity)
		{
			try
			{
				var entityList = _mapper.Map<IList<MeetingTypeVM>>(entity).ToList();
				return entityList;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

