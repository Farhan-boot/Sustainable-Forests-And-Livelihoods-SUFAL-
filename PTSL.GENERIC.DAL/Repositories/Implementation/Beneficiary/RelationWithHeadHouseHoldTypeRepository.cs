using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class RelationWithHeadHouseHoldTypeRepository : BaseRepository<RelationWithHeadHouseHoldType>, IRelationWithHeadHouseHoldTypeRepository
    {
        public RelationWithHeadHouseHoldTypeRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
