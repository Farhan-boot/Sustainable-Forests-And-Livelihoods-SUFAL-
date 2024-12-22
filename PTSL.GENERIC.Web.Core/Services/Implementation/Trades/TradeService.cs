using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Trades;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.Trades;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Trades;

public class TradeService : ITradeService
{
    private readonly HttpHelper _httpHelper;

    public TradeService(HttpHelper httpHelper)
    {
        _httpHelper = httpHelper;
    }

    public (ExecutionState executionState, List<TradeVM> entity, string message) List()
    {
        (ExecutionState executionState, List<TradeVM> entity, string message) returnResponse;
        try
        {
            var respJson = JsonConvert.SerializeObject(null);

            var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TradeList));
            var json = _httpHelper.Get(URL);
            WebApiResponse<List<TradeVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<TradeVM>>>(json);
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

    public (ExecutionState executionState, TradeVM entity, string message) Create(TradeVM model)
    {
        (ExecutionState executionState, TradeVM entity, string message) returnResponse;
        try
        {
            var respJson = JsonConvert.SerializeObject(model);
            var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Trade));
            var json = _httpHelper.Post(URL, respJson, "application/json");
            WebApiResponse<TradeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TradeVM>>(json);
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

    public (ExecutionState executionState, TradeVM entity, string message) GetById(long? id)
    {
        (ExecutionState executionState, TradeVM entity, string message) returnResponse;
        try
        {
            TradeVM model = new TradeVM();
            var respJson = JsonConvert.SerializeObject(model);
            var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Trade + "/" + id));
            var json = _httpHelper.Get(URL);
            WebApiResponse<TradeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TradeVM>>(json);
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
            var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.TradeDoesExist + "/" + id));
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

    public (ExecutionState executionState, TradeVM entity, string message) Update(TradeVM model)
    {
        (ExecutionState executionState, TradeVM entity, string message) returnResponse;
        try
        {
            var respJson = JsonConvert.SerializeObject(model);
            var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Trade));
            var json = _httpHelper.Put(URL, respJson, "application/json");
            WebApiResponse<TradeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TradeVM>>(json);
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

    public (ExecutionState executionState, TradeVM entity, string message) Delete(long? id)
    {
        (ExecutionState executionState, TradeVM entity, string message) returnResponse;
        try
        {
            (ExecutionState executionState, TradeVM entity, string message) IsExist = GetById(id);
            if (IsExist.entity != null)
            {
                IsExist.entity.IsDeleted = true;
                IsExist.entity.DeletedAt = DateTime.Now;
                var respJson = JsonConvert.SerializeObject(IsExist.entity);
                var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Trade));
                var json = _httpHelper.Put(URL, respJson, "application/json");
                WebApiResponse<TradeVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<TradeVM>>(json);
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