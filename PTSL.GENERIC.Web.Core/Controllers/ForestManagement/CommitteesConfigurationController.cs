using Microsoft.AspNetCore.Mvc;
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
    public class CommitteesConfigurationController : Controller
    {
        private readonly ICommitteesConfigurationService _CommitteesConfigurationService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly ICommitteeTypeConfigurationService _CommitteeTypeConfigurationService;
        

        public CommitteesConfigurationController(HttpHelper httpHelper)
        {
            _CommitteesConfigurationService = new CommitteesConfigurationService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _CommitteeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) returnResponse = _CommitteesConfigurationService.List();
            if (returnResponse.entity == null)
            {
                return View(new List<CommitteesConfigurationVM>());
            }

            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommitteesConfigurationVM entity, string message) returnResponse = _CommitteesConfigurationService.GetById(id);

            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            CommitteesConfigurationVM entity = new CommitteesConfigurationVM();
            (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) returnResponseCommitteeTypeConfiguration = _CommitteeTypeConfigurationService.List();
            //if (returnResponseCommitteeTypeConfiguration.entity != null)
            //{
                ViewBag.CommitteeTypeConfigurationId = new SelectList(returnResponseCommitteeTypeConfiguration.entity ?? new List<CommitteeTypeConfigurationVM>(), "Id", "CommitteeTypeName");
            //}

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(CommitteesConfigurationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, CommitteesConfigurationVM entity, string message) returnResponse = _CommitteesConfigurationService.Create(entity);
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

            (ExecutionState executionState, CommitteesConfigurationVM entity, string message) result = _CommitteesConfigurationService.GetById(id);
            (ExecutionState executionState, List<CommitteeTypeConfigurationVM> entity, string message) returnResponseCommitteeTypeConfiguration = _CommitteeTypeConfigurationService.List();
            if (returnResponseCommitteeTypeConfiguration.entity != null)
            {
                ViewBag.CommitteeTypeConfigurationId = new SelectList(returnResponseCommitteeTypeConfiguration.entity, "Id", "CommitteeTypeName", result.entity.CommitteeTypeConfigurationId);
            }

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, CommitteesConfigurationVM entity)
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
                    (ExecutionState executionState, CommitteesConfigurationVM entity, string message) returnResponse = _CommitteesConfigurationService.Update(entity);
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
            var result = _CommitteesConfigurationService.SoftDelete(id);
            if (result.isDeleted)
            {
                result.message = "Item deleted successfully.";
            }
            else
            {
                result.message = "Failed to delete this item.";
            }

            return Json(new { Message = result.message, result.executionState }, SerializerOption.Default);
        }



        //        public JsonResult Delete(int id)
        //        {
        //            (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteesConfigurationService.DoesExist(id);
        //            string message = "Failed, You can't delete this item.";

        //            if (CheckDataExistOrNot.executionState.ToString() != "Success")
        //            {
        //                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        //            }

        //            (ExecutionState executionState, CommitteesConfigurationVM entity, string message) returnResponse = _CommitteesConfigurationService.Delete(id);
        //            if (returnResponse.executionState.ToString() == "Updated")
        //            {
        //                returnResponse.message = "Item deleted successfully.";
        //            }
        //            else
        //            {
        //                returnResponse.message = "Failed to delete this item.";
        //            }

        //            return Json(new { Message = returnResponse.message, returnResponse.executionState }, SerializerOption.Default);
        //        }

        //        [HttpPost]
        //        public ActionResult Delete(int id, CommitteesConfigurationVM entity)
        //        {
        //            try
        //            {
        //                if (id != entity.Id)
        //                {
        //                    return RedirectToAction(nameof(this.Index), "Category");
        //                }
        //                entity.IsDeleted = true;
        //                entity.UpdatedAt = DateTime.Now;
        //                (ExecutionState executionState, CommitteesConfigurationVM entity, string message) returnResponse = _CommitteesConfigurationService.Update(entity);
        //////                Session["Message"] = returnResponse.message;
        ////                Session["executionState"] = returnResponse.executionState;
        //                return RedirectToAction("Index");
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }


    }
}
