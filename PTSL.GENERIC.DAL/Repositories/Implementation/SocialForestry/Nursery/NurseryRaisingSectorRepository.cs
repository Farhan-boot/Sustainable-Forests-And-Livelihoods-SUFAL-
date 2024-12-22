using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Nursery
{
    public class NurseryRaisingSectorRepository : BaseRepository<NurseryRaisingSector>, INurseryRaisingSectorRepository
    {
        public NurseryRaisingSectorRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}