using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.DashBoard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Services.Implementation.GeneralSetup
{
    public class SurveyService : ISurveyService
    {
        private readonly HttpHelper _httpHelper;

        public SurveyService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<SurveyVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SurveyVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SurveyVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyVM entity, string message) Create(SurveyVM model)
        {
            (ExecutionState executionState, SurveyVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Survey));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<SurveyVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SurveyVM entity, string message) returnResponse;
            try
            {
                SurveyVM model = new SurveyVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Survey + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<SurveyVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyVM entity, string message) GetDetailsById(long id)
        {
            (ExecutionState executionState, SurveyVM entity, string message) returnResponse;
            try
            {
                SurveyVM model = new SurveyVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyGetDetailsAsync + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<SurveyVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<HouseholdMemberVM> entity, string message) LoadMembers(long id)
        {
            (ExecutionState executionState, List<HouseholdMemberVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
				HouseholdMemberVM model = new HouseholdMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadMembers + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<HouseholdMemberVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<ExistingSkillVM> entity, string message) LoadExistingSkill(long id)
        {
            (ExecutionState executionState, List<ExistingSkillVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadExistingSkill + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ExistingSkillVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message) LoadAnnualHouseholdExpenditure(long id)
        {
            (ExecutionState executionState, List<AnnualHouseholdExpenditureVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null!, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadAnnualHouseholdExpenditure + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<AnnualHouseholdExpenditureVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<FoodSecurityItemVM> entity, string message) LoadFoodSecurityItem(long id)
        {
            (ExecutionState executionState, List<FoodSecurityItemVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadFoodSecurityItem + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<FoodSecurityItemVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message) LoadVulnerabilitySituation(long id)
        {
            (ExecutionState executionState, List<VulnerabilitySituationVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadVulnerabilitySituation + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<VulnerabilitySituationVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, string message) DoesExist(long? id)
        {
            (ExecutionState executionState, string message) returnResponse;
            try
            {
                DegreeVM model = new DegreeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyDoesExist + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<DegreeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DegreeVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyVM entity, string message) Update(SurveyVM model)
        {
            (ExecutionState executionState, SurveyVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Survey));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<SurveyVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SurveyVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SurveyVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Survey));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<SurveyVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This item does not exist.";
                }
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, PaginationResutlVM<SurveyEssentialVM> entity, string message) GetBeneficiaryByFilter(BeneficiaryFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutlVM<SurveyEssentialVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyGetBeneficiaryByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PaginationResutlVM<SurveyEssentialVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PaginationResutlVM<SurveyEssentialVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) ListNotHasAccountIncluding(ForestCivilLocationFilter filter, long? surveyId = null)
        {
            (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) returnResponse;

            try
            {
                var respJson = JsonConvert.SerializeObject(filter);
                var surveyStr = surveyId.HasValue && surveyId > 0 ? $"/{surveyId}" : string.Empty;

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyListNotHasAccountIncluding + surveyStr));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<List<SurveyEssentialVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyEssentialVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = new List<SurveyEssentialVM>();
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) ListLatest(int take = 50)
        {
            (ExecutionState executionState, List<SurveyEssentialVM> entity, string message) returnResponse;
            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, $"{URLHelper.SurveyListLatest}/{take}");
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SurveyEssentialVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyEssentialVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<SurveyVM> entity, string message) GetBeneficiaryByFcvVcfId(long id)
        {
            (ExecutionState executionState, List<SurveyVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyGetBeneficiaryByFcvVcf+"/"+id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SurveyVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        //
        public (ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message) LoadGrossMarginIncomeAndCostStatus(long id)
        {
            (ExecutionState executionState, List<GrossMarginIncomeAndCostStatusVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadGrossMarginIncomeAndCostStatus + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<GrossMarginIncomeAndCostStatusVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message) LoadManualPhysicalWork(long id)
        {
            (ExecutionState executionState, List<ManualPhysicalWorkVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadManualPhysicalWork + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ManualPhysicalWorkVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message) LoadNaturalResourcesIncomeAndCostStatus(long id)
        {
            (ExecutionState executionState, List<NaturalResourcesIncomeAndCostStatusVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadNaturalResourcesIncomeAndCostStatus + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<NaturalResourcesIncomeAndCostStatusVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message) LoadOtherIncomeSource(long id)
        {
            (ExecutionState executionState, List<OtherIncomeSourceVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadOtherIncomeSource + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherIncomeSourceVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<BusinessVM> entity, string message) LoadBusiness(long id)
        {
            (ExecutionState executionState, List<BusinessVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadBusiness + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<BusinessVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<LandOccupancyVM> entity, string message) LoadLandOccupancy(long id)
        {
            (ExecutionState executionState, List<LandOccupancyVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadLandOccupancy + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LandOccupancyVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<LiveStockVM> entity, string message) LoadLiveStock(long id)
        {
            (ExecutionState executionState, List<LiveStockVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadLiveStock + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LiveStockVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<AssetVM> entity, string message) LoadAsset(long id)
        {
            (ExecutionState executionState, List<AssetVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadAsset + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<AssetVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<ImmovableAssetVM> entity, string message) LoadImmovableAsset(long id)
        {
            (ExecutionState executionState, List<ImmovableAssetVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadImmovableAsset + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ImmovableAssetVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, List<EnergyUseVM> entity, string message) LoadEnergyUse(long id)
        {
            (ExecutionState executionState, List<EnergyUseVM> entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadEnergyUse + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EnergyUseVM>>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, SurveyChildsVM? entity, string message) LoadAllChilds(long id)
        {
            (ExecutionState executionState, SurveyChildsVM? entity, string message) returnResponse;

            if (id < 1)
            {
                return (executionState: ExecutionState.Failure, null, message: "Id is not valid.");
            }

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyLoadAllChilds + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyChildsVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, bool entity, string message) ApproveStatus(long surveyId)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;

            if (surveyId < 1)
            {
                return (executionState: ExecutionState.Failure, false, message: "Id is not valid.");
            }

            try
            {
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyApproveStatus + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, bool entity, string message) RejectStatus(long surveyId)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;

            if (surveyId < 1)
            {
                return (executionState: ExecutionState.Failure, false, message: "Id is not valid.");
            }

            try
            {
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyRejectStatus + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }



        public (ExecutionState executionState, bool entity, string message) PendingStatus(long surveyId)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;

            if (surveyId < 1)
            {
                return (executionState: ExecutionState.Failure, false, message: "Id is not valid.");
            }

            try
            {
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyPendingStatus + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, bool entity, string message) Deactivate(long surveyId)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;

            if (surveyId < 1)
            {
                return (executionState: ExecutionState.Failure, false, message: "Id is not valid.");
            }

            try
            {
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyDeactivate + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }

        public (ExecutionState executionState, bool entity, string message) Activate(long surveyId)
        {
            (ExecutionState executionState, bool entity, string message) returnResponse;

            if (surveyId < 1)
            {
                return (executionState: ExecutionState.Failure, false, message: "Id is not valid.");
            }

            try
            {
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyActivate + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
    }
}