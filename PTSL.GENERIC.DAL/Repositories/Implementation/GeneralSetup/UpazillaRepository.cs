using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.GeneralSetup;
using PTSL.GENERIC.DAL.Repositories.Interface;

namespace PTSL.GENERIC.DAL.Repositories.Implementation
{
    public class UpazillaRepository : BaseRepository<Upazilla>, IUpazillaRepository
    {
        public UpazillaRepository(
            GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
            GENERICReadOnlyCtx ecommarceReadOnlyCtx)
            : base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
    }
}
