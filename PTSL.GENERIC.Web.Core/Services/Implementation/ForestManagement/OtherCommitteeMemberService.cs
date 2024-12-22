using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.ForestManagement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.ForestManagement
{
    public class OtherCommitteeMemberService : IOtherCommitteeMemberService
    {
        private readonly HttpHelper _httpHelper;

        public OtherCommitteeMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMemberList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherCommitteeMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherCommitteeMemberVM>>>(json);
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

        public (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Create(OtherCommitteeMemberVM model)
        {
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMember));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<OtherCommitteeMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherCommitteeMemberVM>>(json);
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

        public (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse;
            try
            {
                OtherCommitteeMemberVM model = new OtherCommitteeMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMember + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<OtherCommitteeMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherCommitteeMemberVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMemberDoesExist + "/" + id));
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

        public (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Update(OtherCommitteeMemberVM model)
        {
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMember));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<OtherCommitteeMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherCommitteeMemberVM>>(json);
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

        public (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OtherCommitteeMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherCommitteeMember));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<OtherCommitteeMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherCommitteeMemberVM>>(json);
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



        public (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) ListByForestFcvVcf(long id)
        {
            (ExecutionState executionState, List<OtherCommitteeMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ListByForestFcvVcf));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherCommitteeMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherCommitteeMemberVM>>>(json);
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