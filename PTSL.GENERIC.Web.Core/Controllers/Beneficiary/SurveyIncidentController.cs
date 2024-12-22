using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class SurveyIncidentController : Controller
    {
        private readonly INgoService _NgoService;
        private readonly ISurveyIncidentService _SurveyIncidentService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        public SurveyIncidentController(HttpHelper httpHelper)
        {
            _SurveyIncidentService = new SurveyIncidentService(httpHelper);

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

        public ActionResult Index(long surveyId = default)
        {
            if (surveyId == default)
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

                var filter = AuthLocationHelper.GetFilterFromSession<SurveyIncidentFilterVM>(HttpContext, 50);

                var allList = _SurveyIncidentService.ListByFilter(filter);
                return View(allList.entity);
            }

            var filterList = _SurveyIncidentService.ListByFilter(new SurveyIncidentFilterVM
            {
                SurveyId = surveyId
            });
            return View(filterList.entity);
        }

        public ActionResult IndexFilter(SurveyIncidentFilterVM filter)
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

            var returnResponse = _SurveyIncidentService.ListByFilter(filter);
            return View("Index", returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse = _SurveyIncidentService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create(long surveyId = default)
        {
            if (surveyId == default)
            {
                return NotFound();
            }

            ViewBag.AllMonths = EnumHelper.GetEnumDropdowns<Months>();
            ViewBag.SurveyIncidentStatus = EnumHelper.GetEnumDropdowns<SurveyIncidentStatus>();

            var entity = new SurveyIncidentVM
            {
                SurveyId = surveyId
            };
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(SurveyIncidentVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse = _SurveyIncidentService.Create(entity);

                    HttpContext.Session.SetString("Message", "Beneficiary incident has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return returnResponse.executionState.ToString() != "Created" ? View(entity) : RedirectToAction("Index", new { surveyId = returnResponse.entity?.SurveyId });
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
            catch
            {
                HttpContext.Session.SetString("Message", "Unexpected error occurred");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
        }

        public ActionResult Edit(int id = default)
        {
            if (id == default)
            {
                return NotFound();
            }

            ViewBag.AllMonths = EnumHelper.GetEnumDropdowns<Months>();
            ViewBag.SurveyIncidentStatus = EnumHelper.GetEnumDropdowns<SurveyIncidentStatus>();

            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse = _SurveyIncidentService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, SurveyIncidentVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "Category");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;

                    var returnResponse = _SurveyIncidentService.Update(entity);

                    HttpContext.Session.SetString("Message", "Beneficiary incident has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    return returnResponse.executionState.ToString() != "Updated" ? View(entity) : RedirectToAction("Index", new { surveyId = returnResponse.entity?.SurveyId });
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
            catch
            {
                HttpContext.Session.SetString("Message", "Unexpected error occurred");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _SurveyIncidentService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse = _SurveyIncidentService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Item deleted successfully.";
            }
            else
            {
                returnResponse.message = "Failed to delete this item.";
            }

            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        }

        [HttpPost]
        public ActionResult Delete(int id, SurveyIncidentVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse = _SurveyIncidentService.Update(entity);
////                Session["Message"] = returnResponse.message;
//                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
