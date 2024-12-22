using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Cutting;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Cutting;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Cutting
{
    public class DistributedToBeneficiaryRepository : BaseRepository<DistributedToBeneficiary>, IDistributedToBeneficiaryRepository
    {
        public DistributedToBeneficiaryRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}