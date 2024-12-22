using AutoMapper;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class NgoService : BaseService<NgoVM, Ngo>, INgoService
    {
        private readonly INgoBusiness _business;
        public IMapper _mapper;

        public NgoService(INgoBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override Ngo CastModelToEntity(NgoVM model)
        {
            try
            {
                return _mapper.Map<Ngo>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override NgoVM CastEntityToModel(Ngo entity)
        {
            try
            {
                var model = _mapper.Map<NgoVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public override IList<NgoVM> CastEntityToModel(IQueryable<Ngo> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<NgoVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IList<NgoVM> CastEntityListToModel(List<Ngo> entity)
        {
            return _mapper.Map<IList<NgoVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, IList<NgoVM> entity, string message)> ListByForestDivisions(List<long> districts)
        {
            (ExecutionState executionState, IList<NgoVM> entity, string message) returnResponse;

            try
            {
                (ExecutionState executionState, List<Ngo> entity, string message) response = await _business.ListByForestDivisions(districts);

                if (response.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (response.executionState, entity: CastEntityListToModel(response.entity), response.message);
                }
                else
                {
                    returnResponse = (response.executionState, entity: null, response.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }

        public override async Task<(ExecutionState executionState, NgoVM entity, string message)> GetAsync(long key)
        {
            var result = await _business.GetCustomAsync(key);
            var resultVm = new NgoVM();

            if (result.entity is not null)
            {
                resultVm = CastEntityToModel(result.entity);
                resultVm.ForestDivisions = _mapper.Map<List<ForestDivisionVM>>(result.forestDivisions);
            }

            return (result.executionState, resultVm, result.message);
        }
    }
}
