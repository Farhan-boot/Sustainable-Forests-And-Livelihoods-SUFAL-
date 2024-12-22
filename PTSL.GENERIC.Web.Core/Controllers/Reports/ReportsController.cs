using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AIG;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG.Reports;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Labour;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.TransactionMangement;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Labour;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Services.Implementation.MeetingManagement;
using PTSL.GENERIC.Web.Services.Implementation.PatrollingSchedulingInformetion;

namespace PTSL.GENERIC.Web.Core.Controllers.Reports;

[SessionAuthorize]
public partial class ReportsController : Controller
{
    private readonly ICipService _CipService;
    private readonly ISurveyService _SurveySerivce;
    private readonly IMeetingService _MeetingService;
    private readonly IMeetingTypeService _MeetingTypeService;
    private readonly ISavingsAccountService _SavingsAccountService;
    private readonly IPatrollingSchedulingService _PatrollingSchedulingService;
    private readonly ITrainingOrganizerService _TrainingOrganizerService;
    private readonly IEventTypeService _EventTypeService;
    private readonly ICommunityTrainingService _CommunityTrainingService;
    private readonly IDepartmentalTrainingService _DepartmentalTrainingService;
    private readonly IAIGBasicInformationService _AIGBasicInformationService;
    private readonly IRepaymentLDFService _RepaymentLDFService;

    private readonly IForestCircleService _ForestCircleService;
    private readonly IForestDivisionService _ForestDivisionService;
    private readonly IForestRangeService _ForestRangeService;
    private readonly IForestBeatService _ForestBeatService;
    private readonly IForestFcvVcfService _ForestFcvVcfService;

    private readonly IDivisionService _DivisionService;
    private readonly IDistrictService _DistrictService;
    private readonly IUpazillaService _UpazillaService;
    private readonly IUnionService _UnionService;
    private readonly INgoService _NgoService;
    private readonly IEthnicityService _EthnicityService;
    private readonly IFinancialYearService _FinancialYearService;
    private readonly ITransactionService _TransactionService;
    private readonly ILabourDatabaseService _LabourDatabaseService;
    private readonly INewRaisedPlantationService _NewRaisedPlantationService;

    public ReportsController(HttpHelper httpHelper)
    {
        _CipService = new CipService(httpHelper);
        _SurveySerivce = new SurveyService(httpHelper);
        _MeetingService = new MeetingService(httpHelper);
        _MeetingTypeService = new MeetingTypeService(httpHelper);
        _SavingsAccountService = new SavingsAccountService(httpHelper);
        _PatrollingSchedulingService = new PatrollingSchedulingService(httpHelper);
        _TrainingOrganizerService = new TrainingOrganizerService(httpHelper);
        _EventTypeService = new EventTypeService(httpHelper);
        _CommunityTrainingService = new CommunityTrainingService(httpHelper);
        _DepartmentalTrainingService = new DepartmentalTrainingService(httpHelper);
        _AIGBasicInformationService = new AIGBasicInformationService(httpHelper);
        _RepaymentLDFService = new RepaymentLDFService(httpHelper);

        _ForestCircleService = new ForestCircleService(httpHelper);
        _ForestDivisionService = new ForestDivisionService(httpHelper);
        _ForestRangeService = new ForestRangeService(httpHelper);
        _ForestBeatService = new ForestBeatService(httpHelper);
        _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

        _DivisionService = new DivisionService(httpHelper);
        _DistrictService = new DistrictService(httpHelper);
        _UpazillaService = new UpazillaService(httpHelper);
        _UnionService = new UnionService(httpHelper);
        _NgoService = new NgoService(httpHelper);
        _EthnicityService = new EthnicityService(httpHelper);
        _FinancialYearService = new FinancialYearService(httpHelper);
        _TransactionService = new TransactionService(httpHelper);
        _LabourDatabaseService = new LabourDatabaseService(httpHelper);
        _NewRaisedPlantationService = new NewRaisedPlantationService(httpHelper);

    }

    public ActionResult Index()
    {
        return View();
    }

    // CIP
    public ActionResult CipReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name");
        ViewBag.NID = string.Empty;
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult CipReport(CipFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.CipWealth = new SelectList(EnumHelper.GetEnumDropdowns<CipWealth>(), "Id", "Name");
        ViewBag.NID = string.Empty;
        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");

        (ExecutionState executionState, PaginationResutlVM<CipVM> entity, string message) returnResponse = _CipService.ListByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    // Beneficiary
    public ActionResult BeneficiaryReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult BeneficiaryReport(BeneficiaryFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        var response = _SurveySerivce.GetBeneficiaryByFilter(filter);

        return View(response.entity.aaData ?? new List<SurveyEssentialVM>());
    }

    // Meeting
    public ActionResult MeetingReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
        ViewBag.MeetingDate = string.Empty;
        ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult MeetingReport(MeetingFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);
        ViewBag.MeetingDate = filter.MeetingDate;
        ViewBag.MeetingTypeId = new SelectList(_MeetingTypeService.List().entity ?? new List<MeetingTypeVM>(), "Id", "Name", filter.MeetingTypeId);

        (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) returnResponse = _MeetingService.GetMeetingByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    // Beneficiary Savings
    public ActionResult BeneficiarySavingsReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult BeneficiarySavingsReport(SavingsAccountFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

        (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    // Transaction
    public ActionResult TransactionReportFilter()
    {
        ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
        ViewBag.ForestDivisionId = new SelectList("");
        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.FromDate = string.Empty;
        ViewBag.ToDate = string.Empty;

        return View();
    }

    [HttpPost]
    public ActionResult TransactionReport(TransactionFilterVM filter)
    {
        ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", filter.ForestCircleId);
        ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(filter.ForestCircleId ?? 0).entity ?? Enumerable.Empty<ForestDivisionVM>(), "Id", "Name", filter.ForestDivisionId);
        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.FromDate = filter.FromDate;
        ViewBag.ToDate = filter.ToDate;

        (ExecutionState executionState, List<TransactionVM> entity, string message) returnResponse = _TransactionService.GetByFilter(filter);

        return View(returnResponse.entity);
    }

    // Patrolling Schedule
    public ActionResult PatrollingScheduleReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult PatrollingScheduleReport(PatrollingSchedulingFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

        (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.GetTrainingByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    // Community Training
    public ActionResult CommunityTrainingReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name");
        ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name");
        ViewBag.StartDate = string.Empty;
        ViewBag.EndDate = string.Empty;

        return View();
    }

    [HttpPost]
    public ActionResult CommunityTrainingReport(CommunityTrainingFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.TrainingOrganizerId = new SelectList(_TrainingOrganizerService.List().entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", filter.NgoId);
        ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", filter.EventTypeId);
        ViewBag.StartDate = filter.StartDate;
        ViewBag.EndDate = filter.EndDate;

        var result = _CommunityTrainingService.GetTrainingByFilter(filter);

        return View(result.entity);
    }

    // Departmental Training
    public ActionResult DepartmentalTrainingReportFilter()
    {
        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult DepartmentalTrainingReport(DepartmentalTrainingFilterVM filter)
    {
        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", filter.FinancialYearId);
        ViewBag.EventTypeId = new SelectList(_EventTypeService.List().entity ?? new List<EventTypeVM>(), "Id", "Name", filter.EventTypeId);

        ViewBag.StartDate = filter.StartDate;
        ViewBag.EndDate = filter.EndDate;

        (ExecutionState executionState, PaginationResutlVM<DepartmentalTrainingVM> entity, string message) result = _DepartmentalTrainingService.GetByFilterVM(filter);

        return View(result.entity.aaData);
    }

    // AIG Basic Info
    public ActionResult AigBasicInformationReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult AigBasicInformationReport(AIGBasicInformationFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? Enumerable.Empty<NgoVM>(), "Id", "Name", filter.NgoId);

        var result = _AIGBasicInformationService.GetAIGByFilter(filter);

        return View(result.entity);
    }

    public ActionResult AIGLoanStatusReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.BadLoanType = new SelectList(EnumHelper.GetEnumDropdowns<BadLoanType>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult AIGLoanStatusReport(AIGLoanStatusReportFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        var result = _AIGBasicInformationService.AIGLoanStatusReport(filter);

        return View(result.entity);
    }

    // RepaymentReport
    public ActionResult RepaymentReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult RepaymentReport(RepaymentReportFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.HasGender ? (int)filter.Gender! : null);
        ViewBag.PhoneNumber = filter.PhoneNumber;
        ViewBag.NID = filter.NID;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? Enumerable.Empty<NgoVM>(), "Id", "Name", filter.NgoId);

        var result = _AIGBasicInformationService.RepaymentReport(filter);

        return View(result.entity);
    }

    public ActionResult DateWiseRepaymentReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Month = new SelectList(EnumHelper.GetEnumDropdowns<Months>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult DateWiseRepaymentReport(DateWiseRepaymentReportFilterVM filter)
    {
        var result = _RepaymentLDFService.DateWiseRepaymentReport(filter);

        return View(result.entity ?? new List<DateWiseRepaymentReportVM>());
    }

    // Labor Database
    public ActionResult LabourDatabaseReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        return View();
    }

    [HttpPost]
    public ActionResult LabourDatabaseReport(LabourDatabaseFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    public ActionResult LabourDatabasePaymentReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        return View();
    }

    [HttpPost]
    public ActionResult LabourDatabasePaymentReport(LabourDatabaseFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        filter.ReturnLabourWorks = true;
        (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);

        return View(returnResponse.entity.aaData);
    }

    /*
    // Executive Committee
    public ActionResult ExecutiveCommitteeReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name");
        ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");


        return View();
    }

    [HttpPost]
    public ActionResult ExecutiveCommitteeReport(ExecutiveCommitteeFilterVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", filter.EthnicityId);
        ViewBag.GenderId = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender);
        ViewBag.PhoneNumber = string.Empty;
        ViewBag.NID = string.Empty;
        ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

        (ExecutionState executionState, List<ExecutiveCommitteeVM> entity, string message) returnResponse = _ExecutiveCommitteeService.GetByFilter(filter);

        return View(returnResponse.entity);
    }
    */

    // Beneficiary Training Report
    public ActionResult BeneficiaryTrainingReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult BeneficiaryTrainingReport(CommunityTrainingFilterByBeneficiaryVM filter)
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService,
            filter
        );

        var result = _CommunityTrainingService.GetCommunityTrainingParticipentsMapByFilter(filter);

        return View(result.entity);
    }

    // Expense For CDF Report
    public ActionResult ExpenseForCDFReportFilter()
    {
        ViewBag.ForestRangeId = new SelectList(_ForestRangeService.List().entity ?? new List<ForestRangeVM>(), "Id", "Name");
        ViewBag.ForestBeatId = new SelectList(_ForestBeatService.List().entity ?? new List<ForestBeatVM>(), "Id", "Name");
        ViewBag.ForestFcvVcfId = new SelectList(_ForestFcvVcfService.List().entity ?? new List<ForestFcvVcfVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult ExpenseForCDFReport(AIGBasicInformationFilterVM filter)
    {
        ViewBag.ForestRangeId = new SelectList(_ForestRangeService.List().entity ?? new List<ForestRangeVM>(), "Id", "Name");
        ViewBag.ForestBeatId = new SelectList(_ForestBeatService.List().entity ?? new List<ForestBeatVM>(), "Id", "Name");
        ViewBag.ForestFcvVcfId = new SelectList(_ForestFcvVcfService.List().entity ?? new List<ForestFcvVcfVM>(), "Id", "Name");

        //var (_, entity, _) = _TransactionExpenseService.GetExpenseForCDFReportByFilter(filter);
        return View();
    }

    #region Ratio Analysis
    public ActionResult OutstandingLoanPerBorrowerFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Month = new SelectList(EnumHelper.GetEnumDropdowns<Months>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult OutstandingLoanPerBorrower(RepaymentLDFOutstandingLoanPerBorrowerFilterVM filter)
    {
        var result = _RepaymentLDFService.OutstandingLoanPerBorrowerList(filter);

        return View(result.entity ?? new List<RepaymentLDFOutstandingLoanPerBorrowerVM>());
    }

    public ActionResult AverageLoanSizeFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.Month = new SelectList(EnumHelper.GetEnumDropdowns<Months>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult AverageLoanSize(AverageLoanSizeFilterVM filter)
    {
        var result = _AIGBasicInformationService.AverageLoanSizeFilter(filter);

        return View(result.entity ?? new List<AverageLoanSizeVM>());
    }

    // Cumulative Recovery Rate Report
    public ActionResult CumulativeRecoveryRateReportFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        //ViewBag.Month = new SelectList(EnumHelper.GetEnumDropdowns<Months>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult CumulativeRecoveryRateReport(CumulativeRecoveryRateFilterVM filter)
    {
        var result = _AIGBasicInformationService.CumulativeRecoveryRateReportList(filter);

        return View(result.entity ?? new List<CumulativeRecoveryRateVM>());
    }

    // On Time Recovery Rate
    public ActionResult OnTimeRecoveryRateFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        
        return View();
    }

    [HttpPost]
    public ActionResult OnTimeRecoveryRate(OnTimeRecoveryRateFilterVM filter)
    {
        var result = _AIGBasicInformationService.OnTimeRecoveryRateList(filter);

        return View(result.entity ?? new List<OnTimeRecoveryRateVM>());
    }

    // Portfolio At Risk
    public ActionResult PortfolioAtRiskFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );


        return View();
    }

    [HttpPost]
    public ActionResult PortfolioAtRisk(PortfolioAtRiskFilterVM filter)
    {
        var result = _AIGBasicInformationService.PortfolioAtRiskList(filter);

        return View(result.entity ?? new List<PortfolioAtRiskVM>());
    }


    // Delinquency Ratio
    public ActionResult DelinquencyRatioFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );


        return View();
    }

    [HttpPost]
    public ActionResult DelinquencyRatio(DelinquencyRatioFilterVM filter)
    {
        var result = _AIGBasicInformationService.DelinquencyRatioList(filter);

        return View(result.entity ?? new List<DelinquencyRatioVM>());
    }

    // Borrower Per Village
    public ActionResult BorrowerPerVillageFilter()
    {
        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService
        );

        return View();
    }

    [HttpPost]
    public ActionResult BorrowerPerVillage(BorrowerPerVillageFilterVM filter)
    {
        var result = _AIGBasicInformationService.BorrowerPerVillageReport(filter);

        return View(result.entity ?? new List<BorrowerPerVillageVM>());
    }

    // Borrower Coverage
    public ActionResult BorrowerCoverageFilter()
    {
        AuthLocationHelper.GenerateViewBagForForest(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService
        );

        return View();
    }

    [HttpPost]
    public ActionResult BorrowerCoverage(BorrowerCoverageFilterVM filter)
    {
        var result = _AIGBasicInformationService.BorrowerCoverageReport(filter);

        return View(result.entity ?? new List<BorrowerCoverageVM>());
    }


    // Member Per Village
    public ActionResult MemberPerVillageFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );


        return View();
    }

    [HttpPost]
    public ActionResult MemberPerVillage(MemberPerVillageFilterVM filter)
    {
        var result = _ForestFcvVcfService.MemberPerVillageList(filter);

        return View(result.entity ?? new List<MemberPerVillageVM>());
    }





    // Portfolio Per Village
    public ActionResult PortfolioPerVillageFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );


        return View();
    }

    [HttpPost]
    public ActionResult PortfolioPerVillage(PortfolioPerVillageFilterVM filter)
    {
        var result = _AIGBasicInformationService.PortfolioPerVillageList(filter);
        return View(result.entity ?? new List<PortfolioPerVillageVM>());
    }

    #endregion


    #region InformationAndDataOnNewlyRaisedPlantation
    public ActionResult InformationAndDataOnNewlyRaisedPlantationFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public ActionResult InformationAndDataOnNewlyRaisedPlantation(InformationAndDataOnNewlyRaisedPlantationFilterVM filter)
    {
        var result = _NewRaisedPlantationService.GetInformationAndDataOnNewlyRaisedPlantationReport(filter);

        return View(result.entity ?? new List<NewRaisedPlantationVM>());
    }

    #endregion





    #region InformationAndDataOnPlantationsFelledOrCut
    public ActionResult InformationAndDataOnPlantationsFelledOrCutFilter()
    {
        AuthLocationHelper.GenerateViewBagForForestAndCivil(
            HttpContext,
            ViewBag,
            _ForestCircleService,
            _ForestDivisionService,
            _ForestRangeService,
            _ForestBeatService,
            _ForestFcvVcfService,
            _DivisionService,
            _DistrictService,
            _UpazillaService,
            _UnionService
        );

        ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
        ViewBag.PlantationId = new SelectList(_NewRaisedPlantationService.List().entity ?? new List<NewRaisedPlantationVM>(), "Id", "PlantationId");

        return View();
    }

    [HttpPost]
    public ActionResult InformationAndDataOnPlantationsFelledOrCut(InformationAndDataOnNewlyRaisedPlantationFilterVM filter)
    {
        var result = _NewRaisedPlantationService.GetInformationAndDataOnPlantationsFelledOrCutReport(filter);

        return View(result.entity ?? new List<NewRaisedPlantationVM>());
    }

    #endregion





}
