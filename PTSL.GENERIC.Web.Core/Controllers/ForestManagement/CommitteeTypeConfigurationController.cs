﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class CommitteeTypeConfigurationController : Controller
    {
        private readonly ICommitteeTypeConfigurationService _CommitteeTypeConfigurationService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestCircleService _ForestCircleService;

        public CommitteeTypeConfigurationController(HttpHelper httpHelper)
        {
            _CommitteeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) returnResponse = _CommitteeTypeConfigurationService.List();

            if (returnResponse.entity == null)
            {
                return View(new List<CommitteeTypeConfigurationVM>());
            }

            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) returnResponse = _CommitteeTypeConfigurationService.GetById(id);

            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ViewBag.FcvOrVcfTypeId = new SelectList(EnumHelper.GetEnumDropdowns<FcvOrVcfType>(), "Id", "Name");
            CommitteeTypeConfigurationVM entity = new CommitteeTypeConfigurationVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(CommitteeTypeConfigurationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) returnResponse = _CommitteeTypeConfigurationService.Create(entity);
////                    Session["Message"] = returnResponse.message;
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
////                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                Session["Message"] = "Form Data Not Valid.";
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

            (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) result = _CommitteeTypeConfigurationService.GetById(id);
            ViewBag.FcvOrVcfTypeId = new SelectList(EnumHelper.GetEnumDropdowns<FcvOrVcfType>(), "Id", "Name", result.entity.FcvOrVcfTypeId);

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, CommitteeTypeConfigurationVM entity)
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
                    (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) returnResponse = _CommitteeTypeConfigurationService.Update(entity);
////                    Session["Message"] = returnResponse.message;
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

////                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                Session["Message"] = "Form Data Not Valid.";
//                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteeTypeConfigurationService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) returnResponse = _CommitteeTypeConfigurationService.Delete(id);
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
        public ActionResult Delete(int id, CommitteeTypeConfigurationVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, CommitteeTypeConfigurationVM entity, string message) returnResponse = _CommitteeTypeConfigurationService.Update(entity);
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
