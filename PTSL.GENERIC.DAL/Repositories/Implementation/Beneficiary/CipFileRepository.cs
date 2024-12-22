using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.DAL.Repositories.Interface.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Beneficiary
{
    public class CipFileRepository : BaseRepository<CipFile>, ICipFileRepository
    {
        public CipFileRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}