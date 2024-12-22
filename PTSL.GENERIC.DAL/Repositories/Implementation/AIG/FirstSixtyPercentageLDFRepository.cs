using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.AIG;
using PTSL.GENERIC.DAL.Repositories.Interface.AIG;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.AIG
{
    public class FirstSixtyPercentageLDFRepository : BaseRepository<FirstSixtyPercentageLDF>, IFirstSixtyPercentageLDFRepository
    {
        public FirstSixtyPercentageLDFRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}