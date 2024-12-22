using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AIG
{
    public class GroupLDFInfoFormRepository : BaseRepository<GroupLDFInfoForm>, IGroupLDFInfoFormRepository
    {
        public GroupLDFInfoFormRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}