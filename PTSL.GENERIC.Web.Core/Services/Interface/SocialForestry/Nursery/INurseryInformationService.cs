using PTSL.GENERIC.Web.Core.Helper.Enum;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry.Nursery;

namespace PTSL.GENERIC.Web.Core.Services.Interface.SocialForestry.Nursery
{
    public interface INurseryInformationService
    {
        (ExecutionState executionState, List<NurseryInformationVM> entity, string message) List();
        (ExecutionState executionState, NurseryInformationVM entity, string message) Create(NurseryInformationVM model);
        (ExecutionState executionState, NurseryInformationVM entity, string message) GetById(long? id);
        (ExecutionState executionState, NurseryInformationVM entity, string message) GetByIdAndDate(long? id,DateTime date);
        (ExecutionState executionState, NurseryInformationVM entity, string message) Update(NurseryInformationVM model);
        (ExecutionState executionState, NurseryInformationVM entity, string message) Delete(long? id);
        (ExecutionState executionState, string message) DoesExist(long? id);
        (ExecutionState executionState, List<NurseryInformationVM> entity, string message) ListByFilter(NurseryFilterVM model);
        (ExecutionState executionState, List<SocialForestryReportVM> entity, string message) GetNurseryReport(NurseryFilterVM model);
        (ExecutionState executionState, List<SocialForestryReportVM> entity, string message) GetNurseryDistributionReport(NurseryFilterVM model);
        (ExecutionState executionState, List<SocialForestryReportVM> entity, string message) GetNurseryDistributionByBeneficiaryReport(NurseryFilterVM model);
        (ExecutionState executionState, bool isDeleted, string message) SoftDelete(long id);

    }
}