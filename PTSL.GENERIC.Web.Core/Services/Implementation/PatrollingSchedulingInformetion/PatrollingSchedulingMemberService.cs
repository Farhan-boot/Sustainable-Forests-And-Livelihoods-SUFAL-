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
    public class PatrollingSchedulingMemberService : IPatrollingSchedulingMemberService
    {
        private readonly HttpHelper _httpHelper;

        public PatrollingSchedulingMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<PatrollingSchedulingMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<PatrollingSchedulingMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMemberList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<PatrollingSchedulingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<PatrollingSchedulingMemberVM>>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Create(PatrollingSchedulingMemberVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMember));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingMemberVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) returnResponse;
            try
            {
                PatrollingSchedulingMemberVM model = new PatrollingSchedulingMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMember + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<PatrollingSchedulingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingMemberVM>>(json);
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
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMemberDoesExist + "/" + id));
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
        public (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Update(PatrollingSchedulingMemberVM model)
        {
            (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMember));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<PatrollingSchedulingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingMemberVM>>(json);
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
        public (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, PatrollingSchedulingMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.PatrollingSchedulingMember));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<PatrollingSchedulingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PatrollingSchedulingMemberVM>>(json);
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