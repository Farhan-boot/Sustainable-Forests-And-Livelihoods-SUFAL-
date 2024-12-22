using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery
{
    public interface INurseryRaisedSeedlingInformationService
    {
        (ExecutionState executionState, List<NurseryRaisedSeedlingInformationVM> entity, string message) List();
        (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) Create(NurseryRaisedSeedlingInformationVM model);
        (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) Update(NurseryRaisedSeedlingInformationVM model);
        (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<NurseryRaisedSeedlingInformationVM> entity, string message) GetSeedlingByNurseryId(long id, bool forPlantationOrDistribution = false);
        (ExecutionState executionState, NurseryRaisedSeedlingInformationVM entity, string message) UpdateSeedlingInfo(UpdateSeedlingInfoVM updateSeedlingInfoVM);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}