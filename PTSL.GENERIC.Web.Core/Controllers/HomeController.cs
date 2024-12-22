using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.DashBoard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Dashboard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.GeneralSetup;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.TransactionMangement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Implementation.TransactionMangement;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.Dashboard;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.TransactionMangement;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Services.Implementation.MeetingManagement;

namespace PTSL.GENERIC.Web.Core.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private readonly IPmsGroupService _PmsGroupService;
        private readonly IAccessMapperService _AccessMapperService;
        private readonly IAccesslistService _AccesslistService;
        private readonly IModuleService _ModuleService;
        private readonly IUserService _UserService;
        private readonly IMeetingService _MeetingService;
        private readonly IUserRoleService _userRoleService;

        private readonly ISurveyService _surveyService;
        private readonly ICommunityTrainingService _CommunityTrainingService;
        private readonly IFinancialYearService _financialYearService;
        private readonly ITransactionService _transactionService;

        private readonly IDashboardService _DashboardService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        public HomeController(HttpHelper httpHelper)
        {
            _PmsGroupService = new PmsGroupService(httpHelper);
            _AccessMapperService = new AccessMapperService(httpHelper);
            _AccesslistService = new AccesslistService(httpHelper);
            _ModuleService = new ModuleService(httpHelper);
            _UserService = new UserService(httpHelper);
            _MeetingService = new MeetingService(httpHelper);
            _userRoleService = new UserRoleService(httpHelper);

            _surveyService = new SurveyService(httpHelper);
            _CommunityTrainingService = new CommunityTrainingService(httpHelper);
            _financialYearService = new FinancialYearService(httpHelper);

            _DashboardService = new DashboardService(httpHelper);
            _transactionService = new TransactionService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);
        }

        public IActionResult Index()
        {
            var financialYear = _financialYearService.List().entity ?? new List<FinancialYearVM>();
            ViewBag.FinancialYearId = new SelectList(financialYear, "Id", "Name", financialYear.FirstOrDefault(x => x.IsCurrent)?.Id);

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

            return View();
        }

        public JsonResult RootMenue()
        {
            var result = _userRoleService.CurrentUserRootMenu();

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult BeneficiaryIndex()
        {
            var surveyIdString = HttpContext.Session.GetString("SurveyId");
            long.TryParse(surveyIdString, out var surveyId);

            var result = _DashboardService.BeneficiaryDashboardData(surveyId);

            return View(result.entity);
        }

        public Menu PmsRootMenueList()
        {
            Menu menu = new Menu();
            try
            {

                List<CustomerAccessList> AllAccesslist = new List<CustomerAccessList>();

                List<MenueViewModel> menueList = new List<MenueViewModel>();

                List<int> AccesList = new List<int>();
                //var aspNetUser = UserManager.Users.ToList().Where(x => !x.IsRemoved && x.Id == User.Identity.GetUserId()).FirstOrDefault();
                long GroupID = 1;// Convert.ToInt32(aspNetUser.PmsGroupID);


                long.TryParse(HttpContext.Session.GetString("UserId"), out var LoggedInUser); // User.Identity.GetUserId();

                var loginUser = _UserService.GetById(LoggedInUser);
                var UserName = HttpContext.Session.GetString("UserEmail");// User.Identity.GetUserName();
                // var PmsGroupId = _PmsGroupService.GetById(GroupID);
                if (loginUser.entity != null)
                {
                    GroupID = loginUser.entity.PmsGroupID;
                }
                (ExecutionState executionState, PmsGroupVM entity, string message) returnPmsGroupResponse = _PmsGroupService.GetById(GroupID);

                //string GroupName = returnPmsGroupResponse.entity.GroupName;


                if (GroupID != 0)
                {
                    (ExecutionState executionState, AccessMapperVM entity, string message) returnAccessMapperVMResponse = _AccessMapperService.GetById(GroupID);

                    //var accessMapper = _AccessMapperService.GetById(GroupID);
                    string s = string.Empty;
                    if (returnAccessMapperVMResponse.entity != null && returnAccessMapperVMResponse.entity.AccessList != null)
                    {
                        s = returnAccessMapperVMResponse.entity.AccessList;
                    }
                    string[] values = s.Split(',');
                    foreach (var value in values)
                    {
                        AccesList.Add(Convert.ToInt32(value));
                    }
                    foreach (var item in AccesList)
                    {
                        try
                        {
                            //var access = _AccesslistService.GetById(item);
                            (ExecutionState executionState, AccesslistVM entity, string message) returnAccesslistResponse = _AccesslistService.GetById(item);

                            CustomerAccessList custom = new CustomerAccessList();

                            if (returnAccesslistResponse.entity != null && returnAccesslistResponse.entity.IsVisible == 0)
                            {
                                custom.AccessID = returnAccesslistResponse.entity.Id;
                                custom.AccessStatus = returnAccesslistResponse.entity.AccessStatus;
                                custom.ActionName = returnAccesslistResponse.entity.ActionName;
                                //custom.BaseModule = returnAccesslistResponse.entity.BaseModule;
                                custom.ControllerName = returnAccesslistResponse.entity.ControllerName;
                                custom.IconClass = returnAccesslistResponse.entity.IconClass;
                                custom.Mask = returnAccesslistResponse.entity.Mask;
                                custom.BaseModuleIndex = returnAccesslistResponse.entity.BaseModuleIndex;
                                AllAccesslist.Add(custom);
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    (ExecutionState executionState, List<ModuleVM> entity, string message) returnModuleVMResponse = _ModuleService.List();

                    var ModuleList = returnModuleVMResponse.entity.OrderBy(a => a.MenueOrder).ToList();
                    foreach (var item in ModuleList)
                    {
                        MenueViewModel menue = new MenueViewModel();
                        menue.ModuleID = item.Id;
                        menue.ModuleName = item.ModuleName;
                        menue.ModuleIcon = item.ModuleIcon;
                        var module = _ModuleService.GetById(item.Id);

                        if (module.entity.IsVisible == 0)
                        {
                            var menulist = AllAccesslist.Where(a => a.BaseModule == item.Id).OrderBy(a => a.BaseModuleIndex).ToList();
                            if (menulist.Count > 0)
                            {
                                menue.AccessList = menulist;
                                menueList.Add(menue);
                            }
                        }
                    }
                }
                menu.MenuList = menueList;
                menu.UserName = UserName;
                //menu.GroupName = GroupName;

                return menu;

            }
            catch (Exception ex)
            {
                //var formatter = RequestFormat.JsonFormaterString();
                //return Request.CreateResponse(HttpStatusCode.OK, new PayloadResponse { Success = false, Message = "200", Payload = null }, formatter);
                return menu;
            }
        }

        public ActionResult Map()
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

            return View();
        }

        public ActionResult TotalHouseholdWithPercentage(ForestCivilLocationFilter filter)
        {
            var result = _DashboardService.TotalHouseholdWithPercentage(filter);

            DashboardHouseholdVM dashboardHouseholdVM = new DashboardHouseholdVM();
            if (result.entity == null)
            {
                return Json(new List<DashboardHouseholdVM>(), SerializerOption.Default);
            }
            dashboardHouseholdVM.TotalHouseholdMember = result.entity.TotalHouseholdMember;
            dashboardHouseholdVM.HouseConditionPercentages = result.entity.HouseConditionPercentages;

            return Json(dashboardHouseholdVM, SerializerOption.Default);
        }

        public ActionResult GetLoanData(DashboardLoanRequest filter)
        {
            var result = _DashboardService.GetLoanData(filter);

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetTotalFcvVcfAndExecutiveSubExecutive(ForestCivilLocationFilter filter)
        {
            var (_, entity, _) = _DashboardService.GetTotalFcvVcfAndExecutiveSubExecutive(filter);

            return entity == null
                ? Json(new List<CommitteeMemberCount>(), SerializerOption.Default)
                : Json(entity, SerializerOption.Default);
        }

        public ActionResult GetTotalBeneficiary(ForestCivilLocationFilter filter)
        {
            var result = _DashboardService.GetTotalBeneficiary(filter);
            if (result.entity == null)
            {
                return Json(new BeneficiaryVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult LoanStatusOverview(ForestCivilLocationFilter filter)
        {
            var result = _DashboardService.LoanOverview(filter);
            if (result.entity == null)
            {
                return Json(new AIGLoanOverviewVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetEnergyUsesPercentage(ForestCivilLocationFilter filter)
        {
            var result = _DashboardService.GetEnergyUsesPercentage(filter);
            List<EnergyUsesPercentageVM> energyUsesPercentageVM = new List<EnergyUsesPercentageVM>();
            if (result.entity == null)
            {
                return Json(new List<EnergyUsesPercentageVM>(), SerializerOption.Default);
            }
            energyUsesPercentageVM.AddRange(result.entity);

            return Json(energyUsesPercentageVM, SerializerOption.Default);
        }

        public ActionResult GetCommunityTrainingList(CommunityTrainingFilterVM filter)
        {
            filter.iDisplayLength = 10;
            filter.iDisplayStart = 0;

            var result = _CommunityTrainingService.GetTrainingByFilter(filter);
            if (result.entity == null)
            {
                return Json(new List<CommunityTrainingVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetTotalExpenseTarget()
        {
            var result = _transactionService.DashboardData();
            if (result.entity == null)
            {
                return Json(new TransactionDashboardVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetMeetingByFilter(MeetingFilterVM filter)
        {
            var result = _MeetingService.GetMeetingByFilter(filter);
            if (result.entity == null)
            {
                return Json(new List<MeetingVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult TotalDashboardSavingsAmount(ForestCivilLocationFilter filter)
        {
            var result = _DashboardService.TotalDashboardSavingsAmount(filter);

            DashboardSavingsAmountVM dashboardSavingsAmountVM = new DashboardSavingsAmountVM();
            if (result.entity == null)
            {
                return Json(new List<DashboardHouseholdVM>(), SerializerOption.Default);
            }
            dashboardSavingsAmountVM.TotalSavingsAmount = result.entity.TotalSavingsAmount;

            return Json(dashboardSavingsAmountVM, SerializerOption.Default);
        }

        public ActionResult GetCIPDetails(ForestCivilLocationFilter filter)
        {
            var (executionState, entity, message) = _DashboardService.GetCIPDetails(filter);
            return Json(entity, SerializerOption.Default);
        }
    }
}
