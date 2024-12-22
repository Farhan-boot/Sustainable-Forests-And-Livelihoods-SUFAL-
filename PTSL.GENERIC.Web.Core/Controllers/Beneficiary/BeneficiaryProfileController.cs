using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Auth;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ApprovalLog;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Implementation.SystemUser;
using PTSL.GENERIC.Web.Core.Services.Interface.ApprovalLog;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.PermissionSettings;
using PTSL.GENERIC.Web.Core.Services.Interface.SystemUser;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Core.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class BeneficiaryProfileController : Controller
    {
        private readonly IEthnicityService _EthnicityService;
        private readonly INgoService _NgoService;
        private readonly ICipService _CipService;

        private readonly IDivisionService _DivisionService;
        private readonly IDistrictService _DistrictService;
        private readonly IUpazillaService _UpazillaService;
        private readonly IUnionService _UnionService;

        private readonly IForestCircleService _ForestCircleService;
        private readonly IForestDivisionService _ForestDivisionService;
        private readonly IForestRangeService _ForestRangeService;
        private readonly IForestBeatService _ForestBeatService;
        private readonly IForestFcvVcfService _ForestFcvVcfService;

        private readonly IRelationWithHeadHouseHoldTypeService _RelationWithHeadHouseHoldTypeService;
        private readonly IOccupationService _OccupationService;
        private readonly ISafetyNetService _SafetyNetService;
        private readonly IBFDAssociationService _BFDAssociationService;
        private readonly IDisabilityTypeService _DisabilityTypeService;
        private readonly IVulnerabilitySituationTypeService _VulnerabilitySituationTypeService;
        private readonly IFoodItemService _FoodItemService;
        private readonly IExpenditureTypeService _ExpenditureTypeService;
        private readonly ILiveStockTypeService _LiveStockTypeService;
        private readonly IAssetTypeService _AssetTypeService;
        private readonly IImmovableAssetTypeService _ImmovableAssetTypeService;
        private readonly IEnergyTypeService _EnergyTypeService;
        private readonly IManualIncomeSourceTypeService _ManualIncomeSourceTypeService;
        private readonly INaturalIncomeSourceTypeService _NaturalIncomeSourceTypeService;
        private readonly IOtherIncomeSourceTypeService _OtherIncomeSourceTypeService;
        private readonly IBusinessIncomeSourceTypeService _BusinessIncomeSourceTypeService;
        private readonly ITypeOfHouseService _TypeOfHouseService;

        private readonly ISurveyService _SurveyService;
        private readonly FileHelper _fileHelper;

        //Add Multi Permition Start
        private readonly IUserService _UserService;
        private readonly IPermissionHeaderSettingsService _PermissionHeaderSettingsService;
        private readonly IPermissionRowSettingsService _PermissionRowSettingsService;
        private readonly IApprovalLogForCfmService _ApprovalLogForCfmService;

        //Add Multi Permition End



        private static readonly JsonSerializerSettings jsonSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public BeneficiaryProfileController(HttpHelper httpHelper, FileHelper fileHelper)
        {
            _EthnicityService = new EthnicityService(httpHelper);
            _NgoService = new NgoService(httpHelper);
            _CipService = new CipService(httpHelper);

            _DivisionService = new DivisionService(httpHelper);
            _DistrictService = new DistrictService(httpHelper);
            _UpazillaService = new UpazillaService(httpHelper);
            _UnionService = new UnionService(httpHelper);

            _ForestCircleService = new ForestCircleService(httpHelper);
            _ForestDivisionService = new ForestDivisionService(httpHelper);
            _ForestRangeService = new ForestRangeService(httpHelper);
            _ForestBeatService = new ForestBeatService(httpHelper);
            _ForestFcvVcfService = new ForestFcvVcfService(httpHelper);

            _RelationWithHeadHouseHoldTypeService = new RelationWithHeadHouseHoldTypeService(httpHelper);
            _OccupationService = new OccupationService(httpHelper);
            _SafetyNetService = new SafetyNetService(httpHelper);
            _BFDAssociationService = new BFDAssociationService(httpHelper);
            _DisabilityTypeService = new DisabilityTypeService(httpHelper);
            _VulnerabilitySituationTypeService = new VulnerabilitySituationTypeService(httpHelper);
            _FoodItemService = new FoodItemService(httpHelper);
            _ExpenditureTypeService = new ExpenditureTypeService(httpHelper);
            _LiveStockTypeService = new LiveStockTypeService(httpHelper);
            _AssetTypeService = new AssetTypeService(httpHelper);
            _ImmovableAssetTypeService = new ImmovableAssetTypeService(httpHelper);
            _EnergyTypeService = new EnergyTypeService(httpHelper);
            _ManualIncomeSourceTypeService = new ManualIncomeSourceTypeService(httpHelper);
            _NaturalIncomeSourceTypeService = new NaturalIncomeSourceTypeService(httpHelper);
            _OtherIncomeSourceTypeService = new OtherIncomeSourceTypeService(httpHelper);
            _BusinessIncomeSourceTypeService = new BusinessIncomeSourceTypeService(httpHelper);
            _TypeOfHouseService = new TypeOfHouseService(httpHelper);

            _SurveyService = new SurveyService(httpHelper);
            _fileHelper = fileHelper;

            //Add Multi Permition Start
            _UserService = new UserService(httpHelper);
            _PermissionHeaderSettingsService = new PermissionHeaderSettingsService(httpHelper);
            _PermissionRowSettingsService = new PermissionRowSettingsService(httpHelper);
            _ApprovalLogForCfmService = new ApprovalLogForCfmService(httpHelper);


            //Add Multi Permition End

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

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

            var filter = AuthLocationHelper.GetSurveyFilterFromSession(HttpContext, 50);
            var surveyResponse = _SurveyService.GetBeneficiaryByFilter(new BeneficiaryFilterVM
            {
                GetPendingAlso = true,
                ForestCivilLocation = filter,
            });


            //Add Multi Permition Start

            var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
            var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

            var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

            var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 25).Select(x => x.Id).FirstOrDefault();
            var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
            //var userList = exceptMyInfoGetAllUser.Select(x => x.User);

            //if (userList != null)
            //{
            //    ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
            //}


            ////new
            string roleName = Convert.ToString(HttpContext.Session.GetString(SessionKey.RoleName));

            var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
            var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);

            if (roleList != null)
            {
                ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
            }


            ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");

            var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).Where(x => x.BeneficiaryProfileId != null).Any(x => x?.ReceiverRoleId == userRoleId);
            ViewBag.CheckIsApprove = checkIsApprove ?? false;

            //Add Multi Permition End


            return View(surveyResponse.entity.aaData ?? new List<SurveyEssentialVM>());
        }

        public ActionResult GetFilterData(BeneficiaryFilterVM filter)
        {
            var response = _SurveyService.GetBeneficiaryByFilter(filter);
            var surveyList = response.entity.aaData ?? new List<SurveyEssentialVM>();

            if (response.entity == null)
            {
                return Json(
                    new { Success = false, Message = response.message, Data = surveyList },
                    SerializerOption.Default);
            }

            return Json(
                new { Success = true, Message = "Successfully data loaded.", Data = surveyList },
                SerializerOption.Default);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            (ExecutionState executionState, SurveyVM entity, string message) surveyResult = _SurveyService.GetDetailsById(id ?? 0);
            (ExecutionState executionState, SurveyChildsVM? entity, string message) surveyChildResult = _SurveyService.LoadAllChilds(id ?? 0);

            if (surveyResult.entity == null)
            {
                surveyResult.entity = new SurveyVM();
            }
            else
            {
                if (surveyChildResult.entity == null) return View(surveyResult.entity);

                var child = surveyChildResult.entity;

                surveyResult.entity.HouseholdMembers = child.HouseholdMembers;
                surveyResult.entity.ExistingSkills = child.ExistingSkills;
                surveyResult.entity.AnnualHouseholdExpenditures = child.AnnualHouseholdExpenditures;
                surveyResult.entity.FoodSecurityItems = child.FoodSecurityItems;
                surveyResult.entity.VulnerabilitySituations = child.VulnerabilitySituations;

                surveyResult.entity.GrossMarginIncomeAndCostStatuses = child.GrossMarginIncomeAndCosts;
                surveyResult.entity.ManualPhysicalWorks = child.ManualPhysicalWorks;
                surveyResult.entity.NaturalResourcesIncomeAndCostStatuses = child.NaturalResourcesIncomeAndCosts;
                surveyResult.entity.OtherIncomeSources = child.OtherIncomeSources;
                surveyResult.entity.Businesses = child.Businesses;

                surveyResult.entity.LandOccupancy = child.LandOccupancies;
                surveyResult.entity.LiveStocks = child.LiveStocks;
                surveyResult.entity.Assets = child.Assets;
                surveyResult.entity.ImmovableAssets = child.ImmovableAssets;
                surveyResult.entity.EnergyUses = child.EnergyUses;
            }

            return View(surveyResult.entity);
        }

        public ActionResult Create()
        {
            SurveyVM entity = new SurveyVM();

            CommonViewBagForCreateEdit();

            return View("CreateEdit", entity);
        }

        [HttpPost]
        public ActionResult Create(SurveyVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.CreatedAt = DateTime.Now;
                entity.BeneficiaryApproveStatus = BeneficiaryApproveStatus.Pending;

                // Files
                if (SaveFiles(HttpContext.Request.Form.Files, entity, out var fileError) == false)
                {
                    return Json(
                        new { Success = false, Message = fileError },
                        SerializerOption.Default);
                }

                // Json Deserialize
                try
                {
                    entity.HouseholdMembers = JsonConvert.DeserializeObject<List<HouseholdMemberVM>>(entity.HouseholdMembersJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.LandOccupancy = JsonConvert.DeserializeObject<List<LandOccupancyVM>>(entity.LandOccupancyJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.LiveStocks = JsonConvert.DeserializeObject<List<LiveStockVM>>(entity.LiveStocksJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.Assets = JsonConvert.DeserializeObject<List<AssetVM>>(entity.AssetsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ImmovableAssets = JsonConvert.DeserializeObject<List<ImmovableAssetVM>>(entity.ImmovableAssetsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.EnergyUses = JsonConvert.DeserializeObject<List<EnergyUseVM>>(entity.EnergyUsesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ExistingSkills = JsonConvert.DeserializeObject<List<ExistingSkillVM>>(entity.ExistingSkillsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.GrossMarginIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<GrossMarginIncomeAndCostStatusVM>>(entity.GrossMarginIncomeAndCostStatusesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ManualPhysicalWorks = JsonConvert.DeserializeObject<List<ManualPhysicalWorkVM>>(entity.ManualPhysicalWorksJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.NaturalResourcesIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<NaturalResourcesIncomeAndCostStatusVM>>(entity.NaturalResourcesIncomeAndCostStatusesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.OtherIncomeSources = JsonConvert.DeserializeObject<List<OtherIncomeSourceVM>>(entity.OtherIncomeSourcesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.Businesses = JsonConvert.DeserializeObject<List<BusinessVM>>(entity.BusinessesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.AnnualHouseholdExpenditures = JsonConvert.DeserializeObject<List<AnnualHouseholdExpenditureVM>>(entity.AnnualHouseholdExpendituresJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.FoodSecurityItems = JsonConvert.DeserializeObject<List<FoodSecurityItemVM>>(entity.FoodSecurityItemsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.VulnerabilitySituations = JsonConvert.DeserializeObject<List<VulnerabilitySituationVM>>(entity.VulnerabilitySituationsJSON ?? string.Empty);
                }
                catch (Exception) { }

                (ExecutionState executionState, SurveyVM entity, string message) returnResponse = _SurveyService.Create(entity);

                ////				//Session["Message"] = returnResponse.message;
                //				//Session["executionState"] = returnResponse.executionState;

                if (returnResponse.executionState.ToString() == "Created")
                {
                    var urlRedirect = Url.Action("Index", "BeneficiaryProfile");

                    HttpContext.Session.SetString("Message", "Beneficiary information has been created successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    // created
                    return Json(
                        new { Success = true, Message = "Successfully created Beneficiary.", RedirectUrl = urlRedirect },
                        SerializerOption.Default);
                }

                // not created
                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
            }
            catch
            {
                const string message = "Unknown error occured.";

                ////                //Session["Message"] = message;
                //                //Session["executionState"] = ExecutionState.Failure;

                return Json(
                    new { Success = false, Message = message },
                    SerializerOption.Default);
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surveyResponse = _SurveyService.GetById(id);

            CommonViewBagForCreateEdit(surveyResponse.entity);

            return View("CreateEdit", surveyResponse.entity);
        }

        [HttpPost]
        public ActionResult Edit(SurveyVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.UpdatedAt = DateTime.Now;

                // Files
                SaveFiles(HttpContext.Request.Form.Files, entity, out var fileError, true);
                if (string.IsNullOrEmpty(fileError) == false)
                {
                    return Json(
                        new { Success = false, Message = fileError },
                        SerializerOption.Default);
                }

                // Json Deserialize
                try
                {
                    entity.HouseholdMembers = JsonConvert.DeserializeObject<List<HouseholdMemberVM>>(entity.HouseholdMembersJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.LandOccupancy = JsonConvert.DeserializeObject<List<LandOccupancyVM>>(entity.LandOccupancyJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.LiveStocks = JsonConvert.DeserializeObject<List<LiveStockVM>>(entity.LiveStocksJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.Assets = JsonConvert.DeserializeObject<List<AssetVM>>(entity.AssetsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ImmovableAssets = JsonConvert.DeserializeObject<List<ImmovableAssetVM>>(entity.ImmovableAssetsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.EnergyUses = JsonConvert.DeserializeObject<List<EnergyUseVM>>(entity.EnergyUsesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ExistingSkills = JsonConvert.DeserializeObject<List<ExistingSkillVM>>(entity.ExistingSkillsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.GrossMarginIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<GrossMarginIncomeAndCostStatusVM>>(entity.GrossMarginIncomeAndCostStatusesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.ManualPhysicalWorks = JsonConvert.DeserializeObject<List<ManualPhysicalWorkVM>>(entity.ManualPhysicalWorksJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.NaturalResourcesIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<NaturalResourcesIncomeAndCostStatusVM>>(entity.NaturalResourcesIncomeAndCostStatusesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.OtherIncomeSources = JsonConvert.DeserializeObject<List<OtherIncomeSourceVM>>(entity.OtherIncomeSourcesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.Businesses = JsonConvert.DeserializeObject<List<BusinessVM>>(entity.BusinessesJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.AnnualHouseholdExpenditures = JsonConvert.DeserializeObject<List<AnnualHouseholdExpenditureVM>>(entity.AnnualHouseholdExpendituresJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.FoodSecurityItems = JsonConvert.DeserializeObject<List<FoodSecurityItemVM>>(entity.FoodSecurityItemsJSON ?? string.Empty);
                }
                catch (Exception) { }
                try
                {
                    entity.VulnerabilitySituations = JsonConvert.DeserializeObject<List<VulnerabilitySituationVM>>(entity.VulnerabilitySituationsJSON ?? string.Empty);
                }
                catch (Exception) { }

                // For deletion
                entity.DeletedHouseholdMembers = JsonConvert.DeserializeObject<List<long>>(entity.DeletedHouseholdMembersJSON ?? string.Empty);
                entity.DeletedLandOccupancy = JsonConvert.DeserializeObject<List<long>>(entity.DeletedLandOccupancyJSON ?? string.Empty);
                entity.DeletedLiveStocks = JsonConvert.DeserializeObject<List<long>>(entity.DeletedLiveStocksJSON ?? string.Empty);
                entity.DeletedAssets = JsonConvert.DeserializeObject<List<long>>(entity.DeletedAssetsJSON ?? string.Empty);
                entity.DeletedImmovableAssets = JsonConvert.DeserializeObject<List<long>>(entity.DeletedImmovableAssetsJSON ?? string.Empty);
                entity.DeletedEnergyUses = JsonConvert.DeserializeObject<List<long>>(entity.DeletedEnergyUsesJSON ?? string.Empty);
                entity.DeletedExistingSkills = JsonConvert.DeserializeObject<List<long>>(entity.DeletedExistingSkillsJSON ?? string.Empty);
                entity.DeletedGrossMarginIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<long>>(entity.DeletedGrossMarginIncomeAndCostStatusesJSON ?? string.Empty);
                entity.DeletedManualPhysicalWorks = JsonConvert.DeserializeObject<List<long>>(entity.DeletedManualPhysicalWorksJSON ?? string.Empty);
                entity.DeletedNaturalResourcesIncomeAndCostStatuses = JsonConvert.DeserializeObject<List<long>>(entity.DeletedNaturalResourcesIncomeAndCostStatusesJSON ?? string.Empty);
                entity.DeletedOtherIncomeSources = JsonConvert.DeserializeObject<List<long>>(entity.DeletedOtherIncomeSourcesJSON ?? string.Empty);
                entity.DeletedBusinesses = JsonConvert.DeserializeObject<List<long>>(entity.DeletedBusinessesJSON ?? string.Empty);
                entity.DeletedAnnualHouseholdExpenditures = JsonConvert.DeserializeObject<List<long>>(entity.DeletedAnnualHouseholdExpendituresJSON ?? string.Empty);
                entity.DeletedFoodSecurityItems = JsonConvert.DeserializeObject<List<long>>(entity.DeletedFoodSecurityItemsJSON ?? string.Empty);
                entity.DeletedVulnerabilitySituations = JsonConvert.DeserializeObject<List<long>>(entity.DeletedVulnerabilitySituationsJSON ?? string.Empty);

                (ExecutionState executionState, SurveyVM entity, string message) returnResponse = _SurveyService.Update(entity);

                ////				//Session["Message"] = returnResponse.message;
                //				//Session["executionState"] = returnResponse.executionState;

                if (returnResponse.executionState.ToString() == "Updated")
                {
                    var urlRedirect = Url.Action("Index", "BeneficiaryProfile");

                    HttpContext.Session.SetString("Message", "Beneficiary information has been updated successfully");
                    HttpContext.Session.SetString("executionState", returnResponse.executionState.ToString());

                    // updated
                    return Json(
                        new { Success = true, Message = "Successfully updated Beneficiary.", RedirectUrl = urlRedirect },
                        SerializerOption.Default);
                }

                // not updated
                return Json(
                    new { Success = false, Message = returnResponse.message },
                    SerializerOption.Default);
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
            (ExecutionState executionState, string message) CheckDataExistOrNot = _SurveyService.DoesExist(id);
            string message = "Failed, You can't delete this item.";

            if (CheckDataExistOrNot.executionState.ToString() != "Success")
            {
                return Json(new { Message = message, CheckDataExistOrNot.executionState }, SerializerOption.Default);
            }

            (ExecutionState executionState, SurveyVM entity, string message) returnResponse = _SurveyService.Delete(id);
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
        public ActionResult Delete(int id, SurveyVM entity)
        {
            try
            {
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(this.Index), "BeneficiaryProfile");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, SurveyVM entity, string message) returnResponse = _SurveyService.Update(entity);
                ////                //Session["Message"] = returnResponse.message;
                //                //Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void CommonViewBagForCreateEdit(SurveyVM? survey = null)
        {
            var emptySelectList = new SelectList("");
            var forestCircleResponse = _ForestCircleService.List().entity?.OrderBy(x => x.Name).ToList();

            var genderEnumList = EnumHelper.GetEnumDropdowns<Gender>();
            var genderEnumSelectList = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");

            var divisionResponse = _DivisionService.List().entity?.OrderBy(x => x.Name).ToList();
            var ethnicityResponse = _EthnicityService.List().entity?.OrderBy(x => x.Name).ToList();

            var forestDependencyEnumList = EnumHelper.GetEnumDropdowns<ForestDependency>();
            var satisfactionLevelEnumList = EnumHelper.GetEnumDropdowns<SatisfactionLevel>();
            var genderMfEnumList = EnumHelper.GetEnumDropdowns<GenderMf>();
            var houseTypeEnumList = EnumHelper.GetEnumDropdowns<HouseType>();
            var educationalInstituteAccessibilityEnumList = EnumHelper.GetEnumDropdowns<EducationalInstituteAccessibility>();
            var sanitationFacilitiesEnumList = EnumHelper.GetEnumDropdowns<SanitationFacilities>();
            var foodConditionEnumList = EnumHelper.GetEnumDropdowns<FoodCondition>();
            var familyMemberTypeEnumList = EnumHelper.GetEnumDropdowns<FamilyMemberType>();
            var ngoList = _NgoService.List().entity?.OrderBy(x => x.Name).ToList() ?? new List<NgoVM>();
            var typeOfHouseList = _TypeOfHouseService.List().entity?.OrderBy(x => x.Name).ToList() ?? new List<TypeOfHouseVM>();
            var recipientStatusEnumList = EnumHelper.GetEnumDropdowns<RecipientStatus>();

            ViewBag.ForestCircleId = new SelectList(forestCircleResponse ?? new List<ForestCircleVM>(), "Id", "Name");
            ViewBag.ForestDivisionId = emptySelectList;
            ViewBag.ForestRangeId = emptySelectList;
            ViewBag.ForestBeatId = emptySelectList;
            ViewBag.ForestFcvVcfId = emptySelectList;
            ViewBag.CipId = emptySelectList;
            ViewBag.NgoId = new SelectList(ngoList, "Id", "Name");

            ViewBag.BeneficiaryGender = genderEnumSelectList;
            ViewBag.BeneficiaryEthnicityId = new SelectList(ethnicityResponse ?? new List<EthnicityVM>(), "Id", "Name");
            ViewBag.HeadOfHouseholdGender = genderEnumSelectList;

            ViewBag.PresentDivisionId = new SelectList(divisionResponse ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.PresentDistrictId = emptySelectList;
            ViewBag.PresentUpazillaId = emptySelectList;
            ViewBag.PresentUnionNewId = emptySelectList;

            ViewBag.PermanentDivisionId = new SelectList(divisionResponse ?? new List<DivisionVM>(), "Id", "Name");
            ViewBag.PermanentDistrictId = emptySelectList;
            ViewBag.PermanentUpazillaId = emptySelectList;
            ViewBag.PermanentUnionNewId = emptySelectList;

            ViewBag.ForestMngmtSatisfactionEnum = new SelectList(satisfactionLevelEnumList, "Id", "Name");
            ViewBag.ForestMngmtEffectivenessEnum = new SelectList(satisfactionLevelEnumList, "Id", "Name");
            ViewBag.ForestDependencyEnum = new SelectList(forestDependencyEnumList, "Id", "Name");
            ViewBag.SourceofDrySeasonWaterEnumList = EnumHelper.GetEnumDropdowns<DrinkingWaterResource>();
            ViewBag.SourceofWetSeasonWaterEnumList = EnumHelper.GetEnumDropdowns<DrinkingWaterResource>();

            // GenderMf
            ViewBag.DicisionTakerEnum = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.ProductiveAssetsOwnerGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.CropTypeDecisionGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.DecisionToTransferAssetsGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.FamilyNeedsDeciderGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.AccessorToCreditGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.ControllerOfCreditGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.OfficeBearerGender = new SelectList(genderMfEnumList, "Id", "Name");
            ViewBag.MorePaymentGetterGender = new SelectList(genderMfEnumList, "Id", "Name");

            ViewBag.BeneficiaryHouseType = new SelectList(houseTypeEnumList, "Id", "Name");
            ViewBag.EducationalInstituteAccessibilityEnum = new SelectList(educationalInstituteAccessibilityEnumList, "Id", "Name");
            ViewBag.SanitationFacilitiesEnum = new SelectList(sanitationFacilitiesEnumList, "Id", "Name");
            ViewBag.HouseholdFoodCondition = new SelectList(foodConditionEnumList, "Id", "Name");
            ViewBag.FoodyPersonInFoodCrisis = new SelectList(familyMemberTypeEnumList, "Id", "Name");
            ViewBag.TypeOfHouseId = new SelectList(typeOfHouseList, "Id", "Name", survey?.TypeOfHouseId ?? 0);
            ViewBag.RecipientStatus = new SelectList(
                recipientStatusEnumList,
                "Id",
                "Name",
                survey is null ? 0 : survey.RecipientStatus is RecipientStatus recipient ? (int)recipient : 0);

            if (survey != null)
            {
                var forestDivisionResponse = _ForestDivisionService.ListByForestCircle(survey.ForestCircleId).entity?.OrderBy(x => x.Name).ToList();
                var forestRangeResponse = _ForestRangeService.ListByForestDivision(survey.ForestDivisionId).entity?.OrderBy(x => x.Name).ToList();
                var forestBeatResponse = _ForestBeatService.ListByForestRange(survey.ForestRangeId).entity?.OrderBy(x => x.Name).ToList();
                var forestFcvVcfResponse = _ForestFcvVcfService.ListByForestBeat(survey.ForestBeatId).entity?.OrderBy(x => x.Name).ToList();

                ViewBag.ForestCircleId = new SelectList(forestCircleResponse ?? new List<ForestCircleVM>(), "Id", "Name", survey.ForestCircleId);
                ViewBag.ForestDivisionId =
                    new SelectList(forestDivisionResponse ?? new List<ForestDivisionVM>(), "Id", "Name", survey.ForestDivisionId);
                ViewBag.ForestRangeId =
                    new SelectList(forestRangeResponse ?? new List<ForestRangeVM>(), "Id", "Name", survey.ForestRangeId);
                ViewBag.ForestBeatId =
                    new SelectList(forestBeatResponse ?? new List<ForestBeatVM>(), "Id", "Name", survey.ForestBeatId);
                ViewBag.ForestFcvVcfId =
                    new SelectList(forestFcvVcfResponse ?? new List<ForestFcvVcfVM>(), "Id", "Name", survey.ForestFcvVcfId);
                ViewBag.NgoId = new SelectList(ngoList, "Id", "Name", survey.NgoId ?? 0);

                if (survey.CipId is not null)
                {
                    var cip = _CipService.GetById(survey.CipId).entity ?? new CipVM();
                    cip.BeneficiaryName = $"{cip.BeneficiaryName} - {cip.NID}";

                    ViewBag.CipId = new SelectList(new List<CipVM>() { cip }, "Id", "BeneficiaryName", survey.CipId);
                }

                var presentDistrictResponse = _DistrictService.ListByDivision(survey.PresentDivisionId).entity?.OrderBy(x => x.Name).ToList();
                var presentUpazillaResponse = _UpazillaService.ListByDistrict(survey.PresentDistrictId).entity?.OrderBy(x => x.Name).ToList();

                ViewBag.PresentDivisionId =
                    new SelectList(divisionResponse ?? new List<DivisionVM>(), "Id", "Name", survey.PresentDivisionId);
                ViewBag.PresentDistrictId =
                    new SelectList(presentDistrictResponse ?? new List<DistrictVM>(), "Id", "Name", survey.PresentDistrictId);
                ViewBag.PresentUpazillaId =
                    new SelectList(presentUpazillaResponse ?? new List<UpazillaVM>(), "Id", "Name", survey.PresentUpazillaId);
                ViewBag.PresentUnionNewId = new SelectList(_UnionService.ListByUpazilla(survey.PresentUpazillaId).entity ?? new List<UnionVM>(), "Id", "Name", survey.PresentUnionNewId);

                ViewBag.PermanentDivisionId = new SelectList(divisionResponse ?? new List<DivisionVM>(), "Id", "Name", survey.PermanentDivisionId);
                if (survey.PermanentDivisionId != null && survey.PermanentDivisionId > 0)
                {
                    var permanentDistrictResponse = _DistrictService.ListByDivision((long)survey.PermanentDivisionId);
                    ViewBag.PermanentDistrictId = new SelectList(permanentDistrictResponse.entity ?? new List<DistrictVM>(), "Id", "Name", survey.PermanentDistrictId);
                }
                if (survey.PermanentDistrictId != null && survey.PermanentDistrictId > 0)
                {
                    var permanentUpazillaResponse = _UpazillaService.ListByDistrict((long)survey.PermanentDistrictId);
                    ViewBag.PermanentUpazillaId = new SelectList(permanentUpazillaResponse.entity ?? new List<UpazillaVM>(), "Id", "Name", survey.PermanentUpazillaId);
                }
                if (survey.PermanentUpazillaId != null && survey.PermanentUpazillaId > 0)
                {
                    var permanentUnionResponse = _UnionService.ListByUpazilla((long)survey.PermanentUpazillaId);
                    ViewBag.PermanentUnionNewId = new SelectList(permanentUnionResponse.entity ?? new List<UnionVM>(), "Id", "Name", survey.PermanentUnionNewId);
                }

                ViewBag.BeneficiaryGender = new SelectList(genderEnumList, "Id", "Name", (int)survey.BeneficiaryGender);
                if (survey.BeneficiaryEthnicityId != null && survey.BeneficiaryEthnicityId > 0)
                {
                    ViewBag.BeneficiaryEthnicityId =
                        new SelectList(ethnicityResponse ?? new List<EthnicityVM>(), "Id", "Name", survey.BeneficiaryEthnicityId);
                }
                if (survey.HeadOfHouseholdGender != null && survey.HeadOfHouseholdGender > 0)
                {
                    ViewBag.HeadOfHouseholdGender = new SelectList(genderEnumList, "Id", "Name", (int)survey.HeadOfHouseholdGender);
                }

                ViewBag.ForestMngmtSatisfactionEnum = new SelectList(satisfactionLevelEnumList, "Id", "Name", (int)survey.ForestMngmtSatisfactionEnum);
                ViewBag.ForestMngmtEffectivenessEnum = new SelectList(satisfactionLevelEnumList, "Id", "Name", (int)survey.ForestMngmtEffectivenessEnum);
                ViewBag.ForestDependencyEnum = new SelectList(forestDependencyEnumList, "Id", "Name", (int)survey.ForestDependencyEnum);

                // GenderMf
                ViewBag.DicisionTakerEnum = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.DicisionTakerEnum);
                ViewBag.ProductiveAssetsOwnerGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.ProductiveAssetsOwnerGender);
                ViewBag.CropTypeDecisionGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.CropTypeDecisionGender);
                ViewBag.DecisionToTransferAssetsGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.DecisionToTransferAssetsGender);
                ViewBag.FamilyNeedsDeciderGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.FamilyNeedsDeciderGender);
                ViewBag.AccessorToCreditGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.AccessorToCreditGender);
                ViewBag.ControllerOfCreditGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.ControllerOfCreditGender);
                ViewBag.OfficeBearerGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.OfficeBearerGender);
                ViewBag.MorePaymentGetterGender = new SelectList(genderMfEnumList, "Id", "Name", (int)survey.MorePaymentGetterGender);

                ViewBag.BeneficiaryHouseType = new SelectList(houseTypeEnumList, "Id", "Name", (int)survey.BeneficiaryHouseType);
                ViewBag.EducationalInstituteAccessibilityEnum = new SelectList(educationalInstituteAccessibilityEnumList, "Id", "Name", (int)survey.EducationalInstituteAccessibilityEnum);
                ViewBag.SanitationFacilitiesEnum = new SelectList(sanitationFacilitiesEnumList, "Id", "Name", (int)survey.SanitationFacilitiesEnum);

                if (survey.HouseholdFoodCondition != null) ViewBag.HouseholdFoodCondition = new SelectList(foodConditionEnumList, "Id", "Name", (int)survey.HouseholdFoodCondition);
                if (survey.FoodyPersonInFoodCrisis != null) ViewBag.FoodyPersonInFoodCrisis = new SelectList(familyMemberTypeEnumList, "Id", "Name", (int)survey.FoodyPersonInFoodCrisis);
            }
        }

        private bool SaveFiles(IFormFileCollection files, SurveyVM entity, out string error, bool isUpdating = false)
        {
            // Profile Pic
            var beneficiaryProfile = files
                .Where(x => x.Name == "BeneficiaryProfileImage")
                .FirstOrDefault();
            if (beneficiaryProfile != null && beneficiaryProfile.Length > 0)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiaryProfile, FileType.Image, "BeneficiaryProfile", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                entity.BeneficiaryProfileURL = fileUrl;
            }

            // Beneficiary Front NID
            var beneficiaryFrontNID = files
                .Where(x => x.Name == "BeneficiaryNIDFrontURL")
                .FirstOrDefault();
            if (beneficiaryFrontNID != null && beneficiaryFrontNID.Length > 0)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiaryFrontNID, FileType.Image, "BeneficiaryNID", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                entity.BeneficiaryNIDFrontURL = fileUrl;
            }
            else
            {
                if (isUpdating == false)
                {
                    error = "Beneficiary NID Front image is required";
                    return false;
                }
            }

            // Beneficiary Back NID
            var beneficiaryBackNID = files
                .Where(x => x.Name == "BeneficiaryNIDBackURL")
                .FirstOrDefault();
            if (beneficiaryBackNID != null && beneficiaryBackNID.Length > 0)
            {
                var (isSaved, fileUrl, _) = _fileHelper.SaveFile(beneficiaryBackNID, FileType.Image, "BeneficiaryNID", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                entity.BeneficiaryNIDBackURL = fileUrl;
            }
            else
            {
                if (isUpdating == false)
                {
                    error = "Beneficiary NID Back image is required";
                    return false;
                }
            }

            // Documents
            var beneficiaryDocuments = files.GetFiles("SurveyDocuments[]");
            entity.SurveyDocuments = new List<SurveyDocumentVM>();
            if (beneficiaryDocuments != null && beneficiaryDocuments.Count > 0)
            {
                foreach (var doc in beneficiaryDocuments)
                {
                    var (isSaved, fileUrl, fileName) = _fileHelper.SaveFile(doc, FileType.Document, "beneficiaryDocument", out var errorMessage);
                    if (isSaved == false)
                    {
                        error = errorMessage;
                        return false;
                    }

                    entity.SurveyDocuments.Add(new SurveyDocumentVM
                    {
                        DocumentName = fileName,
                        DocumentNameURL = fileUrl,
                    });
                }
            }

            // -- Save BeneficiaryHouseFrontImage -- Start
            {
                var beneficiaryHouseFrontImage = files
                    .Where(x => x.Name == nameof(entity.BeneficiaryHouseFrontImage))
                    .FirstOrDefault();
                if (isUpdating == false && (beneficiaryHouseFrontImage == null || beneficiaryHouseFrontImage.Length < 1))
                {
                    error = "Beneficiary house front image is required.";
                    return false;
                }

                if (beneficiaryHouseFrontImage != null)
                {
                    var (isSaved, fileName, _) = _fileHelper.SaveFile(beneficiaryHouseFrontImage, FileType.Image, "BeneficiaryHouseFrontImage", out var errorMessage);
                    if (isSaved == false)
                    {
                        error = errorMessage;
                        return false;
                    }

                    entity.BeneficiaryHouseFrontImageURL = fileName;
                }
            }
            // -- Save BeneficiaryHouseFrontImage -- End

            // -- Save NotesImage -- Start
            var notesImage = files
                .Where(x => x.Name == nameof(entity.NotesImage))
                .FirstOrDefault();
            if (notesImage != null && notesImage.Length > 0)
            {
                var (isSaved, fileName, _) = _fileHelper.SaveFile(notesImage, FileType.Image, "BeneficiaryNotesImage", out var errorMessage);
                if (isSaved == false)
                {
                    error = errorMessage;
                    return false;
                }

                entity.NotesImageUrl = fileName;
            }
            // -- Save NotesImage -- End

            error = string.Empty;
            return true;
        }

        // Partial Related
        public ActionResult LoadHouseholdMemberBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadMembers(surveyId);
            var householdMembers = new List<HouseholdMemberVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                householdMembers.Add(new HouseholdMemberVM());
            }
            else
            {
                householdMembers = result.entity;
            }

            var occupation = _OccupationService.List().entity;

            ViewBag.RelationWithHeadHouseHoldTypeId = _RelationWithHeadHouseHoldTypeService.List().entity ?? new List<RelationWithHeadHouseHoldTypeVM>();

            ViewBag.Gender = EnumHelper.GetEnumDropdowns<Gender>();
            ViewBag.MaritalSatus = EnumHelper.GetEnumDropdowns<MaritalStatus>();
            ViewBag.EducationLevel = EnumHelper.GetEnumDropdowns<EducationLevel>();

            ViewBag.MainOccupationId = occupation ?? new List<OccupationVM>();
            ViewBag.SecondaryOccupationId = occupation ?? new List<OccupationVM>();

            ViewBag.SafetyNetTypeId = _SafetyNetService.List().entity ?? new List<SafetyNetVM>();
            ViewBag.BFDAssociationHouseholdMembers = _BFDAssociationService.List().entity ?? new List<BFDAssociationVM>();
            ViewBag.DisabilityTypeHouseholdMembers = _DisabilityTypeService.List().entity ?? new List<DisabilityTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_HouseholdMemberBase.cshtml", householdMembers);
        }

        public ActionResult LoadAnnualHouseholdExpenditureBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadAnnualHouseholdExpenditure(surveyId);
            var lists = new List<AnnualHouseholdExpenditureVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new AnnualHouseholdExpenditureVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.ExpenditureTypeId = _ExpenditureTypeService.List().entity ?? new List<ExpenditureTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_AnnualHouseholdExpenditureBase.cshtml", lists);
        }

        public ActionResult LoadExistingSkillBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadExistingSkill(surveyId);
            var lists = new List<ExistingSkillVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new ExistingSkillVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.SkillLevelEnum = EnumHelper.GetEnumDropdowns<SkillLevel>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_ExistingSkillBase.cshtml", lists);
        }

        public ActionResult LoadFoodSecurityBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadFoodSecurityItem(surveyId);
            var lists = new List<FoodSecurityItemVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new FoodSecurityItemVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.FoodItemId = _FoodItemService.List().entity ?? new List<FoodItemVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_FoodSecurityBase.cshtml", lists);
        }

        public ActionResult LoadVulnerabilitySituationBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadVulnerabilitySituation(surveyId);
            var lists = new List<VulnerabilitySituationVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new VulnerabilitySituationVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.VulnerabilitySituationTypeId = _VulnerabilitySituationTypeService.List().entity ?? new List<VulnerabilitySituationTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_VulnerabilitySituationBase.cshtml", lists);
        }

        public ActionResult LoadLandOccupancyBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadLandOccupancy(surveyId);
            var lists = new List<LandOccupancyVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new LandOccupancyVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.LandClassificationEnum = EnumHelper.GetEnumDropdowns<LandClassification>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_LandOccupancyBase.cshtml", lists);
        }

        public ActionResult LoadLivestockBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadLiveStock(surveyId);
            var lists = new List<LiveStockVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new LiveStockVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.LiveStockTypeId = _LiveStockTypeService.List().entity ?? new List<LiveStockTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_LivestockBase.cshtml", lists);
        }

        public ActionResult LoadAssetBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadAsset(surveyId);
            var lists = new List<AssetVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new AssetVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.AssetTypeId = _AssetTypeService.List().entity ?? new List<AssetTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_AssetBase.cshtml", lists);
        }

        public ActionResult LoadImmovableAssetBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadImmovableAsset(surveyId);
            var lists = new List<ImmovableAssetVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new ImmovableAssetVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.ImmovableAssetTypeId = _ImmovableAssetTypeService.List().entity ?? new List<ImmovableAssetTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_ImmovableAssetBase.cshtml", lists);
        }

        public ActionResult LoadEnergyUseBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadEnergyUse(surveyId);
            var lists = new List<EnergyUseVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new EnergyUseVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.EnergyTypeId = _EnergyTypeService.List().entity ?? new List<EnergyTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_EnergyUseBase.cshtml", lists);
        }

        public ActionResult LoadGrossMarginIncomeAndCostStatusBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadGrossMarginIncomeAndCostStatus(surveyId);
            var lists = new List<GrossMarginIncomeAndCostStatusVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new GrossMarginIncomeAndCostStatusVM());
            }
            else
            {
                lists = result.entity;
            }

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_GrossMarginIncomeAndCostStatusBase.cshtml", lists);
        }

        public ActionResult LoadManualPhysicalWorkBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadManualPhysicalWork(surveyId);
            var lists = new List<ManualPhysicalWorkVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new ManualPhysicalWorkVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.ManualIncomeSourceTypeId = _ManualIncomeSourceTypeService.List().entity ?? new List<ManualIncomeSourceTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_ManualPhysicalWorkBase.cshtml", lists);
        }

        public ActionResult LoadNaturalPhysicalWorkBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadNaturalResourcesIncomeAndCostStatus(surveyId);
            var lists = new List<NaturalResourcesIncomeAndCostStatusVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new NaturalResourcesIncomeAndCostStatusVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.NaturalIncomeSourceTypeId = _NaturalIncomeSourceTypeService.List().entity ?? new List<NaturalIncomeSourceTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_NaturalResourcesIncomeAndCostStatusBase.cshtml", lists);
        }

        public ActionResult LoadOtherIncomeSourceBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadOtherIncomeSource(surveyId);
            var lists = new List<OtherIncomeSourceVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new OtherIncomeSourceVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.OtherIncomeSourceTypeId = _OtherIncomeSourceTypeService.List().entity ?? new List<OtherIncomeSourceTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_OtherIncomeSourceBase.cshtml", lists);
        }

        public ActionResult LoadBusinessBase(long surveyId = 0)
        {
            var result = _SurveyService.LoadBusiness(surveyId);
            var lists = new List<BusinessVM>();

            if (result.entity == null || result.entity.Count < 1)
            {
                lists.Add(new BusinessVM());
            }
            else
            {
                lists = result.entity;
            }

            ViewBag.BusinessIncomeSourceTypeId = _BusinessIncomeSourceTypeService.List().entity ?? new List<BusinessIncomeSourceTypeVM>();

            return PartialView("~/Views/BeneficiaryProfile/BasePartial/_BusinessBase.cshtml", lists);
        }

        public ActionResult ApproveStatus(long surveyId)
        {
            var result = _SurveyService.ApproveStatus(surveyId);

            return Json(
                new { Success = result.entity, Message = result.message },
                SerializerOption.Default);
        }


        public ActionResult RejectStatus(long surveyId)
        {
            var result = _SurveyService.RejectStatus(surveyId);

            return Json(
                new { Success = result.entity, Message = result.message },
                SerializerOption.Default);
        }

        public ActionResult Activate(long surveyId)
        {
            var result = _SurveyService.Activate(surveyId);

            return Json(
                new { Success = result.entity, Message = result.message },
                SerializerOption.Default);
        }

        public ActionResult Deactivate(long surveyId)
        {
            var result = _SurveyService.Deactivate(surveyId);

            return Json(
                new { Success = result.entity, Message = result.message },
                SerializerOption.Default);
        }

        public ActionResult PendingStatus(long surveyId)
        {
            var result = _SurveyService.PendingStatus(surveyId);

            return Json(
                new { Success = result.entity, Message = result.message },
                SerializerOption.Default);
        }



        public ActionResult RequestList()
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

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");

            var filter = AuthLocationHelper.GetSurveyFilterFromSession(HttpContext, 50);
            var surveyResponse = _SurveyService.GetBeneficiaryByFilter(new BeneficiaryFilterVM
            {
                GetPendingAlso = true,
                ForestCivilLocation = filter,
            });



            //Add Multi Permition Start
            ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");

            var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
            //new
            long userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

            var returnResponseApprovalLogForCfm = _ApprovalLogForCfmService.List().entity?.OrderByDescending(x => x.CreatedAt)?.Where(x => x?.ReceiverRoleId == userRoleId).ToList() ?? new List<ApprovalLogForCfmVM>();
            var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

            var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 25).Select(x => x.Id).FirstOrDefault();

            var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
            var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);

            if (roleList != null)
            {
                ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
            }

            //var checkIsLetestReceiver = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
            //var checkIsLetestReceiver = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).FirstOrDefault();

            var checkIsLetestReceiver = _PermissionRowSettingsService?.List().entity?.OrderByDescending(x => x.Id).FirstOrDefault();
            //?.Any(x => x?.ReceiverId == userId);
            //ViewBag.CheckIsApprove = checkIsLetestReceiver ?? false;

            var returnResponsePermissionHeaderSettings = _PermissionHeaderSettingsService.List().entity.Where(x => x.AccesslistId == 25).FirstOrDefault();
            var returnResponsePermissionRowSettings = returnResponsePermissionHeaderSettings?.PermissionRowSettings?.OrderByDescending(x => x.OrderId).ToList();
            var checkIsVisavaleAcceptButton = false;
            if (returnResponsePermissionRowSettings?.FirstOrDefault()?.UserRoleId == userRoleId)
            {
                checkIsVisavaleAcceptButton = true;
            }
            ViewBag.CheckIsVisavaleAcceptButton = checkIsVisavaleAcceptButton;

            var checkIsApprovalLogForCfm = _ApprovalLogForCfmService?.List().entity?.Where(x => x.BeneficiaryProfileId != null).OrderByDescending(x => x.Id).FirstOrDefault();


            var checkIsVisibaleAcceptButton = returnResponsePermissionRowSettings?.OrderByDescending(x => x?.OrderId)?.FirstOrDefault()?.UserRoleId;
            ViewBag.CheckIsVisavaleAcceptButton = false;

            if (checkIsVisibaleAcceptButton == userRoleId)
            {
                ViewBag.CheckIsVisavaleAcceptButton = true;
            }

            if (checkIsApprovalLogForCfm?.ReceiverRoleId == userRoleId)
            {
                return View(surveyResponse.entity);
            }
            else
            {
                return View(new List<SurveyEssentialVM>());
            }

            //Add Multi Permition End

            return View(surveyResponse.entity.aaData ?? new List<SurveyEssentialVM>());
        }


        [HttpPost]
        public JsonResult SaveMapToUser(ApprovalLogForCfmVM entity)
        {
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.ApprovalStatusId = Helper.Enum.ApprovalLog.ApprovalLogForCfmStatus.Panding;
            entity.SenderId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
            entity.SenderRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

            (ExecutionState executionState, ApprovalLogForCfmVM entity, string message) returnResponse = _ApprovalLogForCfmService.Create(entity);

            return Json(new { Data = returnResponse, Message = "" }, SerializerOption.Default);
        }



        public ActionResult AcceptedById(int id)
        {
            var result = _SurveyService.GetById(id);
            //result.entity.CipTeamMembers = null;
            //result.entity.ApprovalLogForCfms = null;

            result.entity.BeneficiaryApproveStatus = Helper.Enum.Beneficiary.BeneficiaryApproveStatus.Approved;
            result.entity.UpdatedAt = DateTime.Now;

            var returnResponse = _SurveyService.ApproveStatus(result.entity.Id);

            //var returnResponse = _SurveyService.Update(result.entity);
            return RedirectToAction("RequestList", "BeneficiaryProfile");
        }



        //DataTable Get List using server site Pagination
        //[HttpPost]
        public ActionResult GetBeneficiaryProfileListByPagination(JqueryDatatableParam param)
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

            ViewBag.Gender = new SelectList(EnumHelper.GetEnumDropdowns<Gender>(), "Id", "Name");
            ViewBag.NgoId = new SelectList(_NgoService.List().entity ?? new List<NgoVM>(), "Id", "Name");
            var filter = AuthLocationHelper.GetSurveyFilterFromSession(HttpContext);
            var surveyResponse = _SurveyService.GetBeneficiaryByFilter(new BeneficiaryFilterVM
            {
                GetPendingAlso = true,
                ForestCivilLocation = filter,
                iDisplayStart = param.iDisplayStart,
                iDisplayLength = param.iDisplayLength,
                sSearch = param.sSearch,
            });

           
            //Add Multi Permition Start
            var userId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserId));
            var userRoleId = Convert.ToInt64(HttpContext.Session.GetString(SessionKey.UserRoleId));

            var getLogInObj = _UserService.List().entity.SingleOrDefault(x => x.Id == userId);

            var accesslistId = _PermissionHeaderSettingsService.List().entity.ToList().Where(x => x.AccesslistId == 25).Select(x => x.Id).FirstOrDefault();
            var exceptMyInfoGetAllUser = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x.UserRoleId != userRoleId).ToList();
            //var userList = exceptMyInfoGetAllUser.Select(x => x.User);

            //if (userList != null)
            //{
            //    ViewBag.ReceiverId = new SelectList(userList, "Id", "UserName", userList);
            //}

            ////new
            string roleName = Convert.ToString(HttpContext.Session.GetString(SessionKey.RoleName));
            var exceptMyRoleInfoGetAllRoles = _PermissionRowSettingsService.List().entity.Where(x => x.PermissionHeaderSettingsId == accesslistId).Where(x => x?.UserRole?.Id != userRoleId).ToList();
            var roleList = exceptMyRoleInfoGetAllRoles.Select(x => x.UserRole);

            if (roleList != null)
            {
                ViewBag.UserRoleId = new SelectList(roleList, "Id", "RoleName", roleList);
            }

            ViewBag.ReceiverId = new SelectList(new List<UserVM>(), "Id", "UserName");
            var checkIsApprove = _ApprovalLogForCfmService?.List().entity?.OrderByDescending(x => x.Id).Where(x => x.BeneficiaryProfileId != null).Any(x => x?.ReceiverRoleId == userRoleId);
            ViewBag.CheckIsApprove = checkIsApprove ?? false;

            //Add Multi Permition End

            return Json(new
            {
                param.sEcho,
                iTotalRecords = surveyResponse.entity.iTotalRecords,
                iTotalDisplayRecords = surveyResponse.entity.iTotalDisplayRecords,
                aaData = surveyResponse.entity.aaData,
                checkIsApproveBool = checkIsApprove
            }, SerializerOption.Default);

            // return View(surveyResponse.entity ?? new List<SurveyEssentialVM>());
        }



        //[HttpPost]
        //public ActionResult IndexFilterBeneficiaryProfileListByPagination(LabourDatabaseFilterVM filter)
        //{
        //    AuthLocationHelper.GenerateViewBagForForestAndCivil(
        //     HttpContext,
        //     ViewBag,
        //     _ForestCircleService,
        //     _ForestDivisionService,
        //     _ForestRangeService,
        //     _ForestBeatService,
        //     _ForestFcvVcfService,
        //     _DivisionService,
        //     _DistrictService,
        //     _UpazillaService,
        //     _UnionService,
        //     filter
        // );
        //    filter.iDisplayStart = null;
        //    filter.iDisplayLength = null;

        //    (ExecutionState executionState, PaginationResutlVM<LabourDatabaseVM> entity, string message) returnResponse = _LabourDatabaseService.GetByFilter(filter);



        //    foreach (var item in returnResponse.entity.aaData)
        //    {
        //        if (item.SurveyId is null || item.SurveyId == default)
        //        {
        //            item.FullName = item.OtherLabourMember.FullName;
        //            item.GenderName = Enum.GetName(typeof(Gender), (long)item?.OtherLabourMember.Gender);
        //            item.NIDName = item.OtherLabourMember.NID;
        //            item.PhoneNumberName = item.OtherLabourMember.PhoneNumber;
        //            item.UserTypeName = "Other";
        //        }
        //        else
        //        {
        //            item.FullName = item.Survey.BeneficiaryName;
        //            item.GenderName = item.Survey.BeneficiaryGenderString;
        //            item.NIDName = item.Survey.BeneficiaryNid;
        //            item.PhoneNumberName = item.Survey.BeneficiaryPhone;
        //            item.UserTypeName = "Beneficiary";
        //        }
        //    }


        //    return Json(new
        //    {
        //        filter.sEcho,
        //        iTotalRecords = returnResponse.entity.iTotalRecords,
        //        iTotalDisplayRecords = returnResponse.entity.iTotalDisplayRecords,
        //        aaData = returnResponse.entity.aaData
        //    }, SerializerOption.Default);

        //    //return View("Index", returnResponse.entity);

        //}








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

