using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestryMeeting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestryMeeting
{
    public class  SocialForestryMeetingService : BaseService<SocialForestryMeetingVM, Common.Entity.SocialForestryMeeting.SocialForestryMeeting>, ISocialForestryMeetingService
    {
        public IMapper _mapper;
        private readonly ISocialForestryMeetingBusiness _business;

        public  SocialForestryMeetingService(ISocialForestryMeetingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override  Common.Entity.SocialForestryMeeting.SocialForestryMeeting CastModelToEntity( SocialForestryMeetingVM model)
        {
            return _mapper.Map<Common.Entity.SocialForestryMeeting.SocialForestryMeeting>(model);
        }

        public override  SocialForestryMeetingVM CastEntityToModel(Common.Entity.SocialForestryMeeting.SocialForestryMeeting entity)
        {
            return _mapper.Map< SocialForestryMeetingVM>(entity);
        }

        public override IList< SocialForestryMeetingVM> CastEntityToModel(IQueryable<Common.Entity.SocialForestryMeeting.SocialForestryMeeting> entity)
        {
            return _mapper.Map<IList< SocialForestryMeetingVM>>(entity).ToList();
        }


        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryMeetingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(SocialForestryMeetingParticipentsMapId);

                returnResponse = (response.executionState, response.isDeleted, response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, false, message: ex.Message);
            }

            return returnResponse;
        }

        //public async Task<(ExecutionState executionState, IList<SocialForestryMeetingVM> entity, string message)> GetByFilterVM(SocialForestryMeetingFilterVM filter)
        //{
        //    (ExecutionState executionState, IList<SocialForestryTrainingVM> entity, string message) returnResponse;

        //    try
        //    {
        //        var response = await _business.GetByFilterVM(filter);

        //        returnResponse = (response.executionState, _mapper.Map<List<SocialForestryTrainingVM>>(response.entity), response.message);
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure, new List<SocialForestryTrainingVM>(), message: ex.Message);
        //    }

        //    return returnResponse;
        //}
    }
}