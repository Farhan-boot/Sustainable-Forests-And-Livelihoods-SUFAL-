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
    public class LabourDatabaseFileService : ILabourDatabaseFileService
    {
        private readonly HttpHelper _httpHelper;

        public LabourDatabaseFileService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<LabourDatabaseFileVM> entity, string message) List()
        {
            (ExecutionState executionState, List<LabourDatabaseFileVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFileList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<LabourDatabaseFileVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<LabourDatabaseFileVM>>>(json);
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

        public (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Create(LabourDatabaseFileVM model)
        {
            (ExecutionState executionState, LabourDatabaseFileVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFile));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<LabourDatabaseFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourDatabaseFileVM>>(json);
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

        public (ExecutionState executionState, LabourDatabaseFileVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, LabourDatabaseFileVM entity, string message) returnResponse;
            try
            {
                LabourDatabaseFileVM model = new LabourDatabaseFileVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFile + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<LabourDatabaseFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourDatabaseFileVM>>(json);
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
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFileDoesExist + "/" + id));
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

        public (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Update(LabourDatabaseFileVM model)
        {
            (ExecutionState executionState, LabourDatabaseFileVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFile));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<LabourDatabaseFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourDatabaseFileVM>>(json);
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

        public (ExecutionState executionState, LabourDatabaseFileVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, LabourDatabaseFileVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, LabourDatabaseFileVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFile));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<LabourDatabaseFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<LabourDatabaseFileVM>>(json);
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

        public (ExecutionState executionState, bool isDelete, string message) SoftDelete(long id)
        {
            (ExecutionState executionState, bool isDelete, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.LabourDatabaseFileSoftDelete), "/", id);
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var result = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = result.ExecutionState;
                returnResponse.isDelete = result.Data;
                returnResponse.message = result.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.isDelete = false;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
    }
}