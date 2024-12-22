using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public class NurseryInformationService : BaseService<NurseryInformationVM, NurseryInformation>, INurseryInformationService
    {
        private readonly INurseryInformationBusiness _business;
        public IMapper _mapper;

        public NurseryInformationService(INurseryInformationBusiness business, IMapper mapper) : base(business)
        {
            _business = business;
            _mapper = mapper;
        }

        public override NurseryInformation CastModelToEntity(NurseryInformationVM model)
        {
            return _mapper.Map<NurseryInformation>(model);
        }

        public override NurseryInformationVM CastEntityToModel(NurseryInformation entity)
        {
            return _mapper.Map<NurseryInformationVM>(entity);
        }

        public override IList<NurseryInformationVM> CastEntityToModel(IQueryable<NurseryInformation> entity)
        {
            return _mapper.Map<IList<NurseryInformationVM>>(entity).ToList();
        }

        public async Task<(ExecutionState executionState, IList<NurseryInformationVM> entity, string message)> GetFilterData(NurseryFilterVM model)
        {
            try
            {
                (ExecutionState executionState, IList<NurseryInformation> entity, string message) result = await _business.GetFilterData(model);
                if (result.entity is not null)
                {
                    return (result.executionState, _mapper.Map<IList<NurseryInformationVM>>(result.entity), result.message);
                }

                return (result.executionState, new List<NurseryInformationVM>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryReport(NurseryFilterVM model)
        {
            try
            {
                (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _business.GetNurseryReport(model);
                if (result.entity is not null)
                {
                    return (result.executionState, result.entity, result.message);
                }

                return (result.executionState, new List<SocialForestryReport>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionReport(NurseryFilterVM model)
        {
            try
            {
                (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _business.GetNurseryDistributionReport(model);
                if (result.entity is not null)
                {
                    return (result.executionState, result.entity, result.message);
                }

                return (result.executionState, new List<SocialForestryReport>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionByBeneficiaryReport(NurseryFilterVM model)
        {
            try
            {
                (ExecutionState executionState, IList<SocialForestryReport> entity, string message) result = await _business.GetNurseryDistributionByBeneficiaryReport(model);
                if (result.entity is not null)
                {
                    return (result.executionState, result.entity, result.message);
                }

                return (result.executionState, new List<SocialForestryReport>(), result.message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}