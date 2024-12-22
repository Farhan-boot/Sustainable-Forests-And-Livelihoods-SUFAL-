using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry
{
    public interface ISocialForestryDesignationService
    {
        (ExecutionState executionState, List<SocialForestryDesignationVM> entity, string message) List();
        (ExecutionState executionState, SocialForestryDesignationVM entity, string message) Create(SocialForestryDesignationVM model);
        (ExecutionState executionState, SocialForestryDesignationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, SocialForestryDesignationVM entity, string message) Update(SocialForestryDesignationVM model);
        (ExecutionState executionState, SocialForestryDesignationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
    }
}