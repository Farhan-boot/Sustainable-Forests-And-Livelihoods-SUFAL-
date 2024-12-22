using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class ForestDivisionRepository : BaseRepository<ForestDivision>, IForestDivisionRepository
    {
        public ForestDivisionRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
