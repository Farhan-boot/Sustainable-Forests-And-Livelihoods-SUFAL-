using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery
{
    public interface INurseryDistributionService
    {
        (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) List();
        (ExecutionState executionState, NurseryDistributionVM entity, string message) Create(NurseryDistributionVM model);
        (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) CreateRange(NurseryDistributionListVM model);
        (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) UpdateRange(NurseryDistributionListVM model);
        (ExecutionState executionState, NurseryDistributionVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryDistributionVM entity, string message) GetByNurseryId(long? id);
        (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) GetByDistributionId(long? id);
        (ExecutionState executionState, NurseryDistributionVM entity, string message) Update(NurseryDistributionVM model);
        (ExecutionState executionState, NurseryDistributionVM entity, string message) Delete(long? id);
        (ExecutionState executionState, List<NurseryDistributionVM> entity, string message) GetFilterData(DistributionFilter json);
        (ExecutionState executionState, List<DistributionVM> entity, string message) GetFilterByDate(long nurseryId,NurseryFilterVM json);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<DistributionVM> entity, string message) GetByNurseryId(int? id);
    }
}