using AutoMapper;

using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Service.BaseServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Beneficiary
{
    public class SurveyService : BaseService<SurveyVM, Survey>, ISurveyService
    {
        public IMapper _mapper;
        public readonly ISurveyBusiness _surveyBusiness;
        public SurveyService(ISurveyBusiness surveybusiness, IMapper mapper) : base(surveybusiness)
        {
            _mapper = mapper;
            _surveyBusiness = surveybusiness;
        }
        public virtual async Task<(ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message)> GetBeneficiaryByFilter(BeneficiaryFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message) Getentity = await _surveyBusiness.GetBeneficiaryByFilter(filterData);


                if (Getentity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: Getentity.executionState, entity: Getentity.entity, message: Getentity.message);
                }
                else
                {
                    returnResponse = (executionState: Getentity.executionState, entity: null, message: Getentity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }


        public override Survey CastModelToEntity(SurveyVM model)
        {
            try
            {
                return _mapper.Map<Survey>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override SurveyVM CastEntityToModel(Survey entity)
        {
            try
            {
                var model = _mapper.Map<SurveyVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<HouseholdMemberVM> CastHouseholdMemberEntityToModel(IQueryable<HouseholdMember> entity)
        {
            return _mapper.Map<List<HouseholdMemberVM>>(entity.ToList());
        }

        public override IList<SurveyVM> CastEntityToModel(IQueryable<Survey> entity)
        {
            try
            {
                var entityList = _mapper.Map<IList<SurveyVM>>(entity).ToList();
                return entityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private EconomicStatusModelVM CastEconomicStatusToModel(EconomicStatusModel entity)
        {
            return _mapper.Map<EconomicStatusModelVM>(entity);
        }

        private SocioEconomicStatusModelVM CastSocioEconomicStatusToModel(SocioEconomicStatusModel entity)
        {
            return _mapper.Map<SocioEconomicStatusModelVM>(entity);
        }

        public async Task<(ExecutionState executionState, IList<SurveyVM> entity, string message)> GetBeneficiaryByFcvVcf(long fcvVcfId)
        {
            try
            {
                var result = await _surveyBusiness.GetBeneficiaryByFcvVcf(fcvVcfId);

                return (result.executionState, CastEntityToModel(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, SurveyVM entity, string message)> GetDetailsAsync(long key)
        {
            var result = await _surveyBusiness.GetDetailsAsync(key);

            return (result.executionState, CastEntityToModel(result.entity), result.message);
        }

        public async Task<(ExecutionState executionState, List<HouseholdMemberVM> entity, string message)> LoadMembers(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadMembers(surveyId);

                return (result.executionState, CastHouseholdMemberEntityToModel(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, EconomicStatusModelVM entity, string message)> LoadEconomicStatus(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadEconomicStatus(surveyId);

                return (result.executionState, CastEconomicStatusToModel(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, SocioEconomicStatusModelVM entity, string message)> LoadSocioEconomicStatus(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadSocioEconomicStatus(surveyId);

                return (result.executionState, CastSocioEconomicStatusToModel(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<ExistingSkillVM> entity, string message)> LoadExistingSkill(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadExistingSkill(surveyId);

                return (result.executionState, _mapper.Map<List<ExistingSkillVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message)> LoadAnnualHouseholdExpenditure(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadAnnualHouseholdExpenditure(surveyId);

                return (result.executionState, _mapper.Map<List<AnnualHouseholdExpenditureVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<FoodSecurityItemVM> entity, string message)> LoadFoodSecurityItem(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadFoodSecurityItem(surveyId);

                return (result.executionState, _mapper.Map<List<FoodSecurityItemVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message)> LoadVulnerabilitySituation(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadVulnerabilitySituation(surveyId);

                return (result.executionState, _mapper.Map<List<VulnerabilitySituationVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message)> LoadGrossMarginIncomeAndCostStatus(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadGrossMarginIncomeAndCostStatus(surveyId);

                return (result.executionState, _mapper.Map<List<GrossMarginIncomeAndCostStatusVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message)> LoadManualPhysicalWork(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadManualPhysicalWork(surveyId);

                return (result.executionState, _mapper.Map<List<ManualPhysicalWorkVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message)> LoadNaturalResourcesIncomeAndCostStatus(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadNaturalResourcesIncomeAndCostStatus(surveyId);

                return (result.executionState, _mapper.Map<List<NaturalResourcesIncomeAndCostStatusVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message)> LoadOtherIncomeSource(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadOtherIncomeSource(surveyId);

                return (result.executionState, _mapper.Map<List<OtherIncomeSourceVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<BusinessVM> entity, string message)> LoadBusiness(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadBusiness(surveyId);

                return (result.executionState, _mapper.Map<List<BusinessVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<LandOccupancyVM> entity, string message)> LoadLandOccupancy(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadLandOccupancy(surveyId);

                return (result.executionState, _mapper.Map<List<LandOccupancyVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<LiveStockVM> entity, string message)> LoadLiveStock(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadLiveStock(surveyId);

                return (result.executionState, _mapper.Map<List<LiveStockVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<AssetVM> entity, string message)> LoadAsset(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadAsset(surveyId);

                return (result.executionState, _mapper.Map<List<AssetVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<ImmovableAssetVM> entity, string message)> LoadImmovableAsset(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadImmovableAsset(surveyId);

                return (result.executionState, _mapper.Map<List<ImmovableAssetVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, List<EnergyUseVM> entity, string message)> LoadEnergyUse(long surveyId)
        {
            try
            {
                var result = await _surveyBusiness.LoadEnergyUse(surveyId);

                return (result.executionState, _mapper.Map<List<EnergyUseVM>>(result.entity), result.message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(ExecutionState executionState, SurveyChildsVM entity, string message)> LoadAllChilds(long surveyId)
        {
            var result = await _surveyBusiness.LoadAllChilds(surveyId);

            return (result.executionState, _mapper.Map<SurveyChildsVM>(result.entity), result.message);
        }

        public async Task<(ExecutionState executionState, SurveyDashboardVM entity, string message)> BeneficiaryDashboardData(long? surveyId)
        {
            var result = await _surveyBusiness.BeneficiaryDashboardData(surveyId);

            return (result.executionState, _mapper.Map<SurveyDashboardVM>(result.entity), result.message);
        }

        public async Task<(ExecutionState executionState, SurveyVM entity, string message)> GetByIdWithChilds(long surveyId)
        {
            var result = await _surveyBusiness.GetByIdWithChilds(surveyId);

            return (result.executionState, _mapper.Map<SurveyVM>(result.entity), result.message);
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> Deactivate(long surveyId, long deactivatedBy)
        {
            var result = await _surveyBusiness.Deactivate(surveyId, deactivatedBy);
            return (result.executionState, result.entity, result.message);
        }

        public async Task<(ExecutionState executionState, bool entity, string message)> Activate(long surveyId, long activatedBy)
        {
            var result = await _surveyBusiness.Activate(surveyId, activatedBy);
            return (result.executionState, result.entity, result.message);
        }
    }
}
