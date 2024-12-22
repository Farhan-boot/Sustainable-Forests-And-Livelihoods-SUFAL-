using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry
{
    [SessionAuthorize]
    public class SocialForestryBeneficiaryController : Controller
    {
        private readonly ISocialForestryBeneficiaryService _socialForestryBeneficiaryService;
        private readonly IEthnicityService _ethnicityService;
        private readonly INewRaisedPlantationService _newRaisedPlantationService;

        private readonly IPlantationSocialForestryBeneficiaryMapService _plantationSocialForestryBeneficiaryMapService;
        public SocialForestryBeneficiaryController(HttpHelper httpHelper)
        {
            _socialForestryBeneficiaryService = new SocialForestryBeneficiaryService(httpHelper);
            _ethnicityService = new EthnicityService(httpHelper);
            _newRaisedPlantationService = new NewRaisedPlantationService(httpHelper);
            _plantationSocialForestryBeneficiaryMapService = new PlantationSocialForestryBeneficiaryMapService(httpHelper);
        }

        public ActionResult Index()
        {
            (ExecutionState executionState, List<PlantationSocialForestryBeneficiaryMapVM> entity, string message) returnResponse = _plantationSocialForestryBeneficiaryMapService.List();
            return View(returnResponse.entity);
        }

        public JsonResult GetBeneficiariesByNewRaisedId(long newRaisedId)
        {
            var returnResponse = _socialForestryBeneficiaryService.GetBeneficiariesByNewRaisedId(newRaisedId).entity ?? new List<SocialForestryBeneficiaryVM>();
            return Json(new { Data = returnResponse }, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) returnResponse = _socialForestryBeneficiaryService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            var entity = new PlantationSocialForestryBeneficiaryMapVM();
            List<EthnicityVM>? ethnicityResponse = _ethnicityService.List().entity?.OrderBy(x => x.Name).ToList();
            List<NewRaisedPlantationVM>? newRaisedPlantationList = _newRaisedPlantationService.List().entity ?? new List<NewRaisedPlantationVM>();
            ViewBag.NewRaisedPlantationList = newRaisedPlantationList;
            if (ethnicityResponse == null)
            {
                ethnicityResponse = new List<EthnicityVM>();
            }

            ViewBag.Gender = EnumHelper.GetEnumDropdowns<Gender>();
            ViewBag.EthnicityId = ethnicityResponse ?? new List<EthnicityVM>();

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(PlantationSocialForestryBeneficiaryMapVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Gender = EnumHelper.GetEnumDropdowns<Gender>();
                    List<EthnicityVM>? ethnicityResponse = _ethnicityService.List().entity?.OrderBy(x => x.Name).ToList();

                    ViewBag.EthnicityId = ethnicityResponse ?? new List<EthnicityVM>();
                    List<NewRaisedPlantationVM>? newRaisedPlantationList = _newRaisedPlantationService.List().entity ?? new List<NewRaisedPlantationVM>();
                    ViewBag.NewRaisedPlantationList = newRaisedPlantationList;

                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) returnResponse = _plantationSocialForestryBeneficiaryMapService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Social Forestry Beneficiary created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "SocialForestryBeneficiary");

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
            ViewBag.Gender = EnumHelper.GetEnumDropdowns<Gender>();
            List<EthnicityVM>? ethnicityResponse = _ethnicityService.List().entity?.OrderBy(x => x.Name).ToList();
            ViewBag.EthnicityId = ethnicityResponse ?? new List<EthnicityVM>();

            List<NewRaisedPlantationVM>? newRaisedPlantationList = _newRaisedPlantationService.List().entity ?? new List<NewRaisedPlantationVM>();
            ViewBag.NewRaisedPlantationList = newRaisedPlantationList;

            (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) returnResponse = _plantationSocialForestryBeneficiaryMapService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, PlantationSocialForestryBeneficiaryMapVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(this.Index), "SocialForestryBeneficiary");
                    }
                    ViewBag.Gender = EnumHelper.GetEnumDropdowns<Gender>();
                    List<EthnicityVM>? ethnicityResponse = _ethnicityService.List().entity?.OrderBy(x => x.Name).ToList();
                    ViewBag.EthnicityId = ethnicityResponse ?? new List<EthnicityVM>();

                    List<NewRaisedPlantationVM>? newRaisedPlantationList = _newRaisedPlantationService.List().entity ?? new List<NewRaisedPlantationVM>();
                    ViewBag.NewRaisedPlantationList = newRaisedPlantationList;


                    entity.IsActive = true;
                    entity.IsDeleted = false;

                    (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) returnResponse = _plantationSocialForestryBeneficiaryMapService.Update(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return View(entity);

                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Social Forestry Beneficiary updated successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction(nameof(this.Index), "SocialForestryBeneficiary");

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

        [HttpPost]
        public JsonResult EditJson(PlantationSocialForestryBeneficiaryMapVM entity)
        {
            try
            {
                var returnResponse = _plantationSocialForestryBeneficiaryMapService.Update(entity);

                return Json(new
                {
                    Message = returnResponse.message,
                    Success = returnResponse.executionState == ExecutionState.Updated,
                }, SerializerOption.Default);
            }
            catch (Exception)
            {
                return Json(new
                {
                    Message = "Unexpected",
                    Success = false,
                }, SerializerOption.Default);
            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _plantationSocialForestryBeneficiaryMapService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, PlantationSocialForestryBeneficiaryMapVM entity, string message) returnResponse = _plantationSocialForestryBeneficiaryMapService.Delete(id);
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
    }
}
