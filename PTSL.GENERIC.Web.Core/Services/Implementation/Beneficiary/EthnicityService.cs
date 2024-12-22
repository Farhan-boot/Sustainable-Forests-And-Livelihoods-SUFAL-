﻿using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.GeneralSetup
{
    public class EthnicityService : IEthnicityService
    {
        private readonly HttpHelper _httpHelper;

        public EthnicityService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public (ExecutionState executionState, List<EthnicityVM> entity, string message) List()
        {
            (ExecutionState executionState, List<EthnicityVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EthnicityList));
                var json = _httpHelper.Get(URL);
                WebApiResponse<List<EthnicityVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<EthnicityVM>>>(json);
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

        public (ExecutionState executionState, EthnicityVM entity, string message) Create(EthnicityVM model)
        {
            (ExecutionState executionState, EthnicityVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Ethnicity));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<EthnicityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EthnicityVM>>(json);
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

        public (ExecutionState executionState, EthnicityVM entity, string message) GetById(long? id)
        {
            (ExecutionState executionState, EthnicityVM entity, string message) returnResponse;
            try
            {
                EthnicityVM model = new EthnicityVM();
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Ethnicity + "/" + id));
                var json = _httpHelper.Get(URL);
                WebApiResponse<EthnicityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EthnicityVM>>(json);
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
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.EthnicityDoesExist + "/" + id));
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

        public (ExecutionState executionState, EthnicityVM entity, string message) Update(EthnicityVM model)
        {
            (ExecutionState executionState, EthnicityVM entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(model);
                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Ethnicity));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<EthnicityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EthnicityVM>>(json);
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

        public (ExecutionState executionState, EthnicityVM entity, string message) Delete(long? id)
        {
            (ExecutionState executionState, EthnicityVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, EthnicityVM entity, string message) IsExist = GetById(id);
                if (IsExist.entity != null)
                {
                    IsExist.entity.IsDeleted = true;
                    IsExist.entity.DeletedAt = DateTime.Now;
                    var respJson = JsonConvert.SerializeObject(IsExist.entity);
                    var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Ethnicity));
                    var json = _httpHelper.Put(URL, respJson, "application/json");
                    WebApiResponse<EthnicityVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<EthnicityVM>>(json);
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