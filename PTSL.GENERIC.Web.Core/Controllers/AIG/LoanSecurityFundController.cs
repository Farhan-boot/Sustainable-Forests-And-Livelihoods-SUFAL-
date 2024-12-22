using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class LoanSecurityFundController : Controller
    {
        private readonly IAIGBasicInformationService _AIGBasicInformationService;
        private readonly INgoService _NgoService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        public LoanSecurityFundController(HttpHelper httpHelper)
        {
            _AIGBasicInformationService = new AIGBasicInformationService(httpHelper);
            _NgoService = new NgoService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
        }

        public ActionResult Index()
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
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext, 50);
            (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) result = _AIGBasicInformationService.GetAIGByFilter(filter);
            return View(result.entity.aaData);
        }

        [HttpPost]
        public ActionResult IndexFilter(AIGBasicInformationFilterVM filter)
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
            ViewBag.PhoneNumber = filter.PhoneNumber;
            ViewBag.NID = filter.NID;
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender : null);

            (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) result = _AIGBasicInformationService.GetAIGByFilter(filter);
            return View("Index", result.entity.aaData);
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            (ExecutionState executionState, AIGBasicInformationVM entity, string message) returnResponse = _AIGBasicInformationService.GetIncludeFirstSecondAndBen(id);

            return View(returnResponse.entity);
        }

        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetLoanSecurityFundListByPagination(JqueryDatatableParam param)
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
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;

            (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) result = _AIGBasicInformationService.GetAIGByFilter(filter);

            return Json(new
            {
                param.sEcho,
                iTotalRecords = result.entity.iTotalRecords,
                iTotalDisplayRecords = result.entity.iTotalDisplayRecords,
                aaData = result.entity.aaData
            }, SerializerOption.Default);

            //return View(new List<CommunityTrainingVM>());
        }

        [HttpPost]
        public ActionResult IndexFilterLoanSecurityFundListByPagination(AIGBasicInformationFilterVM filter)
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
            ViewBag.PhoneNumber = filter.PhoneNumber;
            ViewBag.NID = filter.NID;
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender : null);

            (ExecutionState executionState, PaginationResutlVM<AIGBasicInformationVM> entity, string message) result = _AIGBasicInformationService.GetAIGByFilter(filter);

            return Json(new
            {
                //filter.sEcho,
                iTotalRecords = result.entity.iTotalRecords,
                iTotalDisplayRecords = result.entity.iTotalDisplayRecords,
                aaData = result.entity.aaData
            }, SerializerOption.Default);
            // return View("Index", result.entity);
        }



    }
}
