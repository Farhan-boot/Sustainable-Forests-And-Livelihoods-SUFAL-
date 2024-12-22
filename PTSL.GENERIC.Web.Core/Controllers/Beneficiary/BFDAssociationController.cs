using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class BFDAssociationController : Controller
    {
        private readonly IBFDAssociationService _BFDAssociationService;

        public BFDAssociationController(HttpHelper httpHelper)
        {
            _BFDAssociationService = new BFDAssociationService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<BFDAssociationVM> entity, string message) returnResponse = _BFDAssociationService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            BFDAssociationVM entity = new BFDAssociationVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(BFDAssociationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.Create(entity);

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
            (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, BFDAssociationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "BFDAssociation");
                    }
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.Update(entity);
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _BFDAssociationService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.Delete(id);
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
        public ActionResult Delete(int id, BFDAssociationVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(BFDAssociationController.Index), "BFDAssociation");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, BFDAssociationVM entity, string message) returnResponse = _BFDAssociationService.Update(entity);
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
