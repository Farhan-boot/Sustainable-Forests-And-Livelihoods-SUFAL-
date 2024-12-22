using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.SystemUser;
using PTSL.GENERIC.Service.BaseServices;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Service.Services.Interface;

public interface IUserService : IBaseService<UserVM, User>
{
    Task<(ExecutionState executionState, IList<UserVM> entity, string message)> GetBeneficiaryByFilter(BeneficiaryUserFilterVM filter);
    Task<(ExecutionState executionState, IList<UserVM> entity, string message)> ListSurveyAccounts(int takeLatest = 50);
    Task<(ExecutionState executionState, UserVM entity, string refreshToken, string message)> UserLogin(LoginVM model);
    Task<(ExecutionState executionState, List<UserVM> entity, string message)> GetUserNameByUserRoleId(long userRoleId);
    Task<(ExecutionState executionState, List<UserVM> entity, string message)> GetFilterByForestId(ExecutiveCommitteeFilterVM filterData);
    Task<(ExecutionState executionState, List<UserVM> entity, string message)> GetUserInfoByUserRoleId(long userRoleId);
}
