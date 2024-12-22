using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Capacity;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Capacity;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Services.Implementation.GeneralSetup
{
    public class DepartmentalTrainingMemberService : IDepartmentalTrainingMemberService
    {
        private readonly HttpHelper _httpHelper;

        public DepartmentalTrainingMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<DepartmentalTrainingMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<DepartmentalTrainingMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMemberList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<DepartmentalTrainingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<DepartmentalTrainingMemberVM>>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Create(DepartmentalTrainingMemberVM model)
        {
            (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMember));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<DepartmentalTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingMemberVM>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) returnResponse;
            try
            {
                DepartmentalTrainingMemberVM model = new DepartmentalTrainingMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMember + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<DepartmentalTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingMemberVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMemberDoesExist + "/" + id));
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
        public (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Update(DepartmentalTrainingMemberVM model)
        {
            (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMember));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<DepartmentalTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingMemberVM>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, DepartmentalTrainingMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingMember));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<DepartmentalTrainingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingMemberVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This DepartmentalTrainingMember is not exist.";
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