using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Controllers.GeneralSetup;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Services.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Services.Implementation.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Model;

namespace PTSL.GENERIC.Web.Core.Controllers.PatrollingSchedulingInformetion
{
    [SessionAuthorize]
    public class PatrollingSchedulingController : Controller
    {
        private readonly IPatrollingSchedulingService _PatrollingSchedulingService;
        private readonly IPatrollingSchedulingMemberService _PatrollingSchedulingMemberService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;
        private readonly INgoService _NgoService;

        private readonly IEthnicityService _EthnicityService;
        private readonly ITrainingOrganizerService _TrainingOrganizerService;
        private readonly IEventTypeService _EventTypeService;
        private readonly IPatrollingSchedulingFileService _PatrollingSchedulingFileService;

        private readonly FileHelper _fileHelper;

        public PatrollingSchedulingController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _PatrollingSchedulingService = new PatrollingSchedulingService(httpHelper);
            _PatrollingSchedulingMemberService = new PatrollingSchedulingMemberService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            _NgoService = new NgoService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _TrainingOrganizerService = new TrainingOrganizerService(httpHelper);
            _EventTypeService = new EventTypeService(httpHelper);
            _PatrollingSchedulingFileService = new PatrollingSchedulingFileService(httpHelper);

            _fileHelper = fileHelper;
        }

        public ActionResult Index()
        {
            AuthLocationHelper.GenerateViewBagForForestAndCivil(
                HttpContext,
                ViewBag,
                _ForestCircleService,
                _ForestDivisionService,
                _ForestRangeService,
                _ForestBeatService,
                _ForestFcvVcfService,
                _DivisionService,
                _DistrictService,
                _UpazillaService,
                _UnionService
            );

            //(ExecutionState executionState, List<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.List();

            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");


            //returnResponse.entity  
            return View(new List<PatrollingSchedulingVM>());
        }

        [HttpPost]
        public ActionResult IndexFilter(PatrollingSchedulingFilterVM filter)
        {
            AuthLocationHelper.GenerateViewBagForForestAndCivil(
                HttpContext,
                ViewBag,
                _ForestCircleService,
                _ForestDivisionService,
                _ForestRangeService,
                _ForestBeatService,
                _ForestFcvVcfService,
                _DivisionService,
                _DistrictService,
                _UpazillaService,
                _UnionService,
                filter
            );

            //Extra Filter
            //ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
            //ViewBag.PhoneNumber = filter.PhoneNumber;
            //ViewBag.NID = filter.NID;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

            (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.GetTrainingByFilter(filter);

            return View("Index", returnResponse.entity.aaData);
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
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.GetById(id);
            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            PatrollingSchedulingVM entity = new PatrollingSchedulingVM();

            var forestCircleResponse = _ForestCircleService.List();
            var ethnicityResponse = _EthnicityService.List();
            var divisionResponse = _DivisionService.List();
            var ngoResponse = _NgoService.List();



            var forestCircleList = forestCircleResponse.entity ?? new List<ForestCircleVM>();
            var ethnicityList = ethnicityResponse.entity ?? new List<EthnicityVM>();
            var divisionList = divisionResponse.entity ?? new List<DivisionVM>();
            var ngoList = ngoResponse.entity ?? new List<NgoVM>();


            ViewBag.ForestCircleId = new SelectList(forestCircleList, "Id", "Name");
            ViewBag.PresentDivisionId = new SelectList(divisionList, "Id", "Name");

            ViewBag.EthnicityId = new SelectList(ethnicityList, "Id", "Name");
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(ngoList, "Id", "Name");

            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");

            return View(entity);
        }

        [HttpPost]
        public ActionResult Create(PatrollingSchedulingVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    entity.PatrollingSchedulingParticipentsMaps = JsonConvert.DeserializeObject<List<PatrollingSchedulingParticipentsMapVM>>(entity.PatrollingSchedulingParticipentsMapsJSON);

                    //Check  AmountOfHonoraryAllowance
                    foreach (var data in entity.PatrollingSchedulingParticipentsMaps)
                    {
                        if (data.AmountOfHonoraryAllowance == null || data.AmountOfHonoraryAllowance < 1)
                        {
                            return Json(
                                 new { Success = false, Message = "All Amount Of Honorary Allowance Not Provided !" },
                                    SerializerOption.Default);
                        }
                    }

                    Decimal? totalAmount = Convert.ToDecimal(entity.AllocatedAmountMonth);
                    Decimal? sumTotalPerBeni = Convert.ToDecimal(entity.PatrollingSchedulingParticipentsMaps.Sum(x => x.AmountOfHonoraryAllowance));

                    if (totalAmount < sumTotalPerBeni)
                    {
                        return Json(
                                  new { Success = false, Message = "Allocated Amount Per Month Must Equal Total Amount Of Honorary Allowance" },
                                     SerializerOption.Default);
                    }
                    if (totalAmount > sumTotalPerBeni)
                    {
                        return Json(
                               new { Success = false, Message = "Allocated Amount Per Month Must Equal Total Amount Of Honorary Allowance" },
                                  SerializerOption.Default);
                    }

                    var imageFiles = HttpContext.Request.Form.Files.GetFiles("PatrollingSchedulingImageFiles[]");
                    var documentFiles = HttpContext.Request.Form.Files.GetFiles("PatrollingSchedulingDocumentFiles[]");

                    // Save image files
                    if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = imageFileError },
                            SerializerOption.Default);
                    }

                    // Save document files
                    if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                    {
                        return Json(
                            new { Success = false, Message = documentFileError },
                            SerializerOption.Default);
                    }

                    (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.Create(entity);

                    if (returnResponse.executionState.ToString() == "Created")
                    {
                        return Json(
                            new { Success = true, Message = "Patrolling scheduling has been created" },
                            SerializerOption.Default);
                    }
                    return Json(
                        new { Success = false, Message = returnResponse.message },
                        SerializerOption.Default);
                }
                var message = ModelState.FirstErrorMessage();
                return Json(
                    new { Success = false, Message = message },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unknown error occured." },
                    SerializerOption.Default);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.GetById(id);

            // Forest Administraction
            var forestCircleResponse = _ForestCircleService.List();
            ViewBag.ForestCircleId = new SelectList(forestCircleResponse.entity ?? new List<ForestCircleVM>(), "Id", "Name", returnResponse.entity?.ForestCircleId ?? 0);
            var forestDivisionResponse = _ForestDivisionService.ListByForestCircle(returnResponse.entity?.ForestCircleId ?? 0);
            ViewBag.ForestDivisionId = new SelectList(forestDivisionResponse.entity ?? new List<ForestDivisionVM>(), "Id", "Name", returnResponse.entity?.ForestDivisionId ?? 0);
            var forestRangeResponse = _ForestRangeService.ListByForestDivision(returnResponse.entity?.ForestDivisionId ?? 0);
            ViewBag.ForestRangeId = new SelectList(forestRangeResponse.entity ?? new List<ForestRangeVM>(), "Id", "Name", returnResponse.entity?.ForestRangeId ?? 0);
            var forestBeatResponse = _ForestBeatService.ListByForestRange(returnResponse.entity?.ForestRangeId ?? 0);
            ViewBag.ForestBeatId = new SelectList(forestBeatResponse.entity ?? new List<ForestBeatVM>(), "Id", "Name", returnResponse.entity?.ForestBeatId ?? 0);
            var forestFcvVcfResponse = _ForestFcvVcfService.ListByForestBeat(returnResponse.entity?.ForestBeatId ?? 0);
            ViewBag.ForestFcvVcfId = new SelectList(forestFcvVcfResponse.entity ?? new List<ForestFcvVcfVM>(), "Id", "Name", returnResponse.entity?.ForestFcvVcfId ?? 0);

            // Civil Administration
            var divisionResponse = _DivisionService.List();
            ViewBag.PresentDivisionId = new SelectList(divisionResponse.entity ?? new List<DivisionVM>(), "Id", "Name", returnResponse.entity?.DivisionId ?? 0);
            var districtResponse = _DistrictService.ListByDivision(returnResponse.entity?.DivisionId ?? 0);
            ViewBag.PresentDistrictId = new SelectList(districtResponse.entity ?? new List<DistrictVM>(), "Id", "Name", returnResponse.entity?.DistrictId ?? 0);
            var upazillaResponse = _UpazillaService.ListByDistrict(returnResponse.entity?.DistrictId ?? 0);
            ViewBag.PresentUpazillaId = new SelectList(upazillaResponse.entity ?? new List<UpazillaVM>(), "Id", "Name", returnResponse.entity?.UpazillaId ?? 0);
            ViewBag.PresentUnionNewId = new SelectList(_UnionService.ListByUpazilla(returnResponse.entity?.UpazillaId ?? 0).entity ?? new List<UnionVM>(), "Id", "Name", returnResponse.entity?.UpazillaId ?? 0);

            // Ethnicity
            var ethnicityResponse = _EthnicityService.List();
            ViewBag.EthnicityId = new SelectList(ethnicityResponse.entity ?? new List<EthnicityVM>(), "Id", "Name");

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            //var trainOrgReturnResponse = _TrainingOrganizerService.List();
            //ViewBag.TrainingOrganizerId = new SelectList(trainOrgReturnResponse.entity ?? new List<TrainingOrganizerVM>(), "Id", "Name", returnResponse.entity?.TrainingOrganizerId ?? 0);

            //var eventTypeResponse = _EventTypeService.List();
            //ViewBag.EventTypeId = new SelectList(eventTypeResponse.entity ?? new List<EventTypeVM>(), "Id", "Name", returnResponse.entity?.EventTypeId ?? 0);


            (ExecutionState executionState, List<UnionVM> entity, string message) returnResponseUnion = _UnionService.List();
            if (returnResponseUnion.entity != null)
            {
                ViewBag.UnionId = new SelectList(returnResponseUnion.entity, "Id", "Name", returnResponse.entity.UnionId);
            }

            var fcvVcfList = _ForestFcvVcfService.ListByForestBeat(returnResponse.entity.ForestBeatId).entity ?? new List<ForestFcvVcfVM>();
            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name", FcvVcfHelper.GetFcvVcfType(fcvVcfList, returnResponse.entity.ForestFcvVcfId));


            (ExecutionState executionState, List<NgoVM> entity, string message) returnResponseNgo = _NgoService.List();
            if (returnResponseNgo.entity != null)
            {
                ViewBag.NgoId = new SelectList(returnResponseNgo.entity, "Id", "Name", returnResponse.entity.NgoId);
            }



            ViewBag.AllocatedAmountMonthId = returnResponse.entity.AllocatedAmountMonth;



            return View(returnResponse.entity ?? new PatrollingSchedulingVM());
        }

        [HttpPost]
        public ActionResult Edit(PatrollingSchedulingVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                entity.PatrollingSchedulingParticipentsMaps = JsonConvert.DeserializeObject<List<PatrollingSchedulingParticipentsMapVM>>(entity.PatrollingSchedulingParticipentsMapsJSON);

                //Check  AmountOfHonoraryAllowance
                foreach (var data in entity.PatrollingSchedulingParticipentsMaps)
                {
                    if (data.AmountOfHonoraryAllowance == null || data.AmountOfHonoraryAllowance < 1)
                    {
                        return Json(
                             new { Success = false, Message = "All Amount Of Honorary Allowance Not Provide !" },
                                SerializerOption.Default);
                    }
                }

                Decimal? totalAmount = Convert.ToDecimal(entity.AllocatedAmountMonth);
                Decimal? sumTotalPerBeni = Convert.ToDecimal(entity.PatrollingSchedulingParticipentsMaps.Sum(x => x.AmountOfHonoraryAllowance));

                if (totalAmount < sumTotalPerBeni)
                {
                    return Json(
                              new { Success = false, Message = "Allocated Amount Per Month Must Equal Total Amount Of Honorary Allowance" },
                                 SerializerOption.Default);
                }
                if (totalAmount > sumTotalPerBeni)
                {
                    return Json(
                           new { Success = false, Message = "Allocated Amount Per Month Must Equal Total Amount Of Honorary Allowance" },
                              SerializerOption.Default);
                }











                var imageFiles = HttpContext.Request.Form.Files.GetFiles("PatrollingSchedulingImageFiles[]");
                var documentFiles = HttpContext.Request.Form.Files.GetFiles("PatrollingSchedulingDocumentFiles[]");

                // Save image files
                if (SaveFiles(imageFiles, ref entity, FileType.Image, out var imageFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = imageFileError },
                        SerializerOption.Default);
                }

                // Save document files
                if (SaveFiles(documentFiles, ref entity, FileType.Document, out var documentFileError) == false)
                {
                    return Json(
                        new { Success = false, Message = documentFileError },
                        SerializerOption.Default);
                }

                (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.Update(entity);

                //                Session["Message"] = returnResponse.message;
                //                Session["executionState"] = returnResponse.executionState;
                if (returnResponse.executionState.ToString() == "Updated")
                {
                    return Json(
                        new { Success = true, Message = "Patrolling scheduling information has been updated" },
                        SerializerOption.Default);
                }
                return Json(
                    new { Success = false, Message = returnResponse.message },
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _PatrollingSchedulingService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.Delete(id);
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
        public ActionResult Delete(int id, PatrollingSchedulingVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(CategoryController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse = _PatrollingSchedulingService.Update(entity);
                //                Session["Message"] = returnResponse.message;
                //                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        [HttpGet]
        public ActionResult DeleteParticipant(long patrollingSchedulingParticipentsMapId)
        {
            try
            {
                (ExecutionState executionState, bool isDeleted, string message) returnResponse = _PatrollingSchedulingService.DeleteParticipant(patrollingSchedulingParticipentsMapId);

                if (returnResponse.isDeleted)
                {
                    return Json(
                        new { Success = true, Message = "Successfully deleted." },
                        SerializerOption.Default);
                }

                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
            }
            catch
            {
                return Json(
                    new { Success = false, Message = "Unknown error occurred." },
                    SerializerOption.Default);
            }
        }


        //[HttpPost]
        //public ActionResult UpdateOtherMember(CommunityTrainingMemberVM member)
        //{
        //    try
        //    {
        //        (ExecutionState executionState, CommunityTrainingMemberVM entity, string message) returnResponse = _CommunityTrainingMemberService.Update(member);

        //        if (returnResponse.executionState == ExecutionState.Updated)
        //        {
        //            return Json(
        //                new { Success = true, Message = "Successfully updated.", Data = returnResponse.entity },
        //                SerializerOption.Default);
        //        }

        //        return Json(
        //            new { Success = false, Message = returnResponse.message },
        //            SerializerOption.Default);
        //    }
        //    catch
        //    {
        //        return Json(
        //            new { Success = false, Message = "Unknown error occured." },
        //            SerializerOption.Default);
        //    }
        //}

        private bool SaveFiles(IReadOnlyList<IFormFile> files, ref PatrollingSchedulingVM entity, FileType fileType, out string error)
        {
            foreach (var file in files)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(file, fileType, "PatrollingScheduling", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                var entityFile = new PatrollingSchedulingFileVM
                {
                    FileName = file.FileName,
                    FileType = fileType,
                    FileNameUrl = fileName,
                };

                entity?.PatrollingSchedulingFiles?.Add(entityFile);
            }

            error = string.Empty;
            return true;
        }



        public ActionResult DeleteImageOrDocument(long id)
        {
            var result = _PatrollingSchedulingFileService.GetById(id);

            if (result.entity != null)
            {
                result.entity.IsDeleted = true;
                var data = _PatrollingSchedulingFileService.Update(result.entity);
                result.message = "Item deleted successfully.";
            }
            else
            {
                result.message = "Failed to delete this item.";
            }

            return Json(new { Success = result.entity.IsDeleted, Message = result.message, result.executionState }, SerializerOption.Default);
            //return null;
        }



        //DataTable Get List using server site Pagination

        public ActionResult GetPatrollingSchedulingListByPagination(JqueryDatatableParam param)
        {
            AuthLocationHelper.GenerateViewBagForForestAndCivil(
               HttpContext,
               ViewBag,
               _ForestCircleService,
               _ForestDivisionService,
               _ForestRangeService,
               _ForestBeatService,
               _ForestFcvVcfService,
               _DivisionService,
               _DistrictService,
               _UpazillaService,
               _UnionService
           );

            var filter = AuthLocationHelper.GetFilterFromSession<PatrollingSchedulingFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;


           // (ExecutionState executionState, List<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.List();

            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");


             (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.GetTrainingByFilter(filter);



            return Json(new
            {
                param.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                data = returnResponse.entity.aaData.ToList()
            }, SerializerOption.Default);


            //  return View(returnResponse.entity);
        }



        [HttpPost]
        public ActionResult IndexFilterPatrollingSchedulingListByPagination(PatrollingSchedulingFilterVM filter)
        {

            AuthLocationHelper.GenerateViewBagForForestAndCivil(
               HttpContext,
               ViewBag,
               _ForestCircleService,
               _ForestDivisionService,
               _ForestRangeService,
               _ForestBeatService,
               _ForestFcvVcfService,
               _DivisionService,
               _DistrictService,
               _UpazillaService,
               _UnionService,
               filter
           );

            //Extra Filter
            //ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
            //ViewBag.PhoneNumber = filter.PhoneNumber;
            //ViewBag.NID = filter.NID;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);

            (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) returnResponse = _PatrollingSchedulingService.GetTrainingByFilter(filter);

      
            return Json(new
            {
                filter.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            //return View("Index", returnResponse.entity.aaData);

        }





    }

    public class JqueryDatatableParam
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }

}
