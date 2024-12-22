using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.AIG;

namespace PTSL.GENERIC.Api.Controllers.AIG
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentLDFFileController : BaseController<IRepaymentLDFFileService, RepaymentLDFFileVM, RepaymentLDFFile>
    {


        private readonly IRepaymentLDFFileService _service;
        private readonly IRepaymentLDFFileBusiness _business;
        public RepaymentLDFFileController(IRepaymentLDFFileService service, IRepaymentLDFFileBusiness business) :
            base(service)
        {
            _service = service;
            _business = business;
        }


        [HttpGet("GetRepaymentLDFFileByRepaymentId/{repaymentId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RepaymentLDFFileVM>>> GetRepaymentLDFFileByRepaymentId(long repaymentId)
        {
            (ExecutionState executionState, List<RepaymentLDFFileVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _service.GetRepaymentLDFFileByRepaymentId(repaymentId);

                

                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity =  result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<RepaymentLDFFileVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;
                    var apiResponse = new WebApiResponse<List<RepaymentLDFFileVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;
                var apiResponse = new WebApiResponse<List<RepaymentLDFFileVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

    }
}