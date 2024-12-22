using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Service.BaseServices;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Service.Services.SocialForestry.Nursery
{
    public interface INurseryInformationService : IBaseService<NurseryInformationVM, NurseryInformation>
    {
        Task<(ExecutionState executionState, IList<NurseryInformationVM> entity, string message)> GetFilterData(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryReport(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionReport(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionByBeneficiaryReport(NurseryFilterVM model);


    }
}