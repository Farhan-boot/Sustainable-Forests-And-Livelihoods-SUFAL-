using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.Capacity
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualLDFInfoFormController : BaseController<IIndividualLDFInfoFormService, IndividualLDFInfoFormVM, IndividualLDFInfoForm>
    {
        private readonly IIndividualLDFInfoFormService _service;
        private readonly IIndividualLDFInfoFormBusiness _business;

        public IndividualLDFInfoFormController(IIndividualLDFInfoFormService service, IIndividualLDFInfoFormBusiness business) :
            base(service)
        {
            _service = service;
            _business = business;
        }

        [HttpGet("ApproveLDF/{ldfId}/{approvedLoanAmount}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<bool>>> ApproveLDF(long ldfId, double approvedLoanAmount)
        {
            (ExecutionState executionState, bool entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _business.ApproveLDF(ldfId, approvedLoanAmount);
                if (result.executionState == ExecutionState.Success)
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
                    return NotFound(apiResponse);
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

        [HttpGet("RejectLDF/{ldfId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<bool>>> RejectLDF(long ldfId)
        {
            (ExecutionState executionState, bool entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, bool entity, string message) result = await _business.RejectLDF(ldfId);
                if (result.executionState == ExecutionState.Retrieved)
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
                    return NotFound(apiResponse);
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

        [HttpPost("ListByFilter")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<IndividualLDFInfoFormVM>>>> ListByFilter(IndividualLDFFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutl<IndividualLDFInfoFormVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, PaginationResutl<IndividualLDFInfoFormVM> entity, string message) result = await _service.ListByFilter(filter);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<IndividualLDFInfoFormVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<PaginationResutl<IndividualLDFInfoFormVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<PaginationResutl<IndividualLDFInfoFormVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("ListByFilterBasic")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<IndividualLDFInfoFormVM>>>> ListByFilterBasic(IndividualLDFFilterVM filter)
        {
            (ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, List<IndividualLDFInfoFormVM> entity, string message) result = await _service.ListByFilterBasic(filter);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<IndividualLDFInfoFormVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<IndividualLDFInfoFormVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<IndividualLDFInfoFormVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("ListByFilterBeneficiary")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<SurveyDropdownVM>>>> ListByFilterBeneficiary(IndividualLDFFilterVM filter)
        {
            (ExecutionState executionState, IList<SurveyDropdownVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<SurveyDropdownVM> entity, string message) result = await _business.ListByFilterBeneficiary(filter);

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<SurveyDropdownVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<IList<SurveyDropdownVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<IList<SurveyDropdownVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("GetLDFAmountForBeneficiary/{beneficiaryId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<double>>> GetLDFAmountForBeneficiary([FromRoute] long beneficiaryId)
        {
            try
            {
                var (executionState, amount, message) = await _business.GetLDFAmountForBeneficiary(beneficiaryId);

                return Ok(new WebApiResponse<double>((executionState, amount, message)));
            }
            catch
            {
                return Ok(new WebApiResponse<double>((ExecutionState.Failure, 0, "An unexpected error occurred")));
            }
        }
    }
}
