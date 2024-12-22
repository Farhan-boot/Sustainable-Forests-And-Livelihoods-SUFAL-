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

namespace PTSL.GENERIC.Web.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingTypeService : IPatrollingSchedulingTypeService
    {
        private readonly HttpHelper _httpHelper;

        public PatrollingSchedulingTypeService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<PatrollingSchedulingTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PatrollingSchedulingTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingTypeList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<PatrollingSchedulingTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PatrollingSchedulingTypeVM>>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Create(PatrollingSchedulingTypeVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingType));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingTypeVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) returnResponse;
            try
            {
                PatrollingSchedulingTypeVM model = new PatrollingSchedulingTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingType + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<PatrollingSchedulingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingTypeVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingTypeDoesExist + "/" + id));
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
        public (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Update(PatrollingSchedulingTypeVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingType));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingTypeVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PatrollingSchedulingTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingType));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<PatrollingSchedulingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingTypeVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This PatrollingSchedulingType is not exist.";
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