using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Entity.Students;

namespace PTSL.GENERIC.DAL.Repositories.Interface
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(
            GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx)
            : base(writeOnlyCtx, readOnlyCtx) { }
    }
}
