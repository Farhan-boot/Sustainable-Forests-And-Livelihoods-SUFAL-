using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Core.Services.Interface.BeneficiarySavingsAccount;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.BeneficiarySavingsAccount
{
    public class SavingsAccountService : ISavingsAccountService
    {
        private readonly HttpHelper _httpHelper;

        public SavingsAccountService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<SavingsAccountVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SavingsAccountVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccountList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SavingsAccountVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SavingsAccountVM>>>(json);
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

        public (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) GetByFilter(SavingsAccountFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutlVM<SavingsAccountVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccountGetByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PaginationResutlVM<SavingsAccountVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PaginationResutlVM<SavingsAccountVM>>>(json);
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

        public (ExecutionState executionState, SavingsAccountVM entity, string message) Create(SavingsAccountVM model)
        {
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccount));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<SavingsAccountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAccountVM>>(json);
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

        public (ExecutionState executionState, SavingsAccountVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse;
            try
            {
                SavingsAccountVM model = new SavingsAccountVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccount + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<SavingsAccountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAccountVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccountDoesExist + "/" + id));
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

        public (ExecutionState executionState, SavingsAccountVM entity, string message) Update(SavingsAccountVM model)
        {
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccount));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<SavingsAccountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAccountVM>>(json);
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

        public (ExecutionState executionState, SavingsAccountVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SavingsAccountVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SavingsAccountVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SavingsAccount));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<SavingsAccountVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<SavingsAccountVM>>(json);
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

        public (ExecutionState executionState, List<SavingsAccountVM> entity, string message) ListBySavingsAccount(long savingsAccountId)
        {
            (ExecutionState executionState, List<SavingsAccountVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format($"{URLHelper.SavingsAccount}/ListBySavingsAccount/{savingsAccountId}"));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<SavingsAccountVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SavingsAccountVM>>>(json);
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