using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers.Authorize;
using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG.Reports;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AIGBasicInformationController : BaseController<IAIGBasicInformationService, AIGBasicInformationVM, AIGBasicInformation>
    {
        private readonly IAIGBasicInformationService _service;
        private readonly IAIGBasicInformationBusiness _business;

        public AIGBasicInformationController(IAIGBasicInformationService service, IAIGBasicInformationBusiness business) :
            base(service)
        {
            _service = service;
            _business = business;
        }

        [HttpGet("GetIncludeFirstSecondAndBen/{aigId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<AIGBasicInformationVM>>> GetIncludeFirstSecondAndBen(long aigId)
        {
            (ExecutionState executionState, AIGBasicInformationVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, AIGBasicInformationVM entity, string message) result = await _service.GetIncludeFirstSecondAndBen(aigId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<AIGBasicInformationVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<AIGBasicInformationVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<AIGBasicInformationVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("GetAIGByFilter")]
        [Authorize]
        [Authorize(Policy = AIGGetByFilterPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<AIGBasicInformationVM>>>> GetAIGByFilter(AIGBasicInformationFilterVM filterData)
        {
            (ExecutionState executionState, PaginationResutl<AIGBasicInformationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<AIGBasicInformationVM> entity, string message) result = await _service.GetAIGByFilter(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    //foreach (var item in responseResult.entity)
                    //{
                    //    item.Survey = new SurveyVM();
                    //}

                    foreach (var item in responseResult.entity.aaData)
                    {
                        //item.Survey = new Survey();
                        item.Survey = new SurveyVM
                        {
                            Id = item.Survey.Id,
                            BeneficiaryName = item.Survey.BeneficiaryName,
                            BeneficiaryPhone = item.Survey.BeneficiaryPhone,
                            BeneficiaryNid = item.Survey.BeneficiaryNid,
                        };
                    }

                    WebApiResponse<PaginationResutl<AIGBasicInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<AIGBasicInformationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<PaginationResutl<AIGBasicInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<AIGBasicInformationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<PaginationResutl<AIGBasicInformationVM>> apiResponse = new WebApiResponse<PaginationResutl<AIGBasicInformationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("SetBadLoanData")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<bool>>> SetBadLoanData()
        {
            (ExecutionState executionState, bool entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _business.SetBadLoanData();
                if (result.executionState == ExecutionState.Success)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<bool> apiResponse = new WebApiResponse<bool>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = false;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<bool> apiResponse = new WebApiResponse<bool>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = false;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<bool> apiResponse = new WebApiResponse<bool>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("RepaymentReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<AIGBasicInformationVM>>>> RepaymentReport(RepaymentReportFilterVM filterData)
        {
            (ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message) result = await _service.RepaymentReport(filterData);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("BeneficiaryWiseRepaymentProgress/{surveyId}")]
        [Authorize(Policy = AIGProgressByBeneficiaryPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<IList<AIGBasicInformationVM>>>> BeneficiaryWiseRepaymentProgress([FromRoute] long surveyId)
        {
            (ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<AIGBasicInformationVM> entity, string message) result = await _service.BeneficiaryWiseRepaymentProgress(surveyId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                WebApiResponse<IList<AIGBasicInformationVM>> apiResponse = new WebApiResponse<IList<AIGBasicInformationVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("AIGBeneficiaryCheckEligibility/{surveyId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<AIGBeneficiaryCheckEligibilityVM>>> AIGBeneficiaryCheckEligibility(long surveyId)
        {
            try
            {
                var (executionState, entity, message) = await _business.AIGBeneficiaryCheckEligibility(surveyId);

                return Ok(new WebApiResponse<AIGBeneficiaryCheckEligibilityVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<AIGBeneficiaryCheckEligibilityVM>(
                        (ExecutionState.Failure, new AIGBeneficiaryCheckEligibilityVM(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("AverageLoanSizeFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AverageLoanSizeVM>>>> AverageLoanSizeFilter([FromBody] AverageLoanSizeFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.AverageLoanSizeFilter(filter);

                return Ok(new WebApiResponse<List<AverageLoanSizeVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<AverageLoanSizeVM>>(
                        (ExecutionState.Failure, new List<AverageLoanSizeVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("AIGLoanStatusReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<AIGLoanStatusReportVM>>>> AIGLoanStatusReport([FromBody] AIGLoanStatusReportFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.AIGLoanStatusReport(filter);

                return Ok(new WebApiResponse<List<AIGLoanStatusReportVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<AIGLoanStatusReportVM>>(
                        (ExecutionState.Failure, new List<AIGLoanStatusReportVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("CumulativeRecoveryRateReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<CumulativeRecoveryRateVM>>>> CumulativeRecoveryRateReport([FromBody] CumulativeRecoveryRateFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.CumulativeRecoveryRateReport(filter);

                return Ok(new WebApiResponse<List<CumulativeRecoveryRateVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<CumulativeRecoveryRateVM>>(
                        (ExecutionState.Failure, new List<CumulativeRecoveryRateVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("OnTimeRecoveryRate")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<OnTimeRecoveryRateVM>>>> OnTimeRecoveryRate([FromBody] OnTimeRecoveryRateFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.OnTimeRecoveryRate(filter);

                return Ok(new WebApiResponse<List<OnTimeRecoveryRateVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<OnTimeRecoveryRateVM>>(
                        (ExecutionState.Failure, new List<OnTimeRecoveryRateVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("PortfolioAtRisk")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<PortfolioAtRiskVM>>>> PortfolioAtRisk([FromBody] PortfolioAtRiskFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.PortfolioAtRisk(filter);

                return Ok(new WebApiResponse<List<PortfolioAtRiskVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<PortfolioAtRiskVM>>(
                        (ExecutionState.Failure, new List<PortfolioAtRiskVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("DelinquencyRatio")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<DelinquencyRatioVM>>>> DelinquencyRatio([FromBody] DelinquencyRatioFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.DelinquencyRatio(filter);

                return Ok(new WebApiResponse<List<DelinquencyRatioVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<DelinquencyRatioVM>>(
                        (ExecutionState.Failure, new List<DelinquencyRatioVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("BorrowerPerVillageReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<BorrowerPerVillageVM>>>> BorrowerPerVillageReport([FromBody] BorrowerPerVillageFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.BorrowerPerVillageReport(filter);

                return Ok(new WebApiResponse<List<BorrowerPerVillageVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<BorrowerPerVillageVM>>(
                        (ExecutionState.Failure, new List<BorrowerPerVillageVM>(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("BorrowerCoverageReport")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<BorrowerCoverageVM>>>> BorrowerCoverageReport([FromBody] BorrowerCoverageFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.BorrowerCoverageReport(filter);

                return Ok(new WebApiResponse<List<BorrowerCoverageVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<BorrowerCoverageVM>>(
                        (ExecutionState.Failure, new List<BorrowerCoverageVM>(), "Unexpected error occurred")
                    ));
            }
        }



        [HttpPost("PortfolioPerVillage")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<List<PortfolioPerVillageVM>>>> PortfolioPerVillage([FromBody] PortfolioPerVillageFilterVM filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.PortfolioPerVillage(filter);

                return Ok(new WebApiResponse<List<PortfolioPerVillageVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new WebApiResponse<List<PortfolioPerVillageVM>>(
                        (ExecutionState.Failure, new List<PortfolioPerVillageVM>(), "Unexpected error occurred")
                    ));
            }
        }



        [HttpPut]
        [Authorize(Policy = AIGEditPermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<AIGBasicInformationVM>>> UpdateAsync([FromBody] AIGBasicInformationVM model)
        {
            return base.UpdateAsync(model);
        }

        [HttpPost]
        [Authorize(Policy = AIGCreatePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<AIGBasicInformationVM>>> CreateAsync([FromBody] AIGBasicInformationVM model)
        {
            return base.CreateAsync(model);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AIGDeletePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<AIGBasicInformationVM>>> RemoveAsync(long id)
        {
            return base.RemoveAsync(id);
        }

        [HttpPut("SoftDelete/{id}")]
        [Authorize(Policy = AIGDeletePermission.PermissionNameConst)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override Task<ActionResult<WebApiResponse<bool>>> SoftDeleteAsync(long id)
        {
            return base.SoftDeleteAsync(id);
        }
    }
}

public class AIGGetByFilterPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.GetByFilter";
    public string PermissionName => "AIG.GetByFilter";
    public string PermissionDetails => "AIG List";
}

public class AIGCreatePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Create";
    public string PermissionName => "AIG.Create";
    public string PermissionDetails => "Create AIG";
}

public class AIGEditPermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Edit";
    public string PermissionName => "AIG.Edit";
    public string PermissionDetails => "Edit AIG";
}

public class AIGDeletePermission : IAPIPermission
{
    public const string PermissionNameConst = "AIG.Delete";
    public string PermissionName => "AIG.Delete";
    public string PermissionDetails => "Delete AIG";
}

