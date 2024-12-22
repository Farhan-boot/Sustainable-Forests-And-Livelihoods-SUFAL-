using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Interface.TransactionMangement;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Service.Services.TransactionMangement;

namespace PTSL.GENERIC.Api.Controllers.Beneficiary;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransactionController : BaseController<ITransactionService, TransactionVM, Transaction>
{
    private readonly ITransactionService _service;
    private readonly ITransactionBusiness _business;

    public TransactionController(ITransactionService service, ITransactionBusiness business) :
        base(service)
    {
        _service = service;
        _business = business;
    }

    [HttpGet("DashboardData")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<WebApiResponse<TransactionDashboardVM>>> DashboardData()
    {
        (ExecutionState executionState, TransactionDashboardVM entity, string message) responseResult;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, TransactionDashboardVM entity, string message) result = await _business.DashboardData();
            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<TransactionDashboardVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<TransactionDashboardVM>(responseResult);
                return NotFound(apiResponse);
            }
        }
        catch (Exception e)
        {
            responseResult.entity = null;
            responseResult.executionState = ExecutionState.Failure;
            responseResult.message = e.Message;
            var apiResponse = new WebApiResponse<TransactionDashboardVM>(responseResult);
            return StatusCode(500, apiResponse);
        }
    }

    [HttpGet("DivisionListByFinancialYear")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public virtual async Task<ActionResult<WebApiResponse<List<long>>>> DivisionListByFinancialYear(long financialYearId)
    {
        (ExecutionState executionState, List<long> entity, string message) responseResult;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, List<long> entity, string message) result = await _business.DivisionListByFinancialYear(financialYearId);
            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<List<long>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<List<long>>(responseResult);
                return NotFound(apiResponse);
            }
        }
        catch (Exception e)
        {
            responseResult.entity = null;
            responseResult.executionState = ExecutionState.Failure;
            responseResult.message = e.Message;
            var apiResponse = new WebApiResponse<List<long>>(responseResult);
            return StatusCode(500, apiResponse);
        }
    }

    [HttpGet("GetDetails/{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebApiResponse<TransactionVM>>> GetDetails(long id)
    {
        (ExecutionState executionState, TransactionVM entity, string message) responseResult;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, TransactionVM entity, string message) result = await _service.GetDetails(id);

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<TransactionVM>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<TransactionVM>(responseResult);
                return NotFound(apiResponse);
            }
        }
        catch (Exception e)
        {
            responseResult.entity = null;
            responseResult.executionState = ExecutionState.Failure;
            responseResult.message = e.Message;
            var apiResponse = new WebApiResponse<TransactionVM>(responseResult);
            return StatusCode(500, apiResponse);
        }
    }

    [HttpGet("ListDate/{financialYearId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebApiResponse<IList<TransactionDateVM>>>> ListDate(long financialYearId)
    {
        (ExecutionState executionState, IList<TransactionDateVM> entity, string message) responseResult;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<TransactionDateVM> entity, string message) result = await _business.ListDate(financialYearId);

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<TransactionDateVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<TransactionDateVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
        catch (Exception e)
        {
            responseResult.entity = null;
            responseResult.executionState = ExecutionState.Failure;
            responseResult.message = e.Message;
            var apiResponse = new WebApiResponse<IList<TransactionDateVM>>(responseResult);
            return StatusCode(500, apiResponse);
        }
    }

    [HttpPost("GetByFilter")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebApiResponse<IList<TransactionVM>>>> GetByFilter(TransactionFilterVM filter)
    {
        (ExecutionState executionState, IList<TransactionVM> entity, string message) responseResult;

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, List<TransactionVM> entity, string message) result = await _service.GetByFilter(filter);

            if (result.executionState == ExecutionState.Retrieved)
            {
                responseResult.entity = result.entity;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<TransactionVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.executionState = result.executionState;
                responseResult.message = result.message;
                var apiResponse = new WebApiResponse<IList<TransactionVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }
        catch (Exception e)
        {
            responseResult.entity = null;
            responseResult.executionState = ExecutionState.Failure;
            responseResult.message = e.Message;
            var apiResponse = new WebApiResponse<IList<TransactionVM>>(responseResult);
            return StatusCode(500, apiResponse);
        }
    }
}
