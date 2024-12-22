﻿using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class DisabilityTypeController : Controller
    {
        private readonly IDisabilityTypeService _DisabilityTypeService;

        public DisabilityTypeController(HttpHelper httpHelper)
        {
            _DisabilityTypeService = new DisabilityTypeService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<DisabilityTypeVM> entity, string message) returnResponse = _DisabilityTypeService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            DisabilityTypeVM entity = new DisabilityTypeVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(DisabilityTypeVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.Create(entity);
////                    //Session["Message"] = returnResponse.message;
//                    //Session["executionState"] = returnResponse.executionState;

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
////                //Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                //Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                //Session["Message"] = "Form Data Not Valid.";
//                //Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, DisabilityTypeVM entity)
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
                    (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.Update(entity);
////                    //Session["Message"] = returnResponse.message;
//                    //Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

////                //Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//                //Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
////                //Session["Message"] = "Form Data Not Valid.";
//                //Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _DisabilityTypeService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.Delete(id);
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
        public ActionResult Delete(int id, DisabilityTypeVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, DisabilityTypeVM entity, string message) returnResponse = _DisabilityTypeService.Update(entity);
////                //Session["Message"] = returnResponse.message;
//                //Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}