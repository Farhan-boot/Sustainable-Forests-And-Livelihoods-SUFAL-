using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup
{
    public class OtherIncomeSourceTypeService : IOtherIncomeSourceTypeService
    {
        private readonly HttpHelper _httpHelper;

        public OtherIncomeSourceTypeService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<OtherIncomeSourceTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OtherIncomeSourceTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceTypeList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherIncomeSourceTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherIncomeSourceTypeVM>>>(json);
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

        public (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Create(OtherIncomeSourceTypeVM model)
        {
            (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceType));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<OtherIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherIncomeSourceTypeVM>>(json);
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

        public (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                OtherIncomeSourceTypeVM model = new OtherIncomeSourceTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceType + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<OtherIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherIncomeSourceTypeVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceTypeDoesExist + "/" + id));
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

        public (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Update(OtherIncomeSourceTypeVM model)
        {
            (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceType));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<OtherIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherIncomeSourceTypeVM>>(json);
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

        public (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OtherIncomeSourceTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherIncomeSourceType));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<OtherIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherIncomeSourceTypeVM>>(json);
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
    }
}