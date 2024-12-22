using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.Beneficiary
{
    [SessionAuthorize]
    public class SavingsAccountController : Controller
    {
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IEthnicityService _EthnicityService;
        private readonly IOtherCommitteeMemberService _OtherCommitteeMemberService;
        private readonly ISurveyService _SurveyService;
        private readonly INgoService _NgoService;

        // Civil administration
        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;
        private readonly ICommitteeDesignationService _SubCommitteeDesignationService;

        private readonly ISavingsAccountService _SavingsAccountService;
        private readonly ISavingsAmountInformationService _SavingsAmountInformationService;
        private readonly IWithdrawAmountInformationService _WithdrawAmountInformationService;
        private readonly FileHelper _fileHelper;

        public SavingsAccountController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _EthnicityService = new EthnicityService(httpHelper);
            _OtherCommitteeMemberService = new OtherCommitteeMemberService(httpHelper);
            _SurveyService = new SurveyService(httpHelper);
            _NgoService = new NgoService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
            _SubCommitteeDesignationService = new CommitteeDesignationService(httpHelper);

            _SavingsAccountService = new SavingsAccountService(httpHelper);
            _SavingsAmountInformationService = new SavingsAmountInformationService(httpHelper);
            _WithdrawAmountInformationService = new WithdrawAmountInformationService(httpHelper);
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

            var filter = AuthLocationHelper.GetFilterFromSession<SavingsAccountFilterVM>(HttpContext, 50);
            (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);

            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

            return View(returnResponse.entity.aaData);
        }

        [HttpPost]
        public ActionResult IndexFilter(SavingsAccountFilterVM filter)
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

            (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);

            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
            ViewBag.PhoneNumber = filter.PhoneNumber;
            ViewBag.NID = filter.NID;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);
            return View("Index", returnResponse.entity.aaData);
        }

        public ActionResult IndexFilter()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Savings(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse = _SavingsAccountService.GetById(id);
            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Savings(SavingsAmountInformationVM? entity)
        {
            if (entity == null)
            {
                return NotFound();
            }
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;


            var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentFileUrl");

            if (documentFile is not null)
            {
                if (SaveFiles(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {

                }
            }
            (ExecutionState executionState, SavingsAmountInformationVM entity, string message) returnResponse = _SavingsAmountInformationService.Create(entity);

            HttpContext.Session.SetString("Message", "Savings information has been updated successfully");
            HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

            return Json(entity, SerializerOption.Default);

        }

        public ActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //(ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse = _WithdrawAmountInformationService.GetById(id);
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse = _SavingsAccountService.GetById(id);

            return View(returnResponse.entity);
        }

        [HttpPost]
        public ActionResult Withdraw(WithdrawAmountInformationVM? entity)
        {
            if (entity == null)
            {
                return NotFound();
            }
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.DfoStatusId = (long)WithdrawDfoStatusEnum.Padding;

            var documentFile = HttpContext.Request.Form.Files.GetFile("DocumentFileUrl");

            if (documentFile is not null)
            {
                if (SaveFilesForWithdraw(documentFile, ref entity, FileType.Document, out var imageFileError) == false)
                {

                }
            }

            (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse = _WithdrawAmountInformationService.Create(entity);

            HttpContext.Session.SetString("Message", "Withdrawal information has been updated successfully");
            HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

            return Json(entity, SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse = _SavingsAccountService.GetById(id);
            ViewBag.AccountTypeId = new SelectList(EnumHelper.GetEnumDropdowns<AccountType>(), "Id", "Name", returnResponse.entity.AccountTypeId);


            return View(returnResponse.entity);
        }

        public ActionResult Create()
        {
            ViewBag.AccountTypeId = new SelectList(EnumHelper.GetEnumDropdowns<AccountType>(), "Id", "Name");

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

            (ExecutionState executionState, List<NgoVM> entity, string message) returnResponseNgo = _NgoService.List();
            if (returnResponseNgo.entity != null)
            {
                ViewBag.NgoId = new SelectList(returnResponseNgo.entity, "Id", "Name", returnResponseNgo.entity);
            }

            // Civil administration
            (ExecutionState executionState, List<DivisionVM> entity, string message) returnResponseCivilDivision = _DivisionService.List();
            ViewBag.CivilDivisionId = new SelectList(returnResponseCivilDivision.entity ?? new List<DivisionVM>(), "Id", "Name", returnResponseCivilDivision.entity);

            ViewBag.FcvVcfType = new SelectList(EnumHelper.GetEnumDropdowns<FcvVcfType>(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(SavingsAccountVM entity)
        {
            try
            {
                entity.FcvId = entity.ForestFcvVcfId ?? 0;

                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse = _SavingsAccountService.Create(entity);

                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        HttpContext.Session.SetString("Message", returnResponse.message);
                        HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                        return View(entity);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Savings Account has been created successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction("Index");
                    }
                }

                HttpContext.Session.SetString("Message", ModelState.FirstErrorMessage());
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
            catch
            {
                HttpContext.Session.SetString("Message", "Unexpected error occurred");
                HttpContext.Session.SetString("executionState", ExecutionState.Failure.ToString());

                return View(entity);
            }
        }

        [HttpGet]
        public ActionResult WithdrawStatusList()
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

            //var filter = AuthLocationHelper.GetFilterFromSession<SavingsAccountFilterVM>(HttpContext, 50);
            //(ExecutionState executionState, List<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);

            (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) returnResponse = _WithdrawAmountInformationService.List();
            if (returnResponse.entity != null)
            {
                return View(returnResponse.entity.Where(x => x.DfoStatusId == 1));
            }
            else
            {
                return View(new List<WithdrawAmountInformationVM>());
            }
        }

        [HttpGet]
        public ActionResult WithdrawAmountApproved(int id)
        {
            try
            {
                var data = _WithdrawAmountInformationService.GetById(id);

                if (ModelState.IsValid)
                {
                    if (id != data.entity.Id)
                    {
                        return RedirectToAction(nameof(this.WithdrawStatusList));
                    }
                    data.entity.IsActive = true;
                    data.entity.IsDeleted = false;
                    data.entity.UpdatedAt = DateTime.Now;
                    data.entity.DfoStatusId = (long)WithdrawDfoStatusEnum.Approved; //2

                    (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse = _WithdrawAmountInformationService.Update(data.entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Withdraw Amount Approved successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction("WithdrawStatusList", "SavingsAccount");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Withdraw Amount Approved successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return RedirectToAction("WithdrawStatusList", "SavingsAccount");
                    }
                }

                return RedirectToAction("WithdrawStatusList", "SavingsAccount");
            }
            catch
            {
                return RedirectToAction("WithdrawStatusList", "SavingsAccount");
            }
        }


        [HttpGet]
        public ActionResult WithdrawAmountRjected(int id)
        {
            try
            {
                var data = _WithdrawAmountInformationService.GetById(id);

                if (ModelState.IsValid)
                {
                    if (id != data.entity.Id)
                    {
                        return RedirectToAction(nameof(this.WithdrawStatusList));
                    }
                    data.entity.IsActive = true;
                    data.entity.IsDeleted = false;
                    data.entity.UpdatedAt = DateTime.Now;
                    data.entity.DfoStatusId = (long)WithdrawDfoStatusEnum.Rejected;//3

                    (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse = _WithdrawAmountInformationService.Update(data.entity);

                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        HttpContext.Session.SetString("Message", "Withdraw Amount Rjected successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                        return RedirectToAction("WithdrawStatusList", "SavingsAccount");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Withdraw Amount Rjected successfully");
                        HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());
                        return RedirectToAction("WithdrawStatusList", "SavingsAccount");
                    }
                }

                return RedirectToAction("WithdrawStatusList", "SavingsAccount");
            }
            catch
            {
                return RedirectToAction("WithdrawStatusList", "SavingsAccount");
            }
        }



        private bool SaveFiles(IFormFile? file, ref SavingsAmountInformationVM entity, FileType fileType, out string error)
        {
            if (file is null)
            {
                error = "File is empty";
                return false;
            }
            var (isSaved, fileUrl, fileName) = _fileHelper.SaveFile(file, fileType, "SavingsAmountInformation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }
            entity.DocumentFileUrl = fileUrl;
            error = string.Empty;
            return true;
        }




        private bool SaveFilesForWithdraw(IFormFile? file, ref WithdrawAmountInformationVM entity, FileType fileType, out string error)
        {
            if (file is null)
            {
                error = "File is empty";
                return false;
            }
            var (isSaved, fileUrl, fileName) = _fileHelper.SaveFile(file, fileType, "WithdrawAmountInformation", out var errorMessage);
            if (isSaved == false)
            {
                error = errorMessage;
                return false;
            }
            entity.DocumentFileUrl = fileUrl;
            error = string.Empty;
            return true;
        }





        //        public ActionResult Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }
        //            (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.GetById(id);

        //            return View(returnResponse.entity);
        //        }

        //        [HttpPost]
        //        public ActionResult Edit(int id, ForestCircleVM entity)
        //        {
        //            try
        //            {
        //                if (ModelState.IsValid)
        //                {
        //                    if (id != entity.Id)
        //                    {
        //                        return RedirectToAction(nameof(this.Index), "Category");
        //                    }
        //                    entity.IsActive = true;
        //                    entity.IsDeleted = false;
        //                    entity.UpdatedAt = DateTime.Now;
        //                    (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Update(entity);
        //////                    Session["Message"] = returnResponse.message;
        ////                    Session["executionState"] = returnResponse.executionState;
        //                    if (returnResponse.executionState.ToString() != "Updated")
        //                    {
        //                        return View(entity);
        //                    }
        //                    else
        //                    {
        //                        return RedirectToAction("Index");
        //                    }
        //                }

        //////                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
        ////                Session["executionState"] = ExecutionState.Failure;
        //                return View(entity);
        //            }
        //            catch
        //            {
        //////                Session["Message"] = "Form Data Not Valid.";
        ////                Session["executionState"] = ExecutionState.Failure;
        //                return View(entity);
        //            }
        //        }

        //        public JsonResult Delete(int id)
        //        {
        //            (ExecutionState executionState, string message) CheckDataExistOrNot = _ForestCircleService.DoesExist(id);
        //            string message = "Failed, You can't delete this item.";

        //            if (CheckDataExistOrNot.executionState.ToString() != "Success")
        //            {
        //                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
        //            }

        //            (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Delete(id);
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
        //        public ActionResult Delete(int id, ForestCircleVM entity)
        //        {
        //            try
        //            {
        //                if (id != entity.Id)
        //                {
        //                    return RedirectToAction(nameof(this.Index), "Category");
        //                }
        //                entity.IsDeleted = true;
        //                entity.UpdatedAt = DateTime.Now;
        //                (ExecutionState executionState, ForestCircleVM entity, string message) returnResponse = _ForestCircleService.Update(entity);
        //////                Session["Message"] = returnResponse.message;
        ////                Session["executionState"] = returnResponse.executionState;
        //                return RedirectToAction("Index");
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }




        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetSavingsAccountListByPagination(JqueryDatatableParam param)
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

            var filter = AuthLocationHelper.GetFilterFromSession<SavingsAccountFilterVM>(HttpContext);
            filter.iDisplayStart = param.iDisplayStart;
            filter.iDisplayLength = param.iDisplayLength;
            filter.sSearch = param.sSearch;

            (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);

            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.PhoneNumber = string.Empty;
            ViewBag.NID = string.Empty;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");



            foreach (var item in returnResponse.entity.aaData)
            {
                if (item?.SavingsAmountInformations?.Count() > 0)
                {
                    item.TotalSavingsAmount = Convert.ToDouble(item.SavingsAmountInformations.Sum(x => x.SavingsAmount));
                }

                if (item?.WithdrawAmountInformations?.Count() > 0)
                {
                    item.TotalWithdrawalAmount = Convert.ToDouble(item?.WithdrawAmountInformations?.Where(x => x.DfoStatusId != 3).Sum(x => x.WithdrawAmount));
                }

                var saving = item.SavingsAmountInformations?.Select(x => x.SavingsAmount).Sum();
                var withdraw = item.WithdrawAmountInformations?.Where(x => x.DfoStatusId != 3).Select(x => x.WithdrawAmount).Sum();
                var totalAccountBalance = saving - withdraw;

                item.TotalAccountBalance = totalAccountBalance;
            }



            return Json(new
            {
                param.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            //return View(new List<CommunityTrainingVM>());
        }



        [HttpPost]
        public ActionResult IndexFilterSavingsAccountListByPagination(SavingsAccountFilterVM filter)
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


            (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse = _SavingsAccountService.GetByFilter(filter);
            //Extra Filter
            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name", filter.Gender.HasValue ? (int)filter.Gender! : null);
            ViewBag.PhoneNumber = filter.PhoneNumber;
            ViewBag.NID = filter.NID;
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name", filter.NgoId);



            foreach (var item in returnResponse.entity.aaData)
            {
                if (item?.SavingsAmountInformations?.Count() > 0)
                {
                    item.TotalSavingsAmount = Convert.ToDouble(item.SavingsAmountInformations.Sum(x => x.SavingsAmount));
                }

                if (item?.WithdrawAmountInformations?.Count() > 0)
                {
                    item.TotalWithdrawalAmount = Convert.ToDouble(item?.WithdrawAmountInformations?.Where(x => x.DfoStatusId != 3).Sum(x => x.WithdrawAmount));
                }

                var saving = item?.SavingsAmountInformations?.Select(x => x.SavingsAmount).Sum() ?? 0;
                var withdraw = item?.WithdrawAmountInformations?.Where(x => x.DfoStatusId != 3).Select(x => x.WithdrawAmount).Sum() ?? 0;
                var totalAccountBalance = saving - withdraw;

                item.TotalAccountBalance = totalAccountBalance;
            }



            return Json(new
            {
                filter.sEcho,
                iTotalRecords = returnResponse.entity.iTotalRecords,
                iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
                aaData = returnResponse.entity.aaData
            }, SerializerOption.Default);

            // return View("Index", result.entity);
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
public class myData
{
    public long? id { get; set; }
    public string? dfoRemark { get; set; }
}