using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class BFDAssociationHouseholdMembersMapRepository : BaseRepository<BFDAssociationHouseholdMembersMap>, IBFDAssociationHouseholdMembersMapRepository
    {
        public BFDAssociationHouseholdMembersMapRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
