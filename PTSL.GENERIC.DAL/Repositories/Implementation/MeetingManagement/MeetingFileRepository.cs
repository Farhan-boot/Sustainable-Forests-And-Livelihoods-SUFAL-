using PTSL.GENERIC.Common.Entity;
using PTSL.GENERIC.Common.Entity.MeetingManagement;
using PTSL.GENERIC.DAL.Repositories.Interface;

namespace PTSL.GENERIC.DAL.Repositories.Implementation
{
	public class MeetingFileRepository : BaseRepository<MeetingFile>, IMeetingFileRepository
	{
		public MeetingFileRepository(
			GENERICWriteOnlyCtx ecommarceWriteOnlyCtx,
			GENERICReadOnlyCtx ecommarceReadOnlyCtx)
			: base(ecommarceWriteOnlyCtx, ecommarceReadOnlyCtx) { }
	}
}

