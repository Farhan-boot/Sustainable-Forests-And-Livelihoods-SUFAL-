using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class TypeOfHouseController : Controller
    {
        private readonly ITypeOfHouseService _TypeOfHouseService;

        public TypeOfHouseController(HttpHelper httpHelper)
        {
            _TypeOfHouseService = new TypeOfHouseService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<TypeOfHouseVM> entity, string message) returnResponse = _TypeOfHouseService.List();
            return View(returnResponse.entity);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            TypeOfHouseVM entity = new TypeOfHouseVM();
            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(TypeOfHouseVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.Create(entity);

                    if (returnResponse.executionState != ExecutionState.Created)
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, TypeOfHouseVM entity)
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
                    (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _TypeOfHouseService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.Delete(id);
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
        public ActionResult Delete(int id, TypeOfHouseVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TypeOfHouseVM entity, string message) returnResponse = _TypeOfHouseService.Update(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
