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
    public class ForestFcvVcfService : IForestFcvVcfService
    {
        private readonly HttpHelper _httpHelper;

        public ForestFcvVcfService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) List()
        {
            (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcfList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<ForestFcvVcfVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ForestFcvVcfVM>>>(json);
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

        public (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) ListByForestBeat(long forestBeatId)
        {
            (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format($"{URLHelper.ForestFcvVcf}/ListByForestBeat/{forestBeatId}"));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<ForestFcvVcfVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ForestFcvVcfVM>>>(json);
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

        public (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) ListByForestBeatAndType(long forestBeatId, FcvVcfType type)
        {
            (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format($"{URLHelper.ForestFcvVcfListByForestBeatAndType}?forestBeatId={forestBeatId}&type={type}"));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<ForestFcvVcfVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ForestFcvVcfVM>>>(json);
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

        public (ExecutionState executionState, ForestFcvVcfVM entity, string message) Create(ForestFcvVcfVM model)
        {
            (ExecutionState executionState, ForestFcvVcfVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcf));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<ForestFcvVcfVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ForestFcvVcfVM>>(json);
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

        public (ExecutionState executionState, ForestFcvVcfVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, ForestFcvVcfVM entity, string message) returnResponse;
            try
            {
                ForestFcvVcfVM model = new ForestFcvVcfVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcf + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<ForestFcvVcfVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ForestFcvVcfVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcfDoesExist + "/" + id));
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

        public (ExecutionState executionState, ForestFcvVcfVM entity, string message) Update(ForestFcvVcfVM model)
        {
            (ExecutionState executionState, ForestFcvVcfVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcf));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<ForestFcvVcfVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ForestFcvVcfVM>>(json);
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

        public (ExecutionState executionState, ForestFcvVcfVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, ForestFcvVcfVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, ForestFcvVcfVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcf));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<ForestFcvVcfVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<ForestFcvVcfVM>>(json);
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

        public (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) GetFcvVcfByType(bool isFcv)
        {
            (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.GetFcvVcfByType + "/" + isFcv));
                var json = _httpHelper.Get(URL);

                WebApiResponse<List<ForestFcvVcfVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<ForestFcvVcfVM>>>(json);
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


        public (ExecutionState executionState, List<MemberPerVillageVM> entity, string message) MemberPerVillageList(MemberPerVillageFilterVM filter)
        {
            (ExecutionState executionState, List<MemberPerVillageVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MemberPerVillageList));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                var responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<MemberPerVillageVM>>>(json);
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

        public (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.ForestFcvVcfSoftDelete), "/", id);
                var json = _httpHelper.Put(URL, respJson, "application/json");
                var result = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = result.ExecutionState;
                returnResponse.isDeleted = result.Data;
                returnResponse.message = result.Message;
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