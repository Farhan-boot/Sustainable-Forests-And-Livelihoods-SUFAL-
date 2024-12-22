using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.SocialForestry;
using PTSL.GENERIC.DAL.Repositories.Interface.SocialForestry;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.SocialForestry
{
    public class InspectionDetailsRepository : BaseRepository<InspectionDetails>, IInspectionDetailsRepository
    {
        public InspectionDetailsRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}