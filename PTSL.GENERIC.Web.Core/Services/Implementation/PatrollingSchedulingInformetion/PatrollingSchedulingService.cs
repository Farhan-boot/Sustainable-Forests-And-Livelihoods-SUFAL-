using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Core.Services.Interface.PatrollingSchedulingInformetion;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Services.Implementation.PatrollingSchedulingInformetion
{
    public class PatrollingSchedulingService : IPatrollingSchedulingService
    {
        private readonly HttpHelper _httpHelper;

        public PatrollingSchedulingService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<PatrollingSchedulingVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PatrollingSchedulingVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<PatrollingSchedulingVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PatrollingSchedulingVM>>>(json);
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

        public (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) GetTrainingByFilter(PatrollingSchedulingFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutlVM<PatrollingSchedulingVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingGetTrainingByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PaginationResutlVM<PatrollingSchedulingVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PaginationResutlVM<PatrollingSchedulingVM>>>(json);
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

        public (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Create(PatrollingSchedulingVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingScheduling));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse;
            try
            {
                PatrollingSchedulingVM model = new PatrollingSchedulingVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingScheduling + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<PatrollingSchedulingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingDoesExist + "/" + id));
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
        public (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Update(PatrollingSchedulingVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingScheduling));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PatrollingSchedulingVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingScheduling + "/" + id));


                    var json = _httpHelper.Delete(URL, respJson, "application/json");
                    WebApiResponse<PatrollingSchedulingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This PatrollingScheduling is not exist.";
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

        public (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long patrollingSchedulingParticipentsMapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingDeleteParticipant + "/" + patrollingSchedulingParticipentsMapId));
                var json = _httpHelper.Get(URL);
                WebApiResponse<bool> responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.isDeleted = responseJson.Data;
                returnResponse.message = responseJson.Message;
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