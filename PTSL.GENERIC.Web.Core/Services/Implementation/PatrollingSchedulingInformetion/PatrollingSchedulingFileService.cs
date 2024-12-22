using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingFileService : IPatrollingSchedulingFileService
    {
        private readonly HttpHelper _httpHelper;

        public PatrollingSchedulingFileService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<PatrollingSchedulingFileVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PatrollingSchedulingFileVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFileList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<PatrollingSchedulingFileVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PatrollingSchedulingFileVM>>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Create(PatrollingSchedulingFileVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFile));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingFileVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) returnResponse;
            try
            {
                PatrollingSchedulingFileVM model = new PatrollingSchedulingFileVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFile + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<PatrollingSchedulingFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingFileVM>>(json);
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
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFileDoesExist + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<DegreeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DegreeVM>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                //returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                //returnResponse.entity = null;
                returnResponse.message = ex.Message.ToString();
            }
            return returnResponse;
        }
        public (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Update(PatrollingSchedulingFileVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFile));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingFileVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PatrollingSchedulingFileVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingFile));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<PatrollingSchedulingFileVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingFileVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This PatrollingSchedulingMember is not exist.";
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