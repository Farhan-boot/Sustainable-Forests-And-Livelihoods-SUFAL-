using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.SocialForestry
{
    public class NewRaisedPlantationService : BaseService<NewRaisedPlantationVM, NewRaisedPlantation>, INewRaisedPlantationService
    {
        private readonly INewRaisedPlantationBusiness _business;
        public IMapper _mapper;

        public NewRaisedPlantationService(INewRaisedPlantationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override NewRaisedPlantation CastModelToEntity(NewRaisedPlantationVM model)
        {
            return _mapper.Map<NewRaisedPlantation>(model);
        }

        public override NewRaisedPlantationVM CastEntityToModel(NewRaisedPlantation entity)
        {
            return _mapper.Map<NewRaisedPlantationVM>(entity);
        }

        public override IList<NewRaisedPlantationVM> CastEntityToModel(IQueryable<NewRaisedPlantation> entity)
        {
            return _mapper.Map<IList<NewRaisedPlantationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, NewRaisedPlantationVM data, string message)> GetDetails(long id)
        {
            var data = await _business.GetDetails(id);
            if (data.data is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, CastEntityToModel(data.data), data.message);
        }

        public async Task<(ExecutionState executionState, NewRaisedPlantationVM data, string message)> GetDetailsForEdit(long id)
        {
            var data = await _business.GetDetailsForEdit(id);
            if (data.data is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, CastEntityToModel(data.data), data.message);
        }

        public Task<(ExecutionState execution, string entity, string message)> GetNextRotationNo(long newRaisedPlantationId)
        {
            return _business.GetNextRotationNo(newRaisedPlantationId);
        }

        public async Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> ListByFilter(NewRaisedPlantationFilter filter)
        {
            var data = await _business.ListByFilter(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<List<NewRaisedPlantationVM>>(data.entity), data.message);
        }

        public async Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> GetInformationAndDataOnNewlyRaisedPlantationReport(NurseryFilterVM filter)
        {
            var data = await _business.GetInformationAndDataOnNewlyRaisedPlantationReport(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<List<NewRaisedPlantationVM>>(data.entity), data.message);
        }



        public async Task<(ExecutionState executionState, List<NewRaisedPlantationVM> data, string message)> GetInformationAndDataOnPlantationsFelledOrCutReport(NurseryFilterVM filter)
        {
            var data = await _business.GetInformationAndDataOnPlantationsFelledOrCutReport(filter);
            if (data.entity is null)
            {
                return (data.executionState, null, data.message);
            }

            return (data.executionState, _mapper.Map<List<NewRaisedPlantationVM>>(data.entity), data.message);
        }




    }
}