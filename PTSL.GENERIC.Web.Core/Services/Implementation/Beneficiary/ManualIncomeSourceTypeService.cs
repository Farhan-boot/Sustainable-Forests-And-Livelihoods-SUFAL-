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
    public class ManualIncomeSourceTypeService : IManualIncomeSourceTypeService
    {
        private readonly HttpHelper _httpHelper;

        public ManualIncomeSourceTypeService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<ManualIncomeSourceTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<ManualIncomeSourceTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceTypeList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<ManualIncomeSourceTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ManualIncomeSourceTypeVM>>>(json);
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

        public (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Create(ManualIncomeSourceTypeVM model)
        {
            (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceType));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<ManualIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ManualIncomeSourceTypeVM>>(json);
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

        public (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                ManualIncomeSourceTypeVM model = new ManualIncomeSourceTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceType + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<ManualIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ManualIncomeSourceTypeVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceTypeDoesExist + "/" + id));
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

        public (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Update(ManualIncomeSourceTypeVM model)
        {
            (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceType));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<ManualIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ManualIncomeSourceTypeVM>>(json);
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

        public (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, ManualIncomeSourceTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ManualIncomeSourceType));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<ManualIncomeSourceTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ManualIncomeSourceTypeVM>>(json);
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