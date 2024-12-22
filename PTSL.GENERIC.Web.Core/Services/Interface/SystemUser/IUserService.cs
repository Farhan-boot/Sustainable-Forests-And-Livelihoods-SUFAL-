using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SystemUser;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SystemUser
{
	public interface IUserService
	{
		(ExecutionState executionState, List<UserVM> entity, string message) List();
		(ExecutionState executionState, UserVM entity, string message) Create(UserVM model);
		(ExecutionState executionState, UserVM entity, string message) GetById(long? id);
		(ExecutionState executionState, UserVM entity, string message) Update(UserVM model);
		(ExecutionState executionState, UserVM entity, string message) Delete(long? id);
		(ExecutionState executionState, LoginResultVM entity, string message) UserLogin(LoginVM model);
        (ExecutionState executionState, List<UserVM> entity, string message) GetBeneficiaryByFilter(BeneficiaryUserFilterVM filter);
        (ExecutionState executionState, long entity, string message) GenerateSurveyAccounts(ForestCivilLocationFilter filter);
        (ExecutionState executionState, IList<UserVM> entity, string message) ListSurveyAccounts(int takeLatest);
    }
}
