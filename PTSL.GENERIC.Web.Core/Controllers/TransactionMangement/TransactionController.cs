using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.TransactionMangement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _TransactionService;
        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IFundTypeService _FundTypeService;
        private readonly IFinancialYearService _FinancialYearService;
        private readonly FileHelper _fileHelper;
        //For CDF
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        public TransactionController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _TransactionService = new TransactionService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _FundTypeService = new FundTypeService(httpHelper);
            _FinancialYearService = new FinancialYearService(httpHelper);
            //For Cdf
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _fileHelper = fileHelper;
        }

        public ActionResult Index()
        {
            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = new SelectList("");
            ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
            ViewBag.FromDate = string.Empty;
            ViewBag.ToDate = string.Empty;

            (ExecutionState executionState, List<TransactionVM> entity, string message) returnResponse = _TransactionService.List();
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult IndexFilter(TransactionFilterVM filter)
        {
            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", filter.ForestCircleId);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(filter.ForestCircleId ?? 0).entity ?? Enumerable.Empty<ForestDivisionVM>(), "Id", "Name", filter.ForestDivisionId);
            ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name");
            ViewBag.FromDate = filter.FromDate;
            ViewBag.ToDate = filter.ToDate;

            (ExecutionState executionState, List<TransactionVM> entity, string message) returnResponse = _TransactionService.GetByFilter(filter);

            return View("Index", returnResponse.entity);
        }

        public ActionResult IndexFilter()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, TransactionVM entity, string message) returnResponse = _TransactionService.GetDetails(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult LoadData(FundTypeVM fundType)
        {
            return PartialView("~/Views/Transaction/LoadPartial.cshtml", fundType);
        }

        public ActionResult Create()
        {
            var entity = new TransactionVM();

            ViewBag.ForestCircleId = _ForestCircleService.List().entity ?? new List<ForestCircleVM>();
            ViewBag.FinancialYearId = _FinancialYearService.List().entity ?? new List<FinancialYearVM>();

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(TransactionVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;

                    var files = HttpContext.Request.Form.Files.GetFiles("TransactionDocuments");
                    var cdfFiles = HttpContext.Request.Form.Files.GetFiles("CDFFiles");

                    if (SaveFiles(files, cdfFiles, ref entity, FileType.Image, out var imageFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = imageFileError },
                            SerializerOption.Default);
                    }

                    (ExecutionState executionState, TransactionVM entity, string message) returnResponse = _TransactionService.Create(entity);

                    if (returnResponse.executionState == ExecutionState.Success)
                    {
                        var urlRedirect = Url.Action("Index", "Transaction");

                        HttpContext.Session.SetString("Message", "Transaction information has been created successfully.");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Transaction information has been created successfully.", RedirectUrl = urlRedirect },
                            SerializerOption.Default);
                    }

                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }

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

        public ActionResult ListDate(long financialYearId)
        {
            var result = _TransactionService.ListDate(financialYearId);

            return Json(
                new { Success = result.entity != null, Message = result.message, Data = result.entity },
                SerializerOption.Default);
        }

        public ActionResult GetDetails(int? id)
        {
            if (id == null || id.Value < 1)
            {
                return Json(
                    new { Success = false, Message = "Invalid id" },
                    SerializerOption.Default);
            }

            (ExecutionState executionState, TransactionVM entity, string message) result = _TransactionService.GetDetails(id);

            return Json(
                new { Success = result.entity != null, Message = result.message, Data = result.entity },
                SerializerOption.Default);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            (ExecutionState executionState, TransactionVM entity, string message) result = _TransactionService.GetById(id);

            ViewBag.ForestCircleId = new SelectList(_ForestCircleService.List().entity ?? new List<ForestCircleVM>(), "Id", "Name", result.entity?.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(_ForestDivisionService.ListByForestCircle(result.entity?.ForestCircleId ?? 0).entity ?? new List<ForestDivisionVM>(), "Id", "Name", result.entity?.ForestDivisionId ?? 0);
            ViewBag.FinancialYearId = new SelectList(_FinancialYearService.List().entity ?? new List<FinancialYearVM>(), "Id", "Name", result.entity?.FinancialYearId ?? 0);
            ViewBag.FundTypeId = _FundTypeService.List().entity ?? new List<FundTypeVM>();

            return View(result.entity);
        }

        [HttpPost]
        public ActionResult Edit(TransactionVM entity)
        {
            try
            {
                var urlRedirect = Url.Action("Index", "Transaction");

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, TransactionVM entity, string message) returnResponse = _TransactionService.Update(entity);

                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Transaction information has been updated successfully.");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return Json(
                            new { Success = true, Message = "Transaction information has been updated successfully.", RedirectUrl = urlRedirect },
                            SerializerOption.Default);
                    }
                    else
                    {
                        return Json(
                            new { Success = false, Message = returnResponse.message },
                            SerializerOption.Default);
                    }
                }

                return Json(
                    new { Success = false, Message = ModelState.FirstErrorMessage() },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unexpected error occurred." },
                    SerializerOption.Default);
            }
        }

        public JsonResult GetByTransaction(long id)
        {
            return Json(new {}, SerializerOption.Default);
        }

        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _TransactionService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, TransactionVM entity, string message) returnResponse = _TransactionService.Delete(id);
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
        public ActionResult Delete(int id, TransactionVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TransactionVM entity, string message) returnResponse = _TransactionService.Update(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool SaveFiles(IReadOnlyList<IFormFile> files, IReadOnlyList<IFormFile> cdfFiles, ref TransactionVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "Transaction", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new TransactionFilesVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileUrl = fileUrl,
                };

                entity?.TransactionFiles?.Add(entityFile);
            }

            if (entity.ExpenseDetailsForCDFs != null && entity.ExpenseDetailsForCDFs?.Count != 0)
            {
                var enumerator = entity.ExpenseDetailsForCDFs!.GetEnumerator();
                var currentCDF = enumerator.Current;

                foreach (var file in cdfFiles)
                {
                    if (currentCDF is null) continue;

                    var (isSaved, fileUrl, _) = _fileHelper.SaveFile(file, null, "TransactionCDF", out var errorMessage);
                    if (isSaved == false)
                    {
                        error = errorMessage;
                        return false;
                    }

                    currentCDF.DocumentFileURL = fileUrl;

                    enumerator.MoveNext();
                }
            }

            error = string.Empty;
            return true;
        }
    }
}
