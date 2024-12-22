using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PTSL.GENERIC.Business.Businesses.Interface.AIG;
using PTSL.GENERIC.Business.Businesses.Interface.Beneficiary;
using PTSL.GENERIC.Business.Businesses.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Business.Businesses.Interface.ForestManagement;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.Common.Entity.BeneficiarySavingsAccount;
using PTSL.GENERIC.Common.Entity.InternalLoan;
using PTSL.GENERIC.Common.Entity.TransactionMangement;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Helper;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;
using PTSL.GENERIC.Service.Services.AIG;
using PTSL.GENERIC.Service.Services.Beneficiary;
using PTSL.GENERIC.Service.Services.BeneficiarySavingsAccount;
using PTSL.GENERIC.Service.Services.Interface;
using PTSL.GENERIC.Service.Services.Interface.Capacity;
using PTSL.GENERIC.Service.Services.InternalLoan;
using PTSL.GENERIC.Service.Services.NecessaryLinkManagement;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Api.Controllers.DashBoard
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly GENERICReadOnlyCtx _genericReadOnlyCtx;
        private readonly IEnergyUseBusiness _energyUseBusiness;
        private readonly ICommitteeManagementBusiness _committeeManagementBusiness;
        private readonly IHouseholdMemberBusiness _householdMemberBusiness;
        private readonly ICipBusiness _cipBusiness;
        private readonly ISurveyBusiness _surveyBusiness;
        private readonly ISurveyService _surveyService;
        private readonly IAIGBasicInformationBusiness _aIGBasicBusiness;
        private readonly ISavingsAccountBusiness _savingsAccountBusiness;

        private readonly INecessaryLinkService _necessaryLinkService;
        private readonly IMeetingService _meetingService;
        private readonly ICommunityTrainingService _communityTrainingService;
        private readonly IInternalLoanInformationService _internalLoanInformationService;
        private readonly IAIGBasicInformationService _aIGBasicInformationService;

        private readonly IMeetingParticipantsMapService _meetingParticipantsMapService;
        private readonly ICommunityTrainingParticipentsMapService _communityTrainingParticipentsMapService;



        public DashBoardController(
            GENERICReadOnlyCtx genericReadOnlyCtx,
            IEnergyUseBusiness energyUseBusiness,
            ICommitteeManagementBusiness committeeManagementBusiness,
            IHouseholdMemberBusiness householdMemberBusiness,
            ICipBusiness cipBusiness,
            ISurveyBusiness surveyBusiness,
            ISurveyService surveyService,
            IAIGBasicInformationBusiness aIGBasicInformation,
            INecessaryLinkService necessaryLinkService,
            IMeetingService meetingService,
            ICommunityTrainingService communityTrainingService,
            IInternalLoanInformationService internalLoanInformationService,
            IAIGBasicInformationService aIGBasicInformationsService,
            ISavingsAccountBusiness savingsAccountBusiness,
            IMeetingParticipantsMapService meetingParticipantsMapService,
            ICommunityTrainingParticipentsMapService communityTrainingParticipentsMapService)
        {
            _genericReadOnlyCtx = genericReadOnlyCtx;
            _energyUseBusiness = energyUseBusiness;
            _committeeManagementBusiness = committeeManagementBusiness;
            _householdMemberBusiness = householdMemberBusiness;
            _cipBusiness = cipBusiness;
            _surveyBusiness = surveyBusiness;
            _surveyService = surveyService;
            _aIGBasicBusiness = aIGBasicInformation;
            _savingsAccountBusiness = savingsAccountBusiness;
            //Mobile Api
            _necessaryLinkService = necessaryLinkService;
            _meetingService = meetingService;
            _communityTrainingService = communityTrainingService;
            _internalLoanInformationService = internalLoanInformationService;
            _aIGBasicInformationService = aIGBasicInformationsService;
            _meetingParticipantsMapService = meetingParticipantsMapService;
            _communityTrainingParticipentsMapService = communityTrainingParticipentsMapService;
        }

        [HttpPost("GetTotalBeneficiary")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<BeneficiaryVM>>> GetTotalBeneficiary([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, BeneficiaryVM entity, string message) result = await _surveyBusiness.GetTotalBeneficiary(filter);

                return result.executionState == ExecutionState.Success
                    ? Ok(new WebApiResponse<BeneficiaryVM>() { Data = result.entity, ExecutionState = ExecutionState.Retrieved, Message = "Success" })
                    : NotFound(new WebApiResponse<BeneficiaryVM>() { Data = result.entity, ExecutionState = ExecutionState.Retrieved, Message = "Failure" });
            }
            catch (Exception)
            {
                return StatusCode(500, new BeneficiaryVM());
            }
        }

        [HttpPost("GetTotalFcvVcfAndExecutiveSubExecutives")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<CommitteeMemberCount>>> GetTotalFcvVcfAndExecutiveSubExecutive([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _committeeManagementBusiness.GetTotalFcvVcfAndExecutiveSubExecutive(filter);

                return Ok(new WebApiResponse<CommitteeMemberCount>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<CommitteeMemberCount>(
                        (ExecutionState.Failure, new CommitteeMemberCount(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("GetCIPDetails")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<CIPDetailsVM>>> GetCIPDetails([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _cipBusiness.GetCipDetails(filter);

                return Ok(new WebApiResponse<CIPDetailsVM>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<CIPDetailsVM>(
                        (ExecutionState.Failure, new CIPDetailsVM(), "Unexpected error occurred")
                    ));
            }
        }

        [HttpPost("GetEnergyUsesPercentage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<IList<EnergyUsesPercentageVM>>>> GetEnergyUsesPercentage([FromBody] ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, List<EnergyUsesPercentageVM> entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, IList<EnergyUsesPercentageVM> entity, string message) result = await _energyUseBusiness.GetEnergyUsesPercentage(filter);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity.ToList();
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<List<EnergyUsesPercentageVM>> apiResponse = new WebApiResponse<List<EnergyUsesPercentageVM>>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<List<EnergyUsesPercentageVM>> apiResponse = new WebApiResponse<List<EnergyUsesPercentageVM>>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                WebApiResponse<List<EnergyUsesPercentageVM>> apiResponse = new WebApiResponse<List<EnergyUsesPercentageVM>>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("TotalHouseholdWithPercentage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DashboardHouseholdVM>>> TotalHouseholdWithPercentage([FromBody] ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, DashboardHouseholdVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, DashboardHouseholdVM entity, string message) result = await _householdMemberBusiness.TotalHouseholdWithPercentage(filter);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<DashboardHouseholdVM> apiResponse = new WebApiResponse<DashboardHouseholdVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<DashboardHouseholdVM> apiResponse = new WebApiResponse<DashboardHouseholdVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                WebApiResponse<DashboardHouseholdVM> apiResponse = new WebApiResponse<DashboardHouseholdVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpPost("LoanStatusOverview")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<AIGLoanOverviewVM>>> LoanStatusOverview([FromBody] ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, AIGLoanOverviewVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, AIGLoanOverviewVM entity, string message) result = await _aIGBasicBusiness.LoanOverview(filter);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    var apiResponse = new WebApiResponse<AIGLoanOverviewVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    var apiResponse = new WebApiResponse<AIGLoanOverviewVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                var apiResponse = new WebApiResponse<AIGLoanOverviewVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        [HttpGet("BeneficiaryDashboardData/{surveyId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<SurveyDashboardVM>>> BeneficiaryDashboardData(long surveyId)
        {
            (ExecutionState executionState, SurveyDashboardVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, SurveyDashboardVM entity, string message) result = await _surveyService.BeneficiaryDashboardData(surveyId);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    var apiResponse = new WebApiResponse<SurveyDashboardVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    var apiResponse = new WebApiResponse<SurveyDashboardVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                var apiResponse = new WebApiResponse<SurveyDashboardVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }




        [HttpPost("TotalDashboardSavingsAmount")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DashboardSavingsAmountVM>>> TotalDashboardSavingsAmount([FromBody] ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, DashboardSavingsAmountVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                (ExecutionState executionState, DashboardSavingsAmountVM entity, string message) result = await _savingsAccountBusiness.TotalDashboardSavingsAmount(filter);
                if (result.executionState == ExecutionState.Retrieved)
                {
                    responseResult.entity = result.entity;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<DashboardSavingsAmountVM> apiResponse = new WebApiResponse<DashboardSavingsAmountVM>(responseResult);
                    return Ok(apiResponse);
                }
                else
                {
                    responseResult.entity = null; ;
                    responseResult.executionState = result.executionState;
                    responseResult.message = result.message;

                    WebApiResponse<DashboardSavingsAmountVM> apiResponse = new WebApiResponse<DashboardSavingsAmountVM>(responseResult);
                    return NotFound(apiResponse);
                }
            }
            catch (Exception e)
            {
                responseResult.entity = null; ;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                WebApiResponse<DashboardSavingsAmountVM> apiResponse = new WebApiResponse<DashboardSavingsAmountVM>(responseResult);
                return StatusCode(500, apiResponse);
            }
        }

        /*
        [HttpPost("BeneficiarySkillPercentage")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<DashboardSavingsAmountVM>>> BeneficiarySkillPercentage([FromBody] ForestCivilLocationFilter filter)
        {
            try
            {
                var (executionState, entity, message) = await _business.DateWiseRepaymentReport(filter);

                return Ok(new WebApiResponse<List<DateWiseRepaymentReportVM>>(
                        (executionState, entity, message)
                    ));
            }
            catch (Exception)
            {
                return StatusCode(500, new WebApiResponse<List<DateWiseRepaymentReportVM>>(
                        (ExecutionState.Failure, new List<DateWiseRepaymentReportVM>(), "Unexpected error occurred")
                    ));
            }
        }
        */


        [HttpPost("GetLoanData")]
        public async Task<ActionResult<DashboardLoanResponse>> GetLoanData([FromBody] DashboardLoanRequest dashboardLoanRequest)
        {
            try
            {
                var firstSixtyAmount = await _genericReadOnlyCtx.Set<FirstSixtyPercentageLDF>()

                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.AIGBasicInformation!.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.AIGBasicInformation!.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.AIGBasicInformation!.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.AIGBasicInformation!.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.AIGBasicInformation!.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)

                    .WhereIf(dashboardLoanRequest.Year is not null, x => x.DisbursementDate.Year == dashboardLoanRequest.Year)
                    .WhereIf(dashboardLoanRequest.Month is not null, x => x.DisbursementDate.Month == (int)dashboardLoanRequest.Month!)
                    .Select(x => x.LDFAmount)
                    .ToListAsync();

                var secondFortyAmount = await _genericReadOnlyCtx.Set<SecondFourtyPercentageLDF>()

                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.AIGBasicInformation!.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.AIGBasicInformation!.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.AIGBasicInformation!.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.AIGBasicInformation!.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.AIGBasicInformation!.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)

                    .WhereIf(dashboardLoanRequest.Year is not null, x => x.DisbursementDate.Year == dashboardLoanRequest.Year)
                    .WhereIf(dashboardLoanRequest.Month is not null, x => x.DisbursementDate.Month == (int)dashboardLoanRequest.Month!)
                    .Select(x => x.LDFAmount)
                    .ToListAsync();

                var totalLdfLoanAmount = firstSixtyAmount.Sum() + secondFortyAmount.Sum();

                var totalLdfRepaymentAmountList = await _genericReadOnlyCtx.Set<RepaymentLDF>()

                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.AIGBasicInformation!.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.AIGBasicInformation!.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.AIGBasicInformation!.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.AIGBasicInformation!.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.AIGBasicInformation!.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)

                    .Where(x => x.IsPaymentCompleted)
                    .WhereIf(dashboardLoanRequest.Year is not null, x => x.PaymentCompletedDateTime!.Value.Year == dashboardLoanRequest.Year)
                    .WhereIf(dashboardLoanRequest.Month is not null, x => x.PaymentCompletedDateTime!.Value.Month == (int)dashboardLoanRequest.Month!)
                    .Select(x => new
                    {
                        x.FirstSixtyPercentRepaymentAmountReceived,
                        x.SecondFortyPercentRepaymentAmountReceived,
                    })
                    .ToListAsync();
                var totalLdfRepaymentAmount = totalLdfRepaymentAmountList.Sum(x => x.FirstSixtyPercentRepaymentAmountReceived) + totalLdfRepaymentAmountList.Sum(x => x.SecondFortyPercentRepaymentAmountReceived);

                var totalCDFList = await _genericReadOnlyCtx.Set<Transaction>()
                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)
                    .Where(x => x.FundType!.IsCdf)
                    .Select(x => x.TotalExpense)
                    .ToListAsync();
                var totalCDFAmount = totalCDFList.Sum();

                var totalInternalSavingsAmountList = await _genericReadOnlyCtx.Set<SavingsAmountInformation>()
                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.SavingsAccounts.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.SavingsAccounts.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.SavingsAccounts.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.SavingsAccounts.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.SavingsAccounts.FcvId == dashboardLoanRequest.ForestFcvVcfId)
                    .Select(x => x.SavingsAmount)
                    .ToListAsync();
                var totalInternalSavingsAmount = totalInternalSavingsAmountList.Sum() ?? 0;

                var internalRepaymentAmountList = await _genericReadOnlyCtx.Set<RepaymentInternalLoan>()
                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.InternalLoanInformations!.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.InternalLoanInformations!.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.InternalLoanInformations!.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.InternalLoanInformations!.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.InternalLoanInformations!.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)
                    .Select(x => x.RepaymentAmount)
                    .ToListAsync();
                var internalRepaymentAmount = internalRepaymentAmountList.Sum() ?? 0;

                var internalAmountList = await _genericReadOnlyCtx.Set<InternalLoanInformation>()
                    .WhereIf(dashboardLoanRequest.HasForestCircleId, x => x.ForestCircleId == dashboardLoanRequest.ForestCircleId)
                    .WhereIf(dashboardLoanRequest.HasForestDivisionId, x => x.ForestDivisionId == dashboardLoanRequest.ForestDivisionId)
                    .WhereIf(dashboardLoanRequest.HasForestRangeId, x => x.ForestRangeId == dashboardLoanRequest.ForestRangeId)
                    .WhereIf(dashboardLoanRequest.HasForestBeatId, x => x.ForestBeatId == dashboardLoanRequest.ForestBeatId)
                    .WhereIf(dashboardLoanRequest.HasForestFcvVcfId, x => x.ForestFcvVcfId == dashboardLoanRequest.ForestFcvVcfId)
                    .Select(x => x.TotalAllocatedLoanAmount)
                    .ToListAsync();
                var internalAmount = internalAmountList.Sum();

                var data = new DashboardLoanResponse
                {
                    TotalLDFLoanAmount = totalLdfLoanAmount,
                    TotalLDFRepaymentAmount = totalLdfRepaymentAmount,

                    TotalCDFCost = totalCDFAmount,
                    TotalInternalSavingsAmount = totalInternalSavingsAmount,

                    TotalInternalLoanAmount = internalAmount,
                    TotalInternalRepaymentAmount = (double)internalRepaymentAmount,
                };

                return Ok(new WebApiResponse<DashboardLoanResponse>(
                        (ExecutionState.Success, data, "Success")
                    ));
            }
            catch
            {
                return Ok(new WebApiResponse<DashboardLoanResponse>(
                        (ExecutionState.Failure, new DashboardLoanResponse(), "Success")
                    ));
            }
        }

        //Api for Mobile

        [HttpGet("BeneficiaryDashboardInformation/{surveyId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<BeneficiaryInformationDashboardVM>>> BeneficiaryDashboardInformation(long surveyId)
        {
            var vmData = new BeneficiaryInformationDashboardVM();
            (ExecutionState executionState, BeneficiaryInformationDashboardVM entity, string message) responseResult;

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //NecessaryLink
                var necessaryLinkData = _necessaryLinkService.List();
                foreach (var necessaryLinkItem in necessaryLinkData.Result.entity.ToList())
                {
                    NecessaryLinkVM obj = new NecessaryLinkVM();
                    obj.LinkTitle = necessaryLinkItem?.LinkTitleEn ?? necessaryLinkItem?.LinkTitleBn;
                    obj.LinkUrl = necessaryLinkItem?.SiteLink;
                    vmData.NecessaryLinks.Add(obj);
                }

                //Meeting
                var meetingData = _meetingParticipantsMapService.List().Result.entity.Where(x => x.SurveyId == surveyId);
                foreach (var meetingItem in meetingData?.Select(x => x.Meeting).Where(x => x.MeetingDate >= DateTime.Now))
                {
                    UpcomingMeetingVM obj = new UpcomingMeetingVM();
                    obj.MeetingTitle = meetingItem?.MeetingTitle;
                    obj.MeetingDate = meetingItem?.MeetingDate;
                    obj.MeetingTime = meetingItem?.StartTime;
                    vmData.UpcomingMeetings.Add(obj);
                }

                //Trainings
                var communityTrainingData = _communityTrainingParticipentsMapService.List().Result.entity.Where(x => x.SurveyId == surveyId);
                foreach (var communityTrainingItem in communityTrainingData.Select(x => x.CommunityTraining).Where(x => x.StartDate >= DateTime.Now || x.EndDate <= DateTime.Now))
                {
                    UpvomingTrainingVM obj = new UpvomingTrainingVM();
                    obj.TrainingTitle = communityTrainingItem?.TrainingTitle;
                    obj.TrainingDate = communityTrainingItem?.StartDate;
                    obj.TrainingVenue = communityTrainingItem?.Location;
                    vmData.UpvomingTrainings.Add(obj);
                }


                //Other Survay
                var survayData = _surveyService.GetDetailsAsync(surveyId);
                vmData.BeneficiaryId = survayData.Result.entity?.Id ?? 0;
                vmData.Nid = survayData.Result.entity?.BeneficiaryNid ?? string.Empty;
                vmData.HouseHoldNo = survayData.Result.entity?.BeneficiaryHouseholdSerialNo ?? string.Empty;
                vmData.ForestCircle = survayData?.Result.entity?.ForestCircle?.Name ?? string.Empty;
                vmData.ForestDivision = survayData.Result.entity?.ForestDivision?.Name ?? string.Empty;
                vmData.ForestRange = survayData.Result.entity?.ForestRange?.Name ?? string.Empty;
                vmData.ForestBeat = survayData.Result.entity?.ForestBeat?.Name ?? string.Empty;
                vmData.ForestFcvVcf = survayData.Result.entity?.ForestFcvVcf?.Name ?? string.Empty;
                vmData.BeneficiaryName = survayData.Result.entity.BeneficiaryName ?? string.Empty;
                //BeneficiaryProfile to BeneficiaryHouseFrontImage by faisal vai
                vmData.BeneficiaryProfileURL = survayData.Result.entity.BeneficiaryHouseFrontImageURL ?? survayData.Result.entity.BeneficiaryHouseFrontImage ?? string.Empty;


                //Other Savings
                var savingsData = _savingsAccountBusiness.List()?.Result.entity?.Where(x => x.SurveyId == surveyId).ToList() ?? null;
                var totalSavings = savingsData?.Select(x => x?.SavingsAmountInformations.Select(x => x?.SavingsAmount).Sum()).ToList();
                vmData.SavingsTotalSavings = totalSavings?.Sum();

                var totalWithdraw = savingsData?.Select(x => x?.WithdrawAmountInformations?.Select(x => x?.WithdrawAmount)?.Sum()).ToList();
                vmData.SavingsTotalWithdraw = totalWithdraw.Sum();
                vmData.SavingsTotalRemaining = vmData?.SavingsTotalSavings - vmData?.SavingsTotalWithdraw;
                var individualDataSavings = savingsData.FirstOrDefault(x => x.SurveyId == surveyId);
                if (savingsData?.FirstOrDefault()?.AccountTypeId == 1)
                {
                    //vmData.SavingsPreviousSavingsDate = savingsData.FirstOrDefault().CreatedAt;
                    //vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(savingsData.FirstOrDefault().AmountLimit);
                    //vmData.SavingsNextSavingsDate = savingsData.FirstOrDefault().CreatedAt.AddMonths(1);
                    //vmData.SavingsNextSavingsAmount = Convert.ToDouble(savingsData.FirstOrDefault().AmountLimit);

                    vmData.SavingsPreviousSavingsDate = individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsDate;
                    vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsAmount);
                    vmData.SavingsNextSavingsDate = vmData.SavingsPreviousSavingsDate?.AddMonths(1);
                    vmData.SavingsNextSavingsAmount = Convert.ToDouble(individualDataSavings.AmountLimit);

                }
                if (savingsData?.FirstOrDefault()?.AccountTypeId == 2)
                {
                    //vmData.SavingsPreviousSavingsDate = savingsData?.FirstOrDefault()?.CreatedAt;
                    //vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(savingsData?.FirstOrDefault()?.AmountLimit);
                    //vmData.SavingsNextSavingsDate = savingsData?.FirstOrDefault()?.CreatedAt.AddDays(7);
                    //vmData.SavingsNextSavingsAmount = Convert.ToDouble(savingsData?.FirstOrDefault()?.AmountLimit);

                    vmData.SavingsPreviousSavingsDate = individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsDate;
                    vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsAmount);
                    vmData.SavingsNextSavingsDate = vmData.SavingsPreviousSavingsDate?.AddDays(7);
                    vmData.SavingsNextSavingsAmount = Convert.ToDouble(individualDataSavings.AmountLimit);

                }
                if (savingsData?.FirstOrDefault()?.AccountTypeId == 3)
                {
                    //vmData.SavingsPreviousSavingsDate = savingsData?.FirstOrDefault()?.CreatedAt;
                    //vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(savingsData?.FirstOrDefault()?.AmountLimit);
                    //vmData.SavingsNextSavingsDate = savingsData?.FirstOrDefault()?.CreatedAt.AddDays(15);
                    //vmData.SavingsNextSavingsAmount = Convert.ToDouble(savingsData?.FirstOrDefault()?.AmountLimit);

                    vmData.SavingsPreviousSavingsDate = individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsDate;
                    vmData.SavingsPreviousSavingsAmount = Convert.ToDouble(individualDataSavings.SavingsAmountInformations.OrderByDescending(x => x.SavingsDate).FirstOrDefault().SavingsAmount);
                    vmData.SavingsNextSavingsDate = vmData.SavingsPreviousSavingsDate?.AddDays(15);
                    vmData.SavingsNextSavingsAmount = Convert.ToDouble(individualDataSavings.AmountLimit);
                }
                vmData.SavingsInformationId = individualDataSavings?.Id;


                //Other Internal Loan
                var internalLoanInformationData = _internalLoanInformationService?.List()?.Result.entity?.Where(x => x?.SurveyId == surveyId && x?.ApprovalStatus == 2).ToList();
                var totalinternalLoanInformation = internalLoanInformationData?.Select(x => x?.TotalAllocatedLoanAmount).Sum();
                vmData.InternalTotalLoan = totalinternalLoanInformation;

                var totalRepaymentInternalLoan = internalLoanInformationData?.Select(x => x?.RepaymentInternalLoans.Where(x => x?.IsPaymentCompleted == false).Select(x => x?.RepaymentAmount)?.Sum()).ToList();
                vmData.InternalTotalRepaid = Convert.ToDouble(totalRepaymentInternalLoan?.Sum());

                vmData.InternalTotalRemaining = vmData?.InternalTotalLoan - Math.Round((double)vmData?.InternalTotalRepaid);

                int count = 0;
                foreach (var item in internalLoanInformationData?.Where(x => x?.ApprovalStatus == 2).SelectMany(x => x?.RepaymentInternalLoans).ToList())
                {
                    //if (item.IsPaymentCompleted == false)
                    //{
                    //    count = 1;
                    //    vmData.InternalIsPaid = item?.IsPaymentCompleted;

                    //    vmData.InternalPreviousPaymentDate = item?.RepaymentEndDate;
                    //    vmData.InternalPreviousPaymentAmount = (double)item?.RepaymentAmount;

                    //    vmData.InternalNextPaymentDate = item?.RepaymentEndDate.AddMonths(count);
                    //    vmData.InternalNextPaymentAmount = (double)item?.RepaymentAmount;
                    //}

                    //if (count == 1)
                    //{
                    //    break;
                    //}


                    //New Logic

                    var currentMonth = DateTime.Now;
                    if (vmData.InternalTotalRemaining > 0)
                    {
                        vmData.InternalIsPaid = item?.IsPaymentCompleted;
                        vmData.InternalPreviousPaymentDate = currentMonth.AddMonths(-1);
                        vmData.InternalPreviousPaymentAmount = (double)item?.RepaymentAmount;
                    }
                    else
                    {
                        vmData.InternalIsPaid = true;
                        vmData.InternalPreviousPaymentDate = null;
                        vmData.InternalPreviousPaymentAmount = null;
                    }


                    if (vmData.InternalTotalRemaining > 0)
                    {
                        vmData.InternalIsPaid = item?.IsPaymentCompleted;
                        vmData.InternalNextPaymentDate = currentMonth.AddMonths(1);
                        vmData.InternalNextPaymentAmount = (double)item?.RepaymentAmount;
                    }
                    else
                    {
                        vmData.InternalIsPaid = true;
                        vmData.InternalNextPaymentDate = null;
                        vmData.InternalNextPaymentAmount = null;
                    }

                }

                vmData.InternalLoanInformationId = internalLoanInformationData?.FirstOrDefault()?.Id ?? 0;

                //Other Ldf Loan
                var beneficiaryDashboardData = await _surveyService?.BeneficiaryDashboardData(surveyId); ;
                vmData.LdfTotalLoan = beneficiaryDashboardData.entity?.TotalAIGLoanTaken;
                vmData.LdfTotalRepaid = beneficiaryDashboardData.entity?.TotalAIGLoanRepayment;

                vmData.LdfTotalRemaining = vmData?.LdfTotalLoan - vmData?.LdfTotalRepaid;


                //Ldf for Aig Start
                var aIGBasicInformationData = _aIGBasicInformationService?.List()?.Result.entity?.Where(x => x?.SurveyId == surveyId)?.ToList() ?? new List<AIGBasicInformationVM>();
                var totalAIGBasicInformation = aIGBasicInformationData?.Select(x => x?.TotalAllocatedLoanAmount)?.Sum();
                //vmData.InternalTotalLoan = totalAIGBasicInformation;

                var totalRepaymentAIGBasicInformation = aIGBasicInformationData?.Select(x => x?.RepaymentLDFs?.Where(x => x?.IsPaymentCompleted == false).Select(x => x?.RepaymentAmount)?.Sum())?.ToList();
                //vmData.InternalTotalRepaid = Convert.ToDouble(totalRepaymentAIGBasicInformation.Sum());
                //vmData.InternalTotalRemaining = vmData.InternalTotalLoan - Math.Round((double)vmData.InternalTotalRepaid);

                int count1 = 0;
                foreach (var item in aIGBasicInformationData?.SelectMany(x => x?.RepaymentLDFs)?.ToList())
                {
                    //if (item?.IsPaymentCompleted == false)
                    //{
                    //    count1 = 1;
                    //    vmData.LdfIsPaid = item?.IsPaymentCompleted;

                    //    vmData.LdfPreviousPaymentDate = item?.RepaymentEndDate;
                    //    vmData.LdfPreviousPaymentAmount = (double)item?.RepaymentAmount;

                    //    vmData.LdfNextPaymentDate = item?.RepaymentEndDate.AddMonths(count1);
                    //    vmData.LdfNextPaymentAMount = (double)item?.RepaymentAmount;
                    //}
                    //if (count1 == 1)
                    //{
                    //    break;
                    //}

                    //New logic

                    var currentMonth = DateTime.Now;

                    if (vmData.LdfTotalRemaining > 0)
                    {
                        vmData.LdfIsPaid = item?.IsPaymentCompleted;
                        vmData.LdfPreviousPaymentDate = currentMonth.AddMonths(-1);
                        vmData.LdfPreviousPaymentAmount = (double)item?.RepaymentAmount;
                    }
                    else
                    {
                        vmData.LdfIsPaid = true;
                        vmData.LdfPreviousPaymentDate = null;
                        vmData.LdfPreviousPaymentAmount = null;
                    }


                    if (vmData.LdfTotalRemaining > 0)
                    {
                        vmData.LdfIsPaid = item?.IsPaymentCompleted;
                        vmData.LdfNextPaymentDate = currentMonth.AddMonths(1);
                        vmData.LdfNextPaymentAMount = (double)item?.RepaymentAmount;
                    }
                    else
                    {
                        vmData.LdfIsPaid = true;
                        vmData.LdfNextPaymentDate = null;
                        vmData.LdfNextPaymentAMount = null;
                    }
                }

                vmData.LdfLoanInformationId = aIGBasicInformationData?.FirstOrDefault()?.Id ?? 0;
                //Ldf for Aig End

                responseResult.entity = vmData ?? new BeneficiaryInformationDashboardVM();
                responseResult.executionState = 0;
                responseResult.message = "";

                var apiResponse = new WebApiResponse<BeneficiaryInformationDashboardVM>(responseResult);
                return Ok(apiResponse);

            }
            catch (Exception e)
            {
                responseResult.entity = null;
                responseResult.executionState = ExecutionState.Failure;
                responseResult.message = e.Message;

                var apiResponse = new WebApiResponse<BeneficiaryInformationDashboardVM>(responseResult);
                apiResponse.Data = new BeneficiaryInformationDashboardVM();

                return StatusCode(500, apiResponse);
            }
        }
    }
}
