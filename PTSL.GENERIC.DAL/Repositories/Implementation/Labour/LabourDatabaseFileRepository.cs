using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.Labour;
using PTSL.GENERIC.DAL.Repositories.Interface.Labour;

namespace PTSL.GENERIC.DAL.Repositories.Implementation.Labour
{
    public class LabourDatabaseFileRepository : BaseRepository<LabourDatabaseFile>, ILabourDatabaseFileRepository
    {
        public LabourDatabaseFileRepository(GENERICWriteOnlyCtx writeOnlyCtx,
            GENERICReadOnlyCtx readOnlyCtx) : base(writeOnlyCtx, readOnlyCtx)
        {

        }
    }
}
