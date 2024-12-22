using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.DAL.Repositories.Interface.Labour;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Labour
{
    public class LabourWorkRepository : BaseRepository<LabourWork>, ILabourWorkRepository
    {
        public LabourWorkRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}