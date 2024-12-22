using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Nursery
{
    [SessionAuthorize]
    public class NurseryRaisedSeedlingInformationController : Controller
    {
        private readonly INurseryRaisedSeedlingInformationService _nurseryRaisedSeedlingInformationService;
        private readonly INurseryInformationService _nurseryInformationService;
        private readonly INurseryRaisingSectorService _nurseryRaisingSectorService;

        public NurseryRaisedSeedlingInformationController(HttpHelper httpHelper)
        {
            _nurseryRaisedSeedlingInformationService = new NurseryRaisedSeedlingInformationService(httpHelper);
            _nurseryInformationService = new NurseryInformationService(httpHelper);
            _nurseryRaisingSectorService = new NurseryRaisingSectorService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<NurseryRaisedSeedlingInformationVM> entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.List();
            return View(returnResponse.entity);
        }

        public JsonResult GetSeedlingByNurseryId(long id)
        {
            var returnResponse = _nurseryRaisedSeedlingInformationService.GetSeedlingByNurseryId(id).entity ?? new List<NurseryRaisedSeedlingInformationVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new NurseryRaisedSeedlingInformationVM();


            var nurseryInformation = _nurseryInformationService.List().entity?.OrderBy(x => x.NurseryName).ToList();
            var nurseryRaisingSector = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();

            ViewBag.NurseryInformationId = new SelectList(nurseryInformation ?? new List<NurseryInformationVM>(), "Id", "NurseryName");
            ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSector ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(NurseryRaisedSeedlingInformationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var nurseryInformation = _nurseryInformationService.List().entity?.OrderBy(x => x.NurseryName).ToList();
                    var nurseryRaisingSector = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();

                    ViewBag.NurseryInformationId = new SelectList(nurseryInformation ?? new List<NurseryInformationVM>(), "Id", "NurseryName");
                    ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSector ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");

                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Nursery Type created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "NurseryRaisedSeedlingInformation");

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

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

            var nurseryInformation = _nurseryInformationService.List().entity?.OrderBy(x => x.NurseryName).ToList();
            var nurseryRaisingSector = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();

            ViewBag.NurseryInformationId = new SelectList(nurseryInformation ?? new List<NurseryInformationVM>(), "Id", "NurseryName");
            ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSector ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");

            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, NurseryRaisedSeedlingInformationVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "NurseryRaisedSeedlingInformation");

                    }

                    var nurseryInformation = _nurseryInformationService.List().entity?.OrderBy(x => x.NurseryName).ToList();
                    var nurseryRaisingSector = _nurseryRaisingSectorService.List().entity?.OrderBy(x => x.Name).ToList();

                    ViewBag.NurseryInformationId = new SelectList(nurseryInformation ?? new List<NurseryInformationVM>(), "Id", "NurseryName");
                    ViewBag.NurseryRaisingSectorId = new SelectList(nurseryRaisingSector ?? new List<NurseryRaisingSectorVM>(), "Id", "Name");

                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Nursery Type updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "NurseryRaisedSeedlingInformation");

                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);

            }
            catch
            {
                return View(entity);

            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _nurseryRaisedSeedlingInformationService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) returnResponse = _nurseryRaisedSeedlingInformationService.Delete(id);
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
        public JsonResult UpdateSeedlingInfo(UpdateSeedlingInfoVM updateSeedlingInfoVM)
        {
            (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) upadateSeedlingInfoResponse = _nurseryRaisedSeedlingInformationService.UpdateSeedlingInfo(updateSeedlingInfoVM);

            return Json(new { ExecutionSate = upadateSeedlingInfoResponse.executionState, Data = upadateSeedlingInfoResponse.entity, Message = upadateSeedlingInfoResponse.message }, SerializerOption.Default);
        }
    }
}