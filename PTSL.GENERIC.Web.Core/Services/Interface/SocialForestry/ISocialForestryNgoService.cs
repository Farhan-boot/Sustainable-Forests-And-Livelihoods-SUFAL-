using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ISocialForestryNgoService
    {
        (ExecutionState executionState, List<SocialForestryNgoVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) Create(SocialForestryNgoVM model);
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) Update(SocialForestryNgoVM model);
        (ExecutionState executionState, SocialForestryNgoVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}