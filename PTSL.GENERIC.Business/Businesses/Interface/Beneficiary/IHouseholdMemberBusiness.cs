using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Model.EntityViewModels.DashBoard;

using System.Threading.Tasks;

namespace PTSL.GENERIC.Business.Businesses.Interface.Beneficiary
{
    public interface IHouseholdMemberBusiness : IBaseBusiness<HouseholdMember>
    {
        Task<(ExecutionState executionState, TotalHouseholdMemberVM entity, string message)> GetTotalHouseholdMember();
		Task<(ExecutionState executionState, DashboardHouseholdVM entity, string message)> TotalHouseholdWithPercentage(ForestCivilLocationFilter filter);
	}
}
