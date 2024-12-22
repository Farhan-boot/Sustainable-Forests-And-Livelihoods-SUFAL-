using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.InternalLoan;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.AIG;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.InternalLoan;
using PTSL.GENERIC.Web.Core.Services.Interface.AIG;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.InternalLoan;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.InternalLoan
{
    [SessionAuthorize]
    public class InternalLoanSecurityFundController : Controller
    {
        private readonly IInternalLoanInformationService _InternalLoanInformationService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        public InternalLoanSecurityFundController(HttpHelper httpHelper)
        {
            _InternalLoanInformationService = new InternalLoanInformationService(httpHelper);

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

            var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext, 50);
            (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) result = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

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

            (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) result = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

            return View("Index", result.entity.aaData);
        }

        public ActionResult IndexFilter()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }
            (ExecutionState executionState, InternalLoanInformationVM entity, string message) returnResponse = _InternalLoanInformationService.GetById(id);

            return View(returnResponse.entity);
        }


        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetInternalLoanSecurityFundListByPagination(JqueryDatatableParam param)
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

            var filter = AuthLocationHelper.GetFilterFromSession<AIGBasicInformationFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;
            (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) result = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

            foreach (var item in result.entity.aaData)
            {
                item.SecurityChargeTkText = Convert.ToString(Math.Round(item.TotalAllocatedLoanAmount * item.SecurityChargePercentage / 100, 2));
                item.ServiceChargeTkText =Convert.ToString(Math.Round(item.TotalAllocatedLoanAmount * item.ServiceChargePercentage / 100, 2));
            }

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
        public ActionResult IndexFilterInternalLoanSecurityFundListByPagination(AIGBasicInformationFilterVM filter)
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

            (ExecutionState executionState, PaginationResutlVM<InternalLoanInformationVM> entity, string message) result = _InternalLoanInformationService.GetInternalLoanInformationByFilter(filter);

            foreach (var item in result.entity.aaData)
            {
                item.SecurityChargeTkText = Convert.ToString(Math.Round(item.TotalAllocatedLoanAmount * item.SecurityChargePercentage / 100, 2));
                item.ServiceChargeTkText = Convert.ToString(Math.Round(item.TotalAllocatedLoanAmount * item.ServiceChargePercentage / 100, 2));
            }

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
