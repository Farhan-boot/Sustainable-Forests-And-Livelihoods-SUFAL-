using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Nursery;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Nursery;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Nursery
{
    public class NurseryTypeRepository : BaseRepository<NurseryType>, INurseryTypeRepository
    {
        public NurseryTypeRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}