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
    public class CommitteeDesignationsConfigurationController : Controller
    {
        private readonly ICommitteeDesignationsConfigurationService _CommitteeDesignationsConfigurationService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly ICommitteeTypeConfigurationService _CommitteeTypeConfigurationService;
        private readonly ICommitteesConfigurationService _CommitteesConfigurationService;

        

        public CommitteeDesignationsConfigurationController(HttpHelper httpHelper)
        {
            _CommitteeDesignationsConfigurationService = new CommitteeDesignationsConfigurationService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _CommitteeTypeConfigurationService = new CommitteeTypeConfigurationService(httpHelper);
            _CommitteesConfigurationService = new CommitteesConfigurationService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<CommitteeDesignationsConfigurationVM> entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.List();

            if (returnResponse.entity == null)
            {
                return View(new List<CommitteeDesignationsConfigurationVM>());
            }
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.GetById(id);

            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            CommitteeDesignationsConfigurationVM entity = new CommitteeDesignationsConfigurationVM();


            (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) returnResponseCommitteesConfiguration = _CommitteesConfigurationService.List();
            if (returnResponseCommitteesConfiguration.entity != null)
            {
                ViewBag.CommitteesConfigurationId = new SelectList(returnResponseCommitteesConfiguration.entity, "Id", "CommitteeName");
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(CommitteeDesignationsConfigurationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.Create(entity);
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

            (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) result = _CommitteeDesignationsConfigurationService.GetById(id);
            (ExecutionState executionState, List<CommitteesConfigurationVM> entity, string message) returnResponseCommitteesConfiguration = _CommitteesConfigurationService.List();
            if (returnResponseCommitteesConfiguration.entity != null)
            {
                ViewBag.CommitteesConfigurationId = new SelectList(returnResponseCommitteesConfiguration.entity, "Id", "CommitteeName", result.entity.CommitteesConfigurationId);
            }

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, CommitteeDesignationsConfigurationVM entity)
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
                    (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.Update(entity);
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


        //public JsonResult Delete(int id)
        //{
        //    var result = _CommitteeDesignationsConfigurationService.SoftDelete(id);
        //    if (result.isDeleted)
        //    {
        //        result.message = "Item deleted successfully.";
        //    }
        //    else
        //    {
        //        result.message = "Failed to delete this item.";
        //    }

        //    return Json(new { Message = result.message, result.executionState }, SerializerOption.Default);
        //}



        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _CommitteeDesignationsConfigurationService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.Delete(id);
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
        public ActionResult Delete(int id, CommitteeDesignationsConfigurationVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, CommitteeDesignationsConfigurationVM entity, string message) returnResponse = _CommitteeDesignationsConfigurationService.Update(entity);
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
