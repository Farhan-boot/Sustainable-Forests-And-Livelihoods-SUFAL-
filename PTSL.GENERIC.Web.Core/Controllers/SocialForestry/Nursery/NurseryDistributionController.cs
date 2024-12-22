using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.SocialForestry.Nursery
{
    [SessionAuthorize]
    public class NurseryDistributionController : Controller
    {
        private readonly INurseryRaisedSeedlingInformationService _nurseryRaisedSeedlingInformationService;
        private readonly INurseryDistributionService _nurseryDistributionService;
        private readonly INurseryInformationService _nurseryInformationService;
        private readonly INurseryRaisingSectorService _nurseryRaisingSectorService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        private readonly IFinancialYearService _financialYearService;
        private readonly IProjectTypeService _projectTypeService;
        private readonly INurseryTypeService _nurseryTypeService;

        private readonly ISocialForestryDesignationService _socialForestryDesignationService;
        private readonly FileHelper _fileHelper;

        public NurseryDistributionController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _nurseryRaisedSeedlingInformationService = new NurseryRaisedSeedlingInformationService(httpHelper);
            _nurseryDistributionService = new NurseryDistributionService(httpHelper);
            _nurseryRaisingSectorService = new NurseryRaisingSectorService(httpHelper);
            _nurseryInformationService = new NurseryInformationService(httpHelper);
            _fileHelper = fileHelper;
        }

        public ActionResult Index(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "NurseryInformation");
            }
            (ExecutionState executionState, List<DistributionVM> entity, string message) returnResponse = _nurseryDistributionService.GetByNurseryId(id);
            ViewBag.Id = id;
            return View(returnResponse.entity);
        }
        public ActionResult IndexFilter(int id, NurseryFilterVM nurseryFilterVM)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "NurseryInformation");
            }
            (ExecutionState executionState, List<DistributionVM> entity, string message) returnResponse = _nurseryDistributionService.GetFilterByDate(id, nurseryFilterVM);
            ViewBag.Id = id;
            return View("Index", returnResponse.entity);
        }

        public ActionResult Details(int? id, string dateParam)
        {
            if (id == null)
            {
                return NotFound();
            }
            DistributionFilter distributionFilter = new DistributionFilter();
            distributionFilter.NurseryId = id;
            distributionFilter.DistributionDate = Convert.ToDateTime(dateParam);

            (ExecutionState executionState, NurseryInformationVM entity, string message) returnResponse = _nurseryInformationService.GetById(id);
            var distributionInformation = _nurseryDistributionService.GetFilterData(distributionFilter);
            ViewBag.distributionInformation = distributionInformation.entity ?? new List<NurseryDistributionVM>();

            return View(returnResponse.entity);
        }

        public ActionResult Create(int? id)
        {
            var entity = new NurseryDistributionVM();
            NurseryInformationVM nurserydata = _nurseryInformationService.GetById(id).entity;

            if (id == null)
            {
                return RedirectToAction(nameof(this.Index));
            }
            if (nurserydata != null)
            {
                ViewBag.NurseryData = nurserydata;
                return View(entity);
            }
            return View(entity);

        }

        [HttpPost]
        public ActionResult Create(int? id, NurseryDistributionListVM entity)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (entity.NurseryDistributionList != null)
                    {

                        foreach (var item in entity.NurseryDistributionList)
                        {
                            item.IsActive = true;
                            item.CreatedAt = DateTime.Now;
                            item.IsDeleted = false;
                            item.NurseryInformation = null;

                        }
                    }

                    (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) returnResponse = _nurseryDistributionService.CreateRange(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty }, SerializerOption.Default);

                    }
                    else
                    {
                        var urlRedirect = "../Index?id="+ id;

                        HttpContext.Session.SetString("Message", "Nursery distributed successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return Json(
                            new { Success = true, Message = "Nursery distributed successfully", RedirectUrl = urlRedirect },
                            SerializerOption.Default);

                    }
                }
                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                   new { Success = false, Message = "Unknown error occured." },
                   SerializerOption.Default);

            }
        }

        public ActionResult Edit(int? id, string dateParam)
        {
            if (id == null)
            {

            }
            NurseryInformationVM nurserydata = _nurseryInformationService.GetById(id).entity;
            ViewBag.NurseryData = nurserydata;

            var DistributionFilter = new DistributionFilter();
            DistributionFilter.NurseryId = id;
            DistributionFilter.DistributionDate = Convert.ToDateTime(dateParam);

            List<NurseryDistributionVM> filteredData = _nurseryDistributionService.GetFilterData(DistributionFilter).entity;
            var entity = new NurseryDistributionVM();
            ViewBag.DistributionDate = filteredData;
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(int id, NurseryDistributionListVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (entity.NurseryDistributionList != null)
                    {

                        foreach (var item in entity.NurseryDistributionList)
                        {
                            item.IsActive = true;
                            item.UpdatedAt = DateTime.Now;
                            item.NurseryInformation = null;
                        }
                    }
                    (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) returnResponse = _nurseryDistributionService.CreateRange(entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(new { Success = false, Message = returnResponse.message, RedirectUrl = string.Empty }, SerializerOption.Default);

                    }
                    else
                    {
                        var urlRedirect = Url.Action(nameof(this.Index), "NurseryDistribution") + "/Index?id=" + id;

                        HttpContext.Session.SetString("Message", "Nursery distribution updated  successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return Json(
                            new { Success = true, Message = "Nursery distributed updated successfully", RedirectUrl = urlRedirect },
                            SerializerOption.Default);

                    }
                }
                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());
                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage(), RedirectUrl = string.Empty },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                   new { Success = false, Message = "Unknown error occured." },
                   SerializerOption.Default);

            }
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _nurseryDistributionService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, NurseryDistributionVM entity, string message) returnResponse = _nurseryDistributionService.Delete(id);
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
        public JsonResult GetDistributionByNurseryId(int id)
        {
            (ExecutionState executionState, List<DistributionVM> entity, string message) nurseryDistributionData = _nurseryDistributionService.GetByNurseryId(id);



            if (nurseryDistributionData.executionState == ExecutionState.Retrieved)
            {
                return Json(new { Success = true, Message = nurseryDistributionData.message, RedirectUrl = string.Empty, data = nurseryDistributionData.entity }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = nurseryDistributionData.message, RedirectUrl = string.Empty, data = new NurseryDistributionVM() }, SerializerOption.Default);
            }


        }
        public JsonResult GetDistributionId(int id)
        {
            (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) nurseryDistributionData = _nurseryDistributionService.List();

            if (nurseryDistributionData.executionState == ExecutionState.Retrieved)
            {
                return Json(new { Success = true, Message = nurseryDistributionData.message, RedirectUrl = string.Empty, data = nurseryDistributionData.entity }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = nurseryDistributionData.message, RedirectUrl = string.Empty, data = new NurseryDistributionVM() }, SerializerOption.Default);
            }


        }
        public JsonResult GetSeedlingInfo()
        {
            var nurserySeedlingData = _nurseryRaisedSeedlingInformationService.List();

            if (nurserySeedlingData.executionState == ExecutionState.Retrieved)
            {
                return Json(new { Success = true, Message = nurserySeedlingData.message, RedirectUrl = string.Empty, data = nurserySeedlingData.entity }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = nurserySeedlingData.message, RedirectUrl = string.Empty, data = new NurseryDistributionVM() }, SerializerOption.Default);
            }


        }
        [HttpPost]
        public ActionResult GetFilterData([FromBody] FilterObj data)
        {
            var DistributionFilter = new DistributionFilter();
            DistributionFilter.NurseryId = data.NurseryId;
            DistributionFilter.DistributionDate = Convert.ToDateTime(data.DistributionDate);
            List<NurseryDistributionVM> nurserydata = _nurseryDistributionService.GetFilterData(DistributionFilter).entity;


            if (nurserydata.Count > 0 && nurserydata is not null)
            {
                return Json(new { Success = true, Message = "Success", RedirectUrl = string.Empty, data = nurserydata }, SerializerOption.Default);
            }
            else
            {
                return Json(new { Success = false, Message = "Failure", RedirectUrl = string.Empty, data = new List<NurseryDistributionVM>() }, SerializerOption.Default);
            }


        }
    }
}