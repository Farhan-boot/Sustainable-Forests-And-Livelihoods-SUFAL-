using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Patrolling;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Patrolling;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Patrolling
{
    public class OtherPatrollingMemberService : IOtherPatrollingMemberService
    {
        private readonly HttpHelper _httpHelper;

        public OtherPatrollingMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMemberList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherPatrollingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherPatrollingMemberVM>>>(json);
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

        public (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Create(OtherPatrollingMemberVM model)
        {
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMember));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<OtherPatrollingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherPatrollingMemberVM>>(json);
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

        public (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse;
            try
            {
                OtherPatrollingMemberVM model = new OtherPatrollingMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMember + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<OtherPatrollingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherPatrollingMemberVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMemberDoesExist + "/" + id));
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

        public (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Update(OtherPatrollingMemberVM model)
        {
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMember));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<OtherPatrollingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherPatrollingMemberVM>>(json);
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

        public (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OtherPatrollingMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMember));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<OtherPatrollingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherPatrollingMemberVM>>(json);
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



        public (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) ListByForestFcvVcf(long id)
        {
            (ExecutionState executionState, List<OtherPatrollingMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherPatrollingMemberListByForestFcvVcf));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherPatrollingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherPatrollingMemberVM>>>(json);
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