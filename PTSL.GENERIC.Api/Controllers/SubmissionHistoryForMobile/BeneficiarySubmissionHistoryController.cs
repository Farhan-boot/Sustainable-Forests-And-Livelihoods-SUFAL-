using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Api.Helpers;
using PTSL.GENERIC.Business.Businesses.Implementation.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile;
using PTSL.GENERIC.Service.Services;
using PTSL.GENERIC.Service.Services.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Business.Businesses.Implementation.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Api.Controllers.SubmissionHistoryForMobile
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarySubmissionHistoryController : BaseController<IBeneficiarySubmissionHistoryService, BeneficiarySubmissionHistoryVM, BeneficiarySubmissionHistory>
    {
        private readonly IBeneficiarySubmissionHistoryService _beneficiarySubmissionHistoryService;
        private readonly IBeneficiarySubmissionHistoryBusiness _beneficiarySubmissionHistoryBusiness;
        private readonly FileHelper _fileHelper;
        public BeneficiarySubmissionHistoryController(IBeneficiarySubmissionHistoryService service, IBeneficiarySubmissionHistoryBusiness beneficiarySubmissionHistoryBusiness, FileHelper fileHelper) :
            base(service)
        {
            _beneficiarySubmissionHistoryService = service;
            _beneficiarySubmissionHistoryBusiness = beneficiarySubmissionHistoryBusiness;
            _fileHelper = fileHelper;
        }



        [HttpPost("UploadFiles")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<WebApiResponse<bool>>> UploadFiles(
            long? SurveyId,
            long? AIGBasicInformationId,
            long? InternalLoanInformationId,
            long? SavingsAccountId,
           IFormFile beneficiarySubmissionHistoryFile)
        {
            (ExecutionState executionState, bool entity, string message) responseResult;

            
           BeneficiarySubmissionHistoryVM entity = new BeneficiarySubmissionHistoryVM
           {
               SurveyId = SurveyId,
               AIGBasicInformationId = AIGBasicInformationId,
               InternalLoanInformationId = InternalLoanInformationId,
               SavingsAccountId = SavingsAccountId,
           };

            try
            {
               
                // Save files to disk
                var beneficiarySubmissionHistoryFileSaved = string.Empty;
                var beneficiarySubmissionHistoryDocumentsSaved = new List<BeneficiarySubmissionHistory>();


                // Documents
                {
                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiarySubmissionHistoryFile, FileType.Unknown, "BeneficiarySubmissionHistoryImage", out var errorMessage);
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
                    if (isSaved) beneficiarySubmissionHistoryFileSaved = fileUrl;
                }

      
                var fileSaveResult = await _beneficiarySubmissionHistoryBusiness.UploadFiles(
                    entity: entity,
                    beneficiarySubmissionHistoryFileUrl: beneficiarySubmissionHistoryFileSaved
                    );



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














    }
}