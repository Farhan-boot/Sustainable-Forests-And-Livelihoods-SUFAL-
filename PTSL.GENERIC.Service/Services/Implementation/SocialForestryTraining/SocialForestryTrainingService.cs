using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Business.Businesses.Interface.SocialForestryTraining;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestryTraining;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestryTraining
{
    public class SocialForestryTrainingService : BaseService<SocialForestryTrainingVM, Common.Entity.SocialForestryTraining.SocialForestryTraining>, ISocialForestryTrainingService
    {
        public IMapper _mapper;
        private readonly ISocialForestryTrainingBusiness _business;

        public SocialForestryTrainingService(ISocialForestryTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override Common.Entity.SocialForestryTraining.SocialForestryTraining CastModelToEntity(SocialForestryTrainingVM model)
        {
            return _mapper.Map<Common.Entity.SocialForestryTraining.SocialForestryTraining>(model);
        }

        public override SocialForestryTrainingVM CastEntityToModel(Common.Entity.SocialForestryTraining.SocialForestryTraining entity)
        {
            return _mapper.Map<SocialForestryTrainingVM>(entity);
        }

        public override IList<SocialForestryTrainingVM> CastEntityToModel(IQueryable<Common.Entity.SocialForestryTraining.SocialForestryTraining> entity)
        {
            return _mapper.Map<IList<SocialForestryTrainingVM>>(entity).ToList();
        }


        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long SocialForestryTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(SocialForestryTrainingParticipentsMapId);

                returnResponse = (response.executionState, response.isDeleted, response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, false, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IList<SocialForestryTrainingVM> entity, string message)> GetByFilterVM(SocialForestryTrainingFilterVM filter)
        {
            (ExecutionState executionState, IList<SocialForestryTrainingVM> entity, string message) returnResponse;

            try
            {
                var response = await _business.GetByFilterVM(filter);

                returnResponse = (response.executionState, _mapper.Map<List<SocialForestryTrainingVM>>(response.entity), response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, new List<SocialForestryTrainingVM>(), message: ex.Message);
            }

            return returnResponse;
        }

    }
}