using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ISocialForestryBeneficiaryService
    {
        (ExecutionState executionState, List<SocialForestryBeneficiaryVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) Create(SocialForestryBeneficiaryVM model);
        (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) Update(SocialForestryBeneficiaryVM model);
        (ExecutionState executionState, SocialForestryBeneficiaryVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<SocialForestryBeneficiaryVM> entity, string message) GetBeneficiariesByNewRaisedId(long newRaiseId, bool hasPbsa = false);
    }
}
