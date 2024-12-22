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
	public class MeetingFileService : BaseService<MeetingFileVM, MeetingFile>, IMeetingFileService
	{
		public IMapper _mapper;

		public MeetingFileService(IMeetingFileBusiness business, IMapper mapper) : base(business)
		{
			_mapper = mapper;
		}

		public override MeetingFile CastModelToEntity(MeetingFileVM model)
		{
			try
			{
				return _mapper.Map<MeetingFile>(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override MeetingFileVM CastEntityToModel(MeetingFile entity)
		{
			try
			{
				var model = _mapper.Map<MeetingFileVM>(entity);
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public override IList<MeetingFileVM> CastEntityToModel(IQueryable<MeetingFile> entity)
		{
			try
			{
				var entityList = _mapper.Map<IList<MeetingFileVM>>(entity).ToList();
				return entityList;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

