using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Patrolling;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Patrolling;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Patrolling
{
    [SessionAuthorize]
    public class OtherPatrollingMemberController : Controller
    {
        private readonly IOtherPatrollingMemberService _OtherPatrollingMemberService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;
        private readonly IEthnicityService _EthnicityService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;

        public OtherPatrollingMemberController(HttpHelper httpHelper)
        {
            _OtherPatrollingMemberService = new OtherPatrollingMemberService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) returnResponse = _OtherPatrollingMemberService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            OtherPatrollingMemberVM entity = new OtherPatrollingMemberVM();

            (ExecutionState executionState, List<ForestCircleVM> entity, string message) forestCircleResponse = _ForestCircleService.List();
            var ethnicityResponse = _EthnicityService.List();

            // Forest Administration
            ViewBag.ForestCircleId = new SelectList(forestCircleResponse.entity ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");
            ViewBag.ForestBeatId = new SelectList("");
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");
            ViewBag.ForestFcvVcfId = new SelectList("");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            // Civil Administration
            var divisionResponse = _DivisionService.List();
            ViewBag.DivisionId = new SelectList(divisionResponse.entity ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.DistrictId = new SelectList("");
            ViewBag.UpazillaId = new SelectList("");

            ViewBag.EthnicityId = new SelectList(ethnicityResponse.entity ?? new List<EthnicityVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(OtherPatrollingMemberVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.Create(entity);
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
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.GetById(id);

            (ExecutionState executionState, List<ForestCircleVM> entity, string message) forestCircleResponse = _ForestCircleService.List();

            ViewBag.ForestCircleId = new SelectList("");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.ForestRangeId = new SelectList("");
            ViewBag.ForestBeatId = new SelectList("");
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");
            ViewBag.ForestFcvVcfId = new SelectList("");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", (int)returnResponse.entity.Gender);

            if (returnResponse.entity != null)
            {
                var forestCircleId = returnResponse.entity.ForestCircleId;
                var forestDivisionId = returnResponse.entity.ForestDivisionId;
                var forestRangeId = returnResponse.entity.ForestRangeId;
                var forestBeatId = returnResponse.entity.ForestBeatId;
                var forestFcvVcfId = returnResponse.entity?.ForestFcvVcfId ?? 0;

                if (forestCircleResponse.entity != null)
                {
                    ViewBag.ForestCircleId = new SelectList(forestCircleResponse.entity, "Id", "Name", forestCircleId);
                }

                if (forestCircleId != 0)
                {
                    var forestDivisionResponse = _ForestDivisionService.ListByForestCircle(forestCircleId);

                    if (forestDivisionResponse.entity != null)
                    {
                        ViewBag.ForestDivisionId = new SelectList(forestDivisionResponse.entity, "Id", "Name", forestDivisionId);
                    }
                }
                if (forestDivisionId != 0)
                {
                    var forestRangeResponse = _ForestRangeService.ListByForestDivision(forestDivisionId);

                    if (forestRangeResponse.entity != null)
                    {
                        ViewBag.ForestRangeId = new SelectList(forestRangeResponse.entity, "Id", "Name", forestRangeId);
                    }
                }
                if (forestRangeId != 0)
                {
                    var forestBeatResponse = _ForestBeatService.ListByForestRange(forestRangeId);

                    if (forestBeatResponse.entity != null)
                    {
                        ViewBag.ForestBeatId = new SelectList(forestBeatResponse.entity, "Id", "Name", forestBeatId);
                    }
                }
                if (forestFcvVcfId != 0)
                {
                    var forestFcvVcfResponse = _ForestFcvVcfService.ListByForestBeat(forestBeatId);

                    if (forestFcvVcfResponse.entity != null)
                    {
                        var isFcvFound = forestFcvVcfResponse.entity.Find(x => x.Id == forestFcvVcfId)?.IsFcv;
                        var selectedId = -1;

                        if (isFcvFound != null)
                        {
                            if (isFcvFound == true)
                            {
                                selectedId = (int)FcvVcfType.FCV;
                            }
                            else
                            {
                                selectedId = (int)FcvVcfType.VCF;
                            }
                        }

                        ViewBag.ForestFcvVcfId = new SelectList(forestFcvVcfResponse.entity, "Id", "Name", forestFcvVcfId);
                        ViewBag.FcvVcfType = new SelectList(
                            EnumHelper.GetEnumDropdowns<FcvVcfType>(),
                            "Id",
                            "Name",
                            selectedId);
                    }
                }


                var divisionId = returnResponse.entity.DivisionId;
                var districtId = returnResponse.entity.DistrictId;
                var upazillaId = returnResponse.entity.UpazillaId;

                var divisionResponse = _DivisionService.List();
                var districtResponse = _DistrictService.ListByDivision(divisionId);
                var upazillaResponse = _UpazillaService.ListByDistrict(districtId);

                ViewBag.DivisionId = new SelectList(divisionResponse.entity ?? new List<DivisionVM>(), "Id", "Name", divisionId);
                ViewBag.DistrictId = new SelectList(districtResponse.entity ?? new List<DistrictVM>(), "Id", "Name", districtId);
                ViewBag.UpazillaId = new SelectList(upazillaResponse.entity ?? new List<UpazillaVM>(), "Id", "Name", upazillaId);
            }

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, OtherPatrollingMemberVM entity)
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
                    (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.Update(entity);
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _OtherPatrollingMemberService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.Delete(id);
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
        public ActionResult Delete(int id, OtherPatrollingMemberVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse = _OtherPatrollingMemberService.Update(entity);
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
