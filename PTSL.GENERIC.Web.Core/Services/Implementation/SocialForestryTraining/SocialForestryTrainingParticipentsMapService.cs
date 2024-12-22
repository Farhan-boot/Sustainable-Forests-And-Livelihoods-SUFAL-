using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestryTraining;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.SocialForestryTraining;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.SocialForestryTraining
{
    public class SocialForestryTrainingParticipentsMapService : ISocialForestryTrainingParticipentsMapService
    {
        private readonly HttpHelper _httpHelper;

        public SocialForestryTrainingParticipentsMapService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<SocialForestryTrainingParticipentsMapVM> entity, string message) List()
        {
            (ExecutionState executionState, List<SocialForestryTrainingParticipentsMapVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMapList));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<SocialForestryTrainingParticipentsMapVM>>>(json);
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

        public (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Create(SocialForestryTrainingParticipentsMapVM model)
        {
            (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMap));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SocialForestryTrainingParticipentsMapVM>>(json);
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

        public (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) returnResponse;
            try
            {
                var model = new SocialForestryTrainingParticipentsMapVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMap + "/" + id));
                var json = _httpHelper.Get(URL);
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SocialForestryTrainingParticipentsMapVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMapDoesExist + "/" + id));
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

        public (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Update(SocialForestryTrainingParticipentsMapVM model)
        {
            (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMap));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SocialForestryTrainingParticipentsMapVM>>(json);
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

        public (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, SocialForestryTrainingParticipentsMapVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.SocialForestryTrainingParticipentsMap));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    var responseJson = JsonConvert.DeserializeObject<WebApiResponse<SocialForestryTrainingParticipentsMapVM>>(json);
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