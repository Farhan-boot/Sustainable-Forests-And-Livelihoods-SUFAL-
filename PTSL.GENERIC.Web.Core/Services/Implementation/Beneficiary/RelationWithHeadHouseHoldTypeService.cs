using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup
{
    public class RelationWithHeadHouseHoldTypeService : IRelationWithHeadHouseHoldTypeService
    {
        private readonly HttpHelper _httpHelper;

        public RelationWithHeadHouseHoldTypeService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<RelationWithHeadHouseHoldTypeVM> entity, string message) List()
        {
            (ExecutionState executionState, List<RelationWithHeadHouseHoldTypeVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldTypeList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<RelationWithHeadHouseHoldTypeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<RelationWithHeadHouseHoldTypeVM>>>(json);
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

        public (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Create(RelationWithHeadHouseHoldTypeVM model)
        {
            (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldType));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<RelationWithHeadHouseHoldTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RelationWithHeadHouseHoldTypeVM>>(json);
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

        public (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) returnResponse;
            try
            {
                RelationWithHeadHouseHoldTypeVM model = new RelationWithHeadHouseHoldTypeVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldType + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<RelationWithHeadHouseHoldTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RelationWithHeadHouseHoldTypeVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldTypeDoesExist + "/" + id));
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

        public (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Update(RelationWithHeadHouseHoldTypeVM model)
        {
            (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldType));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<RelationWithHeadHouseHoldTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RelationWithHeadHouseHoldTypeVM>>(json);
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

        public (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, RelationWithHeadHouseHoldTypeVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.RelationWithHeadHouseHoldType));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<RelationWithHeadHouseHoldTypeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<RelationWithHeadHouseHoldTypeVM>>(json);
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