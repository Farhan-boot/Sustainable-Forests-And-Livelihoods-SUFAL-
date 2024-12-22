using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface IZoneOrAreaService
    {
        (ExecutionState executionState, List<ZoneOrAreaVM> entity, string message) List();
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) Create(ZoneOrAreaVM model);
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) GetById(long? id);
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) Update(ZoneOrAreaVM model);
        (ExecutionState executionState, ZoneOrAreaVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}