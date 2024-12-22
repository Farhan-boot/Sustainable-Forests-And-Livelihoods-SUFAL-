using AutoMapper;
using Azure;

using PTSL.GENERIC.Business.Businesses.Interface.Capacity;
using PTSL.GENERIC.Common.Entity.Capacity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Implementation.Capacity
{
    public class DepartmentalTrainingService : BaseService<DepartmentalTrainingVM, DepartmentalTraining>, IDepartmentalTrainingService
    {
        private readonly IDepartmentalTrainingBusiness _business;
        public IMapper _mapper;

        public DepartmentalTrainingService(IDepartmentalTrainingBusiness business, IMapper mapper) : base(business)
        {
            _mapper = mapper;
            _business = business;
        }

        public override DepartmentalTraining CastModelToEntity(DepartmentalTrainingVM model)
        {
            try
            {
                return _mapper.Map<DepartmentalTraining>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override DepartmentalTrainingVM CastEntityToModel(DepartmentalTraining entity)
        {
            try
            {
                var model = _mapper.Map<DepartmentalTrainingVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override IList<DepartmentalTrainingVM> CastEntityToModel(IQueryable<DepartmentalTraining> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<DepartmentalTrainingVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, bool isDeleted, string message)> DeleteParticipant(long DepartmentalTrainingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;

            try
            {
                (ExecutionState executionState, bool isDeleted, string message) response = await _business.DeleteParticipant(DepartmentalTrainingParticipentsMapId);

                returnResponse = (response.executionState, response.isDeleted, response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, false, message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, IList<DepartmentalTrainingVM> entity, string message)> GetByFilter(long finalYearId)
        {
            (ExecutionState executionState, IList<DepartmentalTrainingVM> entity, string message) returnResponse;

            try
            {
                var response = await _business.GetByFilter(finalYearId);

                returnResponse = (response.executionState, CastEntityToModel(response.entity), response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, new List<DepartmentalTrainingVM>(), message: ex.Message);
            }

            return returnResponse;
        }

        public async Task<(ExecutionState executionState, PaginationResutl<DepartmentalTrainingVM> entity, string message)> GetByFilterVM(DepartmentalTrainingFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutl<DepartmentalTrainingVM> entity, string message) returnResponse;

            try
            {
                var response = await _business.GetByFilterVM(filter);

                returnResponse = (response.executionState, _mapper.Map<PaginationResutl<DepartmentalTrainingVM>>(response.entity), response.message);

                // returnResponse = (response.executionState, _mapper.Map<List<DepartmentalTrainingVM>>(response.entity), response.message);
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, new PaginationResutl<DepartmentalTrainingVM>(), message: ex.Message);
                //returnResponse = (executionState: ExecutionState.Failure, new List<DepartmentalTrainingVM>(), message: ex.Message);
            }

            return returnResponse;
        }
    }
}
