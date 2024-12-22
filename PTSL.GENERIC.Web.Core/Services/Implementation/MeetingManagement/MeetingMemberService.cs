using Newtonsoft.Json;

using PTSL.GENERIC.Web.Core.Entity.MeetingManagement;
using PTSL.GENERIC.Web.Core.Helper;
using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.ApiResponseModel;
using PTSL.GENERIC.Web.Core.Model.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Interface.MeetingManagement;
using PTSL.GENERIC.Web.Helper;

namespace PTSL.GENERIC.Web.Services.Implementation.MeetingManagement
{
	public class MeetingMemberService : IMeetingMemberService
	{
        private readonly HttpHelper _httpHelper;

        public MeetingMemberService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

		public (ExecutionState executionState, List<MeetingMemberVM> entity, string message) List()
		{
			(ExecutionState executionState, List<MeetingMemberVM> entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(null);

				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMemberList));
				var json = _httpHelper.Get(URL);
				WebApiResponse<List<MeetingMemberVM>> responseJson = JsonConvert.DeserializeObject<WebApiResponse<List<MeetingMemberVM>>>(json);
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

		public (ExecutionState executionState, MeetingMemberVM entity, string message) Create(MeetingMemberVM model)
		{
			(ExecutionState executionState, MeetingMemberVM entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMember));
				var json = _httpHelper.Post(URL, respJson, "application/json");
				WebApiResponse<MeetingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingMemberVM>>(json);
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

		public (ExecutionState executionState, MeetingMemberVM entity, string message) GetById(long? id)
		{
			(ExecutionState executionState, MeetingMemberVM entity, string message) returnResponse;
			try
			{
				MeetingMemberVM model = new MeetingMemberVM();
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMember + "/" + id));
				var json = _httpHelper.Get(URL);
				WebApiResponse<MeetingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingMemberVM>>(json);
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
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMemberDoesExist + "/" + id));
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

		public (ExecutionState executionState, MeetingMemberVM entity, string message) Update(MeetingMemberVM model)
		{
			(ExecutionState executionState, MeetingMemberVM entity, string message) returnResponse;
			try
			{
				var respJson = JsonConvert.SerializeObject(model);
				var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMember));
				var json = _httpHelper.Put(URL, respJson, "application/json");
				WebApiResponse<MeetingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingMemberVM>>(json);
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

		public (ExecutionState executionState, MeetingMemberVM entity, string message) Delete(long? id)
		{
			(ExecutionState executionState, MeetingMemberVM entity, string message) returnResponse;
			try
			{
				(ExecutionState executionState, MeetingMemberVM entity, string message) IsExist = GetById(id);
				if (IsExist.entity != null)
				{
					IsExist.entity.IsDeleted = true;
					IsExist.entity.DeletedAt = DateTime.Now;
					var respJson = JsonConvert.SerializeObject(IsExist.entity);
					var URL = string.Concat(URLHelper.ApiBaseURL, string.Format(URLHelper.MeetingMember));
					var json = _httpHelper.Put(URL, respJson, "application/json");
					WebApiResponse<MeetingMemberVM> responseJson = JsonConvert.DeserializeObject<WebApiResponse<MeetingMemberVM>>(json);
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