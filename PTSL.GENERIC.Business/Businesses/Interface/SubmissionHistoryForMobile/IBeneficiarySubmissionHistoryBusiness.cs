using System.Collections.Generic;
using System.Threading.Tasks;

using PTSL.GENERIC.Business.BaseBusinesses;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.Common.Enum;
using PTSL.GENERIC.Common.Model.EntityViewModels.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.Business.Businesses.Interface.SubmissionHistoryForMobile
{
    public interface IBeneficiarySubmissionHistoryBusiness : IBaseBusiness<BeneficiarySubmissionHistory>
    {
        Task<(ExecutionState executionState, bool entity, string message)> UploadFiles(
            BeneficiarySubmissionHistoryVM entity,
            string beneficiarySubmissionHistoryFileUrl
            );
    }
}