using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services
{
	public class MeetingService : BaseService<MeetingVM, Meeting>, IMeetingService
	{
        private readonly IMeetingBusiness _business;
        public IMapper _mapper;

		public MeetingService(IMeetingBusiness business, IMapper mapper) : base(business)
		{
            _business = business;
            _mapper = mapper;
		}

		public override Meeting CastModelToEntity(MeetingVM model)
		{
			try
			{
				return _mapper.Map<Meeting>(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public override MeetingVM CastEntityToModel(Meeting entity)
		{
			try
			{
				var model = _mapper.Map<MeetingVM>(entity);
				return model;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public override IList<MeetingVM> CastEntityToModel(IQueryable<Meeting> entity)
		{
			try
			{
				var entityList = _mapper.Map<IList<MeetingVM>>(entity).ToList();
				return entityList;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public List<MeetingVM> CastEntityListToModel(List<Meeting> entity)
		{
            return _mapper.Map<List<MeetingVM>>(entity);
        }

        public async Task<(ExecutionState executionState, PaginationResutl<MeetingVM> entity, string message)> GetMeetingByFilter(MeetingFilterVM filterData)
        {
            var result = await _business.GetMeetingByFilter(filterData);

            if (result.entity is not null)
            {
                return (result.executionState, _mapper.Map<PaginationResutl<MeetingVM>>(result.entity), result.message);
                //return (result.executionState, CastEntityListToModel(result.entity), result.message);
            }

            return (result.executionState, new PaginationResutl<MeetingVM>(), result.message);
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long mapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(mapId);

                returnResponse = (response.executionState, response.isDeleted, response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, false, message: ex.Message);
            }

            return returnResponse;
        }
	}
}

