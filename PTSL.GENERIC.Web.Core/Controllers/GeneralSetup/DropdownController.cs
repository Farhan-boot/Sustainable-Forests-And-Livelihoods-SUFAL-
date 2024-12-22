using Microsoft.AspNetCore.Mvc;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Helper.Enum.AccountManagement;
using PTSL.GENERIC.Web.Core.Helper.Enum.Beneficiary;
using PTSL.GENERIC.Web.Core.Helper.Enum.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.Capacity;
using PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Core.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryMeeting;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining;
using PTSL.GENERIC.Web.Helper;
using PTSL.GENERIC.Web.Services.Implementation.GeneralSetup;

namespace PTSL.GENERIC.Web.Controllers.GeneralSetup
{
    public class DropdownController : Controller
    {
        private readonly IForestCircleService _forestCircleService;
        private readonly IForestDivisionService _forestDivisionService;
        private readonly IForestRangeService _forestRangeService;
        private readonly IForestBeatService _forestBeatService;
        private readonly IForestFcvVcfService _forestFcvVcfService;
        private readonly IEthnicityService _ethnicityService;
        private readonly IEventTypeService _eventTypeService;
        private readonly ITrainingOrganizerService _trainingOrganizerService;
        private readonly ICommunityTrainingTypeService _communityTrainingTypeService;
        private readonly ICommunityTrainingMemberService _communityTrainingMemberService;
        private readonly IDepartmentalTrainingMemberService _departmentalTrainingMemberService;
        private readonly IDepartmentalTrainingTypeService _DepartmentalTrainingTypeService;
        private readonly IDistrictService _districtService;
        private readonly IDivisionService _divisionService;
        private readonly IUpazillaService _upazillaService;
        private readonly IUnionService _unionService;
        private readonly IOccupationService _occupationService;
        private readonly IBFDAssociationService _bFDAssociationService;
        private readonly IDisabilityTypeService _disabilityTypeService;
        private readonly ISafetyNetService _safetyNetService;
        private readonly ILiveStockTypeService _liveStockTypeService;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IImmovableAssetTypeService _immovableAssetTypeService;
        private readonly IRelationWithHeadHouseHoldTypeService _relationWithHeadHouseHoldTypeService;
        private readonly IEnergyTypeService _energyTypeService;
        private readonly IManualIncomeSourceTypeService _manualIncomeSourceTypeService;
        private readonly INaturalIncomeSourceTypeService _naturalIncomeSourceTypeService;
        private readonly IOtherIncomeSourceTypeService _otherIncomeSourceTypeService;
        private readonly IBusinessIncomeSourceTypeService _businessIncomeSourceTypeService;
        private readonly IExpenditureTypeService _expenditureTypeService;
        private readonly IFoodItemService _foodItemService;
        private readonly IVulnerabilitySituationTypeService _vulnerabilitySituationTypeService;
        private readonly ISurveyService _surveyService;
        private readonly ITrainerDesignationForTrainingService _trainerDesignationForTrainingService;
        private readonly ITrainingOrganizerForTrainingService _trainingOrganizerForTrainingService;
        private readonly IEventTypeForTrainingService _eventTypeForTrainingService;
        private readonly ISocialForestryTrainingMemberService _socialForestryTrainingMemberService;
        private readonly ISocialForestryMeetingMemberService _socialForestryMeetingMemberService;

        public DropdownController(HttpHelper httpHelper)
        {
            _forestCircleService = new ForestCircleService(httpHelper);
            _forestDivisionService = new ForestDivisionService(httpHelper);
            _forestRangeService = new ForestRangeService(httpHelper);
            _forestBeatService = new ForestBeatService(httpHelper);
            _forestFcvVcfService = new ForestFcvVcfService(httpHelper);
            _ethnicityService = new EthnicityService(httpHelper);
            _eventTypeService = new EventTypeService(httpHelper);
            _trainingOrganizerService = new TrainingOrganizerService(httpHelper);
            _communityTrainingTypeService = new CommunityTrainingTypeService(httpHelper);
            _communityTrainingMemberService = new CommunityTrainingMemberService(httpHelper);
            _departmentalTrainingMemberService = new DepartmentalTrainingMemberService(httpHelper);
            _DepartmentalTrainingTypeService = new DepartmentalTrainingTypeService(httpHelper);
            _districtService = new DistrictService(httpHelper);
            _divisionService = new DivisionService(httpHelper);
            _upazillaService = new UpazillaService(httpHelper);
            _unionService = new UnionService(httpHelper);
            _occupationService = new OccupationService(httpHelper);
            _bFDAssociationService = new BFDAssociationService(httpHelper);
            _disabilityTypeService = new DisabilityTypeService(httpHelper);
            _safetyNetService = new SafetyNetService(httpHelper);
            _liveStockTypeService = new LiveStockTypeService(httpHelper);
            _assetTypeService = new AssetTypeService(httpHelper);
            _immovableAssetTypeService = new ImmovableAssetTypeService(httpHelper);
            _relationWithHeadHouseHoldTypeService = new RelationWithHeadHouseHoldTypeService(httpHelper);
            _energyTypeService = new EnergyTypeService(httpHelper);
            _manualIncomeSourceTypeService = new ManualIncomeSourceTypeService(httpHelper);
            _naturalIncomeSourceTypeService = new NaturalIncomeSourceTypeService(httpHelper);
            _otherIncomeSourceTypeService = new OtherIncomeSourceTypeService(httpHelper);
            _businessIncomeSourceTypeService = new BusinessIncomeSourceTypeService(httpHelper);
            _expenditureTypeService = new ExpenditureTypeService(httpHelper);
            _foodItemService = new FoodItemService(httpHelper);
            _vulnerabilitySituationTypeService = new VulnerabilitySituationTypeService(httpHelper);
            _surveyService = new SurveyService(httpHelper);
            _trainerDesignationForTrainingService = new TrainerDesignationForTrainingService(httpHelper);
            _trainingOrganizerForTrainingService = new TrainingOrganizerForTrainingService(httpHelper);
            _eventTypeForTrainingService = new EventTypeForTrainingService(httpHelper);
            _socialForestryTrainingMemberService = new SocialForestryTrainingMemberService(httpHelper);
            _socialForestryMeetingMemberService = new SocialForestryMeetingMemberService(httpHelper);

        }

        public ActionResult ListAllForestCircles()
        {
            var result = _forestCircleService.List();
            if (result.entity == null)
            {
                return Json(new List<ForestCircleVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListAllDivisions()
        {
            var result = _divisionService.List();
            if (result.entity == null)
            {
                return Json(new List<DivisionVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListForestDivisionByForestCircle(long id)
        {
            var result = _forestDivisionService.ListByForestCircle(id);
            if (result.entity == null)
            {
                return Json(new List<ForestDivisionVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListForestRangeByForestDivision(long id)
        {
            var result = _forestRangeService.ListByForestDivision(id);
            if (result.entity == null)
            {
                return Json(new List<ForestRangeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListForestBeatByForestRange(long id)
        {
            var result = _forestBeatService.ListByForestRange(id);
            if (result.entity == null)
            {
                return Json(new List<ForestBeatVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListForestFcvVcfByForestBeat(long id)
        {
            var result = _forestFcvVcfService.ListByForestBeat(id);
            if (result.entity == null)
            {
                return Json(new List<ForestFcvVcfVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListByForestBeatAndType(long beatId, FcvVcfType type)
        {
            var result = _forestFcvVcfService.ListByForestBeatAndType(beatId, type);
            if (result.entity == null)
            {
                return Json(new List<ForestFcvVcfVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListDistrictByDivision(long id)
        {
            var result = _districtService.ListByDivision(id);
            if (result.entity == null)
            {
                return Json(new List<DistrictVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListUpazillaByDistrict(long id)
        {
            var result = _upazillaService.ListByDistrict(id);
            if (result.entity == null)
            {
                return Json(new List<UpazillaVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListUnionByUpazilla(long id)
        {
            var result = _unionService.ListByUpazilla(id);
            if (result.entity == null)
            {
                return Json(new List<UnionVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult ListUnionByMultipleUpazilla(List<long> ids)
        {
            var result = _unionService.ListByMultipleUpazilla(ids);
            if (result.entity == null)
            {
                return Json(new List<UnionVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetEthnicityList()
        {
            var result = _ethnicityService.List();
            if (result.entity == null)
            {
                return Json(new List<EthnicityVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetEventTypeList()
        {
            var result = _eventTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<EventTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetEventTypeForTrainingList()
        {
            var result = _eventTypeForTrainingService.List();
            if (result.entity == null)
            {
                return Json(new List<EventTypeForTrainingVM>(), SerializerOption.Default);
            }
            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetCommunityTrainingTypeList()
        {
            var result = _communityTrainingTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<CommunityTrainingTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetCommunityTrainingMemberById(long id)
        {
            var result = _communityTrainingMemberService.GetById(id);
            if (result.entity == null)
            {
                return Json(new CommunityTrainingMemberVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetDepartmentalTrainingMemberById(long id)
        {
            var result = _departmentalTrainingMemberService.GetById(id);
            if (result.entity == null)
            {
                return Json(new DepartmentalTrainingMemberVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetSocialForestryTrainingMemberById(long id)
        {
            var result = _socialForestryTrainingMemberService.GetById(id);
            if (result.entity == null)
            {
                return Json(new SocialForestryTrainingMemberVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }


        public ActionResult GetSocialForestryMeetingMemberById(long id)
        {
            var result = _socialForestryMeetingMemberService.GetById(id);
            if (result.entity == null)
            {
                return Json(new SocialForestryMeetingMemberVM(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }



        public ActionResult GetDepartmentalTrainingTypeList()
        {
            var result = _DepartmentalTrainingTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<DepartmentalTrainingTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetTrainingOrganizerList()
        {
            var result = _trainingOrganizerService.List();
            if (result.entity == null)
            {
                return Json(new List<TrainingOrganizerVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }


        public ActionResult GetTrainingOrganizerForTrainingList()
        {
            var result = _trainingOrganizerForTrainingService.List();
            if (result.entity == null)
            {
                return Json(new List<TrainingOrganizerForTrainingVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }


        public ActionResult GetTrainerDesignationForTrainingList()
        {
            var result = _trainerDesignationForTrainingService.List();
            if (result.entity == null)
            {
                return Json(new List<TrainerDesignationForTrainingVM>(), SerializerOption.Default);
            }
            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetDivisionList()
        {
            var result = _divisionService.List();
            if (result.entity == null)
            {
                return Json(new List<DivisionVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetOccupationList()
        {
            var result = _occupationService.List();
            if (result.entity == null)
            {
                return Json(new List<OccupationVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetBFDAssociationList()
        {
            var result = _bFDAssociationService.List();
            if (result.entity == null)
            {
                return Json(new List<BFDAssociationVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetDisabilityList()
        {
            var result = _disabilityTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<DisabilityTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetSafetyNetList()
        {
            var result = _safetyNetService.List();
            if (result.entity == null)
            {
                return Json(new List<SafetyNetVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetLiveStockTypeList()
        {
            var result = _liveStockTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<LiveStockTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetAssetTypeList()
        {
            var result = _assetTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<AssetTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetImmovableAssetTypeList()
        {
            var result = _immovableAssetTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<ImmovableAssetTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetRelationWithHeadHouseHoldTypeList()
        {
            var result = _relationWithHeadHouseHoldTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<RelationWithHeadHouseHoldTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetEnergyUseList()
        {
            var result = _energyTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<EnergyUseVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetManualIncomeSourceTypeList()
        {
            var result = _manualIncomeSourceTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<ManualIncomeSourceTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetNaturalIncomeSourceTypeList()
        {
            var result = _naturalIncomeSourceTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<NaturalIncomeSourceTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetOtherIncomeSourceTypeList()
        {
            var result = _otherIncomeSourceTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<OtherIncomeSourceTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetBusinessIncomeSourceTypeList()
        {
            var result = _businessIncomeSourceTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<BusinessIncomeSourceTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetExpenditureTypeList()
        {
            var result = _expenditureTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<ExpenditureTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetFoodItemList()
        {
            var result = _foodItemService.List();
            if (result.entity == null)
            {
                return Json(new List<FoodItemVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetVulnerabilitySituationTypeList()
        {
            var result = _vulnerabilitySituationTypeService.List();
            if (result.entity == null)
            {
                return Json(new List<VulnerabilitySituationTypeVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetAccountAllowedFundExpenseList()
        {
            return Json(EnumHelper.GetEnumDropdowns<AccountAllowedFundExpense>(), SerializerOption.Default);
        }
        public ActionResult GetGenderEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<Gender>(), SerializerOption.Default);
        }
        public ActionResult GetGenderMfEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<GenderMf>(), SerializerOption.Default);
        }
        public ActionResult GetMaritalStatusEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<MaritalStatus>(), SerializerOption.Default);
        }
        public ActionResult GetEducationLevelEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<EducationLevel>(), SerializerOption.Default);
        }
        public ActionResult GetLandClassificationEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<LandClassification>(), SerializerOption.Default);
        }
        public ActionResult GetHouseTypeEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<HouseType>(), SerializerOption.Default);
        }
        public ActionResult GetDrinkingWaterResourceEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<DrinkingWaterResource>(), SerializerOption.Default);
        }
        public ActionResult GetEducationalInstituteAccessibilityEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<EducationalInstituteAccessibility>(), SerializerOption.Default);
        }
        public ActionResult GetSanitationFacilitiesEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<SanitationFacilities>(), SerializerOption.Default);
        }
        public ActionResult GetSkillLevelEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<SkillLevel>(), SerializerOption.Default);
        }
        public ActionResult GetSatisfactionLevelEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<SatisfactionLevel>(), SerializerOption.Default);
        }
        public ActionResult GetForestDependencyEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<ForestDependency>(), SerializerOption.Default);
        }
        public ActionResult GetFoodConditionEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<FoodCondition>(), SerializerOption.Default);
        }
        public ActionResult GetFamilyMemberTypeEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<FamilyMemberType>(), SerializerOption.Default);
        }

        public ActionResult GetMonthsEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<Months>(), SerializerOption.Default);
        }

        // Executive Member Type
        public ActionResult GetExecutiveMemberTypeEnumList()
        {
            return Json(EnumHelper.GetEnumDropdowns<SubCommitteeType>(), SerializerOption.Default);
        }

        // Get Beneficiary ByFcv Vcf Id
        public ActionResult GetBeneficiaryByFcvVcfId(long id)
        {
            var result = _surveyService.GetBeneficiaryByFcvVcfId(id);
            if (result.entity == null)
            {
                return Json(new List<SurveyVM>(), SerializerOption.Default);
            }

            return Json(result.entity, SerializerOption.Default);
        }

        public ActionResult GetFilterData(BeneficiaryFilterVM filter)
        {
            var response = _surveyService.GetBeneficiaryByFilter(filter);
            var surveyList = response.entity.aaData ?? new List<SurveyEssentialVM>();

            if (response.entity == null)
            {
                return Json(
                    new { Success = false, Message = response.message, Data = surveyList },
                    SerializerOption.Default);
            }

            return Json(surveyList, SerializerOption.Default);
        }
    }
}
