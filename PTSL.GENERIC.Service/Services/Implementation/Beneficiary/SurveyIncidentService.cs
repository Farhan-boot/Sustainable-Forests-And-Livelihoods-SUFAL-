using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class SurveyIncidentService : BaseService<SurveyIncidentVM, SurveyIncident>, ISurveyIncidentService
    {
        private readonly ISurveyIncidentBusiness _business;
        public IMapper _mapper;

        public SurveyIncidentService(ISurveyIncidentBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override SurveyIncident CastModelToEntity(SurveyIncidentVM model)
        {
            return _mapper.Map<SurveyIncident>(model);
        }

        public override SurveyIncidentVM CastEntityToModel(SurveyIncident entity)
        {
            return _mapper.Map<SurveyIncidentVM>(entity);
        }

        public override IList<SurveyIncidentVM> CastEntityToModel(IQueryable<SurveyIncident> entity)
        {
            return _mapper.Map<IList<SurveyIncidentVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, List<SurveyIncidentVM> entity, string message)> ListByFilter(SurveyIncidentFilterVM filter)
        {
            var (executionState, entity, message) = await _business.ListByFilter(filter);

            return (executionState, _mapper.Map<List<SurveyIncidentVM>>(entity), message);
        }
    }
}