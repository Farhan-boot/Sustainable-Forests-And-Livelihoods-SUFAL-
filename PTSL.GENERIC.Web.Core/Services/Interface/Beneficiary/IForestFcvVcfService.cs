using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.Beneficiary;

namespace PTSL.GENERIC.Web.Core.Services.Interface.Beneficiary
{
    public interface IForestFcvVcfService
    {
        (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) List();
        (ExecutionState executionState, ForestFcvVcfVM entity, string message) Create(ForestFcvVcfVM model);
        (ExecutionState executionState, ForestFcvVcfVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ForestFcvVcfVM entity, string message) Update(ForestFcvVcfVM model);
        (ExecutionState executionState, ForestFcvVcfVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) ListByForestBeat(long forestBeatId);

        (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) GetFcvVcfByType(bool isFcv);
        (ExecutionState executionState, List<ForestFcvVcfVM> entity, string message) ListByForestBeatAndType(long forestBeatId, FcvVcfType type);
        (ExecutionState executionState, List<MemberPerVillageVM> entity, string message) MemberPerVillageList(MemberPerVillageFilterVM filter);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);
    }
}
