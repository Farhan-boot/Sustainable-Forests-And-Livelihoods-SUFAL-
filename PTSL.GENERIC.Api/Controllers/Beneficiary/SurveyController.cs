using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.Beneficiary;

using System.Net;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : BaseController<ISurveyService, SurveyVM, Survey>
    {
        private readonly ISurveyService _surveyService;
        private readonly ISurveyBusiness _surveyBusiness;
        private readonly FileHelper _fileHelper;

        public SurveyController(ISurveyService surveyservice, ISurveyBusiness surveyBusiness, FileHelper fileHelper) :
            base(surveyservice)
        {
            _surveyService = surveyservice;
            _surveyBusiness = surveyBusiness;
            _fileHelper = fileHelper;
        }

        [HttpGet("GetDetailsAsync/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<SurveyVM>>> GetDetailsAsync(long id)
        {
            (ExecutionState executionState, SurveyVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, SurveyVM entity, string message) result = await _surveyService.GetDetailsAsync(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetByIdWithChilds/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<SurveyVM>>> GetByIdWithChilds(long id)
        {
            (ExecutionState executionState, SurveyVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, SurveyVM entity, string message) result = await _surveyService.GetByIdWithChilds(id);
                if (result.executionState == ExecutionState.Success)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SurveyVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("GetBeneficiaryByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<SurveyEssentialVM>>>> GetBeneficiaryByFilter(BeneficiaryFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<SurveyEssentialVM> entity, string message) result = await _surveyService.GetBeneficiaryByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<PaginationResutl<SurveyEssentialVM>> apiResponse = new WebApiResponse<PaginationResutl<SurveyEssentialVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<PaginationResutl<SurveyEssentialVM>> apiResponse = new WebApiResponse<PaginationResutl<SurveyEssentialVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<PaginationResutl<SurveyEssentialVM>> apiResponse = new WebApiResponse<PaginationResutl<SurveyEssentialVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetBeneficiaryByFcvVcf/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<SurveyVM>>>> GetBeneficiaryByFcvVcf(long id)
        {
            (ExecutionState executionState, List<SurveyVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<SurveyVM> entity, string message) result = await _surveyService.GetBeneficiaryByFcvVcf(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<SurveyVM>> apiResponse = new WebApiResponse<List<SurveyVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<SurveyVM>> apiResponse = new WebApiResponse<List<SurveyVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<List<SurveyVM>> apiResponse = new WebApiResponse<List<SurveyVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadMembers/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<HouseholdMemberVM>>>> LoadMembers(long id)
        {
            (ExecutionState executionState, List<HouseholdMemberVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<HouseholdMemberVM> entity, string message) result = await _surveyService.LoadMembers(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<HouseholdMemberVM>> apiResponse = new WebApiResponse<List<HouseholdMemberVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<HouseholdMemberVM>> apiResponse = new WebApiResponse<List<HouseholdMemberVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<List<HouseholdMemberVM>> apiResponse = new WebApiResponse<List<HouseholdMemberVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadEconomicStatus/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<EconomicStatusModelVM>>> LoadEconomicStatus(long id)
        {
            (ExecutionState executionState, EconomicStatusModelVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, EconomicStatusModelVM entity, string message) result = await _surveyService.LoadEconomicStatus(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<EconomicStatusModelVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<EconomicStatusModelVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<EconomicStatusModelVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadSocioEconomicStatus/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<SocioEconomicStatusModelVM>>> LoadSocioEconomicStatus(long id)
        {
            (ExecutionState executionState, SocioEconomicStatusModelVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, SocioEconomicStatusModelVM entity, string message) result = await _surveyService.LoadSocioEconomicStatus(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SocioEconomicStatusModelVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SocioEconomicStatusModelVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SocioEconomicStatusModelVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadExistingSkill/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<ExistingSkillVM>>>> LoadExistingSkill(long id)
        {
            (ExecutionState executionState, List<ExistingSkillVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<ExistingSkillVM> entity, string message) result = await _surveyService.LoadExistingSkill(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ExistingSkillVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ExistingSkillVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<ExistingSkillVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadAnnualHouseholdExpenditure/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AnnualHouseholdExpenditureVM>>>> LoadAnnualHouseholdExpenditure(long id)
        {
            (ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message) result = await _surveyService.LoadAnnualHouseholdExpenditure(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<AnnualHouseholdExpenditureVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<AnnualHouseholdExpenditureVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<AnnualHouseholdExpenditureVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadFoodSecurityItem/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<FoodSecurityItemVM>>>> LoadFoodSecurityItem(long id)
        {
            (ExecutionState executionState, List<FoodSecurityItemVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<FoodSecurityItemVM> entity, string message) result = await _surveyService.LoadFoodSecurityItem(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<FoodSecurityItemVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<FoodSecurityItemVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<FoodSecurityItemVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadVulnerabilitySituation/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<VulnerabilitySituationVM>>>> LoadVulnerabilitySituation(long id)
        {
            (ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message) result = await _surveyService.LoadVulnerabilitySituation(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<VulnerabilitySituationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<VulnerabilitySituationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<VulnerabilitySituationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadGrossMarginIncomeAndCostStatus/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<GrossMarginIncomeAndCostStatusVM>>>> LoadGrossMarginIncomeAndCostStatus(long id)
        {
            (ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message) result = await _surveyService.LoadGrossMarginIncomeAndCostStatus(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<GrossMarginIncomeAndCostStatusVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<GrossMarginIncomeAndCostStatusVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<GrossMarginIncomeAndCostStatusVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadManualPhysicalWork/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<ManualPhysicalWorkVM>>>> LoadManualPhysicalWork(long id)
        {
            (ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message) result = await _surveyService.LoadManualPhysicalWork(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ManualPhysicalWorkVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ManualPhysicalWorkVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<ManualPhysicalWorkVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadNaturalResourcesIncomeAndCostStatus/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<NaturalResourcesIncomeAndCostStatusVM>>>> LoadNaturalResourcesIncomeAndCostStatus(long id)
        {
            (ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message) result = await _surveyService.LoadNaturalResourcesIncomeAndCostStatus(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<NaturalResourcesIncomeAndCostStatusVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<NaturalResourcesIncomeAndCostStatusVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<NaturalResourcesIncomeAndCostStatusVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadOtherIncomeSource/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<OtherIncomeSourceVM>>>> LoadOtherIncomeSource(long id)
        {
            (ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message) result = await _surveyService.LoadOtherIncomeSource(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<OtherIncomeSourceVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<OtherIncomeSourceVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<OtherIncomeSourceVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadBusiness/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<BusinessVM>>>> LoadBusiness(long id)
        {
            (ExecutionState executionState, List<BusinessVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<BusinessVM> entity, string message) result = await _surveyService.LoadBusiness(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<BusinessVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<BusinessVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<BusinessVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadLandOccupancy/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<LandOccupancyVM>>>> LoadLandOccupancy(long id)
        {
            (ExecutionState executionState, List<LandOccupancyVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<LandOccupancyVM> entity, string message) result = await _surveyService.LoadLandOccupancy(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<LandOccupancyVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<LandOccupancyVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<LandOccupancyVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadLiveStock/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<LiveStockVM>>>> LoadLiveStock(long id)
        {
            (ExecutionState executionState, List<LiveStockVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<LiveStockVM> entity, string message) result = await _surveyService.LoadLiveStock(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<LiveStockVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<LiveStockVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<LiveStockVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadAsset/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AssetVM>>>> LoadAsset(long id)
        {
            (ExecutionState executionState, List<AssetVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<AssetVM> entity, string message) result = await _surveyService.LoadAsset(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<AssetVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<AssetVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<AssetVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadImmovableAsset/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<ImmovableAssetVM>>>> LoadImmovableAsset(long id)
        {
            (ExecutionState executionState, List<ImmovableAssetVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<ImmovableAssetVM> entity, string message) result = await _surveyService.LoadImmovableAsset(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ImmovableAssetVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<ImmovableAssetVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<ImmovableAssetVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadEnergyUse/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<EnergyUseVM>>>> LoadEnergyUse(long id)
        {
            (ExecutionState executionState, List<EnergyUseVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<EnergyUseVM> entity, string message) result = await _surveyService.LoadEnergyUse(id);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<EnergyUseVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<EnergyUseVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<EnergyUseVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("ListLatest/{take}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<SurveyEssentialVM>>>> ListLatest(int take = 50)
        {
            (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<SurveyEssentialVM> entity, string message) result = await _surveyBusiness.ListLatest(take);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<SurveyEssentialVM>> apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<List<SurveyEssentialVM>> apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<List<SurveyEssentialVM>> apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("LoadAllChilds/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<SurveyChildsVM>>> LoadAllChilds(long id)
        {
            (ExecutionState executionState, SurveyChildsVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, SurveyChildsVM entity, string message) result = await _surveyService.LoadAllChilds(id);
                if (result.executionState == ExecutionState.Success)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyChildsVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<SurveyChildsVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SurveyChildsVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("ListNotHasAccountIncluding/{surveyId?}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<SurveyEssentialVM>>>> ListNotHasAccountIncluding(ForestCivilLocationFilter filter, long? surveyId = null)
        {
            (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<SurveyEssentialVM> entity, string message) result = await _surveyBusiness.ListNotHasAccountIncluding(filter, surveyId);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<SurveyEssentialVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("ApproveStatus/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<bool>>> ApproveStatus(long surveyId)
        {
            var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
            _ = long.TryParse(userIdJwt, out var userId);

            (ExecutionState executionState, bool entity, string message) responseResult;

            if (surveyId < 1)
            {
                return BadRequest(new WebApiResponse<bool>((ExecutionState.Failure, false, "Invalid id")));
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _surveyBusiness.ApproveStatus(surveyId, userId);

                if (result.executionState == ExecutionState.Updated)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = false;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<bool>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("RequestStatus/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<bool>>> RequestStatus(long surveyId)
        {
            var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
            _ = long.TryParse(userIdJwt, out var userId);

            (ExecutionState executionState, bool entity, string message) responseResult;

            if (surveyId < 1)
            {
                return BadRequest(new WebApiResponse<bool>((ExecutionState.Failure, false, "Invalid id")));
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _surveyBusiness.RejectStatus(surveyId, userId);

                if (result.executionState == ExecutionState.Updated)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = false;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<bool>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }




        [HttpGet("PendingStatus/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<bool>>> PendingStatus(long surveyId)
        {
            var userIdJwt = HttpContext.User.FindFirst("UserId")?.Value;
            _ = long.TryParse(userIdJwt, out var userId);

            (ExecutionState executionState, bool entity, string message) responseResult;

            if (surveyId < 1)
            {
                return BadRequest(new WebApiResponse<bool>((ExecutionState.Failure, false, "Invalid id")));
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _surveyBusiness.PendingStatus(surveyId, userId);

                if (result.executionState == ExecutionState.Updated)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = false;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<bool>(responseResult);
                    return BadRequest(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<bool>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("DropdownOthers")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<SurveyDropdownOthers>>> DropdownOthers()
        {
            (ExecutionState executionState, SurveyDropdownOthers entity, string message) responseResult;
           
            try
            {
                var result = await _surveyBusiness.DropdownOthers();

                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<SurveyDropdownOthers>(responseResult);

                return Ok(apiResponse);
            }
            catch (Exception e)
            {
                responseResult.entity = new SurveyDropdownOthers();
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SurveyDropdownOthers>(responseResult);

                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("DropdownLocation")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<SurveyDropdownLocation>>> DropdownLocation()
        {
            (ExecutionState executionState, SurveyDropdownLocation entity, string message) responseResult;
           
            try
            {
                var result = await _surveyBusiness.DropdownLocation();

                return Ok(new WebApiResponse<SurveyDropdownLocation>((result.executionState, result.entity, result.message)));
            }
            catch (Exception e)
            {
                responseResult.entity = new SurveyDropdownLocation();
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<SurveyDropdownLocation>(responseResult);

                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("UploadFiles/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<bool>>> UploadFiles(
            IFormFile beneficiaryProfileImage,
            List<IFormFile> surveyDocuments,
            IFormFile beneficiaryHouseFrontImage,
            IFormFile nidFrontImage,
            IFormFile nidBackImage,
            IFormFile notesImage,
            long surveyId,
            bool isUpdating)
        {
            (ExecutionState executionState, bool entity, string message) responseResult;
           
            try
            {
                // Check if survey id is exists
                var result = await _surveyBusiness.DoesExistAsync(surveyId);
                if (result.executionState != ExecutionState.Success)
                {
                    return NotFound(
                        new WebApiResponse<bool>
                        {
                            ExecutionState = result.executionState,
                            Data = false,
                            Message = result.message
                        });
                }

                // Save files to disk
                var beneficiaryProfileImageSaved = string.Empty;
                var surveyDocumentsSaved = new List<SurveyDocument>();
                var beneficiaryHouseFrontImageSaved = string.Empty;
                var beneficiaryNidFrontImageSaved = string.Empty;
                var beneficiaryNidBackImageSaved = string.Empty;
                var notesImageSaved = string.Empty;

                // Profile image
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiaryProfileImage, FileType.Image, "BeneficiaryProfile", out var errorMessage);
                    if (isSaved == false && isUpdating == false)
                    {
                        return NotFound(
                            new WebApiResponse<bool>
                            {
                                ExecutionState = ExecutionState.Failure,
                                Data = false,
                                Message = errorMessage
                            });
                    }
                    if (isSaved) beneficiaryProfileImageSaved = fileUrl;
                }

                // Documents
                {
                    foreach (var document in surveyDocuments)
                    {
                        var (isSaved, fileUrl, fileName) = _fileHelper.SaveFile(document, FileType.Document, "beneficiaryDocument", out var errorMessage);
                        if (isSaved == false)
                        {
                            return NotFound(
                                new WebApiResponse<bool>
                                {
                                    ExecutionState = ExecutionState.Failure,
                                    Data = false,
                                    Message = errorMessage
                                });
                        }
                        if (isSaved) surveyDocumentsSaved.Add(new SurveyDocument
                        {
                            SurveyId = surveyId,
                            DocumentNameURL = fileUrl,
                            DocumentName = fileName
                        });
                    }
                }

                // House front image
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiaryHouseFrontImage, FileType.Image, "BeneficiaryHouseFrontImage", out var errorMessage);
                    if (isSaved == false && isUpdating == false)
                    {
                        return NotFound(
                            new WebApiResponse<bool>
                            {
                                ExecutionState = ExecutionState.Failure,
                                Data = false,
                                Message = errorMessage
                            });
                    }
                    if (isSaved) beneficiaryHouseFrontImageSaved = fileUrl;
                }

                // Nid Front Image
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nidFrontImage, FileType.Image, "BeneficiaryNID", out var errorMessage);
                    if (isSaved == false && isUpdating == false)
                    {
                        return NotFound(
                            new WebApiResponse<bool>
                            {
                                ExecutionState = ExecutionState.Failure,
                                Data = false,
                                Message = errorMessage
                            });
                    }
                    if (isSaved) beneficiaryNidFrontImageSaved = fileUrl;
                }

                // Nid Back Image
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(nidBackImage, FileType.Image, "BeneficiaryNID", out var errorMessage);
                    if (isSaved == false && isUpdating == false)
                    {
                        return NotFound(
                            new WebApiResponse<bool>
                            {
                                ExecutionState = ExecutionState.Failure,
                                Data = false,
                                Message = errorMessage
                            });
                    }
                    if (isSaved) beneficiaryNidBackImageSaved = fileUrl;
                }

                // Notes image
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(notesImage, FileType.Image, "BeneficiaryNotesImage", out var errorMessage);
                    if (isSaved) notesImageSaved = fileUrl;
                }

                var fileSaveResult = await _surveyBusiness.UploadFiles(
                    surveyId: surveyId,
                    profileUrl: beneficiaryProfileImageSaved,
                    documents: surveyDocumentsSaved,
                    beneficiaryHouseFrontImageUrl: beneficiaryHouseFrontImageSaved,
                    beneficiaryNidFrontImageUrl: beneficiaryNidFrontImageSaved,
                    beneficiaryNidBackImageUrl: beneficiaryNidBackImageSaved,
                    notesImageUrl: notesImageSaved);

                if (fileSaveResult.executionState == ExecutionState.Success)
                {
                    responseResult.entity = fileSaveResult.entity;
                    responseResult.executionState = fileSaveResult.executionState;
                    responseResult.message = fileSaveResult.message;
                    return Ok(responseResult);
                }
                else
                {
                    responseResult.entity = fileSaveResult.entity;
                    responseResult.executionState = fileSaveResult.executionState;
                    responseResult.message = fileSaveResult.message;
                    return StatusCode((int)HttpStatusCode.BadRequest, responseResult);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                return StatusCode(500, responseResult);
            }
        }

        [HttpGet("Activate/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<SurveyDropdownLocation>>> Activate([FromRoute] long surveyId)
        {
            try
            {
                var (executionState, entity, message) = await _surveyBusiness.Activate(surveyId, HttpContext.GetCurrentUserId());

                return Ok(new WebApiResponse<bool>((executionState, entity, message)));
            }
            catch (Exception e)
            {
                return StatusCode(500, new WebApiResponse<bool>((ExecutionState.Failure, false, e.Message)));
            }
        }

        [HttpGet("Deactivate/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<SurveyDropdownLocation>>> Deactivate([FromRoute] long surveyId)
        {
            try
            {
                var (executionState, entity, message) = await _surveyBusiness.Deactivate(surveyId, HttpContext.GetCurrentUserId());

                return Ok(new WebApiResponse<bool>((executionState, entity, message)));
            }
            catch (Exception e)
            {
                return StatusCode(500, new WebApiResponse<bool>((ExecutionState.Failure, false, e.Message)));
            }
        }
    }
}
