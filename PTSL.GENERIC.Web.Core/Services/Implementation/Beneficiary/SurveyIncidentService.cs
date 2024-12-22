using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Beneficiary
{
    public class SurveyIncidentService : ISurveyIncidentService
    {
        private readonly HttpHelper _httpHelper;

        public SurveyIncidentService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) ListByFilter(SurveyIncidentFilterVM filter)
        {
            (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) returnResponse;

            try
            {
                var respJson = JsonConvert.SerializeObject(filter);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncidentListByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");

                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyIncidentVM>>>(json);
                returnResponse.executionState = responseJson!.ExecutionState;
                returnResponse.entity = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.entity = new List<SurveyIncidentVM>();
                returnResponse.message = ex.Message.ToString();
            }

            return returnResponse;
        }

        public (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SurveyIncidentVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncidentList));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SurveyIncidentVM>>>(json);
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

        public (ExecutionState executionState, SurveyIncidentVM entity, string message) Create(SurveyIncidentVM model)
        {
            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncident));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyIncidentVM>>(json);
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

        public (ExecutionState executionState, SurveyIncidentVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse;
            try
            {
                var model = new SurveyIncidentVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncident + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyIncidentVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncidentDoesExist + "/" + id));
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

        public (ExecutionState executionState, SurveyIncidentVM entity, string message) Update(SurveyIncidentVM model)
        {
            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncident));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyIncidentVM>>(json);
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

        public (ExecutionState executionState, SurveyIncidentVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SurveyIncidentVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SurveyIncidentVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SurveyIncident));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SurveyIncidentVM>>(json);
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