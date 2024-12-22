using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Labour;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Labour
{
    public class LabourWorkService : ILabourWorkService
    {
        private readonly HttpHelper _httpHelper;

        public LabourWorkService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<LabourWorkVM> entity, string message) ListByFilter(LabourWorkFilterVM filter)
        {
            (ExecutionState executionState, List<LabourWorkVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWorkListByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LabourWorkVM>>>(json);
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

        public (ExecutionState executionState, List<LabourWorkVM> entity, string message) List()
        {
            (ExecutionState executionState, List<LabourWorkVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWorkList));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LabourWorkVM>>>(json);
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

        public (ExecutionState executionState, LabourWorkVM entity, string message) Create(LabourWorkVM model)
        {
            (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWork));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourWorkVM>>(json);
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

        public (ExecutionState executionState, LabourWorkVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse;
            try
            {
                var model = new LabourWorkVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWork + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourWorkVM>>(json);
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
                var model = new DegreeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWorkDoesExist + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<DegreeVM>>(json);
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

        public (ExecutionState executionState, LabourWorkVM entity, string message) Update(LabourWorkVM model)
        {
            (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWork));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourWorkVM>>(json);
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

        public (ExecutionState executionState, LabourWorkVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, LabourWorkVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, LabourWorkVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWork));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    var responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourWorkVM>>(json);
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

        public (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourWorkSoftDelete), "/", id);
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var result = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = result.ExecutionState;
                returnResponse.isDeleted = result.Data;
                returnResponse.message = result.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.isDeleted = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
    }
}