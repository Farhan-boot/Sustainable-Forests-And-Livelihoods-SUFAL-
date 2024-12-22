using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.DAL.Repositories.Interface.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Beneficiary
{
    public class SurveyDocumentRepository : BaseRepository<SurveyDocument>, ISurveyDocumentRepository
    {
        public SurveyDocumentRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}