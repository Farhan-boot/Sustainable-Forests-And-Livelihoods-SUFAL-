using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.MeetingManagement;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Services.Implementation.MeetingManagement
{
	public class MeetingService : IMeetingService
	{
        private readonly HttpHelper _httpHelper;

        public MeetingService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

		public (ExecutionState executionState, List<MeetingVM> entity, string message) List()
		{
			(ExecutionState executionState, List<MeetingVM> entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(null);

				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingList));
				var json = _httpHelper.Get(URL);
				WebApiResponse<List<MeetingVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<MeetingVM>>>(json);
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

        public (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) GetMeetingByFilter(MeetingFilterVM filter)
        {
            (ExecutionState executionState, PaginationResutlVM<MeetingVM> entity, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(filter);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingGetMeetingByFilter));
                var json = _httpHelper.Post(URL, respJson, "application/json");
                WebApiResponse<PaginationResutlVM<MeetingVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<PaginationResutlVM<MeetingVM>>>(json);
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

		public (ExecutionState executionState, MeetingVM entity, string message) Create(MeetingVM model)
		{
			(ExecutionState executionState, MeetingVM entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Meeting));
				var json = _httpHelper.Post(URL, respJson, "application/json");
				WebApiResponse<MeetingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingVM>>(json);
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

		public (ExecutionState executionState, MeetingVM entity, string message) GetById(long? id)
		{
			(ExecutionState executionState, MeetingVM entity, string message) returnResponse;
			try
			{
				MeetingVM model = new MeetingVM();
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Meeting + "/" + id));
				var json = _httpHelper.Get(URL);
				WebApiResponse<MeetingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingVM>>(json);
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
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingDoesExist + "/" + id));
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

		public (ExecutionState executionState, MeetingVM entity, string message) Update(MeetingVM model)
		{
			(ExecutionState executionState, MeetingVM entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Meeting));
				var json = _httpHelper.Put(URL, respJson, "application/json");
				WebApiResponse<MeetingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingVM>>(json);
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

		public (ExecutionState executionState, MeetingVM entity, string message) Delete(long? id)
		{
			(ExecutionState executionState, MeetingVM entity, string message) returnResponse;
			try
			{
				(ExecutionState executionState, MeetingVM entity, string message) IsExist = GetById(id);
				if (IsExist.entity != null)
				{
					IsExist.entity.IsDeleted = true;
					IsExist.entity.DeletedAt = DateTime.Now;
					var respJson = JsonConvert.SerializeObject(IsExist.entity);
					var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.Meeting));
					var json = _httpHelper.Put(URL, respJson, "application/json");
					WebApiResponse<MeetingVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingVM>>(json);
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

        public (ExecutionState executionState, bool isDeleted, string message) DeleteParticipant(long mapId)
        {
            (ExecutionState executionState, bool isDeleted, string message) returnResponse;
            try
            {
                var respJson = JsonConvert.SerializeObject(null);

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingTrainingDeleteParticipant + "/" + mapId));
                var json = _httpHelper.Get(URL);
                WebApiResponse<bool> responseJson = JsonConvert.DeserializeObject<WebApiResponse<bool>>(json);
                returnResponse.executionState = responseJson.ExecutionState;
                returnResponse.isDeleted = responseJson.Data;
                returnResponse.message = responseJson.Message;
            }
            catch (Exception ex)
            {
                returnResponse.executionState = ExecutionState.Failure;
                returnResponse.isDeleted = false;
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

                var URL = String.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingSoftDelete), "/", id);
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