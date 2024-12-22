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
    public class SavingsAmountInformationService : ISavingsAmountInformationService
    {
        private readonly HttpHelper _httpHelper;

        public SavingsAmountInformationService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformationList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SavingsAmountInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SavingsAmountInformationVM>>>(json);
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

        public (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Create(SavingsAmountInformationVM model)
        {
            (ExecutionState executionState, SavingsAmountInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformation));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<SavingsAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAmountInformationVM>>(json);
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

        public (ExecutionState executionState, SavingsAmountInformationVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SavingsAmountInformationVM entity, string message) returnResponse;
            try
            {
                SavingsAmountInformationVM model = new SavingsAmountInformationVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformation + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<SavingsAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAmountInformationVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformationDoesExist + "/" + id));
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

        public (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Update(SavingsAmountInformationVM model)
        {
            (ExecutionState executionState, SavingsAmountInformationVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformation));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<SavingsAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAmountInformationVM>>(json);
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

        public (ExecutionState executionState, SavingsAmountInformationVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SavingsAmountInformationVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SavingsAmountInformationVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAmountInformation));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<SavingsAmountInformationVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAmountInformationVM>>(json);
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

        public (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) ListBySavingsAmountInformation(long savingsAmountInformationId)
        {
            (ExecutionState executionState, List<SavingsAmountInformationVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format($"{URLHelper.SavingsAccount}/ListBySavingsAmountInformation/{savingsAmountInformationId}"));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SavingsAmountInformationVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SavingsAmountInformationVM>>>(json);
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