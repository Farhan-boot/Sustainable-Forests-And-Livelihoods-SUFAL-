using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry.Reforestation;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry.Reforestation;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry.Reforestation
{
    public class ReplantationSocialForestryBeneficiaryMapRepository : BaseRepository<ReplantationSocialForestryBeneficiaryMap>, IReplantationSocialForestryBeneficiaryMapRepository
    {
        public ReplantationSocialForestryBeneficiaryMapRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}