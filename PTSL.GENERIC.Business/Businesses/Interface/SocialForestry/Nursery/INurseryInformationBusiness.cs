using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.CustomModel;
using PTSL.GENERIC.Common.Model.EntityViewModels.SocialForestry.Nursery;
using PTSL.GENERIC.Web.Core.Model.EntityViewModels.SocialForestry;

namespace PTSL.GENERIC.Business.Businesses.Interface.SocialForestry.Nursery
{
    public interface INurseryInformationBusiness : IBaseBusiness<NurseryInformation>
    {
        Task<(ExecutionState executionState, IList<NurseryInformation> entity, string message)> GetFilterData(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryReport(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionReport(NurseryFilterVM model);
        Task<(ExecutionState executionState, IList<SocialForestryReport> entity, string message)> GetNurseryDistributionByBeneficiaryReport(NurseryFilterVM model);
    }
}