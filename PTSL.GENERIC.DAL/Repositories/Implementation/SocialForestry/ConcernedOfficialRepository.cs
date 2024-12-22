using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry
{
    public class ConcernedOfficialRepository : BaseRepository<ConcernedOfficial>, IConcernedOfficialRepository
    {
        public ConcernedOfficialRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}