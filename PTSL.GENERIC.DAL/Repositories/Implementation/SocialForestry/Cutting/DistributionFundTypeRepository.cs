using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Cutting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Cutting
{
    public class DistributionFundTypeRepository : BaseRepository<DistributionFundType>, IDistributionFundTypeRepository
    {
        public DistributionFundTypeRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}