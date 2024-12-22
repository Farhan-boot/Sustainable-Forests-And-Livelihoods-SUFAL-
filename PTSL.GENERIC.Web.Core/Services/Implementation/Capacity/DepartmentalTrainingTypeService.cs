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
    public class DepartmentalTrainingTypeService : IDepartmentalTrainingTypeService
    {
        private readonly HttpHelper _httpHelper;

        public DepartmentalTrainingTypeService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<DepartmentalTrainingTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<DepartmentalTrainingTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingTypeList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<DepartmentalTrainingTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<DepartmentalTrainingTypeVM>>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Create(DepartmentalTrainingTypeVM model)
        {
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingType));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<DepartmentalTrainingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingTypeVM>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse;
            try
            {
                DepartmentalTrainingTypeVM model = new DepartmentalTrainingTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingType + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<DepartmentalTrainingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingTypeVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingTypeDoesExist + "/" + id));
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
        public (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Update(DepartmentalTrainingTypeVM model)
        {
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingType));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<DepartmentalTrainingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingTypeVM>>(json);
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
        public (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, DepartmentalTrainingTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.DepartmentalTrainingType));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<DepartmentalTrainingTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<DepartmentalTrainingTypeVM>>(json);
                    returnResponse.executionState = responseJson.ExecutionState;
                    returnResponse.entity = responseJson.Data;
                    returnResponse.message = responseJson.Message;
                }
                else
                {
                    returnResponse.executionState = ExecutionState.Failure;
                    returnResponse.entity = null;
                    returnResponse.message = "This DepartmentalTrainingType is not exist.";
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