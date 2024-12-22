using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.ForestManagement
{
    [SessionAuthorize]
    public class OtherCommitteeMemberController : Controller
    {
        private readonly IOtherCommitteeMemberService _OtherCommitteeMemberService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;
        private readonly IEthnicityService _EthnicityService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        public OtherCommitteeMemberController(HttpHelper httpHelper)
        {
            _OtherCommitteeMemberService = new OtherCommitteeMemberService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponse = _OtherCommitteeMemberService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse = _OtherCommitteeMemberService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            OtherCommitteeMemberVM entity = new OtherCommitteeMemberVM();

            (ExecutionState executionState, List<ForestCircleVM> entity, string message) forestCircleResponse = _ForestCircleService.List();
            var ethnicityResponse = _EthnicityService.List();

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
            ViewBag.EthnicityId = new SelectList(ethnicityResponse.entity ?? new List<EthnicityVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(OtherCommitteeMemberVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse = _OtherCommitteeMemberService.Create(entity);
                    //                    Session["Message"] = returnResponse.message;
                    //                    Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                //                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                //                Session["Message"] = "Form Data Not Valid.";
                //                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) result = _OtherCommitteeMemberService.GetById(id);

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

                result.entity.ForestCircleId,
                result.entity.ForestDivisionId,
                result.entity.ForestRangeId,
                result.entity.ForestBeatId,
                result.entity.ForestFcvVcfId,
                result.entity.DivisionId,
                result.entity.DistrictId,
                result.entity.UpazillaId,
                result.entity.UnionId
            );

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", (int)result.entity.Gender);
            ViewBag.EthnicityId = new SelectList(_EthnicityService.List().entity ?? new List<EthnicityVM>(), "Id", "Name", result.entity?.EthnicityId ?? 0);

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, OtherCommitteeMemberVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(CategoryController.Index), "Category");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse = _OtherCommitteeMemberService.Update(entity);
                    //                    Session["Message"] = returnResponse.message;
                    //                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                //                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                //                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                //                Session["Message"] = "Form Data Not Valid.";
                //                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _OtherCommitteeMemberService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse = _OtherCommitteeMemberService.Delete(id);
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
        public ActionResult Delete(int id, OtherCommitteeMemberVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse = _OtherCommitteeMemberService.Update(entity);
                //                Session["Message"] = returnResponse.message;
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
