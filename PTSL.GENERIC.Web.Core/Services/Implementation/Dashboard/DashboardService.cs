using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.DashBoard;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.AIG;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Dashboard;
using PTSL.GENERIC.Web.Core.Services.Interface.Dashboard;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpHelper _httpHelper;

        public DashboardService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, DashboardLoanResponse entity, string message) GetLoanData(DashboardLoanRequest filter)
        {
            (ExecutionState executionState, DashboardLoanResponse entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetGetLoanData));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<DashboardLoanResponse> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DashboardLoanResponse>>(json);
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

        public (ExecutionState executionState, List<EnergyUsesPercentageVM> entity, string message) GetEnergyUsesPercentage(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, List<EnergyUsesPercentageVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetEnergyUsesPercentage));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<List<EnergyUsesPercentageVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EnergyUsesPercentageVM>>>(json);
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

        public (ExecutionState executionState, BeneficiaryVM entity, string message) GetTotalBeneficiary(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, BeneficiaryVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetTotalBeneficiary));
                var json = _httpHelper.Post(URL, respJson, "application/json");

                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<BeneficiaryVM>>(json);
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

        public (ExecutionState executionState, AIGLoanOverviewVM? entity, string message) LoanOverview(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, AIGLoanOverviewVM? entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LoanStatusOverview));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<AIGLoanOverviewVM>>(json);
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

        public (ExecutionState executionState, SurveyDashboardVM? entity, string message) BeneficiaryDashboardData(long? surveyId)
        {
            (ExecutionState executionState, SurveyDashboardVM? entity, string message) returnResponse;

            if (surveyId is null || surveyId < 0)
                return (ExecutionState.Failure, null, "Invalid id");

            try
            {
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DashboardBeneficiaryDashboardData + "/" + surveyId));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyDashboardVM>>(json);
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

        public (ExecutionState executionState, CommitteeMemberCount? entity, string message) GetTotalFcvVcfAndExecutiveSubExecutive(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, CommitteeMemberCount? entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetTotalFcvVcfAndExecutiveSubExecutive));
                var json = _httpHelper.Post(URL, respJson, "application/json");

                //FcvVcfVM responseJson = JsonConvert.DeserializeObject<FcvVcfVM>(json);

                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<CommitteeMemberCount>>(json);
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

        public (ExecutionState executionState, DashboardHouseholdVM entity, string message) TotalHouseholdWithPercentage(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, DashboardHouseholdVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TotalHouseholdWithPercentage));
                var json = _httpHelper.Post(URL, respJson, "application/json");

                WebApiResponse<DashboardHouseholdVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DashboardHouseholdVM>>(json);
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



        public (ExecutionState executionState, DashboardSavingsAmountVM entity, string message) TotalDashboardSavingsAmount(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, DashboardSavingsAmountVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TotalDashboardSavingsAmount));
                var json = _httpHelper.Post(URL, respJson, "application/json");

                WebApiResponse<DashboardSavingsAmountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DashboardSavingsAmountVM>>(json);
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

        public (ExecutionState executionState, CIPDetailsVM entity, string message) GetCIPDetails(ForestCivilLocationFilter filter)
        {
            (ExecutionState executionState, CIPDetailsVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetCIPDetails));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<CIPDetailsVM>>(json);
                returnResponse.executionState = responseJson!.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = new CIPDetailsVM();
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
    }
}
