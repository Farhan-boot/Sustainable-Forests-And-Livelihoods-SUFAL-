using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.BeneficiarySavingsAccount
{
    public class WithdrawAmountInformationService : IWithdrawAmountInformationService
    {
        private readonly HttpHelper _httpHelper;

        public WithdrawAmountInformationService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformationList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<WithdrawAmountInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<WithdrawAmountInformationVM>>>(json);
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

        public (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Create(WithdrawAmountInformationVM model)
        {
            (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformation));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<WithdrawAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<WithdrawAmountInformationVM>>(json);
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

        public (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse;
            try
            {
                WithdrawAmountInformationVM model = new WithdrawAmountInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformation + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<WithdrawAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<WithdrawAmountInformationVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformationDoesExist + "/" + id));
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

        public (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Update(WithdrawAmountInformationVM model)
        {
            (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformation));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<WithdrawAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<WithdrawAmountInformationVM>>(json);
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

        public (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, WithdrawAmountInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.WithdrawAmountInformation));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<WithdrawAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<WithdrawAmountInformationVM>>(json);
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

        public (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) ListByWithdrawAmountInformation(long withdrawAmountInformationId)
        {
            (ExecutionState executionState, List<WithdrawAmountInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format($"{URLHelper.SavingsAccount}/ListByWithdrawAmountInformation/{withdrawAmountInformationId}"));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<WithdrawAmountInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<WithdrawAmountInformationVM>>>(json);
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
    }
}