using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Cutting;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Cutting
{
    public class DistributionPercentageService : BaseService<DistributionPercentageVM, DistributionPercentage>, IDistributionPercentageService
    {
        private readonly IDistributionPercentageBusiness _business;
        public IMapper _mapper;

        public DistributionPercentageService(IDistributionPercentageBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override DistributionPercentage CastModelToEntity(DistributionPercentageVM model)
        {
            return _mapper.Map<DistributionPercentage>(model);
        }
        public List<DistributionPercentage> CastModelToEntityList(List<DistributionPercentageVM> model)
        {
            return _mapper.Map<List<DistributionPercentage>>(model);
        }

        public override DistributionPercentageVM CastEntityToModel(DistributionPercentage entity)
        {
            return _mapper.Map<DistributionPercentageVM>(entity);
        }
        public List<DistributionPercentageVM> CastEntityToModelList(List<DistributionPercentage> entity)
        {
            return _mapper.Map<List<DistributionPercentageVM>>(entity);
        }

        public override IList<DistributionPercentageVM> CastEntityToModel(IQueryable<DistributionPercentage> entity)
        {
            return _mapper.Map<IList<DistributionPercentageVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<DistributionPercentageVM> entity, string message)> CreateRangeAsync(DistributionPercentageCustomVM model)
        {
            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse;
            try
            {

                var entity = CastModelToEntityList(model.DistributionPercentageListVM);
                //entity.CreatedBy = 1;
                (ExecutionState executionState, List<DistributionPercentage> entity, string message) createEntity = await _business.CreateRangeAsync(entity);

                if (createEntity.executionState == ExecutionState.Created)
                {
                    returnResponse = (executionState: createEntity.executionState, entity: CastEntityToModelList(createEntity.entity), message: createEntity.message);

                }
                else
                {
                    returnResponse = (executionState: createEntity.executionState, entity: null, message: createEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        public async Task<(ExecutionState executionState, List<DistributionPercentageVM> entity, string message)> UpdateRangeAsync(long id, DistributionPercentageCustomVM model)
        {
            (ExecutionState executionState, List<DistributionPercentageVM> entity, string message) returnResponse;
            try
            {

                var entity = CastModelToEntityList(model.DistributionPercentageListVM);
                (ExecutionState executionState, List<DistributionPercentage> entity, string message) createEntity = await _business.UpdateRangeAsync(id,entity);

                if (createEntity.executionState == ExecutionState.Updated)
                {
                    returnResponse = (executionState: createEntity.executionState, entity: CastEntityToModelList(createEntity.entity), message: createEntity.message);

                }
                else
                {
                    returnResponse = (executionState: createEntity.executionState, entity: null, message: createEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public async  Task<(ExecutionState executionState, IList<DistributionPercentageVM> entity, string message)> GetByPlantationTypeId(long? id)
        {
            (ExecutionState executionState, IList<DistributionPercentageVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, IQueryable<DistributionPercentage> entity, string message) getEntityList = await _business.GetByPlantationTypeId(id);

                if (getEntityList.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: getEntityList.executionState, entity: CastEntityToModel(getEntityList.entity), message: getEntityList.message);
                }
                else
                {
                    returnResponse = (executionState: getEntityList.executionState, entity: null, message: getEntityList.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
    }
}