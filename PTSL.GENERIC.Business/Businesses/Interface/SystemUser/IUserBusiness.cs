using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels.ForestManagement;
using PTSL.GENERIC.Common.Model.EntityViewModels.SystemUser;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface
{
    public interface IUserBusiness : IBaseBusiness<User>
    {
        Task<(ExecutionState executionState, long entity, string message)> GenerateSurveyAccounts(ForestCivilLocationFilter filter);
        Task<(ExecutionState executionState, IList<User> entity, string message)> GetBeneficiaryByFilter(BeneficiaryUserFilterVM filter);
        Task<(ExecutionState executionState, IList<User> entity, string message)> ListSurveyAccounts(int takeLatest = 50);
        Task<(ExecutionState executionState, User entity, string message)> UserLogin(LoginVM model);
        //GetUserNameByUserRoleId
        Task<(ExecutionState executionState, List<User> entity, string message)> GetUserNameByUserRoleId(long userRoleId);
        Task<(ExecutionState executionState, List<User> entity, string message)> GetFilterByForestId(ExecutiveCommitteeFilterVM filterData);
        Task<(ExecutionState executionState, List<User> entity, string message)> GetUserInfoByUserRoleId(long userRoleId);
    }
}
