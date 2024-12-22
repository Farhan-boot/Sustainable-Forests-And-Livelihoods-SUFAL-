using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Reforestation;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Reforestation
{
    public class ReplantationNurseryInfoRepository : BaseRepository<ReplantationNurseryInfo>, IReplantationNurseryInfoRepository
    {
        public ReplantationNurseryInfoRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}