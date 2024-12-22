using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Reforestation;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Reforestation
{
    public interface IReplantationSocialForestryBeneficiaryMapService
    {
        (ExecutionState executionState, List<ReplantationSocialForestryBeneficiaryMapVM> entity, string message) List();
        (ExecutionState executionState, ReplantationSocialForestryBeneficiaryMapVM entity, string message) Create(ReplantationSocialForestryBeneficiaryMapVM model);
        (ExecutionState executionState, ReplantationSocialForestryBeneficiaryMapVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ReplantationSocialForestryBeneficiaryMapVM entity, string message) Update(ReplantationSocialForestryBeneficiaryMapVM model);
        (ExecutionState executionState, ReplantationSocialForestryBeneficiaryMapVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}