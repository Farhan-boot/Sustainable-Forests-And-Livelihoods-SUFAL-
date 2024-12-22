using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ILandOwningAgencyService
    {
        (ExecutionState executionState, List<LandOwningAgencyVM> entity, string message) List();
        (ExecutionState executionState, LandOwningAgencyVM entity, string message) Create(LandOwningAgencyVM model);
        (ExecutionState executionState, LandOwningAgencyVM entity, string message) GetById(long? id);
        (ExecutionState executionState, LandOwningAgencyVM entity, string message) Update(LandOwningAgencyVM model);
        (ExecutionState executionState, LandOwningAgencyVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}