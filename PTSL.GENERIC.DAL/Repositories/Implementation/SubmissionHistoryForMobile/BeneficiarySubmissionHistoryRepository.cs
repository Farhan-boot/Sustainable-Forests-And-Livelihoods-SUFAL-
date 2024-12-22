using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SubmissionHistoryForMobile;
using PTSL.GENERIC.DAL.Repositories.Interface.SubmissionHistoryForMobile;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SubmissionHistoryForMobile
{
    public class BeneficiarySubmissionHistoryRepository : BaseRepository<BeneficiarySubmissionHistory>, IBeneficiarySubmissionHistoryRepository
    {
        public BeneficiarySubmissionHistoryRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}