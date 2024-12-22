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
	public class MeetingMemberService : BaseService<MeetingMemberVM, MeetingMember>, IMeetingMemberService
	{
		public IMapper _mapper;

		public MeetingMemberService(IMeetingMemberBusiness business, IMapper mapper) : base(business)
		{
			_mapper = mapper;
		}

		public override MeetingMember CastModelToEntity(MeetingMemberVM model)
		{
			try
			{
				return _mapper.Map<MeetingMember>(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override MeetingMemberVM CastEntityToModel(MeetingMember entity)
		{
			try
			{
				var model = _mapper.Map<MeetingMemberVM>(entity);
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public override IList<MeetingMemberVM> CastEntityToModel(IQueryable<MeetingMember> entity)
		{
			try
			{
				var entityList = _mapper.Map<IList<MeetingMemberVM>>(entity).ToList();
				return entityList;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

