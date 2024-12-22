using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Labour;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Labour;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Labour
{
    public class OtherLabourMemberService : IOtherLabourMemberService
    {
        private readonly HttpHelper _httpHelper;

        public OtherLabourMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) List()
        {
            (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMemberList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherLabourMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherLabourMemberVM>>>(json);
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

        public (ExecutionState executionState, OtherLabourMemberVM entity, string message) Create(OtherLabourMemberVM model)
        {
            (ExecutionState executionState, OtherLabourMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMember));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<OtherLabourMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherLabourMemberVM>>(json);
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

        public (ExecutionState executionState, OtherLabourMemberVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, OtherLabourMemberVM entity, string message) returnResponse;
            try
            {
                OtherLabourMemberVM model = new OtherLabourMemberVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMember + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<OtherLabourMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherLabourMemberVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMemberDoesExist + "/" + id));
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

        public (ExecutionState executionState, OtherLabourMemberVM entity, string message) Update(OtherLabourMemberVM model)
        {
            (ExecutionState executionState, OtherLabourMemberVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMember));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<OtherLabourMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherLabourMemberVM>>(json);
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

        public (ExecutionState executionState, OtherLabourMemberVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, OtherLabourMemberVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, OtherLabourMemberVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.OtherLabourMember));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<OtherLabourMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<OtherLabourMemberVM>>(json);
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



        public (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) ListByForestFcvVcf2(long id)
        {
            (ExecutionState executionState, List<OtherLabourMemberVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ListByForestFcvVcf2));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<OtherLabourMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<OtherLabourMemberVM>>>(json);
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