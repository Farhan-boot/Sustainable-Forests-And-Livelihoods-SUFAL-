using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.MeetingManagement;

namespace PTSL.GENERIC.Web.Controllers.MeetingManagement
{
    [SessionAuthorize]
	public class MeetingTypeController : Controller
	{
		private readonly IMeetingTypeService _MeetingTypeService;

		public MeetingTypeController(HttpHelper httpHelper)
		{
			_MeetingTypeService = new MeetingTypeService(httpHelper);
		}

		public ActionResult Index()
		{
			(ExecutionState executionState, List<MeetingTypeVM> entity, string message) returnResponse = _MeetingTypeService.List();
			return View(returnResponse.entity);
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.GetById(id);
			return View(returnResponse.entity);
		}

		public ActionResult Create()
		{
			MeetingTypeVM entity = new MeetingTypeVM();
			return View(entity);
		}

		[HttpPost]
		public ActionResult Create(MeetingTypeVM entity)
		{
			try
			{
				if (ModelState.IsValid)
				{
					entity.IsActive = true;
					entity.CreatedAt = DateTime.Now;
					(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.Create(entity);
//					Session["Message"] = returnResponse.message;
//					Session["executionState"] = returnResponse.executionState;

					if (returnResponse.executionState.ToString() != "Created")
					{
						return View(entity);
					}
					else
					{
						return RedirectToAction("Index");
					}
				}
//				Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//				Session["executionState"] = ExecutionState.Failure;
				return View(entity);
			}
			catch
			{
//				Session["Message"] = "Form Data Not Valid.";
//				Session["executionState"] = ExecutionState.Failure;
				return View(entity);
			}
		}

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.GetById(id);

			return View(returnResponse.entity);
		}

		[HttpPost]
		public ActionResult Edit(int id, MeetingTypeVM entity)
		{
			try
			{
				if (ModelState.IsValid)
				{
					if (id != entity.Id)
					{
						return RedirectToAction(nameof(MeetingTypeController.Index), "MeetingType");
					}
					entity.IsActive = true;
					entity.IsDeleted = false;
					entity.UpdatedAt = DateTime.Now;
					(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.Update(entity);
//					Session["Message"] = returnResponse.message;
//					Session["executionState"] = returnResponse.executionState;
					if (returnResponse.executionState.ToString() != "Updated")
					{
						return View(entity);
					}
					else
					{
						return RedirectToAction("Index");
					}
				}

//				Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
//				Session["executionState"] = ExecutionState.Failure;
				return View(entity);
			}
			catch
			{
//				Session["Message"] = "Form Data Not Valid.";
//				Session["executionState"] = ExecutionState.Failure;
				return View(entity);
			}
		}

		public JsonResult Delete(int id)
		{
			(ExecutionState executionState, string message) CheckDataExistOrNot = _MeetingTypeService.DoesExist(id);
			string message = "Failed, You can't delete this item.";

			if (CheckDataExistOrNot.executionState.ToString() != "Success")
			{
				return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
			}

			(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.Delete(id);
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
		public ActionResult Delete(int id, MeetingTypeVM entity)
		{
			try
			{
				if (id != entity.Id)
				{
					return RedirectToAction(nameof(CategoryController.Index), "Category");
				}
				entity.IsDeleted = true;
				entity.UpdatedAt = DateTime.Now;
				(ExecutionState executionState, MeetingTypeVM entity, string message) returnResponse = _MeetingTypeService.Update(entity);
//				Session["Message"] = returnResponse.message;
//				Session["executionState"] = returnResponse.executionState;
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
